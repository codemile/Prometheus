
namespace Prometheus.Grammar
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum GrammarSymbol
	{
		@EOF = 0,                                        // 3 (EOF)
		@Error = 1,                                      // 7 (Error)
		@Comment = 2,                                    // 2 Comment
		@NewLine = 3,                                    // 2 NewLine
		@Whitespace = 4,                                 // 2 Whitespace
		@TimesDiv = 5,                                   // 5 '*/'
		@DivTimes = 6,                                   // 4 '/*'
		@DivDiv = 7,                                     // 6 '//'
		@Exclam = 8,                                     // 1 '!'
		@ExclamEq = 9,                                   // 1 '!='
		@AmpAmp = 10,                                    // 1 '&&'
		@LParen = 11,                                    // 1 '('
		@RParen = 12,                                    // 1 ')'
		@Times = 13,                                     // 1 '*'
		@Plus = 14,                                      // 1 '+'
		@Minus = 15,                                     // 1 '-'
		@Div = 16,                                       // 1 '/'
		@Lt = 17,                                        // 1 '<'
		@LtEq = 18,                                      // 1 '<='
		@LtGt = 19,                                      // 1 '<>'
		@Eq = 20,                                        // 1 '='
		@EqEq = 21,                                      // 1 '=='
		@Gt = 22,                                        // 1 '>'
		@GtEq = 23,                                      // 1 '>='
		@accept = 24,                                    // 1 accept
		@and = 25,                                       // 1 and
		@Boolean = 26,                                   // 1 Boolean
		@contains = 27,                                  // 1 contains
		@else = 28,                                      // 1 else
		@Float = 29,                                     // 1 Float
		@has = 30,                                       // 1 has
		@Identifier = 31,                                // 1 Identifier
		@if = 32,                                        // 1 if
		@include = 33,                                   // 1 include
		@Integer = 34,                                   // 1 Integer
		@not = 35,                                       // 1 not
		@or = 36,                                        // 1 or
		@print = 37,                                     // 1 print
		@reject = 38,                                    // 1 reject
		@scope = 39,                                     // 1 scope
		@set = 40,                                       // 1 set
		@StringDouble = 41,                              // 1 StringDouble
		@StringSingle = 42,                              // 1 StringSingle
		@unset = 43,                                     // 1 unset
		@LBrace = 44,                                    // 1 '{'
		@PipePipe = 45,                                  // 1 '||'
		@RBrace = 46,                                    // 1 '}'
		@Tilde = 47,                                     // 1 '~'
		@AcceptCommand = 48,                             // 0 <AcceptCommand>
		@AddExpression = 49,                             // 0 <AddExpression>
		@Block = 50,                                     // 0 <Block>
		@DivideExpression = 51,                          // 0 <DivideExpression>
		@Expression = 52,                                // 0 <Expression>
		@IfBlock = 53,                                   // 0 <IfBlock>
		@IfElseBlock = 54,                               // 0 <IfElseBlock>
		@IncludeCommand = 55,                            // 0 <IncludeCommand>
		@MultiplyExpression = 56,                        // 0 <MultiplyExpression>
		@PrintCommand = 57,                              // 0 <PrintCommand>
		@Program = 58,                                   // 0 <Program>
		@RejectCommand = 59,                             // 0 <RejectCommand>
		@ScopeCommand = 60,                              // 0 <ScopeCommand>
		@SearchTerm = 61,                                // 0 <SearchTerm>
		@SetCommand = 62,                                // 0 <SetCommand>
		@Statement = 63,                                 // 0 <Statement>
		@Statements = 64,                                // 0 <Statements>
		@SubExpression = 65,                             // 0 <SubExpression>
		@UnaryOperator = 66,                             // 0 <UnaryOperator>
		@UnsetCommand = 67,                              // 0 <UnsetCommand>
		@Value = 68,                                     // 0 <Value>
		@Variable = 69                                   // 0 <Variable>
	}
}
