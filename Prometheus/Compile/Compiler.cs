using System.Diagnostics;
using System.IO;
using System.Reflection;
using GOLD;
using Prometheus.Compile.Optomizer;
using Prometheus.Exceptions.Compiler;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Properties;

namespace Prometheus.Compile
{
    /// <summary>
    /// Handles the execution of the source code file.
    /// </summary>
    public class Compiler
    {
        /// <summary>
        /// Used to create nodes.
        /// </summary>
        private readonly NodeFactory _factory;

        /// <summary>
        /// The GOLD parser.
        /// </summary>
        private readonly GOLD.Parser _parser;

        /// <summary>
        /// The lines of source code.
        /// </summary>
        private string[] _lines;

        /// <summary>
        /// Calculates the command tree from the source code and returns the root node.
        /// </summary>
        /// <param name="pFileName">The name of the source file.</param>
        /// <param name="pReader">A stream of the source file.</param>
        private Node Compile(string pFileName, TextReader pReader)
        {
            //This procedure starts the GOLD Parser Engine and handles each of the
            //messages it returns. Each time a reduction is made, you can create new
            //custom object and reassign the .CurrentReduction property. Otherwise, 
            //the system will use the Reduction object that was returned.
            //
            //The resulting tree will be a pure representation of the language 
            //and will be ready to implement.

            _parser.Open(pReader);
            _parser.TrimReductions = true;

            for (ParseMessage response = _parser.Parse(); response != ParseMessage.Accept; response = _parser.Parse())
            {
                int x = _parser.CurrentPosition().Line + 1;
                int y = _parser.CurrentPosition().Column + 1;
                Location location = new Location(pFileName, _lines[x-1].Trim(), x, y);

                if (!CreateNode(response, location))
                {
                    continue;
                }

                Reduction reduction = _parser.CurrentReduction as Reduction;
                _parser.CurrentReduction = (reduction != null)
                    ? _factory.Create(reduction, location)
                    : _parser.CurrentReduction;
            }

            Node node = _parser.CurrentReduction as Node;
            if (node == null)
            {
                throw new InternalErrorException(Errors.ProgramMissing, Location.None);
            }
            return node;
        }

        /// <summary>
        /// Checks if the current response from the parser is to
        /// create a new node.
        /// </summary>
        /// <param name="pResponse">The current response</param>
        /// <param name="pLocation">Location</param>
        /// <returns>True if a reduction</returns>
        private bool CreateNode(ParseMessage pResponse, Location pLocation)
        {
            switch (pResponse)
            {
                case ParseMessage.LexicalError:
                    throw new LexicalException(_parser, pLocation);

                case ParseMessage.SyntaxError:
                    throw new SyntaxException(_parser, pLocation);

                case ParseMessage.InternalError:
                    throw new InternalErrorException(pLocation);

                case ParseMessage.NotLoadedError:
                    throw new NotLoadedException(pLocation);

                case ParseMessage.GroupError:
                    throw new EofException(pLocation);
            }

            return pResponse == ParseMessage.Reduction;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Compiler()
        {
            _parser = new GOLD.Parser();

            _factory = new NodeFactory();
            _factory.DataType(GrammarSymbol.Identifier);
            _factory.DataType(GrammarSymbol.StringDouble);
            _factory.DataType(GrammarSymbol.StringSingle);
            _factory.DataType(GrammarSymbol.Decimal);
            _factory.DataType(GrammarSymbol.Number);
            _factory.DataType(GrammarSymbol.Boolean);

            const string fullResourceName = "Prometheus.Grammar.Grammar.egt";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                {
                    throw new CompilerException(string.Format(Errors.MissingResource, fullResourceName), Location.None);
                }

                using (BinaryReader reader = new BinaryReader(stream))
                {
                    _parser.LoadTables(reader);
                }
            }
        }

        /// <summary>
        /// Calculates the command tree from the source code.
        /// </summary>
        /// <param name="pFileName">The name of the source file.</param>
        /// <param name="pSource">Contents of the source file.</param>
        public TargetCode Compile(string pFileName, string pSource)
        {
            _lines = pSource.Split('\n');

            using (StringReader reader = new StringReader(pSource))
            {
                Node root = Compile(pFileName, reader);

#if DEBUG
                TraceCode("Before Optimizer", root);
#endif
                Optimizer optimizer = new Optimizer();
                root = optimizer.Optimize(root);
#if DEBUG
                TraceCode("After Optimizer", root);
#endif
                return new TargetCode(root);
            }
        }

#if DEBUG
        /// <summary>
        /// Dumps a trace of the code tree to the console.
        /// </summary>
        private static void TraceCode(string pMessage, Node pRoot)
        {
            Debug.WriteLine(pMessage);
            Debug.WriteLine("Root");
            PrintCode(pRoot);
            Debug.WriteLine("");
        }

        /// <summary>
        /// Walks the tree of nodes displaying details about each node.
        /// </summary>
        private static void PrintCode(Node pNode, int pIndent = 0)
        {
            Debug.WriteLine("{0} {1} {2}", " ".PadLeft(pIndent * 2), pNode.Type, string.Join(" ", pNode.Data));

            foreach (Node child in pNode.Children)
            {
                PrintCode(child, pIndent+1);
            }
        }
#endif
    }
}