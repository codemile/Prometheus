
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
		@Whitespace = 3,                                 // 2 Whitespace
		@TimesDiv = 4,                                   // 5 '*/'
		@DivTimes = 5,                                   // 4 '/*'
		@DivDiv = 6,                                     // 6 '//'
		@Exclam = 7,                                     // 1 '!'
		@ExclamEq = 8,                                   // 1 '!='
		@AmpAmp = 9,                                     // 1 '&&'
		@LParen = 10,                                    // 1 '('
		@RParen = 11,                                    // 1 ')'
		@Times = 12,                                     // 1 '*'
		@Plus = 13,                                      // 1 '+'
		@PlusPlus = 14,                                  // 1 '++'
		@Minus = 15,                                     // 1 '-'
		@MinusMinus = 16,                                // 1 '--'
		@Div = 17,                                       // 1 '/'
		@Lt = 18,                                        // 1 '<'
		@LtEq = 19,                                      // 1 '<='
		@LtGt = 20,                                      // 1 '<>'
		@Eq = 21,                                        // 1 '='
		@EqEq = 22,                                      // 1 '=='
		@Gt = 23,                                        // 1 '>'
		@GtEq = 24,                                      // 1 '>='
		@ACCEPT = 25,                                    // 1 ACCEPT
		@AND = 26,                                       // 1 AND
		@Boolean = 27,                                   // 1 Boolean
		@Decimal = 28,                                   // 1 Decimal
		@DO = 29,                                        // 1 DO
		@ELSE = 30,                                      // 1 ELSE
		@END = 31,                                       // 1 END
		@Identifier = 32,                                // 1 Identifier
		@IF = 33,                                        // 1 IF
		@INCLUDE = 34,                                   // 1 INCLUDE
		@LOWER = 35,                                     // 1 LOWER
		@NewLine = 36,                                   // 1 NewLine
		@NOT = 37,                                       // 1 NOT
		@Number = 38,                                    // 1 Number
		@OR = 39,                                        // 1 OR
		@PRINT = 40,                                     // 1 PRINT
		@REJECT = 41,                                    // 1 REJECT
		@SCOPE = 42,                                     // 1 SCOPE
		@StringDouble = 43,                              // 1 StringDouble
		@StringSingle = 44,                              // 1 StringSingle
		@TRIM = 45,                                      // 1 TRIM
		@UNSET = 46,                                     // 1 UNSET
		@UPPER = 47,                                     // 1 UPPER
		@VAR = 48,                                       // 1 VAR
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
