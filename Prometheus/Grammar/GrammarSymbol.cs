
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
		@VAR = 65,                                       // 1 VAR
		@VARS = 66,                                      // 1 VARS
		@WHILE = 67,                                     // 1 WHILE
		@LBracket = 68,                                  // 1 '['
		@RBracket = 69,                                  // 1 ']'
		@LBrace = 70,                                    // 1 '{'
		@PipePipe = 71,                                  // 1 '||'
		@RBrace = 72,                                    // 1 '}'
		@Tilde = 73,                                     // 1 '~'
		@AcceptProc = 74,                                // 0 <AcceptProc>
		@AddExpression = 75,                             // 0 <AddExpression>
		@AndOperator = 76,                               // 0 <AndOperator>
		@ArgumentArray = 77,                             // 0 <Argument Array>
		@ArgumentList = 78,                              // 0 <Argument List>
		@ArrayLiteral = 79,                              // 0 <Array Literal>
		@ArrayLiteralList = 80,                          // 0 <Array Literal List>
		@Assignment = 81,                                // 0 <Assignment>
		@BaseClassID = 82,                               // 0 <BaseClass ID>
		@BitInvertOperator = 83,                         // 0 <BitInvertOperator>
		@Block = 84,                                     // 0 <Block>
		@BlockorEnd = 85,                                // 0 <Block or End>
		@BooleanChain = 86,                              // 0 <BooleanChain>
		@BreakControl = 87,                              // 0 <BreakControl>
		@CallExpression = 88,                            // 0 <Call Expression>
		@CallInternal = 89,                              // 0 <CallInternal>
		@ContainsTerm = 90,                              // 0 <ContainsTerm>
		@ContinueControl = 91,                           // 0 <ContinueControl>
		@Declare = 92,                                   // 0 <Declare>
		@Decrement = 93,                                 // 0 <Decrement>
		@DivideExpression = 94,                          // 0 <DivideExpression>
		@DoUntilControl = 95,                            // 0 <DoUntilControl>
		@DoWhileControl = 96,                            // 0 <DoWhileControl>
		@End = 97,                                       // 0 <End>
		@EndOpt = 98,                                    // 0 <End Opt>
		@EqualOperator = 99,                             // 0 <EqualOperator>
		@Expression = 100,                               // 0 <Expression>
		@FlowControl = 101,                              // 0 <FlowControl>
		@ForControl = 102,                               // 0 <ForControl>
		@ForStepControl = 103,                           // 0 <ForStepControl>
		@FunctionBlock = 104,                            // 0 <Function Block>
		@FunctionDecl = 105,                             // 0 <Function Decl>
		@FunctionExpression = 106,                       // 0 <Function Expression>
		@GteOperator = 107,                              // 0 <GteOperator>
		@GtOperator = 108,                               // 0 <GtOperator>
		@IfControl = 109,                                // 0 <IfControl>
		@IncludeProc = 110,                              // 0 <IncludeProc>
		@Increment = 111,                                // 0 <Increment>
		@ListVars = 112,                                 // 0 <ListVars>
		@LoopUntilControl = 113,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 114,                         // 0 <LoopWhileControl>
		@LteOperator = 115,                              // 0 <LteOperator>
		@LtOperator = 116,                               // 0 <LtOperator>
		@MathChain = 117,                                // 0 <MathChain>
		@MemberID = 118,                                 // 0 <Member ID>
		@MemberList = 119,                               // 0 <Member List>
		@MultiplyExpression = 120,                       // 0 <MultiplyExpression>
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
		@PrintProc = 137,                                // 0 <PrintProc>
		@Procedure = 138,                                // 0 <Procedure>
		@Program = 139,                                  // 0 <Program>
		@ProgramCode = 140,                              // 0 <Program Code>
		@ProgramTest = 141,                              // 0 <Program Test>
		@QualifiedID = 142,                              // 0 <Qualified ID>
		@QualifiedList = 143,                            // 0 <Qualified List>
		@RejectProc = 144,                               // 0 <RejectProc>
		@RemainderExpression = 145,                      // 0 <RemainderExpression>
		@ReturnProc = 146,                               // 0 <ReturnProc>
		@ScopeProc = 147,                                // 0 <ScopeProc>
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
