
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
		@ELSEIF = 31,                                    // 1 ELSEIF
		@END = 32,                                       // 1 END
		@Identifier = 33,                                // 1 Identifier
		@IF = 34,                                        // 1 IF
		@INCLUDE = 35,                                   // 1 INCLUDE
		@LOWER = 36,                                     // 1 LOWER
		@NewLine = 37,                                   // 1 NewLine
		@NOT = 38,                                       // 1 NOT
		@Number = 39,                                    // 1 Number
		@OR = 40,                                        // 1 OR
		@PRINT = 41,                                     // 1 PRINT
		@REJECT = 42,                                    // 1 REJECT
		@SCOPE = 43,                                     // 1 SCOPE
		@StringDouble = 44,                              // 1 StringDouble
		@StringSingle = 45,                              // 1 StringSingle
		@THEN = 46,                                      // 1 THEN
		@TRIM = 47,                                      // 1 TRIM
		@UNSET = 48,                                     // 1 UNSET
		@UPPER = 49,                                     // 1 UPPER
		@VAR = 50,                                       // 1 VAR
		@WHILE = 51,                                     // 1 WHILE
		@PipePipe = 52,                                  // 1 '||'
		@Tilde = 53,                                     // 1 '~'
		@AcceptProc = 54,                                // 0 <AcceptProc>
		@AddExpression = 55,                             // 0 <AddExpression>
		@AndOperator = 56,                               // 0 <AndOperator>
		@Assignment = 57,                                // 0 <Assignment>
		@Decrement = 58,                                 // 0 <Decrement>
		@DivideExpression = 59,                          // 0 <DivideExpression>
		@DoControl = 60,                                 // 0 <DoControl>
		@EndIfControl = 61,                              // 0 <EndIfControl>
		@EqualOperator = 62,                             // 0 <EqualOperator>
		@Expression = 63,                                // 0 <Expression>
		@FlowControl = 64,                               // 0 <FlowControl>
		@Function = 65,                                  // 0 <Function>
		@GteOperator = 66,                               // 0 <GteOperator>
		@GtOperator = 67,                                // 0 <GtOperator>
		@IfControl = 68,                                 // 0 <IfControl>
		@IncludeProc = 69,                               // 0 <IncludeProc>
		@Increment = 70,                                 // 0 <Increment>
		@LowerFunc = 71,                                 // 0 <LowerFunc>
		@LteOperator = 72,                               // 0 <LteOperator>
		@LtOperator = 73,                                // 0 <LtOperator>
		@MultiplyExpression = 74,                        // 0 <MultiplyExpression>
		@NotEqualOperator = 75,                          // 0 <NotEqualOperator>
		@OrOperator = 76,                                // 0 <OrOperator>
		@PrintProc = 77,                                 // 0 <PrintProc>
		@Procedure = 78,                                 // 0 <Procedure>
		@Program = 79,                                   // 0 <Program>
		@RejectProc = 80,                                // 0 <RejectProc>
		@ScopeProc = 81,                                 // 0 <ScopeProc>
		@Statement = 82,                                 // 0 <Statement>
		@Statements = 83,                                // 0 <Statements>
		@SubExpression = 84,                             // 0 <SubExpression>
		@TrimFunc = 85,                                  // 0 <TrimFunc>
		@UnaryOperator = 86,                             // 0 <UnaryOperator>
		@UnsetProc = 87,                                 // 0 <UnsetProc>
		@UpperFunc = 88,                                 // 0 <UpperFunc>
		@Value = 89,                                     // 0 <Value>
		@Variable = 90,                                  // 0 <Variable>
		@WhileControl = 91                               // 0 <WhileControl>
	}
}
