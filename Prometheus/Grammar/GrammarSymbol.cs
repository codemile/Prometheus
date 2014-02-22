
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
		@FAIL = 39,                                      // 1 FAIL
		@FOR = 40,                                       // 1 FOR
		@function = 41,                                  // 1 function
		@HAS = 42,                                       // 1 HAS
		@Identifier = 43,                                // 1 Identifier
		@IF = 44,                                        // 1 IF
		@MemberName = 45,                                // 1 MemberName
		@new = 46,                                       // 1 new
		@NOT = 47,                                       // 1 NOT
		@Number = 48,                                    // 1 Number
		@object = 49,                                    // 1 object
		@OR = 50,                                        // 1 OR
		@PRINT = 51,                                     // 1 PRINT
		@RegExpPipe = 52,                                // 1 RegExpPipe
		@RegExpSlash = 53,                               // 1 RegExpSlash
		@RETURN = 54,                                    // 1 RETURN
		@STEP = 55,                                      // 1 STEP
		@StringDouble = 56,                              // 1 StringDouble
		@StringSingle = 57,                              // 1 StringSingle
		@test = 58,                                      // 1 test
		@tests = 59,                                     // 1 tests
		@TO = 60,                                        // 1 TO
		@Undefined = 61,                                 // 1 Undefined
		@UNSET = 62,                                     // 1 UNSET
		@UNTIL = 63,                                     // 1 UNTIL
		@use = 64,                                       // 1 use
		@VAR = 65,                                       // 1 VAR
		@VARS = 66,                                      // 1 VARS
		@WHILE = 67,                                     // 1 WHILE
		@LBracket = 68,                                  // 1 '['
		@RBracket = 69,                                  // 1 ']'
		@LBrace = 70,                                    // 1 '{'
		@PipePipe = 71,                                  // 1 '||'
		@RBrace = 72,                                    // 1 '}'
		@Tilde = 73,                                     // 1 '~'
		@AddExpression = 74,                             // 0 <AddExpression>
		@AndOperator = 75,                               // 0 <AndOperator>
		@ArgumentArray = 76,                             // 0 <Argument Array>
		@ArgumentList = 77,                              // 0 <Argument List>
		@ArrayLiteral = 78,                              // 0 <Array Literal>
		@ArrayLiteralList = 79,                          // 0 <Array Literal List>
		@AssertProc = 80,                                // 0 <AssertProc>
		@Assignment = 81,                                // 0 <Assignment>
		@BaseClassID = 82,                               // 0 <BaseClass ID>
		@BitInvertOperator = 83,                         // 0 <BitInvertOperator>
		@Block = 84,                                     // 0 <Block>
		@BlockorEnd = 85,                                // 0 <Block or End>
		@BooleanChain = 86,                              // 0 <BooleanChain>
		@BreakControl = 87,                              // 0 <BreakControl>
		@CallExpression = 88,                            // 0 <Call Expression>
		@CallGeneric = 89,                               // 0 <Call Generic>
		@ClassNameID = 90,                               // 0 <ClassName ID>
		@ClassNameList = 91,                             // 0 <ClassName List>
		@ContainsTerm = 92,                              // 0 <ContainsTerm>
		@ContinueControl = 93,                           // 0 <ContinueControl>
		@Declare = 94,                                   // 0 <Declare>
		@DivideExpression = 95,                          // 0 <DivideExpression>
		@DoUntilControl = 96,                            // 0 <DoUntilControl>
		@DoWhileControl = 97,                            // 0 <DoWhileControl>
		@End = 98,                                       // 0 <End>
		@EndOpt = 99,                                    // 0 <End Opt>
		@EqualOperator = 100,                            // 0 <EqualOperator>
		@Expression = 101,                               // 0 <Expression>
		@FailProc = 102,                                 // 0 <FailProc>
		@FlowControl = 103,                              // 0 <FlowControl>
		@ForControl = 104,                               // 0 <ForControl>
		@ForStepControl = 105,                           // 0 <ForStepControl>
		@FunctionBlock = 106,                            // 0 <Function Block>
		@FunctionDecl = 107,                             // 0 <Function Decl>
		@FunctionExpression = 108,                       // 0 <Function Expression>
		@GteOperator = 109,                              // 0 <GteOperator>
		@GtOperator = 110,                               // 0 <GtOperator>
		@IfControl = 111,                                // 0 <IfControl>
		@ImportDecl = 112,                               // 0 <Import Decl>
		@ImportDecls = 113,                              // 0 <Import Decls>
		@ListVars = 114,                                 // 0 <ListVars>
		@LoopUntilControl = 115,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 116,                         // 0 <LoopWhileControl>
		@LteOperator = 117,                              // 0 <LteOperator>
		@LtOperator = 118,                               // 0 <LtOperator>
		@MathChain = 119,                                // 0 <MathChain>
		@MemberID = 120,                                 // 0 <Member ID>
		@MultiplyExpression = 121,                       // 0 <MultiplyExpression>
		@NameSpace = 122,                                // 0 <NameSpace>
		@NegOperator = 123,                              // 0 <NegOperator>
		@NewExpression = 124,                            // 0 <New Expression>
		@NotEqualOperator = 125,                         // 0 <NotEqualOperator>
		@NotOperator = 126,                              // 0 <NotOperator>
		@ObjectBlock = 127,                              // 0 <Object Block>
		@ObjectDecl = 128,                               // 0 <Object Decl>
		@ObjectDecls = 129,                              // 0 <Object Decls>
		@OrOperator = 130,                               // 0 <OrOperator>
		@ParameterArray = 131,                           // 0 <Parameter Array>
		@ParameterList = 132,                            // 0 <Parameter List>
		@ParameterName = 133,                            // 0 <Parameter Name>
		@PlusOperator = 134,                             // 0 <PlusOperator>
		@PostDecOperator = 135,                          // 0 <PostDecOperator>
		@PostDecrement = 136,                            // 0 <PostDecrement>
		@PostIncOperator = 137,                          // 0 <PostIncOperator>
		@PostIncrement = 138,                            // 0 <PostIncrement>
		@PreDecOperator = 139,                           // 0 <PreDecOperator>
		@PreDecrement = 140,                             // 0 <PreDecrement>
		@PreIncOperator = 141,                           // 0 <PreIncOperator>
		@PreIncrement = 142,                             // 0 <PreIncrement>
		@PrintProc = 143,                                // 0 <PrintProc>
		@Procedure = 144,                                // 0 <Procedure>
		@Program = 145,                                  // 0 <Program>
		@ProgramCode = 146,                              // 0 <Program Code>
		@ProgramTest = 147,                              // 0 <Program Test>
		@QualifiedID = 148,                              // 0 <Qualified ID>
		@QualifiedList = 149,                            // 0 <Qualified List>
		@RemainderExpression = 150,                      // 0 <RemainderExpression>
		@ReturnProc = 151,                               // 0 <ReturnProc>
		@SearchChain = 152,                              // 0 <SearchChain>
		@Statement = 153,                                // 0 <Statement>
		@StatementorBlock = 154,                         // 0 <Statement or Block>
		@Statements = 155,                               // 0 <Statements>
		@SubExpression = 156,                            // 0 <SubExpression>
		@TestBlock = 157,                                // 0 <Test Block>
		@TestDecl = 158,                                 // 0 <Test Decl>
		@TestDecls = 159,                                // 0 <Test Decls>
		@TestExecute = 160,                              // 0 <Test Execute>
		@TestSuiteArray = 161,                           // 0 <TestSuite Array>
		@TestSuiteDecl = 162,                            // 0 <TestSuite Decl>
		@UnaryChain = 163,                               // 0 <UnaryChain>
		@UnsetProc = 164,                                // 0 <UnsetProc>
		@ValidID = 165,                                  // 0 <Valid ID>
		@Value = 166,                                    // 0 <Value>
		@VariableStatements = 167                        // 0 <Variable Statements>
	}
}
