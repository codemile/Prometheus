
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
		@Semi = 19,                                      // 1 ';'
		@Lt = 20,                                        // 1 '<'
		@LtEq = 21,                                      // 1 '<='
		@LtGt = 22,                                      // 1 '<>'
		@Eq = 23,                                        // 1 '='
		@EqEq = 24,                                      // 1 '=='
		@Gt = 25,                                        // 1 '>'
		@GtEq = 26,                                      // 1 '>='
		@ACCEPT = 27,                                    // 1 ACCEPT
		@AND = 28,                                       // 1 AND
		@Boolean = 29,                                   // 1 Boolean
		@BREAK = 30,                                     // 1 BREAK
		@CONTINUE = 31,                                  // 1 CONTINUE
		@Decimal = 32,                                   // 1 Decimal
		@DO = 33,                                        // 1 DO
		@ELSE = 34,                                      // 1 ELSE
		@FOR = 35,                                       // 1 FOR
		@Identifier = 36,                                // 1 Identifier
		@IF = 37,                                        // 1 IF
		@INCLUDE = 38,                                   // 1 INCLUDE
		@LOWER = 39,                                     // 1 LOWER
		@NOT = 40,                                       // 1 NOT
		@Number = 41,                                    // 1 Number
		@OR = 42,                                        // 1 OR
		@PRINT = 43,                                     // 1 PRINT
		@RegExp = 44,                                    // 1 RegExp
		@REJECT = 45,                                    // 1 REJECT
		@SCOPE = 46,                                     // 1 SCOPE
		@STEP = 47,                                      // 1 STEP
		@StringDouble = 48,                              // 1 StringDouble
		@StringSingle = 49,                              // 1 StringSingle
		@TO = 50,                                        // 1 TO
		@TRIM = 51,                                      // 1 TRIM
		@UNSET = 52,                                     // 1 UNSET
		@UNTIL = 53,                                     // 1 UNTIL
		@UPPER = 54,                                     // 1 UPPER
		@VAR = 55,                                       // 1 VAR
		@VARS = 56,                                      // 1 VARS
		@WHILE = 57,                                     // 1 WHILE
		@LBrace = 58,                                    // 1 '{'
		@PipePipe = 59,                                  // 1 '||'
		@RBrace = 60,                                    // 1 '}'
		@Tilde = 61,                                     // 1 '~'
		@AcceptProc = 62,                                // 0 <AcceptProc>
		@AddExpression = 63,                             // 0 <AddExpression>
		@AndOperator = 64,                               // 0 <AndOperator>
		@Assignment = 65,                                // 0 <Assignment>
		@Block = 66,                                     // 0 <Block>
		@BreakControl = 67,                              // 0 <BreakControl>
		@ContinueControl = 68,                           // 0 <ContinueControl>
		@Declare = 69,                                   // 0 <Declare>
		@Decrement = 70,                                 // 0 <Decrement>
		@DivideExpression = 71,                          // 0 <DivideExpression>
		@DoUntilControl = 72,                            // 0 <DoUntilControl>
		@DoWhileControl = 73,                            // 0 <DoWhileControl>
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
		@StatementorBlock = 100,                         // 0 <Statement or Block>
		@Statements = 101,                               // 0 <Statements>
		@SubExpression = 102,                            // 0 <SubExpression>
		@TrimFunc = 103,                                 // 0 <TrimFunc>
		@UnaryOperator = 104,                            // 0 <UnaryOperator>
		@UnsetProc = 105,                                // 0 <UnsetProc>
		@UpperFunc = 106,                                // 0 <UpperFunc>
		@Value = 107,                                    // 0 <Value>
		@Variable = 108,                                 // 0 <Variable>
		@Variables = 109                                 // 0 <Variables>
	}
}
