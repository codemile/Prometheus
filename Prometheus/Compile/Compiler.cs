using System.IO;
using System.Reflection;
using GOLD;
using Prometheus.Exceptions;
using Prometheus.Nodes;
using Prometheus.Parser;
using Prometheus.Properties;

namespace Prometheus.Compile
{
    /// <summary>
    /// Handles the execution of the source code file.
    /// </summary>
    public class Compiler
    {
        /// <summary>
        /// The GOLD parser.
        /// </summary>
        private readonly GOLD.Parser _parser;

        /// <summary>
        /// Used to create nodes.
        /// </summary>
        private readonly NodeFactory _factory;

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
                Cursor cursor = new Cursor(pFileName, x, y);

                if (!CreateNode(response, cursor))
                {
                    continue;
                }

                Reduction reduction = _parser.CurrentReduction as Reduction;
                _parser.CurrentReduction = (reduction != null)
                    ? _factory.Create(reduction, cursor)
                    : _parser.CurrentReduction;
            }

            Node node = _parser.CurrentReduction as Node;
            if (node == null)
            {
                throw new InternalErrorException(Errors.ProgramMissing, Cursor.None);
            }
            return node;
        }

        /// <summary>
        /// Checks if the current response from the parser is to
        /// create a new node.
        /// </summary>
        /// <param name="pResponse">The current response</param>
        /// <param name="pCursor">Location</param>
        /// <returns>True if a reduction</returns>
        private bool CreateNode(ParseMessage pResponse, Cursor pCursor)
        {
            switch (pResponse)
            {
                case ParseMessage.LexicalError:
                    throw new LexicalException(_parser, pCursor);

                case ParseMessage.SyntaxError:
                    throw new SyntaxException(_parser, pCursor);

                case ParseMessage.InternalError:
                    throw new InternalErrorException(pCursor);

                case ParseMessage.NotLoadedError:
                    throw new NotLoadedException(pCursor);

                case ParseMessage.GroupError:
                    throw new EofException(pCursor);
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
            _factory.DataType(ParserSymbol.Identifier);
            _factory.DataType(ParserSymbol.StringDouble);
            _factory.DataType(ParserSymbol.StringSingle);
            _factory.DataType(ParserSymbol.Integer);
            _factory.DataType(ParserSymbol.Float);
            _factory.DataType(ParserSymbol.Boolean);
            _factory.DataType(ParserSymbol.Integer);

            const string fullResourceName = "Prometheus.Parser.ParserGrammar.egt";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                {
                    throw new CompilerException(string.Format(Errors.MissingResource, fullResourceName), Cursor.None);
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
            using (StringReader reader = new StringReader(pSource))
            {
                Node root = Compile(pFileName, reader);
                return new TargetCode(root);
            }
        }
    }
}