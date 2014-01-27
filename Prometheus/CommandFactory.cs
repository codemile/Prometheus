using System;
using System.Collections.Generic;
using GOLD;
using Prometheus.Documents;
using Prometheus.Exceptions;
using Prometheus.Tokens.Arguments;
using Prometheus.Tokens.Blocks;
using Prometheus.Tokens.Expressions;
using Prometheus.Tokens.Statements;
using Token = Prometheus.Tokens.Token;

namespace Prometheus
{
    /// <summary>
    /// Handles the conversion of GOLD parser tokens into Aggregator class objects.
    /// How to add new commands:
    /// CreateArugments:
    /// This handles creating a list of arguments. The list must match
    /// the available constructors for the command class.
    /// Create:
    /// Commands that don't follow a naming convention have to be
    /// created manually in this method. If they take more then
    /// one arrangement of arguments, then you have to check the
    /// available tokens to call the correct constructor.
    /// </summary>
    public class CommandFactory
    {
        /// <summary>
        /// The current context of the program being created.
        /// </summary>
        private Context _context { get; set; }

        /// <summary>
        /// The current location being processed.
        /// </summary>
        private Cursor _cursor { get; set; }

        /// <summary>
        /// Creates an array of ParserArgument objects using the GOLD parser's tree
        /// to discover what arguments are required. These arguments are then
        /// used to call the constructor of the command object.
        /// A command class can have different constructors. The one that matches
        /// the arguments will be used.
        /// </summary>
        private object[] CreateArguments(Production pParent, TokenList pTokens)
        {
            List<object> arguments = new List<object> {_context, _cursor};

            SymbolList children = pParent.Handle();
            for (int i = 0, c = children.Count(); i < c; i++)
            {
                Symbol child = children[i];
                if (child.Type != SymbolType.Nonterminal)
                {
                    continue;
                }
                ParserSymbol symbol = (ParserSymbol)child.TableIndex();
                switch (symbol)
                {
                    case ParserSymbol.Variable:
                    case ParserSymbol.Value:
                        arguments.Add(pTokens[i].Data);
                        break;

                    case ParserSymbol.UnaryOperator:
                    case ParserSymbol.MultiplyExpression:
                    case ParserSymbol.DivideExpression:
                    case ParserSymbol.AddExpression:
                    case ParserSymbol.SubExpression:
                    case ParserSymbol.Expression:
                    case ParserSymbol.SearchTerm:
                        arguments.Add(pTokens[i].Data);
                        break;

                    default:
                        throw new UnsupportedSymbolException(symbol, _cursor);
                }
            }

            return arguments.ToArray();
        }

        /// <summary>
        /// Creates a block of statements.
        /// </summary>
        private Block CreateBlock(Statement pStatement)
        {
            List<Statement> statements = new List<Statement>();
            ReduceStatementChain(statements, pStatement);
            return new Block(_context, _cursor, statements);
        }

        /// <summary>
        /// Creates a block of statements.
        /// </summary>
        private Block CreateBlock(TokenList pTokens)
        {
            GOLD.Token second = getTokenByOffset(pTokens, 1, 3);
            return CreateBlock((Statement)second.Data);
        }

        /// <summary>
        /// Attempts to create an object using the symbol as a naming convention.
        /// If the symbol ends with a classifier, then a class name is generated
        /// using that symbol as a string.
        /// </summary>
        private Token CreateBySymbolName(Reduction pReduct, ParserSymbol pSymbol, string pEndsWith,
                                         string pPackage)
        {
            string symbolName = pSymbol.ToString();
            if (!symbolName.EndsWith(pEndsWith))
            {
                return null;
            }
            string className = string.Format("Prometheus.Tokens.Expressions.{0}.{1}", pPackage, symbolName);
            try
            {
                Type type = Type.GetType(className);
                if (type == null)
                {
                    throw new TypeNotFoundException(symbolName, _cursor);
                }

                object[] arguments = CreateArguments(pReduct.Parent, pReduct);
                return (Token)Activator.CreateInstance(type, arguments);
            }
            catch (TypeLoadException e)
            {
                throw new TypeNotFoundException(symbolName, _cursor, e);
            }
        }

        /// <summary>
        /// Creates the main program.
        /// The first token can be either a chain of statements or
        /// a code block. If it's chain then create a new block to
        /// hold the statements.
        /// </summary>
        private Program CreateProgram(TokenList pTokens)
        {
            Block block;
            GOLD.Token first = getTokenByOffset(pTokens, 0, 1);

            Block firstBlock = first.Data as Block;
            if (firstBlock != null)
            {
                block = firstBlock;
            }
            else
            {
                Statement statement = first.Data as Statement;
                if (statement != null)
                {
                    block = CreateBlock(statement);
                }
                else
                {
                    throw new LexicalException("Unexpected statement in main block", _cursor);
                }
            }

            return new Program(_context, _cursor, block);
        }

        /// <summary>
        /// Creates a reference object for different types of values.
        /// </summary>
        private Ref CreateValueRef(TokenList pTokens)
        {
            GOLD.Token token = pTokens.Count() == 3 ? getTokenByOffset(pTokens, 1, 3) : getTokenByOffset(pTokens, 0, 1);

            Symbol symbol = token.Parent;
            object data = token.Data;

            // has this token already been converted?
            if (data is Ref)
            {
                return (Ref)data;
            }

            switch ((ParserSymbol)symbol.TableIndex())
            {
                case ParserSymbol.StringDouble:
                case ParserSymbol.StringSingle:
                    string str = data.ToString();
                    if (str.Length < 2)
                    {
                        throw new SyntaxException("Expected string quotes", _cursor);
                    }
                    str = str.Substring(1, str.Length - 2);
                    return new RefValue(_context, _cursor, str);

                case ParserSymbol.Float:
                case ParserSymbol.Integer:
                case ParserSymbol.Boolean:
                    return new RefValue(_context, _cursor, data.ToString());

                case ParserSymbol.Variable:
                    return new RefVariable(_context, _cursor, data.ToString());

                case ParserSymbol.Expression:
                    return new RefExpression(_context, _cursor, (BaseExpression)data);
            }

            throw new UnsupportedSymbolException(symbol, _cursor);
        }

        /// <summary>
        /// Reduces a tree of statements down to a list of statements.
        /// Discarding AggStatements instances.
        /// </summary>
        private void ReduceStatementChain(List<Statement> pStatements, Statement pStatement)
        {
            Statements statement = pStatement as Statements;
            if (statement != null)
            {
                Statements multi = statement;
                ReduceStatementChain(pStatements, multi.Left);
                ReduceStatementChain(pStatements, multi.Right);
            }
            else if (pStatement != null)
            {
                pStatements.Add(pStatement);
            }
            else
            {
                throw new LexicalException("Token is not a type of statement", _cursor);
            }
        }

        /// <summary>
        /// Converts the first token to it's string data. There must be only one token.
        /// </summary>
        private string getStringByOffset(TokenList pTokens, int pOffset, int pExpected)
        {
            object data = getTokenByOffset(pTokens, pOffset, pExpected).Data;
            if (data is Token)
            {
                // it's like this is a programming error. AggToken should not be converted to strings
                // as part of the parsing process.
                throw new LexicalException("Invalid conversion to string", _cursor);
            }
            return data.ToString();
        }

        /// <summary>
        /// Returns a token from the collection. Asserts that the collection has an expected
        /// size. If the size of the collection does not match the expected size an
        /// exception is thrown.
        /// This is used to verify the structure of the token tree while parsing.
        /// </summary>
        /// <param name="pTokens">The token collection.</param>
        /// <param name="pOffset">A zero based offset.</param>
        /// <param name="pExpected">The expected number of tokens in the collection.</param>
        private GOLD.Token getTokenByOffset(TokenList pTokens, int pOffset, int pExpected)
        {
            if (pTokens.Count() != pExpected)
            {
                throw new CommandFactoryException(
                    string.Format("{0} token expected, but {1} were found", pExpected, pTokens.Count()), _cursor);
            }
            return pTokens[pOffset];
        }

        /// <summary>
        /// Attempts to convert a GOLD Reduction object to a Token object.
        /// </summary>
        public object Create(Context pContext, object pReference, Cursor pCursor)
        {
            Reduction reduct = pReference as Reduction;
            if (reduct == null)
            {
                return pReference;
            }
            _cursor = pCursor;
            _context = pContext;

            ParserSymbol symbol = (ParserSymbol)reduct.Parent.Head().TableIndex();
            Token token;

            // create tokens with a symbol name following a naming convention of XXXXCommand
            if ((token = CreateBySymbolName(reduct, symbol, "Command", "Commands")) != null)
            {
                return token;
            }
            if ((token = CreateBySymbolName(reduct, symbol, "Expression", "Expressions")) != null)
            {
                return token;
            }

            // These types of symbols are easy to convert and can be done
            // using regular code.
            switch (symbol)
            {
                case ParserSymbol.Block:
                    return CreateBlock(reduct);

                case ParserSymbol.Program:
                    return CreateProgram(reduct);

                case ParserSymbol.Statements:
                    if (reduct.Count() == 1)
                    {
                        return reduct[0].Data;
                    }
                    if (reduct.Count() == 2)
                    {
                        return new Statements(_context, _cursor, (Statement)reduct[0].Data,
                            (Statement)reduct[1].Data);
                    }
                    throw new LexicalException("Unexpected number of statements", pCursor);

                case ParserSymbol.Statement:
                    return reduct[0].Data;

                case ParserSymbol.Variable:
                    return new RefVariable(_context, _cursor, getStringByOffset(reduct, 0, 1));

                case ParserSymbol.Value:
                    return CreateValueRef(reduct);

                case ParserSymbol.SearchTerm:
                    if (reduct.Count() == 1)
                    {
                        return new SearchTerm(_context, _cursor, (BaseExpression)reduct[0].Data);
                    }
                    if (reduct.Count() == 2)
                    {
                        return new SearchTerm(_context, _cursor, reduct[0].Data.ToString(),
                            (BaseExpression)reduct[1].Data);
                    }
                    throw new LexicalException("Unexpected number of search terms", pCursor);

                case ParserSymbol.UnaryOperator:
                    if (reduct.Count() == 1)
                    {
                        return new UnaryOperator(_context, _cursor, (Ref)reduct[0].Data);
                    }
                    if (reduct.Count() == 2)
                    {
                        return new UnaryOperator(_context, _cursor, reduct[0].Data.ToString(), (Ref)reduct[1].Data);
                    }
                    throw new LexicalException("Unexpected number of operators", pCursor);
            }

            return pReference;
        }
    }
}