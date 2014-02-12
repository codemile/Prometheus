
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
		@ColonColon = 20,                                // 1 '::'
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
		@MemberName = 42,                                // 1 MemberName
		@new = 43,                                       // 1 new
		@NOT = 44,                                       // 1 NOT
		@Number = 45,                                    // 1 Number
		@object = 46,                                    // 1 object
		@OBJECTS = 47,                                   // 1 OBJECTS
		@OR = 48,                                        // 1 OR
		@PRINT = 49,                                     // 1 PRINT
		@RegExp = 50,                                    // 1 RegExp
		@REJECT = 51,                                    // 1 REJECT
		@RETURN = 52,                                    // 1 RETURN
		@SCOPE = 53,                                     // 1 SCOPE
		@STEP = 54,                                      // 1 STEP
		@StringDouble = 55,                              // 1 StringDouble
		@StringSingle = 56,                              // 1 StringSingle
		@TO = 57,                                        // 1 TO
		@UNSET = 58,                                     // 1 UNSET
		@UNTIL = 59,                                     // 1 UNTIL
		@VAR = 60,                                       // 1 VAR
		@VARS = 61,                                      // 1 VARS
		@WHILE = 62,                                     // 1 WHILE
		@LBracket = 63,                                  // 1 '['
		@RBracket = 64,                                  // 1 ']'
		@LBrace = 65,                                    // 1 '{'
		@PipePipe = 66,                                  // 1 '||'
		@RBrace = 67,                                    // 1 '}'
		@Tilde = 68,                                     // 1 '~'
		@AcceptProc = 69,                                // 0 <AcceptProc>
		@AddExpression = 70,                             // 0 <AddExpression>
		@AndOperator = 71,                               // 0 <AndOperator>
		@ArgumentList = 72,                              // 0 <Argument List>
		@Arguments = 73,                                 // 0 <Arguments>
		@ArrayList = 74,                                 // 0 <Array List>
		@ArrayLiteral = 75,                              // 0 <Array Literal>
		@Assignment = 76,                                // 0 <Assignment>
		@BaseClassID = 77,                               // 0 <BaseClass ID>
		@Block = 78,                                     // 0 <Block>
		@BlockorEnd = 79,                                // 0 <Block or End>
		@BreakControl = 80,                              // 0 <BreakControl>
		@CallExpression = 81,                            // 0 <Call Expression>
		@CallInternal = 82,                              // 0 <CallInternal>
		@ClassNameID = 83,                               // 0 <ClassName ID>
		@ConstructParamsList = 84,                       // 0 <ConstructParams List>
		@ContinueControl = 85,                           // 0 <ContinueControl>
		@Declare = 86,                                   // 0 <Declare>
		@Decrement = 87,                                 // 0 <Decrement>
		@DivideExpression = 88,                          // 0 <DivideExpression>
		@DoUntilControl = 89,                            // 0 <DoUntilControl>
		@DoWhileControl = 90,                            // 0 <DoWhileControl>
		@End = 91,                                       // 0 <End>
		@EndOpt = 92,                                    // 0 <End Opt>
		@EqualOperator = 93,                             // 0 <EqualOperator>
		@Expression = 94,                                // 0 <Expression>
		@FlowControl = 95,                               // 0 <FlowControl>
		@ForControl = 96,                                // 0 <ForControl>
		@FormalParameterList = 97,                       // 0 <Formal Parameter List>
		@FormalParameters = 98,                          // 0 <Formal Parameters>
		@ForStepControl = 99,                            // 0 <ForStepControl>
		@FunctionExpression = 100,                       // 0 <Function Expression>
		@GteOperator = 101,                              // 0 <GteOperator>
		@GtOperator = 102,                               // 0 <GtOperator>
		@IfControl = 103,                                // 0 <IfControl>
		@IncludeProc = 104,                              // 0 <IncludeProc>
		@Increment = 105,                                // 0 <Increment>
		@ListObjects = 106,                              // 0 <ListObjects>
		@ListVars = 107,                                 // 0 <ListVars>
		@LoopUntilControl = 108,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 109,                         // 0 <LoopWhileControl>
		@LteOperator = 110,                              // 0 <LteOperator>
		@LtOperator = 111,                               // 0 <LtOperator>
		@MemberList = 112,                               // 0 <Member List>
		@MultiplyExpression = 113,                       // 0 <MultiplyExpression>
		@NewExpression = 114,                            // 0 <New Expression>
		@NotEqualOperator = 115,                         // 0 <NotEqualOperator>
		@ObjectDecl = 116,                               // 0 <Object Decl>
		@ObjectDecls = 117,                              // 0 <Object Decls>
		@OrOperator = 118,                               // 0 <OrOperator>
		@PrintProc = 119,                                // 0 <PrintProc>
		@Procedure = 120,                                // 0 <Procedure>
		@Program = 121,                                  // 0 <Program>
		@QualifiedID = 122,                              // 0 <Qualified ID>
		@RejectProc = 123,                               // 0 <RejectProc>
		@ReturnProc = 124,                               // 0 <ReturnProc>
		@ScopeProc = 125,                                // 0 <ScopeProc>
		@Statement = 126,                                // 0 <Statement>
		@StatementorBlock = 127,                         // 0 <Statement or Block>
		@Statements = 128,                               // 0 <Statements>
		@SubExpression = 129,                            // 0 <SubExpression>
		@UnaryOperator = 130,                            // 0 <UnaryOperator>
		@UnsetProc = 131,                                // 0 <UnsetProc>
		@ValidID = 132,                                  // 0 <Valid ID>
		@Value = 133,                                    // 0 <Value>
		@VariableStatements = 134                        // 0 <Variable Statements>
	}
}
