
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
		@FOR = 35,                                       // 1 FOR
		@Identifier = 36,                                // 1 Identifier
		@IF = 37,                                        // 1 IF
		@INCLUDE = 38,                                   // 1 INCLUDE
		@LOOP = 39,                                      // 1 LOOP
		@LOWER = 40,                                     // 1 LOWER
		@NewLine = 41,                                   // 1 NewLine
		@NOT = 42,                                       // 1 NOT
		@Number = 43,                                    // 1 Number
		@OR = 44,                                        // 1 OR
		@PRINT = 45,                                     // 1 PRINT
		@REJECT = 46,                                    // 1 REJECT
		@SCOPE = 47,                                     // 1 SCOPE
		@STEP = 48,                                      // 1 STEP
		@StringDouble = 49,                              // 1 StringDouble
		@StringSingle = 50,                              // 1 StringSingle
		@THEN = 51,                                      // 1 THEN
		@TO = 52,                                        // 1 TO
		@TRIM = 53,                                      // 1 TRIM
		@UNSET = 54,                                     // 1 UNSET
		@UNTIL = 55,                                     // 1 UNTIL
		@UPPER = 56,                                     // 1 UPPER
		@VAR = 57,                                       // 1 VAR
		@VARS = 58,                                      // 1 VARS
		@WHILE = 59,                                     // 1 WHILE
		@PipePipe = 60,                                  // 1 '||'
		@Tilde = 61,                                     // 1 '~'
		@AcceptProc = 62,                                // 0 <AcceptProc>
		@AddExpression = 63,                             // 0 <AddExpression>
		@AndOperator = 64,                               // 0 <AndOperator>
		@Assignment = 65,                                // 0 <Assignment>
		@BreakControl = 66,                              // 0 <BreakControl>
		@ContinueControl = 67,                           // 0 <ContinueControl>
		@Declare = 68,                                   // 0 <Declare>
		@Decrement = 69,                                 // 0 <Decrement>
		@DivideExpression = 70,                          // 0 <DivideExpression>
		@DoUntilControl = 71,                            // 0 <DoUntilControl>
		@DoWhileControl = 72,                            // 0 <DoWhileControl>
		@ElseIfControl = 73,                             // 0 <ElseIfControl>
		@EqualOperator = 74,                             // 0 <EqualOperator>
		@Expression = 75,                                // 0 <Expression>
		@FlowControl = 76,                               // 0 <FlowControl>
		@ForControl = 77,                                // 0 <ForControl>
		@ForStepControl = 78,                            // 0 <ForStepControl>
		@Function = 79,                                  // 0 <Function>
		@GteOperator = 80,                               // 0 <GteOperator>
		@GtOperator = 81,                                // 0 <GtOperator>
		@IfControl = 82,                                 // 0 <IfControl>
		@IncludeProc = 83,                               // 0 <IncludeProc>
		@Increment = 84,                                 // 0 <Increment>
		@ListVars = 85,                                  // 0 <ListVars>
		@LoopUntilControl = 86,                          // 0 <LoopUntilControl>
		@LoopWhileControl = 87,                          // 0 <LoopWhileControl>
		@LowerFunc = 88,                                 // 0 <LowerFunc>
		@LteOperator = 89,                               // 0 <LteOperator>
		@LtOperator = 90,                                // 0 <LtOperator>
		@MultiplyExpression = 91,                        // 0 <MultiplyExpression>
		@NotEqualOperator = 92,                          // 0 <NotEqualOperator>
		@OrOperator = 93,                                // 0 <OrOperator>
		@PrintProc = 94,                                 // 0 <PrintProc>
		@Procedure = 95,                                 // 0 <Procedure>
		@Program = 96,                                   // 0 <Program>
		@RejectProc = 97,                                // 0 <RejectProc>
		@ScopeProc = 98,                                 // 0 <ScopeProc>
		@Statement = 99,                                 // 0 <Statement>
		@Statements = 100,                               // 0 <Statements>
		@SubExpression = 101,                            // 0 <SubExpression>
		@TrimFunc = 102,                                 // 0 <TrimFunc>
		@UnaryOperator = 103,                            // 0 <UnaryOperator>
		@UnsetProc = 104,                                // 0 <UnsetProc>
		@UpperFunc = 105,                                // 0 <UpperFunc>
		@Value = 106,                                    // 0 <Value>
		@Variable = 107,                                 // 0 <Variable>
		@Variables = 108                                 // 0 <Variables>
	}
}
