
namespace Prometheus.Parser
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum ParserSymbol
	{
		@EOF = 0,                                        // (EOF)
		@Error = 1,                                      // (Error)
		@Comment = 2,                                    // Comment
		@NewLine = 3,                                    // NewLine
		@Whitespace = 4,                                 // Whitespace
		@TimesDiv = 5,                                   // '*/'
		@DivTimes = 6,                                   // '/*'
		@DivDiv = 7,                                     // '//'
		@Exclam = 8,                                     // '!'
		@ExclamEq = 9,                                   // '!='
		@AmpAmp = 10,                                    // '&&'
		@LParen = 11,                                    // '('
		@RParen = 12,                                    // ')'
		@Times = 13,                                     // '*'
		@Plus = 14,                                      // '+'
		@Minus = 15,                                     // '-'
		@Div = 16,                                       // '/'
		@Lt = 17,                                        // '<'
		@LtEq = 18,                                      // '<='
		@LtGt = 19,                                      // '<>'
		@Eq = 20,                                        // '='
		@EqEq = 21,                                      // '=='
		@Gt = 22,                                        // '>'
		@GtEq = 23,                                      // '>='
		@accept = 24,                                    // accept
		@and = 25,                                       // and
		@Boolean = 26,                                   // Boolean
		@contains = 27,                                  // contains
		@else = 28,                                      // else
		@Float = 29,                                     // Float
		@has = 30,                                       // has
		@Identifier = 31,                                // Identifier
		@if = 32,                                        // if
		@include = 33,                                   // include
		@Integer = 34,                                   // Integer
		@not = 35,                                       // not
		@or = 36,                                        // or
		@print = 37,                                     // print
		@reject = 38,                                    // reject
		@scope = 39,                                     // scope
		@set = 40,                                       // set
		@StringDouble = 41,                              // StringDouble
		@StringSingle = 42,                              // StringSingle
		@unset = 43,                                     // unset
		@LBrace = 44,                                    // '{'
		@PipePipe = 45,                                  // '||'
		@RBrace = 46,                                    // '}'
		@Tilde = 47,                                     // '~'
		@AcceptCommand = 48,                             // <AcceptCommand>
		@AddExpression = 49,                             // <AddExpression>
		@Block = 50,                                     // <Block>
		@DivideExpression = 51,                          // <DivideExpression>
		@Expression = 52,                                // <Expression>
		@IfBlock = 53,                                   // <IfBlock>
		@IfElseBlock = 54,                               // <IfElseBlock>
		@IncludeCommand = 55,                            // <IncludeCommand>
		@MultiplyExpression = 56,                        // <MultiplyExpression>
		@PrintCommand = 57,                              // <PrintCommand>
		@Program = 58,                                   // <Program>
		@RejectCommand = 59,                             // <RejectCommand>
		@ScopeCommand = 60,                              // <ScopeCommand>
		@SearchTerm = 61,                                // <SearchTerm>
		@SetCommand = 62,                                // <SetCommand>
		@Statement = 63,                                 // <Statement>
		@Statements = 64,                                // <Statements>
		@SubExpression = 65,                             // <SubExpression>
		@UnaryOperator = 66,                             // <UnaryOperator>
		@UnsetCommand = 67,                              // <UnsetCommand>
		@Value = 68,                                     // <Value>
		@Variable = 69                                   // <Variable>
	}
}
