
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
		@new = 41,                                       // 1 new
		@NOT = 42,                                       // 1 NOT
		@Number = 43,                                    // 1 Number
		@OBJECTS = 44,                                   // 1 OBJECTS
		@OR = 45,                                        // 1 OR
		@PRINT = 46,                                     // 1 PRINT
		@RegExp = 47,                                    // 1 RegExp
		@REJECT = 48,                                    // 1 REJECT
		@RETURN = 49,                                    // 1 RETURN
		@SCOPE = 50,                                     // 1 SCOPE
		@STEP = 51,                                      // 1 STEP
		@StringDouble = 52,                              // 1 StringDouble
		@StringSingle = 53,                              // 1 StringSingle
		@this = 54,                                      // 1 this
		@TO = 55,                                        // 1 TO
		@Type = 56,                                      // 1 Type
		@UNSET = 57,                                     // 1 UNSET
		@UNTIL = 58,                                     // 1 UNTIL
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
		@BaseClass = 72,                                 // 0 <Base Class>
		@Block = 73,                                     // 0 <Block>
		@BlockorEnd = 74,                                // 0 <Block or End>
		@BreakControl = 75,                              // 0 <BreakControl>
		@CallExpression = 76,                            // 0 <Call Expression>
		@CallInternal = 77,                              // 0 <CallInternal>
		@ContinueControl = 78,                           // 0 <ContinueControl>
		@Declare = 79,                                   // 0 <Declare>
		@Decrement = 80,                                 // 0 <Decrement>
		@DivideExpression = 81,                          // 0 <DivideExpression>
		@DoUntilControl = 82,                            // 0 <DoUntilControl>
		@DoWhileControl = 83,                            // 0 <DoWhileControl>
		@End = 84,                                       // 0 <End>
		@EndOpt = 85,                                    // 0 <End Opt>
		@EqualOperator = 86,                             // 0 <EqualOperator>
		@Expression = 87,                                // 0 <Expression>
		@FlowControl = 88,                               // 0 <FlowControl>
		@ForControl = 89,                                // 0 <ForControl>
		@FormalParameterList = 90,                       // 0 <Formal Parameter List>
		@ForStepControl = 91,                            // 0 <ForStepControl>
		@FunctionDeclaration = 92,                       // 0 <Function Declaration>
		@FunctionExpression = 93,                        // 0 <Function Expression>
		@GteOperator = 94,                               // 0 <GteOperator>
		@GtOperator = 95,                                // 0 <GtOperator>
		@IfControl = 96,                                 // 0 <IfControl>
		@IncludeProc = 97,                               // 0 <IncludeProc>
		@Increment = 98,                                 // 0 <Increment>
		@ListObjects = 99,                               // 0 <ListObjects>
		@ListVars = 100,                                 // 0 <ListVars>
		@LoopUntilControl = 101,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 102,                         // 0 <LoopWhileControl>
		@LteOperator = 103,                              // 0 <LteOperator>
		@LtOperator = 104,                               // 0 <LtOperator>
		@MultiplyExpression = 105,                       // 0 <MultiplyExpression>
		@NewExpression = 106,                            // 0 <New Expression>
		@NotEqualOperator = 107,                         // 0 <NotEqualOperator>
		@ObjectDecl = 108,                               // 0 <Object Decl>
		@ObjectDecls = 109,                              // 0 <Object Decls>
		@OrOperator = 110,                               // 0 <OrOperator>
		@PrintProc = 111,                                // 0 <PrintProc>
		@Procedure = 112,                                // 0 <Procedure>
		@Program = 113,                                  // 0 <Program>
		@RejectProc = 114,                               // 0 <RejectProc>
		@ReturnProc = 115,                               // 0 <ReturnProc>
		@ScopeProc = 116,                                // 0 <ScopeProc>
		@Statement = 117,                                // 0 <Statement>
		@StatementorBlock = 118,                         // 0 <Statement or Block>
		@Statements = 119,                               // 0 <Statements>
		@SubExpression = 120,                            // 0 <SubExpression>
		@UnaryOperator = 121,                            // 0 <UnaryOperator>
		@UnsetProc = 122,                                // 0 <UnsetProc>
		@Value = 123,                                    // 0 <Value>
		@Variable = 124,                                 // 0 <Variable>
		@Variables = 125                                 // 0 <Variables>
	}
}
