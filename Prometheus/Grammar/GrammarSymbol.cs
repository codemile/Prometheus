
namespace Prometheus.Grammar
{
	// ReSharper disable UnusedMember.Global
	// ReSharper disable CSharpWarnings::CS1591
	// ReSharper disable InconsistentNaming

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
		@Percent = 10,                                   // 1 '%'
		@AmpAmp = 11,                                    // 1 '&&'
		@LParen = 12,                                    // 1 '('
		@RParen = 13,                                    // 1 ')'
		@Times = 14,                                     // 1 '*'
		@Plus = 15,                                      // 1 '+'
		@PlusPlus = 16,                                  // 1 '++'
		@Comma = 17,                                     // 1 ','
		@Minus = 18,                                     // 1 '-'
		@MinusMinus = 19,                                // 1 '--'
		@Div = 20,                                       // 1 '/'
		@ColonColon = 21,                                // 1 '::'
		@Semi = 22,                                      // 1 ';'
		@Lt = 23,                                        // 1 '<'
		@LtEq = 24,                                      // 1 '<='
		@LtGt = 25,                                      // 1 '<>'
		@Eq = 26,                                        // 1 '='
		@EqEq = 27,                                      // 1 '=='
		@Gt = 28,                                        // 1 '>'
		@GtEq = 29,                                      // 1 '>='
		@AND = 30,                                       // 1 AND
		@Boolean = 31,                                   // 1 Boolean
		@BREAK = 32,                                     // 1 BREAK
		@CONTAINS = 33,                                  // 1 CONTAINS
		@CONTINUE = 34,                                  // 1 CONTINUE
		@Decimal = 35,                                   // 1 Decimal
		@DO = 36,                                        // 1 DO
		@ELSE = 37,                                      // 1 ELSE
		@FOR = 38,                                       // 1 FOR
		@function = 39,                                  // 1 function
		@HAS = 40,                                       // 1 HAS
		@Identifier = 41,                                // 1 Identifier
		@IF = 42,                                        // 1 IF
		@MemberName = 43,                                // 1 MemberName
		@new = 44,                                       // 1 new
		@NOT = 45,                                       // 1 NOT
		@Number = 46,                                    // 1 Number
		@object = 47,                                    // 1 object
		@OR = 48,                                        // 1 OR
		@RegExpPipe = 49,                                // 1 RegExpPipe
		@RegExpSlash = 50,                               // 1 RegExpSlash
		@RETURN = 51,                                    // 1 RETURN
		@STEP = 52,                                      // 1 STEP
		@StringDouble = 53,                              // 1 StringDouble
		@StringSingle = 54,                              // 1 StringSingle
		@test = 55,                                      // 1 test
		@tests = 56,                                     // 1 tests
		@TO = 57,                                        // 1 TO
		@Undefined = 58,                                 // 1 Undefined
		@UNSET = 59,                                     // 1 UNSET
		@UNTIL = 60,                                     // 1 UNTIL
		@use = 61,                                       // 1 use
		@VAR = 62,                                       // 1 VAR
		@VARS = 63,                                      // 1 VARS
		@WHILE = 64,                                     // 1 WHILE
		@LBracket = 65,                                  // 1 '['
		@RBracket = 66,                                  // 1 ']'
		@LBrace = 67,                                    // 1 '{'
		@PipePipe = 68,                                  // 1 '||'
		@RBrace = 69,                                    // 1 '}'
		@Tilde = 70,                                     // 1 '~'
		@AddExpression = 71,                             // 0 <AddExpression>
		@AndOperator = 72,                               // 0 <AndOperator>
		@ArgumentArray = 73,                             // 0 <Argument Array>
		@ArgumentList = 74,                              // 0 <Argument List>
		@ArrayLiteral = 75,                              // 0 <Array Literal>
		@ArrayLiteralList = 76,                          // 0 <Array Literal List>
		@Assignment = 77,                                // 0 <Assignment>
		@BaseClassID = 78,                               // 0 <BaseClass ID>
		@BitInvertOperator = 79,                         // 0 <BitInvertOperator>
		@Block = 80,                                     // 0 <Block>
		@BlockorEnd = 81,                                // 0 <Block or End>
		@BooleanChain = 82,                              // 0 <BooleanChain>
		@BreakControl = 83,                              // 0 <BreakControl>
		@CallExpression = 84,                            // 0 <Call Expression>
		@ClassNameID = 85,                               // 0 <ClassName ID>
		@ClassNameList = 86,                             // 0 <ClassName List>
		@ContainsTerm = 87,                              // 0 <ContainsTerm>
		@ContinueControl = 88,                           // 0 <ContinueControl>
		@Declare = 89,                                   // 0 <Declare>
		@Decrement = 90,                                 // 0 <Decrement>
		@DivideExpression = 91,                          // 0 <DivideExpression>
		@DoUntilControl = 92,                            // 0 <DoUntilControl>
		@DoWhileControl = 93,                            // 0 <DoWhileControl>
		@End = 94,                                       // 0 <End>
		@EndOpt = 95,                                    // 0 <End Opt>
		@EqualOperator = 96,                             // 0 <EqualOperator>
		@Expression = 97,                                // 0 <Expression>
		@FlowControl = 98,                               // 0 <FlowControl>
		@ForControl = 99,                                // 0 <ForControl>
		@ForStepControl = 100,                           // 0 <ForStepControl>
		@FunctionBlock = 101,                            // 0 <Function Block>
		@FunctionDecl = 102,                             // 0 <Function Decl>
		@FunctionExpression = 103,                       // 0 <Function Expression>
		@Generic0Args = 104,                             // 0 <Generic0Args>
		@Generic1Args = 105,                             // 0 <Generic1Args>
		@GenericNArgs = 106,                             // 0 <GenericNArgs>
		@GteOperator = 107,                              // 0 <GteOperator>
		@GtOperator = 108,                               // 0 <GtOperator>
		@IfControl = 109,                                // 0 <IfControl>
		@ImportDecl = 110,                               // 0 <Import Decl>
		@ImportDecls = 111,                              // 0 <Import Decls>
		@Increment = 112,                                // 0 <Increment>
		@ListVars = 113,                                 // 0 <ListVars>
		@LoopUntilControl = 114,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 115,                         // 0 <LoopWhileControl>
		@LteOperator = 116,                              // 0 <LteOperator>
		@LtOperator = 117,                               // 0 <LtOperator>
		@MathChain = 118,                                // 0 <MathChain>
		@MemberID = 119,                                 // 0 <Member ID>
		@MultiplyExpression = 120,                       // 0 <MultiplyExpression>
		@NameSpace = 121,                                // 0 <NameSpace>
		@NegOperator = 122,                              // 0 <NegOperator>
		@NewExpression = 123,                            // 0 <New Expression>
		@NotEqualOperator = 124,                         // 0 <NotEqualOperator>
		@NotOperator = 125,                              // 0 <NotOperator>
		@ObjectBlock = 126,                              // 0 <Object Block>
		@ObjectDecl = 127,                               // 0 <Object Decl>
		@ObjectDecls = 128,                              // 0 <Object Decls>
		@OrOperator = 129,                               // 0 <OrOperator>
		@ParameterArray = 130,                           // 0 <Parameter Array>
		@ParameterList = 131,                            // 0 <Parameter List>
		@ParameterName = 132,                            // 0 <Parameter Name>
		@PlusOperator = 133,                             // 0 <PlusOperator>
		@PostDecOperator = 134,                          // 0 <PostDecOperator>
		@PostIncOperator = 135,                          // 0 <PostIncOperator>
		@PreDecOperator = 136,                           // 0 <PreDecOperator>
		@PreIncOperator = 137,                           // 0 <PreIncOperator>
		@Procedure = 138,                                // 0 <Procedure>
		@Program = 139,                                  // 0 <Program>
		@ProgramCode = 140,                              // 0 <Program Code>
		@ProgramTest = 141,                              // 0 <Program Test>
		@QualifiedID = 142,                              // 0 <Qualified ID>
		@QualifiedList = 143,                            // 0 <Qualified List>
		@RemainderExpression = 144,                      // 0 <RemainderExpression>
		@ReturnProc = 145,                               // 0 <ReturnProc>
		@SearchChain = 146,                              // 0 <SearchChain>
		@Statement = 147,                                // 0 <Statement>
		@StatementorBlock = 148,                         // 0 <Statement or Block>
		@Statements = 149,                               // 0 <Statements>
		@SubExpression = 150,                            // 0 <SubExpression>
		@TestBlock = 151,                                // 0 <Test Block>
		@TestDecl = 152,                                 // 0 <Test Decl>
		@TestDecls = 153,                                // 0 <Test Decls>
		@TestExecute = 154,                              // 0 <Test Execute>
		@TestSuiteArray = 155,                           // 0 <TestSuite Array>
		@TestSuiteDecl = 156,                            // 0 <TestSuite Decl>
		@UnaryChain = 157,                               // 0 <UnaryChain>
		@UnsetProc = 158,                                // 0 <UnsetProc>
		@ValidID = 159,                                  // 0 <Valid ID>
		@Value = 160,                                    // 0 <Value>
		@VariableStatements = 161                        // 0 <Variable Statements>
	}
}
