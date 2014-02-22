
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
		@ASSERT = 31,                                    // 1 ASSERT
		@Boolean = 32,                                   // 1 Boolean
		@BREAK = 33,                                     // 1 BREAK
		@CONTAINS = 34,                                  // 1 CONTAINS
		@CONTINUE = 35,                                  // 1 CONTINUE
		@Decimal = 36,                                   // 1 Decimal
		@DO = 37,                                        // 1 DO
		@ELSE = 38,                                      // 1 ELSE
		@FOR = 39,                                       // 1 FOR
		@function = 40,                                  // 1 function
		@HAS = 41,                                       // 1 HAS
		@Identifier = 42,                                // 1 Identifier
		@IF = 43,                                        // 1 IF
		@MemberName = 44,                                // 1 MemberName
		@new = 45,                                       // 1 new
		@NOT = 46,                                       // 1 NOT
		@Number = 47,                                    // 1 Number
		@object = 48,                                    // 1 object
		@OR = 49,                                        // 1 OR
		@RegExpPipe = 50,                                // 1 RegExpPipe
		@RegExpSlash = 51,                               // 1 RegExpSlash
		@RETURN = 52,                                    // 1 RETURN
		@STEP = 53,                                      // 1 STEP
		@StringDouble = 54,                              // 1 StringDouble
		@StringSingle = 55,                              // 1 StringSingle
		@test = 56,                                      // 1 test
		@tests = 57,                                     // 1 tests
		@TO = 58,                                        // 1 TO
		@Undefined = 59,                                 // 1 Undefined
		@UNSET = 60,                                     // 1 UNSET
		@UNTIL = 61,                                     // 1 UNTIL
		@use = 62,                                       // 1 use
		@VAR = 63,                                       // 1 VAR
		@VARS = 64,                                      // 1 VARS
		@WHILE = 65,                                     // 1 WHILE
		@LBracket = 66,                                  // 1 '['
		@RBracket = 67,                                  // 1 ']'
		@LBrace = 68,                                    // 1 '{'
		@PipePipe = 69,                                  // 1 '||'
		@RBrace = 70,                                    // 1 '}'
		@Tilde = 71,                                     // 1 '~'
		@AddExpression = 72,                             // 0 <AddExpression>
		@AndOperator = 73,                               // 0 <AndOperator>
		@ArgumentArray = 74,                             // 0 <Argument Array>
		@ArgumentList = 75,                              // 0 <Argument List>
		@ArrayLiteral = 76,                              // 0 <Array Literal>
		@ArrayLiteralList = 77,                          // 0 <Array Literal List>
		@AssertProc = 78,                                // 0 <AssertProc>
		@Assignment = 79,                                // 0 <Assignment>
		@BaseClassID = 80,                               // 0 <BaseClass ID>
		@BitInvertOperator = 81,                         // 0 <BitInvertOperator>
		@Block = 82,                                     // 0 <Block>
		@BlockorEnd = 83,                                // 0 <Block or End>
		@BooleanChain = 84,                              // 0 <BooleanChain>
		@BreakControl = 85,                              // 0 <BreakControl>
		@CallExpression = 86,                            // 0 <Call Expression>
		@CallGeneric = 87,                               // 0 <Call Generic>
		@ClassNameID = 88,                               // 0 <ClassName ID>
		@ClassNameList = 89,                             // 0 <ClassName List>
		@ContainsTerm = 90,                              // 0 <ContainsTerm>
		@ContinueControl = 91,                           // 0 <ContinueControl>
		@Declare = 92,                                   // 0 <Declare>
		@DivideExpression = 93,                          // 0 <DivideExpression>
		@DoUntilControl = 94,                            // 0 <DoUntilControl>
		@DoWhileControl = 95,                            // 0 <DoWhileControl>
		@End = 96,                                       // 0 <End>
		@EndOpt = 97,                                    // 0 <End Opt>
		@EqualOperator = 98,                             // 0 <EqualOperator>
		@Expression = 99,                                // 0 <Expression>
		@FlowControl = 100,                              // 0 <FlowControl>
		@ForControl = 101,                               // 0 <ForControl>
		@ForStepControl = 102,                           // 0 <ForStepControl>
		@FunctionBlock = 103,                            // 0 <Function Block>
		@FunctionDecl = 104,                             // 0 <Function Decl>
		@FunctionExpression = 105,                       // 0 <Function Expression>
		@GteOperator = 106,                              // 0 <GteOperator>
		@GtOperator = 107,                               // 0 <GtOperator>
		@IfControl = 108,                                // 0 <IfControl>
		@ImportDecl = 109,                               // 0 <Import Decl>
		@ImportDecls = 110,                              // 0 <Import Decls>
		@ListVars = 111,                                 // 0 <ListVars>
		@LoopUntilControl = 112,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 113,                         // 0 <LoopWhileControl>
		@LteOperator = 114,                              // 0 <LteOperator>
		@LtOperator = 115,                               // 0 <LtOperator>
		@MathChain = 116,                                // 0 <MathChain>
		@MemberID = 117,                                 // 0 <Member ID>
		@MultiplyExpression = 118,                       // 0 <MultiplyExpression>
		@NameSpace = 119,                                // 0 <NameSpace>
		@NegOperator = 120,                              // 0 <NegOperator>
		@NewExpression = 121,                            // 0 <New Expression>
		@NotEqualOperator = 122,                         // 0 <NotEqualOperator>
		@NotOperator = 123,                              // 0 <NotOperator>
		@ObjectBlock = 124,                              // 0 <Object Block>
		@ObjectDecl = 125,                               // 0 <Object Decl>
		@ObjectDecls = 126,                              // 0 <Object Decls>
		@OrOperator = 127,                               // 0 <OrOperator>
		@ParameterArray = 128,                           // 0 <Parameter Array>
		@ParameterList = 129,                            // 0 <Parameter List>
		@ParameterName = 130,                            // 0 <Parameter Name>
		@PlusOperator = 131,                             // 0 <PlusOperator>
		@PostDecOperator = 132,                          // 0 <PostDecOperator>
		@PostDecrement = 133,                            // 0 <PostDecrement>
		@PostIncOperator = 134,                          // 0 <PostIncOperator>
		@PostIncrement = 135,                            // 0 <PostIncrement>
		@PreDecOperator = 136,                           // 0 <PreDecOperator>
		@PreDecrement = 137,                             // 0 <PreDecrement>
		@PreIncOperator = 138,                           // 0 <PreIncOperator>
		@PreIncrement = 139,                             // 0 <PreIncrement>
		@Procedure = 140,                                // 0 <Procedure>
		@Program = 141,                                  // 0 <Program>
		@ProgramCode = 142,                              // 0 <Program Code>
		@ProgramTest = 143,                              // 0 <Program Test>
		@QualifiedID = 144,                              // 0 <Qualified ID>
		@QualifiedList = 145,                            // 0 <Qualified List>
		@RemainderExpression = 146,                      // 0 <RemainderExpression>
		@ReturnProc = 147,                               // 0 <ReturnProc>
		@SearchChain = 148,                              // 0 <SearchChain>
		@Statement = 149,                                // 0 <Statement>
		@StatementorBlock = 150,                         // 0 <Statement or Block>
		@Statements = 151,                               // 0 <Statements>
		@SubExpression = 152,                            // 0 <SubExpression>
		@TestBlock = 153,                                // 0 <Test Block>
		@TestDecl = 154,                                 // 0 <Test Decl>
		@TestDecls = 155,                                // 0 <Test Decls>
		@TestExecute = 156,                              // 0 <Test Execute>
		@TestSuiteArray = 157,                           // 0 <TestSuite Array>
		@TestSuiteDecl = 158,                            // 0 <TestSuite Decl>
		@UnaryChain = 159,                               // 0 <UnaryChain>
		@UnsetProc = 160,                                // 0 <UnsetProc>
		@ValidID = 161,                                  // 0 <Valid ID>
		@Value = 162,                                    // 0 <Value>
		@VariableStatements = 163                        // 0 <Variable Statements>
	}
}
