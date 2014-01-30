
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
		@ACCEPT = 24,                                    // 1 ACCEPT
		@and = 25,                                       // 1 and
		@Boolean = 26,                                   // 1 Boolean
		@contains = 27,                                  // 1 contains
		@DO = 28,                                        // 1 DO
		@ELSE = 29,                                      // 1 ELSE
		@END = 30,                                       // 1 END
		@Float = 31,                                     // 1 Float
		@has = 32,                                       // 1 has
		@Identifier = 33,                                // 1 Identifier
		@IF = 34,                                        // 1 IF
		@INCLUDE = 35,                                   // 1 INCLUDE
		@Integer = 36,                                   // 1 Integer
		@LOWER = 37,                                     // 1 LOWER
		@not = 38,                                       // 1 not
		@or = 39,                                        // 1 or
		@PRINT = 40,                                     // 1 PRINT
		@REJECT = 41,                                    // 1 REJECT
		@SCOPE = 42,                                     // 1 SCOPE
		@SET = 43,                                       // 1 SET
		@StringDouble = 44,                              // 1 StringDouble
		@StringSingle = 45,                              // 1 StringSingle
		@TRIM = 46,                                      // 1 TRIM
		@UNSET = 47,                                     // 1 UNSET
		@UPPER = 48,                                     // 1 UPPER
		@WHILE = 49,                                     // 1 WHILE
		@PipePipe = 50,                                  // 1 '||'
		@Tilde = 51,                                     // 1 '~'
		@AcceptCommand = 52,                             // 0 <AcceptCommand>
		@AddExpression = 53,                             // 0 <AddExpression>
		@DivideExpression = 54,                          // 0 <DivideExpression>
		@DoControl = 55,                                 // 0 <DoControl>
		@Expression = 56,                                // 0 <Expression>
		@IfControl = 57,                                 // 0 <IfControl>
		@IfElseControl = 58,                             // 0 <IfElseControl>
		@IncludeCommand = 59,                            // 0 <IncludeCommand>
		@LowerCommand = 60,                              // 0 <LowerCommand>
		@MultiplyExpression = 61,                        // 0 <MultiplyExpression>
		@PrintCommand = 62,                              // 0 <PrintCommand>
		@Program = 63,                                   // 0 <Program>
		@RejectCommand = 64,                             // 0 <RejectCommand>
		@ScopeCommand = 65,                              // 0 <ScopeCommand>
		@SearchTerm = 66,                                // 0 <SearchTerm>
		@SetCommand = 67,                                // 0 <SetCommand>
		@Statement = 68,                                 // 0 <Statement>
		@Statements = 69,                                // 0 <Statements>
		@SubExpression = 70,                             // 0 <SubExpression>
		@TrimCommand = 71,                               // 0 <TrimCommand>
		@UnaryOperator = 72,                             // 0 <UnaryOperator>
		@UnsetCommand = 73,                              // 0 <UnsetCommand>
		@UpperCommand = 74,                              // 0 <UpperCommand>
		@Value = 75,                                     // 0 <Value>
		@Variable = 76,                                  // 0 <Variable>
		@WhileControl = 77                               // 0 <WhileControl>
	}
}
