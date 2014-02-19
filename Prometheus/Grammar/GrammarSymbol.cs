
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
		@ACCEPT = 30,                                    // 1 ACCEPT
		@AND = 31,                                       // 1 AND
		@ASSERT = 32,                                    // 1 ASSERT
		@Boolean = 33,                                   // 1 Boolean
		@BREAK = 34,                                     // 1 BREAK
		@CONTAINS = 35,                                  // 1 CONTAINS
		@CONTINUE = 36,                                  // 1 CONTINUE
		@Decimal = 37,                                   // 1 Decimal
		@DO = 38,                                        // 1 DO
		@ELSE = 39,                                      // 1 ELSE
		@FOR = 40,                                       // 1 FOR
		@function = 41,                                  // 1 function
		@HAS = 42,                                       // 1 HAS
		@Identifier = 43,                                // 1 Identifier
		@IF = 44,                                        // 1 IF
		@INCLUDE = 45,                                   // 1 INCLUDE
		@MemberName = 46,                                // 1 MemberName
		@new = 47,                                       // 1 new
		@NOT = 48,                                       // 1 NOT
		@Number = 49,                                    // 1 Number
		@object = 50,                                    // 1 object
		@OR = 51,                                        // 1 OR
		@PRINT = 52,                                     // 1 PRINT
		@RegExpPipe = 53,                                // 1 RegExpPipe
		@RegExpSlash = 54,                               // 1 RegExpSlash
		@REJECT = 55,                                    // 1 REJECT
		@RETURN = 56,                                    // 1 RETURN
		@SCOPE = 57,                                     // 1 SCOPE
		@STEP = 58,                                      // 1 STEP
		@StringDouble = 59,                              // 1 StringDouble
		@StringSingle = 60,                              // 1 StringSingle
		@test = 61,                                      // 1 test
		@tests = 62,                                     // 1 tests
		@TO = 63,                                        // 1 TO
		@UNSET = 64,                                     // 1 UNSET
		@UNTIL = 65,                                     // 1 UNTIL
		@use = 66,                                       // 1 use
		@VAR = 67,                                       // 1 VAR
		@VARS = 68,                                      // 1 VARS
		@WHILE = 69,                                     // 1 WHILE
		@LBracket = 70,                                  // 1 '['
		@RBracket = 71,                                  // 1 ']'
		@LBrace = 72,                                    // 1 '{'
		@PipePipe = 73,                                  // 1 '||'
		@RBrace = 74,                                    // 1 '}'
		@Tilde = 75,                                     // 1 '~'
		@AcceptProc = 76,                                // 0 <AcceptProc>
		@AddExpression = 77,                             // 0 <AddExpression>
		@AndOperator = 78,                               // 0 <AndOperator>
		@ArgumentArray = 79,                             // 0 <Argument Array>
		@ArgumentList = 80,                              // 0 <Argument List>
		@ArrayLiteral = 81,                              // 0 <Array Literal>
		@ArrayLiteralList = 82,                          // 0 <Array Literal List>
		@AssertProc = 83,                                // 0 <AssertProc>
		@Assignment = 84,                                // 0 <Assignment>
		@BaseClassID = 85,                               // 0 <BaseClass ID>
		@BitInvertOperator = 86,                         // 0 <BitInvertOperator>
		@Block = 87,                                     // 0 <Block>
		@BlockorEnd = 88,                                // 0 <Block or End>
		@BooleanChain = 89,                              // 0 <BooleanChain>
		@BreakControl = 90,                              // 0 <BreakControl>
		@CallExpression = 91,                            // 0 <Call Expression>
		@CallInternal = 92,                              // 0 <CallInternal>
		@ClassNameID = 93,                               // 0 <ClassName ID>
		@ClassNameList = 94,                             // 0 <ClassName List>
		@ContainsTerm = 95,                              // 0 <ContainsTerm>
		@ContinueControl = 96,                           // 0 <ContinueControl>
		@Declare = 97,                                   // 0 <Declare>
		@Decrement = 98,                                 // 0 <Decrement>
		@DivideExpression = 99,                          // 0 <DivideExpression>
		@DoUntilControl = 100,                           // 0 <DoUntilControl>
		@DoWhileControl = 101,                           // 0 <DoWhileControl>
		@End = 102,                                      // 0 <End>
		@EndOpt = 103,                                   // 0 <End Opt>
		@EqualOperator = 104,                            // 0 <EqualOperator>
		@Expression = 105,                               // 0 <Expression>
		@FlowControl = 106,                              // 0 <FlowControl>
		@ForControl = 107,                               // 0 <ForControl>
		@ForStepControl = 108,                           // 0 <ForStepControl>
		@FunctionBlock = 109,                            // 0 <Function Block>
		@FunctionDecl = 110,                             // 0 <Function Decl>
		@FunctionExpression = 111,                       // 0 <Function Expression>
		@GteOperator = 112,                              // 0 <GteOperator>
		@GtOperator = 113,                               // 0 <GtOperator>
		@IfControl = 114,                                // 0 <IfControl>
		@ImportDecl = 115,                               // 0 <Import Decl>
		@ImportDecls = 116,                              // 0 <Import Decls>
		@IncludeProc = 117,                              // 0 <IncludeProc>
		@Increment = 118,                                // 0 <Increment>
		@ListVars = 119,                                 // 0 <ListVars>
		@LoopUntilControl = 120,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 121,                         // 0 <LoopWhileControl>
		@LteOperator = 122,                              // 0 <LteOperator>
		@LtOperator = 123,                               // 0 <LtOperator>
		@MathChain = 124,                                // 0 <MathChain>
		@MemberID = 125,                                 // 0 <Member ID>
		@MultiplyExpression = 126,                       // 0 <MultiplyExpression>
		@NameSpace = 127,                                // 0 <NameSpace>
		@NegOperator = 128,                              // 0 <NegOperator>
		@NewExpression = 129,                            // 0 <New Expression>
		@NotEqualOperator = 130,                         // 0 <NotEqualOperator>
		@NotOperator = 131,                              // 0 <NotOperator>
		@ObjectBlock = 132,                              // 0 <Object Block>
		@ObjectDecl = 133,                               // 0 <Object Decl>
		@ObjectDecls = 134,                              // 0 <Object Decls>
		@OrOperator = 135,                               // 0 <OrOperator>
		@ParameterArray = 136,                           // 0 <Parameter Array>
		@ParameterList = 137,                            // 0 <Parameter List>
		@ParameterName = 138,                            // 0 <Parameter Name>
		@PlusOperator = 139,                             // 0 <PlusOperator>
		@PostDecOperator = 140,                          // 0 <PostDecOperator>
		@PostIncOperator = 141,                          // 0 <PostIncOperator>
		@PreDecOperator = 142,                           // 0 <PreDecOperator>
		@PreIncOperator = 143,                           // 0 <PreIncOperator>
		@PrintProc = 144,                                // 0 <PrintProc>
		@Procedure = 145,                                // 0 <Procedure>
		@Program = 146,                                  // 0 <Program>
		@ProgramCode = 147,                              // 0 <Program Code>
		@ProgramTest = 148,                              // 0 <Program Test>
		@QualifiedID = 149,                              // 0 <Qualified ID>
		@QualifiedList = 150,                            // 0 <Qualified List>
		@RejectProc = 151,                               // 0 <RejectProc>
		@RemainderExpression = 152,                      // 0 <RemainderExpression>
		@ReturnProc = 153,                               // 0 <ReturnProc>
		@ScopeProc = 154,                                // 0 <ScopeProc>
		@SearchChain = 155,                              // 0 <SearchChain>
		@Statement = 156,                                // 0 <Statement>
		@StatementorBlock = 157,                         // 0 <Statement or Block>
		@Statements = 158,                               // 0 <Statements>
		@SubExpression = 159,                            // 0 <SubExpression>
		@TestBlock = 160,                                // 0 <Test Block>
		@TestDecl = 161,                                 // 0 <Test Decl>
		@TestDecls = 162,                                // 0 <Test Decls>
		@TestExecute = 163,                              // 0 <Test Execute>
		@TestSuiteArray = 164,                           // 0 <TestSuite Array>
		@TestSuiteDecl = 165,                            // 0 <TestSuite Decl>
		@UnaryChain = 166,                               // 0 <UnaryChain>
		@UnsetProc = 167,                                // 0 <UnsetProc>
		@ValidID = 168,                                  // 0 <Valid ID>
		@Value = 169,                                    // 0 <Value>
		@VariableStatements = 170                        // 0 <Variable Statements>
	}
}
