
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
		@UNSET = 58,                                     // 1 UNSET
		@UNTIL = 59,                                     // 1 UNTIL
		@use = 60,                                       // 1 use
		@VAR = 61,                                       // 1 VAR
		@VARS = 62,                                      // 1 VARS
		@WHILE = 63,                                     // 1 WHILE
		@LBracket = 64,                                  // 1 '['
		@RBracket = 65,                                  // 1 ']'
		@LBrace = 66,                                    // 1 '{'
		@PipePipe = 67,                                  // 1 '||'
		@RBrace = 68,                                    // 1 '}'
		@Tilde = 69,                                     // 1 '~'
		@AddExpression = 70,                             // 0 <AddExpression>
		@AndOperator = 71,                               // 0 <AndOperator>
		@ArgumentArray = 72,                             // 0 <Argument Array>
		@ArgumentList = 73,                              // 0 <Argument List>
		@ArrayLiteral = 74,                              // 0 <Array Literal>
		@ArrayLiteralList = 75,                          // 0 <Array Literal List>
		@Assignment = 76,                                // 0 <Assignment>
		@BaseClassID = 77,                               // 0 <BaseClass ID>
		@BitInvertOperator = 78,                         // 0 <BitInvertOperator>
		@Block = 79,                                     // 0 <Block>
		@BlockorEnd = 80,                                // 0 <Block or End>
		@BooleanChain = 81,                              // 0 <BooleanChain>
		@BreakControl = 82,                              // 0 <BreakControl>
		@CallExpression = 83,                            // 0 <Call Expression>
		@ClassNameID = 84,                               // 0 <ClassName ID>
		@ClassNameList = 85,                             // 0 <ClassName List>
		@ContainsTerm = 86,                              // 0 <ContainsTerm>
		@ContinueControl = 87,                           // 0 <ContinueControl>
		@Declare = 88,                                   // 0 <Declare>
		@Decrement = 89,                                 // 0 <Decrement>
		@DivideExpression = 90,                          // 0 <DivideExpression>
		@DoUntilControl = 91,                            // 0 <DoUntilControl>
		@DoWhileControl = 92,                            // 0 <DoWhileControl>
		@End = 93,                                       // 0 <End>
		@EndOpt = 94,                                    // 0 <End Opt>
		@EqualOperator = 95,                             // 0 <EqualOperator>
		@Expression = 96,                                // 0 <Expression>
		@FlowControl = 97,                               // 0 <FlowControl>
		@ForControl = 98,                                // 0 <ForControl>
		@ForStepControl = 99,                            // 0 <ForStepControl>
		@FunctionBlock = 100,                            // 0 <Function Block>
		@FunctionDecl = 101,                             // 0 <Function Decl>
		@FunctionExpression = 102,                       // 0 <Function Expression>
		@Generic0Args = 103,                             // 0 <Generic0Args>
		@Generic1Args = 104,                             // 0 <Generic1Args>
		@GenericNArgs = 105,                             // 0 <GenericNArgs>
		@GteOperator = 106,                              // 0 <GteOperator>
		@GtOperator = 107,                               // 0 <GtOperator>
		@IfControl = 108,                                // 0 <IfControl>
		@ImportDecl = 109,                               // 0 <Import Decl>
		@ImportDecls = 110,                              // 0 <Import Decls>
		@Increment = 111,                                // 0 <Increment>
		@ListVars = 112,                                 // 0 <ListVars>
		@LoopUntilControl = 113,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 114,                         // 0 <LoopWhileControl>
		@LteOperator = 115,                              // 0 <LteOperator>
		@LtOperator = 116,                               // 0 <LtOperator>
		@MathChain = 117,                                // 0 <MathChain>
		@MemberID = 118,                                 // 0 <Member ID>
		@MultiplyExpression = 119,                       // 0 <MultiplyExpression>
		@NameSpace = 120,                                // 0 <NameSpace>
		@NegOperator = 121,                              // 0 <NegOperator>
		@NewExpression = 122,                            // 0 <New Expression>
		@NotEqualOperator = 123,                         // 0 <NotEqualOperator>
		@NotOperator = 124,                              // 0 <NotOperator>
		@ObjectBlock = 125,                              // 0 <Object Block>
		@ObjectDecl = 126,                               // 0 <Object Decl>
		@ObjectDecls = 127,                              // 0 <Object Decls>
		@OrOperator = 128,                               // 0 <OrOperator>
		@ParameterArray = 129,                           // 0 <Parameter Array>
		@ParameterList = 130,                            // 0 <Parameter List>
		@ParameterName = 131,                            // 0 <Parameter Name>
		@PlusOperator = 132,                             // 0 <PlusOperator>
		@PostDecOperator = 133,                          // 0 <PostDecOperator>
		@PostIncOperator = 134,                          // 0 <PostIncOperator>
		@PreDecOperator = 135,                           // 0 <PreDecOperator>
		@PreIncOperator = 136,                           // 0 <PreIncOperator>
		@Procedure = 137,                                // 0 <Procedure>
		@Program = 138,                                  // 0 <Program>
		@ProgramCode = 139,                              // 0 <Program Code>
		@ProgramTest = 140,                              // 0 <Program Test>
		@QualifiedID = 141,                              // 0 <Qualified ID>
		@QualifiedList = 142,                            // 0 <Qualified List>
		@RemainderExpression = 143,                      // 0 <RemainderExpression>
		@ReturnProc = 144,                               // 0 <ReturnProc>
		@SearchChain = 145,                              // 0 <SearchChain>
		@Statement = 146,                                // 0 <Statement>
		@StatementorBlock = 147,                         // 0 <Statement or Block>
		@Statements = 148,                               // 0 <Statements>
		@SubExpression = 149,                            // 0 <SubExpression>
		@TestBlock = 150,                                // 0 <Test Block>
		@TestDecl = 151,                                 // 0 <Test Decl>
		@TestDecls = 152,                                // 0 <Test Decls>
		@TestExecute = 153,                              // 0 <Test Execute>
		@TestSuiteArray = 154,                           // 0 <TestSuite Array>
		@TestSuiteDecl = 155,                            // 0 <TestSuite Decl>
		@UnaryChain = 156,                               // 0 <UnaryChain>
		@UnsetProc = 157,                                // 0 <UnsetProc>
		@ValidID = 158,                                  // 0 <Valid ID>
		@Value = 159,                                    // 0 <Value>
		@VariableStatements = 160                        // 0 <Variable Statements>
	}
}
