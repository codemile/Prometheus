
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
		@Comma = 16,                                     // 1 ','
		@Minus = 17,                                     // 1 '-'
		@MinusMinus = 18,                                // 1 '--'
		@Div = 19,                                       // 1 '/'
		@Semi = 20,                                      // 1 ';'
		@Lt = 21,                                        // 1 '<'
		@LtEq = 22,                                      // 1 '<='
		@LtGt = 23,                                      // 1 '<>'
		@Eq = 24,                                        // 1 '='
		@EqEq = 25,                                      // 1 '=='
		@Gt = 26,                                        // 1 '>'
		@GtEq = 27,                                      // 1 '>='
		@ACCEPT = 28,                                    // 1 ACCEPT
		@AND = 29,                                       // 1 AND
		@Boolean = 30,                                   // 1 Boolean
		@BREAK = 31,                                     // 1 BREAK
		@CONTINUE = 32,                                  // 1 CONTINUE
		@Decimal = 33,                                   // 1 Decimal
		@DO = 34,                                        // 1 DO
		@ELSE = 35,                                      // 1 ELSE
		@FOR = 36,                                       // 1 FOR
		@function = 37,                                  // 1 function
		@Identifier = 38,                                // 1 Identifier
		@IF = 39,                                        // 1 IF
		@INCLUDE = 40,                                   // 1 INCLUDE
		@LOWER = 41,                                     // 1 LOWER
		@NOT = 42,                                       // 1 NOT
		@Number = 43,                                    // 1 Number
		@OR = 44,                                        // 1 OR
		@PRINT = 45,                                     // 1 PRINT
		@RegExp = 46,                                    // 1 RegExp
		@REJECT = 47,                                    // 1 REJECT
		@RETURN = 48,                                    // 1 RETURN
		@SCOPE = 49,                                     // 1 SCOPE
		@STEP = 50,                                      // 1 STEP
		@StringDouble = 51,                              // 1 StringDouble
		@StringSingle = 52,                              // 1 StringSingle
		@this = 53,                                      // 1 this
		@TO = 54,                                        // 1 TO
		@TRIM = 55,                                      // 1 TRIM
		@UNSET = 56,                                     // 1 UNSET
		@UNTIL = 57,                                     // 1 UNTIL
		@UPPER = 58,                                     // 1 UPPER
		@VAR = 59,                                       // 1 VAR
		@VARS = 60,                                      // 1 VARS
		@WHILE = 61,                                     // 1 WHILE
		@LBrace = 62,                                    // 1 '{'
		@PipePipe = 63,                                  // 1 '||'
		@RBrace = 64,                                    // 1 '}'
		@Tilde = 65,                                     // 1 '~'
		@AcceptProc = 66,                                // 0 <AcceptProc>
		@AddExpression = 67,                             // 0 <AddExpression>
		@AndOperator = 68,                               // 0 <AndOperator>
		@ArgumentList = 69,                              // 0 <Argument List>
		@Arguments = 70,                                 // 0 <Arguments>
		@Assignment = 71,                                // 0 <Assignment>
		@Block = 72,                                     // 0 <Block>
		@BreakControl = 73,                              // 0 <BreakControl>
		@CallExpression = 74,                            // 0 <Call Expression>
		@ContinueControl = 75,                           // 0 <ContinueControl>
		@Declare = 76,                                   // 0 <Declare>
		@Decrement = 77,                                 // 0 <Decrement>
		@DivideExpression = 78,                          // 0 <DivideExpression>
		@DoUntilControl = 79,                            // 0 <DoUntilControl>
		@DoWhileControl = 80,                            // 0 <DoWhileControl>
		@EqualOperator = 81,                             // 0 <EqualOperator>
		@Expression = 82,                                // 0 <Expression>
		@FlowControl = 83,                               // 0 <FlowControl>
		@ForControl = 84,                                // 0 <ForControl>
		@FormalParameterList = 85,                       // 0 <Formal Parameter List>
		@ForStepControl = 86,                            // 0 <ForStepControl>
		@FunctionDeclaration = 87,                       // 0 <Function Declaration>
		@FunctionExpression = 88,                        // 0 <Function Expression>
		@GteOperator = 89,                               // 0 <GteOperator>
		@GtOperator = 90,                                // 0 <GtOperator>
		@IfControl = 91,                                 // 0 <IfControl>
		@IncludeProc = 92,                               // 0 <IncludeProc>
		@Increment = 93,                                 // 0 <Increment>
		@ListVars = 94,                                  // 0 <ListVars>
		@LoopUntilControl = 95,                          // 0 <LoopUntilControl>
		@LoopWhileControl = 96,                          // 0 <LoopWhileControl>
		@LowerFunc = 97,                                 // 0 <LowerFunc>
		@LteOperator = 98,                               // 0 <LteOperator>
		@LtOperator = 99,                                // 0 <LtOperator>
		@MultiplyExpression = 100,                       // 0 <MultiplyExpression>
		@NotEqualOperator = 101,                         // 0 <NotEqualOperator>
		@OrOperator = 102,                               // 0 <OrOperator>
		@PrintProc = 103,                                // 0 <PrintProc>
		@Procedure = 104,                                // 0 <Procedure>
		@Program = 105,                                  // 0 <Program>
		@RejectProc = 106,                               // 0 <RejectProc>
		@ReturnProc = 107,                               // 0 <ReturnProc>
		@ScopeProc = 108,                                // 0 <ScopeProc>
		@Statement = 109,                                // 0 <Statement>
		@StatementorBlock = 110,                         // 0 <Statement or Block>
		@Statements = 111,                               // 0 <Statements>
		@SubExpression = 112,                            // 0 <SubExpression>
		@TrimFunc = 113,                                 // 0 <TrimFunc>
		@UnaryOperator = 114,                            // 0 <UnaryOperator>
		@UnsetProc = 115,                                // 0 <UnsetProc>
		@UpperFunc = 116,                                // 0 <UpperFunc>
		@Value = 117,                                    // 0 <Value>
		@Variable = 118,                                 // 0 <Variable>
		@Variables = 119                                 // 0 <Variables>
	}
}
