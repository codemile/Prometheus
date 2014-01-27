using System.IO;
using System.Reflection;
using GOLD;
using Prometheus.Documents;
using Prometheus.Exceptions;
using Prometheus.Tokens.Blocks;

namespace Prometheus
{
    /// <summary>
    /// Handles the execution of the source code file.
    /// </summary>
    public class Parser
    {
        /// <summary>
        /// The GOLD parser.
        /// </summary>
        private readonly GOLD.Parser _parser;

        /// <summary>
        /// Calculates the command tree from the source code and returns the root node.
        /// </summary>
        /// <param name="pContext"></param>
        /// <param name="pResourceName">The name of the source file.</param>
        /// <param name="pReader">A stream of the source file.</param>
        private Program Parse(Context pContext, string pResourceName, TextReader pReader)
        {
            //This procedure starts the GOLD Parser Engine and handles each of the
            //messages it returns. Each time a reduction is made, you can create new
            //custom object and reassign the .CurrentReduction property. Otherwise, 
            //the system will use the Reduction object that was returned.
            //
            //The resulting tree will be a pure representation of the language 
            //and will be ready to implement.

            _parser.Open(pReader);
            _parser.TrimReductions = false;

            TokenFactory factory = new TokenFactory();

            for (ParseMessage response = _parser.Parse(); response != ParseMessage.Accept; response = _parser.Parse())
            {
                int x = _parser.CurrentPosition().Line + 1;
                int y = _parser.CurrentPosition().Column + 1;
                DocumentCursor cursor = new DocumentCursor(pResourceName, x, y);

                switch (response)
                {
                    case ParseMessage.LexicalError:
                        throw new LexicalException(_parser, cursor);

                    case ParseMessage.SyntaxError:
                        throw new SyntaxException(_parser, cursor);

                    case ParseMessage.InternalError:
                        throw new InternalErrorException(cursor);

                    case ParseMessage.NotLoadedError:
                        throw new NotLoadedException(cursor);

                    case ParseMessage.GroupError:
                        throw new EofException(cursor);

                    case ParseMessage.Reduction:
                        //Create a customized object to store the reduction
                        _parser.CurrentReduction = factory.Create(pContext, _parser.CurrentReduction, cursor);
                        break;
                }
            }

            Program program = _parser.CurrentReduction as Program;
            if (program != null)
            {
                return program;
            }

            throw new InternalErrorException("Program was not created", DocumentCursor.None);
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Parser()
        {
            _parser = new GOLD.Parser();

            const string fullResourceName = "Prometheus.ParserGrammar.egt";
            using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(fullResourceName))
            {
                if (stream == null)
                {
                    throw new ResourceNotFoundException(fullResourceName);
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
        /// <param name="pContext"></param>
        /// <param name="pResourceName">The name of the source file.</param>
        /// <param name="pSource">Contents of the source file.</param>
        public Program Parse(Context pContext, string pResourceName, string pSource)
        {
            using (StringReader reader = new StringReader(pSource))
            {
                return Parse(pContext, pResourceName, reader);
            }
        }
    }
}