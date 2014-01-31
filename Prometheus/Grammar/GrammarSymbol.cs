
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
		@PlusPlus = 15,                                  // 1 '++'
		@Minus = 16,                                     // 1 '-'
		@MinusMinus = 17,                                // 1 '--'
		@Div = 18,                                       // 1 '/'
		@Lt = 19,                                        // 1 '<'
		@LtEq = 20,                                      // 1 '<='
		@LtGt = 21,                                      // 1 '<>'
		@Eq = 22,                                        // 1 '='
		@EqEq = 23,                                      // 1 '=='
		@Gt = 24,                                        // 1 '>'
		@GtEq = 25,                                      // 1 '>='
		@ACCEPT = 26,                                    // 1 ACCEPT
		@and = 27,                                       // 1 and
		@Boolean = 28,                                   // 1 Boolean
		@DO = 29,                                        // 1 DO
		@ELSE = 30,                                      // 1 ELSE
		@END = 31,                                       // 1 END
		@ENDWHILE = 32,                                  // 1 ENDWHILE
		@Float = 33,                                     // 1 Float
		@Identifier = 34,                                // 1 Identifier
		@IF = 35,                                        // 1 IF
		@INCLUDE = 36,                                   // 1 INCLUDE
		@Integer = 37,                                   // 1 Integer
		@LOWER = 38,                                     // 1 LOWER
		@not = 39,                                       // 1 not
		@or = 40,                                        // 1 or
		@PRINT = 41,                                     // 1 PRINT
		@REJECT = 42,                                    // 1 REJECT
		@SCOPE = 43,                                     // 1 SCOPE
		@StringDouble = 44,                              // 1 StringDouble
		@StringSingle = 45,                              // 1 StringSingle
		@TRIM = 46,                                      // 1 TRIM
		@UNSET = 47,                                     // 1 UNSET
		@UPPER = 48,                                     // 1 UPPER
		@WHILE = 49,                                     // 1 WHILE
		@PipePipe = 50,                                  // 1 '||'
		@Tilde = 51,                                     // 1 '~'
		@AcceptProc = 52,                                // 0 <AcceptProc>
		@AddExpression = 53,                             // 0 <AddExpression>
		@Assignment = 54,                                // 0 <Assignment>
		@Decrement = 55,                                 // 0 <Decrement>
		@DivideExpression = 56,                          // 0 <DivideExpression>
		@DoControl = 57,                                 // 0 <DoControl>
		@Expression = 58,                                // 0 <Expression>
		@Function = 59,                                  // 0 <Function>
		@IfControl = 60,                                 // 0 <IfControl>
		@IfElseControl = 61,                             // 0 <IfElseControl>
		@IncludeProc = 62,                               // 0 <IncludeProc>
		@Increment = 63,                                 // 0 <Increment>
		@LowerFunc = 64,                                 // 0 <LowerFunc>
		@MultiplyExpression = 65,                        // 0 <MultiplyExpression>
		@PrintProc = 66,                                 // 0 <PrintProc>
		@Procedure = 67,                                 // 0 <Procedure>
		@Program = 68,                                   // 0 <Program>
		@RejectProc = 69,                                // 0 <RejectProc>
		@ScopeProc = 70,                                 // 0 <ScopeProc>
		@Statement = 71,                                 // 0 <Statement>
		@Statements = 72,                                // 0 <Statements>
		@SubExpression = 73,                             // 0 <SubExpression>
		@TrimFunc = 74,                                  // 0 <TrimFunc>
		@UnaryOperator = 75,                             // 0 <UnaryOperator>
		@UnsetProc = 76,                                 // 0 <UnsetProc>
		@UpperFunc = 77,                                 // 0 <UpperFunc>
		@Value = 78,                                     // 0 <Value>
		@Variable = 79,                                  // 0 <Variable>
		@WhileControl = 80                               // 0 <WhileControl>
	}
}
