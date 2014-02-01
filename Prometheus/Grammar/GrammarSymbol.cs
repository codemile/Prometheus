
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
		@BREAK = 28,                                     // 1 BREAK
		@CONTINUE = 29,                                  // 1 CONTINUE
		@Decimal = 30,                                   // 1 Decimal
		@DO = 31,                                        // 1 DO
		@ELSE = 32,                                      // 1 ELSE
		@ELSEIF = 33,                                    // 1 ELSEIF
		@END = 34,                                       // 1 END
		@Identifier = 35,                                // 1 Identifier
		@IF = 36,                                        // 1 IF
		@INCLUDE = 37,                                   // 1 INCLUDE
		@LOOP = 38,                                      // 1 LOOP
		@LOWER = 39,                                     // 1 LOWER
		@NewLine = 40,                                   // 1 NewLine
		@NOT = 41,                                       // 1 NOT
		@Number = 42,                                    // 1 Number
		@OR = 43,                                        // 1 OR
		@PRINT = 44,                                     // 1 PRINT
		@REJECT = 45,                                    // 1 REJECT
		@SCOPE = 46,                                     // 1 SCOPE
		@StringDouble = 47,                              // 1 StringDouble
		@StringSingle = 48,                              // 1 StringSingle
		@THEN = 49,                                      // 1 THEN
		@TRIM = 50,                                      // 1 TRIM
		@UNSET = 51,                                     // 1 UNSET
		@UNTIL = 52,                                     // 1 UNTIL
		@UPPER = 53,                                     // 1 UPPER
		@VAR = 54,                                       // 1 VAR
		@VARS = 55,                                      // 1 VARS
		@WHILE = 56,                                     // 1 WHILE
		@PipePipe = 57,                                  // 1 '||'
		@Tilde = 58,                                     // 1 '~'
		@AcceptProc = 59,                                // 0 <AcceptProc>
		@AddExpression = 60,                             // 0 <AddExpression>
		@AndOperator = 61,                               // 0 <AndOperator>
		@BreakControl = 62,                              // 0 <BreakControl>
		@ContinueControl = 63,                           // 0 <ContinueControl>
		@Declare = 64,                                   // 0 <Declare>
		@Decrement = 65,                                 // 0 <Decrement>
		@DivideExpression = 66,                          // 0 <DivideExpression>
		@DoUntilControl = 67,                            // 0 <DoUntilControl>
		@DoWhileControl = 68,                            // 0 <DoWhileControl>
		@EndIfControl = 69,                              // 0 <EndIfControl>
		@EqualOperator = 70,                             // 0 <EqualOperator>
		@Expression = 71,                                // 0 <Expression>
		@FlowControl = 72,                               // 0 <FlowControl>
		@Function = 73,                                  // 0 <Function>
		@GteOperator = 74,                               // 0 <GteOperator>
		@GtOperator = 75,                                // 0 <GtOperator>
		@IfControl = 76,                                 // 0 <IfControl>
		@IncludeProc = 77,                               // 0 <IncludeProc>
		@Increment = 78,                                 // 0 <Increment>
		@ListVars = 79,                                  // 0 <ListVars>
		@LoopUntilControl = 80,                          // 0 <LoopUntilControl>
		@LoopWhileControl = 81,                          // 0 <LoopWhileControl>
		@LowerFunc = 82,                                 // 0 <LowerFunc>
		@LteOperator = 83,                               // 0 <LteOperator>
		@LtOperator = 84,                                // 0 <LtOperator>
		@MultiplyExpression = 85,                        // 0 <MultiplyExpression>
		@NotEqualOperator = 86,                          // 0 <NotEqualOperator>
		@OrOperator = 87,                                // 0 <OrOperator>
		@PrintProc = 88,                                 // 0 <PrintProc>
		@Procedure = 89,                                 // 0 <Procedure>
		@Program = 90,                                   // 0 <Program>
		@RejectProc = 91,                                // 0 <RejectProc>
		@ScopeProc = 92,                                 // 0 <ScopeProc>
		@Statement = 93,                                 // 0 <Statement>
		@Statements = 94,                                // 0 <Statements>
		@SubExpression = 95,                             // 0 <SubExpression>
		@TrimFunc = 96,                                  // 0 <TrimFunc>
		@UnaryOperator = 97,                             // 0 <UnaryOperator>
		@UnsetProc = 98,                                 // 0 <UnsetProc>
		@UpperFunc = 99,                                 // 0 <UpperFunc>
		@Value = 100,                                    // 0 <Value>
		@Variable = 101,                                 // 0 <Variable>
		@Variables = 102                                 // 0 <Variables>
	}
}
