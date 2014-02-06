
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
		@Dot = 19,                                       // 1 '.'
		@Div = 20,                                       // 1 '/'
		@Semi = 21,                                      // 1 ';'
		@Lt = 22,                                        // 1 '<'
		@LtEq = 23,                                      // 1 '<='
		@LtGt = 24,                                      // 1 '<>'
		@Eq = 25,                                        // 1 '='
		@EqEq = 26,                                      // 1 '=='
		@Gt = 27,                                        // 1 '>'
		@GtEq = 28,                                      // 1 '>='
		@ACCEPT = 29,                                    // 1 ACCEPT
		@AND = 30,                                       // 1 AND
		@Boolean = 31,                                   // 1 Boolean
		@BREAK = 32,                                     // 1 BREAK
		@CONTINUE = 33,                                  // 1 CONTINUE
		@Decimal = 34,                                   // 1 Decimal
		@DO = 35,                                        // 1 DO
		@ELSE = 36,                                      // 1 ELSE
		@FOR = 37,                                       // 1 FOR
		@function = 38,                                  // 1 function
		@Identifier = 39,                                // 1 Identifier
		@IF = 40,                                        // 1 IF
		@INCLUDE = 41,                                   // 1 INCLUDE
		@new = 42,                                       // 1 new
		@NOT = 43,                                       // 1 NOT
		@Number = 44,                                    // 1 Number
		@OBJECTS = 45,                                   // 1 OBJECTS
		@OR = 46,                                        // 1 OR
		@PRINT = 47,                                     // 1 PRINT
		@RegExp = 48,                                    // 1 RegExp
		@REJECT = 49,                                    // 1 REJECT
		@RETURN = 50,                                    // 1 RETURN
		@SCOPE = 51,                                     // 1 SCOPE
		@STEP = 52,                                      // 1 STEP
		@StringDouble = 53,                              // 1 StringDouble
		@StringSingle = 54,                              // 1 StringSingle
		@This = 55,                                      // 1 This
		@TO = 56,                                        // 1 TO
		@Type = 57,                                      // 1 Type
		@UNSET = 58,                                     // 1 UNSET
		@UNTIL = 59,                                     // 1 UNTIL
		@VAR = 60,                                       // 1 VAR
		@VARS = 61,                                      // 1 VARS
		@WHILE = 62,                                     // 1 WHILE
		@LBrace = 63,                                    // 1 '{'
		@PipePipe = 64,                                  // 1 '||'
		@RBrace = 65,                                    // 1 '}'
		@Tilde = 66,                                     // 1 '~'
		@AcceptProc = 67,                                // 0 <AcceptProc>
		@AddExpression = 68,                             // 0 <AddExpression>
		@AndOperator = 69,                               // 0 <AndOperator>
		@ArgumentList = 70,                              // 0 <Argument List>
		@Arguments = 71,                                 // 0 <Arguments>
		@Assignment = 72,                                // 0 <Assignment>
		@BaseClass = 73,                                 // 0 <Base Class>
		@Block = 74,                                     // 0 <Block>
		@BlockorEnd = 75,                                // 0 <Block or End>
		@BreakControl = 76,                              // 0 <BreakControl>
		@CallExpression = 77,                            // 0 <Call Expression>
		@CallInternal = 78,                              // 0 <CallInternal>
		@ContinueControl = 79,                           // 0 <ContinueControl>
		@Declare = 80,                                   // 0 <Declare>
		@Decrement = 81,                                 // 0 <Decrement>
		@DivideExpression = 82,                          // 0 <DivideExpression>
		@DoUntilControl = 83,                            // 0 <DoUntilControl>
		@DoWhileControl = 84,                            // 0 <DoWhileControl>
		@End = 85,                                       // 0 <End>
		@EndOpt = 86,                                    // 0 <End Opt>
		@EqualOperator = 87,                             // 0 <EqualOperator>
		@Expression = 88,                                // 0 <Expression>
		@FlowControl = 89,                               // 0 <FlowControl>
		@ForControl = 90,                                // 0 <ForControl>
		@FormalParameterList = 91,                       // 0 <Formal Parameter List>
		@ForStepControl = 92,                            // 0 <ForStepControl>
		@FunctionDeclaration = 93,                       // 0 <Function Declaration>
		@FunctionExpression = 94,                        // 0 <Function Expression>
		@GteOperator = 95,                               // 0 <GteOperator>
		@GtOperator = 96,                                // 0 <GtOperator>
		@IfControl = 97,                                 // 0 <IfControl>
		@IncludeProc = 98,                               // 0 <IncludeProc>
		@Increment = 99,                                 // 0 <Increment>
		@ListObjects = 100,                              // 0 <ListObjects>
		@ListVars = 101,                                 // 0 <ListVars>
		@LoopUntilControl = 102,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 103,                         // 0 <LoopWhileControl>
		@LteOperator = 104,                              // 0 <LteOperator>
		@LtOperator = 105,                               // 0 <LtOperator>
		@MultiplyExpression = 106,                       // 0 <MultiplyExpression>
		@NewExpression = 107,                            // 0 <New Expression>
		@NotEqualOperator = 108,                         // 0 <NotEqualOperator>
		@ObjectDecl = 109,                               // 0 <Object Decl>
		@ObjectDecls = 110,                              // 0 <Object Decls>
		@OrOperator = 111,                               // 0 <OrOperator>
		@PrintProc = 112,                                // 0 <PrintProc>
		@Procedure = 113,                                // 0 <Procedure>
		@Program = 114,                                  // 0 <Program>
		@RejectProc = 115,                               // 0 <RejectProc>
		@ReturnProc = 116,                               // 0 <ReturnProc>
		@ScopeProc = 117,                                // 0 <ScopeProc>
		@Statement = 118,                                // 0 <Statement>
		@StatementorBlock = 119,                         // 0 <Statement or Block>
		@Statements = 120,                               // 0 <Statements>
		@SubExpression = 121,                            // 0 <SubExpression>
		@UnaryOperator = 122,                            // 0 <UnaryOperator>
		@UnsetProc = 123,                                // 0 <UnsetProc>
		@Value = 124,                                    // 0 <Value>
		@Variable = 125,                                 // 0 <Variable>
		@Variables = 126                                 // 0 <Variables>
	}
}
