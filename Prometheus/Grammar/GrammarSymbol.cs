
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
		@CONTAINS = 27,                                  // 1 CONTAINS
		@DO = 28,                                        // 1 DO
		@ELSE = 29,                                      // 1 ELSE
		@END = 30,                                       // 1 END
		@ENDS = 31,                                      // 1 ENDS
		@ENDWHILE = 32,                                  // 1 ENDWHILE
		@Float = 33,                                     // 1 Float
		@HAS = 34,                                       // 1 HAS
		@Identifier = 35,                                // 1 Identifier
		@IF = 36,                                        // 1 IF
		@INCLUDE = 37,                                   // 1 INCLUDE
		@Integer = 38,                                   // 1 Integer
		@LOWER = 39,                                     // 1 LOWER
		@not = 40,                                       // 1 not
		@or = 41,                                        // 1 or
		@PRINT = 42,                                     // 1 PRINT
		@REJECT = 43,                                    // 1 REJECT
		@SCOPE = 44,                                     // 1 SCOPE
		@SET = 45,                                       // 1 SET
		@STARTS = 46,                                    // 1 STARTS
		@StringDouble = 47,                              // 1 StringDouble
		@StringSingle = 48,                              // 1 StringSingle
		@TRIM = 49,                                      // 1 TRIM
		@UNSET = 50,                                     // 1 UNSET
		@UPPER = 51,                                     // 1 UPPER
		@WHILE = 52,                                     // 1 WHILE
		@WITH = 53,                                      // 1 WITH
		@PipePipe = 54,                                  // 1 '||'
		@Tilde = 55,                                     // 1 '~'
		@AcceptCommand = 56,                             // 0 <AcceptCommand>
		@AddExpression = 57,                             // 0 <AddExpression>
		@DivideExpression = 58,                          // 0 <DivideExpression>
		@DoControl = 59,                                 // 0 <DoControl>
		@Expression = 60,                                // 0 <Expression>
		@IfControl = 61,                                 // 0 <IfControl>
		@IfElseControl = 62,                             // 0 <IfElseControl>
		@IncludeCommand = 63,                            // 0 <IncludeCommand>
		@LowerCommand = 64,                              // 0 <LowerCommand>
		@MultiplyExpression = 65,                        // 0 <MultiplyExpression>
		@PrintCommand = 66,                              // 0 <PrintCommand>
		@Program = 67,                                   // 0 <Program>
		@RejectCommand = 68,                             // 0 <RejectCommand>
		@ScopeCommand = 69,                              // 0 <ScopeCommand>
		@SearchTerm = 70,                                // 0 <SearchTerm>
		@SetCommand = 71,                                // 0 <SetCommand>
		@Statement = 72,                                 // 0 <Statement>
		@Statements = 73,                                // 0 <Statements>
		@SubExpression = 74,                             // 0 <SubExpression>
		@TrimCommand = 75,                               // 0 <TrimCommand>
		@UnaryOperator = 76,                             // 0 <UnaryOperator>
		@UnsetCommand = 77,                              // 0 <UnsetCommand>
		@UpperCommand = 78,                              // 0 <UpperCommand>
		@Value = 79,                                     // 0 <Value>
		@Variable = 80,                                  // 0 <Variable>
		@WhileControl = 81                               // 0 <WhileControl>
	}
}
