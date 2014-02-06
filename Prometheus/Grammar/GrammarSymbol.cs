
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
		@base = 30,                                      // 1 base
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
		@MemberName = 42,                                // 1 MemberName
		@new = 43,                                       // 1 new
		@NOT = 44,                                       // 1 NOT
		@Number = 45,                                    // 1 Number
		@OBJECTS = 46,                                   // 1 OBJECTS
		@OR = 47,                                        // 1 OR
		@PRINT = 48,                                     // 1 PRINT
		@RegExp = 49,                                    // 1 RegExp
		@REJECT = 50,                                    // 1 REJECT
		@RETURN = 51,                                    // 1 RETURN
		@SCOPE = 52,                                     // 1 SCOPE
		@STEP = 53,                                      // 1 STEP
		@StringDouble = 54,                              // 1 StringDouble
		@StringSingle = 55,                              // 1 StringSingle
		@this = 56,                                      // 1 this
		@TO = 57,                                        // 1 TO
		@Type = 58,                                      // 1 Type
		@UNSET = 59,                                     // 1 UNSET
		@UNTIL = 60,                                     // 1 UNTIL
		@VAR = 61,                                       // 1 VAR
		@VARS = 62,                                      // 1 VARS
		@WHILE = 63,                                     // 1 WHILE
		@LBrace = 64,                                    // 1 '{'
		@PipePipe = 65,                                  // 1 '||'
		@RBrace = 66,                                    // 1 '}'
		@Tilde = 67,                                     // 1 '~'
		@AcceptProc = 68,                                // 0 <AcceptProc>
		@AddExpression = 69,                             // 0 <AddExpression>
		@AndOperator = 70,                               // 0 <AndOperator>
		@ArgumentList = 71,                              // 0 <Argument List>
		@Arguments = 72,                                 // 0 <Arguments>
		@Assignment = 73,                                // 0 <Assignment>
		@BaseClass = 74,                                 // 0 <Base Class>
		@Block = 75,                                     // 0 <Block>
		@BlockorEnd = 76,                                // 0 <Block or End>
		@BreakControl = 77,                              // 0 <BreakControl>
		@CallExpression = 78,                            // 0 <Call Expression>
		@CallInternal = 79,                              // 0 <CallInternal>
		@ContinueControl = 80,                           // 0 <ContinueControl>
		@Declare = 81,                                   // 0 <Declare>
		@Decrement = 82,                                 // 0 <Decrement>
		@DivideExpression = 83,                          // 0 <DivideExpression>
		@DoUntilControl = 84,                            // 0 <DoUntilControl>
		@DoWhileControl = 85,                            // 0 <DoWhileControl>
		@End = 86,                                       // 0 <End>
		@EndOpt = 87,                                    // 0 <End Opt>
		@EqualOperator = 88,                             // 0 <EqualOperator>
		@Expression = 89,                                // 0 <Expression>
		@FlowControl = 90,                               // 0 <FlowControl>
		@ForControl = 91,                                // 0 <ForControl>
		@FormalParameterList = 92,                       // 0 <Formal Parameter List>
		@ForStepControl = 93,                            // 0 <ForStepControl>
		@FunctionDeclaration = 94,                       // 0 <Function Declaration>
		@FunctionExpression = 95,                        // 0 <Function Expression>
		@GteOperator = 96,                               // 0 <GteOperator>
		@GtOperator = 97,                                // 0 <GtOperator>
		@IfControl = 98,                                 // 0 <IfControl>
		@IncludeProc = 99,                               // 0 <IncludeProc>
		@Increment = 100,                                // 0 <Increment>
		@ListObjects = 101,                              // 0 <ListObjects>
		@ListVars = 102,                                 // 0 <ListVars>
		@LoopUntilControl = 103,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 104,                         // 0 <LoopWhileControl>
		@LteOperator = 105,                              // 0 <LteOperator>
		@LtOperator = 106,                               // 0 <LtOperator>
		@MemberList = 107,                               // 0 <Member List>
		@MultiplyExpression = 108,                       // 0 <MultiplyExpression>
		@NewExpression = 109,                            // 0 <New Expression>
		@NotEqualOperator = 110,                         // 0 <NotEqualOperator>
		@ObjectDecl = 111,                               // 0 <Object Decl>
		@ObjectDecls = 112,                              // 0 <Object Decls>
		@OrOperator = 113,                               // 0 <OrOperator>
		@PrintProc = 114,                                // 0 <PrintProc>
		@Procedure = 115,                                // 0 <Procedure>
		@Program = 116,                                  // 0 <Program>
		@QualifiedID = 117,                              // 0 <Qualified ID>
		@RejectProc = 118,                               // 0 <RejectProc>
		@ReturnProc = 119,                               // 0 <ReturnProc>
		@ScopeProc = 120,                                // 0 <ScopeProc>
		@Statement = 121,                                // 0 <Statement>
		@StatementorBlock = 122,                         // 0 <Statement or Block>
		@Statements = 123,                               // 0 <Statements>
		@SubExpression = 124,                            // 0 <SubExpression>
		@UnaryOperator = 125,                            // 0 <UnaryOperator>
		@UnsetProc = 126,                                // 0 <UnsetProc>
		@ValidID = 127,                                  // 0 <Valid ID>
		@Value = 128,                                    // 0 <Value>
		@VariableStatements = 129                        // 0 <Variable Statements>
	}
}
