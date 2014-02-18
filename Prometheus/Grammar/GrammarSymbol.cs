
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
		@INCLUDE = 44,                                   // 1 INCLUDE
		@MemberName = 45,                                // 1 MemberName
		@new = 46,                                       // 1 new
		@NOT = 47,                                       // 1 NOT
		@Number = 48,                                    // 1 Number
		@object = 49,                                    // 1 object
		@OR = 50,                                        // 1 OR
		@PRINT = 51,                                     // 1 PRINT
		@RegExpPipe = 52,                                // 1 RegExpPipe
		@RegExpSlash = 53,                               // 1 RegExpSlash
		@REJECT = 54,                                    // 1 REJECT
		@RETURN = 55,                                    // 1 RETURN
		@SCOPE = 56,                                     // 1 SCOPE
		@STEP = 57,                                      // 1 STEP
		@StringDouble = 58,                              // 1 StringDouble
		@StringSingle = 59,                              // 1 StringSingle
		@test = 60,                                      // 1 test
		@tests = 61,                                     // 1 tests
		@TO = 62,                                        // 1 TO
		@UNSET = 63,                                     // 1 UNSET
		@UNTIL = 64,                                     // 1 UNTIL
		@use = 65,                                       // 1 use
		@VAR = 66,                                       // 1 VAR
		@VARS = 67,                                      // 1 VARS
		@WHILE = 68,                                     // 1 WHILE
		@LBracket = 69,                                  // 1 '['
		@RBracket = 70,                                  // 1 ']'
		@LBrace = 71,                                    // 1 '{'
		@PipePipe = 72,                                  // 1 '||'
		@RBrace = 73,                                    // 1 '}'
		@Tilde = 74,                                     // 1 '~'
		@AcceptProc = 75,                                // 0 <AcceptProc>
		@AddExpression = 76,                             // 0 <AddExpression>
		@AndOperator = 77,                               // 0 <AndOperator>
		@ArgumentArray = 78,                             // 0 <Argument Array>
		@ArgumentList = 79,                              // 0 <Argument List>
		@ArrayLiteral = 80,                              // 0 <Array Literal>
		@ArrayLiteralList = 81,                          // 0 <Array Literal List>
		@Assignment = 82,                                // 0 <Assignment>
		@BaseClassID = 83,                               // 0 <BaseClass ID>
		@BitInvertOperator = 84,                         // 0 <BitInvertOperator>
		@Block = 85,                                     // 0 <Block>
		@BlockorEnd = 86,                                // 0 <Block or End>
		@BooleanChain = 87,                              // 0 <BooleanChain>
		@BreakControl = 88,                              // 0 <BreakControl>
		@CallExpression = 89,                            // 0 <Call Expression>
		@CallInternal = 90,                              // 0 <CallInternal>
		@ClassNameID = 91,                               // 0 <ClassName ID>
		@ClassNameList = 92,                             // 0 <ClassName List>
		@ContainsTerm = 93,                              // 0 <ContainsTerm>
		@ContinueControl = 94,                           // 0 <ContinueControl>
		@Declare = 95,                                   // 0 <Declare>
		@Decrement = 96,                                 // 0 <Decrement>
		@DivideExpression = 97,                          // 0 <DivideExpression>
		@DoUntilControl = 98,                            // 0 <DoUntilControl>
		@DoWhileControl = 99,                            // 0 <DoWhileControl>
		@End = 100,                                      // 0 <End>
		@EndOpt = 101,                                   // 0 <End Opt>
		@EqualOperator = 102,                            // 0 <EqualOperator>
		@Expression = 103,                               // 0 <Expression>
		@FlowControl = 104,                              // 0 <FlowControl>
		@ForControl = 105,                               // 0 <ForControl>
		@ForStepControl = 106,                           // 0 <ForStepControl>
		@FunctionBlock = 107,                            // 0 <Function Block>
		@FunctionDecl = 108,                             // 0 <Function Decl>
		@FunctionExpression = 109,                       // 0 <Function Expression>
		@GteOperator = 110,                              // 0 <GteOperator>
		@GtOperator = 111,                               // 0 <GtOperator>
		@IfControl = 112,                                // 0 <IfControl>
		@ImportDecl = 113,                               // 0 <Import Decl>
		@ImportDecls = 114,                              // 0 <Import Decls>
		@IncludeProc = 115,                              // 0 <IncludeProc>
		@Increment = 116,                                // 0 <Increment>
		@ListVars = 117,                                 // 0 <ListVars>
		@LoopUntilControl = 118,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 119,                         // 0 <LoopWhileControl>
		@LteOperator = 120,                              // 0 <LteOperator>
		@LtOperator = 121,                               // 0 <LtOperator>
		@MathChain = 122,                                // 0 <MathChain>
		@MemberID = 123,                                 // 0 <Member ID>
		@MultiplyExpression = 124,                       // 0 <MultiplyExpression>
		@NegOperator = 125,                              // 0 <NegOperator>
		@NewExpression = 126,                            // 0 <New Expression>
		@NotEqualOperator = 127,                         // 0 <NotEqualOperator>
		@NotOperator = 128,                              // 0 <NotOperator>
		@ObjectBlock = 129,                              // 0 <Object Block>
		@ObjectDecl = 130,                               // 0 <Object Decl>
		@ObjectDecls = 131,                              // 0 <Object Decls>
		@OrOperator = 132,                               // 0 <OrOperator>
		@ParameterArray = 133,                           // 0 <Parameter Array>
		@ParameterList = 134,                            // 0 <Parameter List>
		@ParameterName = 135,                            // 0 <Parameter Name>
		@PlusOperator = 136,                             // 0 <PlusOperator>
		@PostDecOperator = 137,                          // 0 <PostDecOperator>
		@PostIncOperator = 138,                          // 0 <PostIncOperator>
		@PreDecOperator = 139,                           // 0 <PreDecOperator>
		@PreIncOperator = 140,                           // 0 <PreIncOperator>
		@PrintProc = 141,                                // 0 <PrintProc>
		@Procedure = 142,                                // 0 <Procedure>
		@Program = 143,                                  // 0 <Program>
		@ProgramCode = 144,                              // 0 <Program Code>
		@ProgramTest = 145,                              // 0 <Program Test>
		@QualifiedID = 146,                              // 0 <Qualified ID>
		@QualifiedList = 147,                            // 0 <Qualified List>
		@RejectProc = 148,                               // 0 <RejectProc>
		@RemainderExpression = 149,                      // 0 <RemainderExpression>
		@ReturnProc = 150,                               // 0 <ReturnProc>
		@ScopeProc = 151,                                // 0 <ScopeProc>
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
