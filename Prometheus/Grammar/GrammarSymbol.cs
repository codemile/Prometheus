
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
		@as = 31,                                        // 1 as
		@assert = 32,                                    // 1 assert
		@Boolean = 33,                                   // 1 Boolean
		@break = 34,                                     // 1 break
		@CONTAINS = 35,                                  // 1 CONTAINS
		@continue = 36,                                  // 1 continue
		@Decimal = 37,                                   // 1 Decimal
		@do = 38,                                        // 1 do
		@each = 39,                                      // 1 each
		@else = 40,                                      // 1 else
		@fail = 41,                                      // 1 fail
		@for = 42,                                       // 1 for
		@function = 43,                                  // 1 function
		@HAS = 44,                                       // 1 HAS
		@Identifier = 45,                                // 1 Identifier
		@if = 46,                                        // 1 if
		@isset = 47,                                     // 1 isset
		@MemberName = 48,                                // 1 MemberName
		@new = 49,                                       // 1 new
		@NOT = 50,                                       // 1 NOT
		@Number = 51,                                    // 1 Number
		@object = 52,                                    // 1 object
		@OR = 53,                                        // 1 OR
		@print = 54,                                     // 1 print
		@RegExpPipe = 55,                                // 1 RegExpPipe
		@RegExpSlash = 56,                               // 1 RegExpSlash
		@return = 57,                                    // 1 return
		@StringDouble = 58,                              // 1 StringDouble
		@StringSingle = 59,                              // 1 StringSingle
		@test = 60,                                      // 1 test
		@tests = 61,                                     // 1 tests
		@typeof = 62,                                    // 1 typeof
		@Undefined = 63,                                 // 1 Undefined
		@unset = 64,                                     // 1 unset
		@until = 65,                                     // 1 until
		@use = 66,                                       // 1 use
		@VAR = 67,                                       // 1 VAR
		@vars = 68,                                      // 1 vars
		@while = 69,                                     // 1 while
		@LBracket = 70,                                  // 1 '['
		@RBracket = 71,                                  // 1 ']'
		@LBrace = 72,                                    // 1 '{'
		@PipePipe = 73,                                  // 1 '||'
		@RBrace = 74,                                    // 1 '}'
		@Tilde = 75,                                     // 1 '~'
		@AddExpression = 76,                             // 0 <Add Expression>
		@AllFunctions = 77,                              // 0 <All Functions>
		@AllProcedures = 78,                             // 0 <All Procedures>
		@AndOperator = 79,                               // 0 <And Operator>
		@ArgumentArray = 80,                             // 0 <Argument Array>
		@ArgumentList = 81,                              // 0 <Argument List>
		@ArrayLiteral = 82,                              // 0 <Array Literal>
		@ArrayLiteralList = 83,                          // 0 <Array Literal List>
		@AssertProc = 84,                                // 0 <Assert Proc>
		@Assignment = 85,                                // 0 <Assignment>
		@BaseClassID = 86,                               // 0 <BaseClass ID>
		@BitInvertOperator = 87,                         // 0 <Bit Invert Operator>
		@Block = 88,                                     // 0 <Block>
		@BooleanChain = 89,                              // 0 <Boolean Chain>
		@BreakControl = 90,                              // 0 <Break Control>
		@CallExpression = 91,                            // 0 <Call Expression>
		@ClassNameID = 92,                               // 0 <ClassName ID>
		@ClassNameList = 93,                             // 0 <ClassName List>
		@ContainsTerm = 94,                              // 0 <Contains Term>
		@ContinueControl = 95,                           // 0 <Continue Control>
		@Declare = 96,                                   // 0 <Declare>
		@DivideExpression = 97,                          // 0 <Divide Expression>
		@DoUntilControl = 98,                            // 0 <Do Until Control>
		@DoWhileControl = 99,                            // 0 <Do While Control>
		@EachControl = 100,                              // 0 <Each Control>
		@EachOperator = 101,                             // 0 <Each Operator>
		@End = 102,                                      // 0 <End>
		@EndOpt = 103,                                   // 0 <End Opt>
		@EqualOperator = 104,                            // 0 <Equal Operator>
		@Expression = 105,                               // 0 <Expression>
		@FailProc = 106,                                 // 0 <Fail Proc>
		@FlowControl = 107,                              // 0 <Flow Control>
		@ForControl = 108,                               // 0 <For Control>
		@ForDeclare = 109,                               // 0 <For Declare>
		@ForExpression = 110,                            // 0 <For Expression>
		@ForStep = 111,                                  // 0 <For Step>
		@FunctionBlock = 112,                            // 0 <Function Block>
		@FunctionDecl = 113,                             // 0 <Function Decl>
		@FunctionExpression = 114,                       // 0 <Function Expression>
		@GtOperator = 115,                               // 0 <Gt Operator>
		@GteOperator = 116,                              // 0 <Gte Operator>
		@IfControl = 117,                                // 0 <If Control>
		@ImportDecl = 118,                               // 0 <Import Decl>
		@ImportDecls = 119,                              // 0 <Import Decls>
		@IssetFunc = 120,                                // 0 <Isset Func>
		@ListVars = 121,                                 // 0 <List Vars>
		@LtOperator = 122,                               // 0 <Lt Operator>
		@LteOperator = 123,                              // 0 <Lte Operator>
		@MathChain = 124,                                // 0 <Math Chain>
		@MemberID = 125,                                 // 0 <Member ID>
		@MultiplyExpression = 126,                       // 0 <Multiply Expression>
		@NameSpace = 127,                                // 0 <NameSpace>
		@NegOperator = 128,                              // 0 <Neg Operator>
		@NewExpression = 129,                            // 0 <New Expression>
		@NotEqualOperator = 130,                         // 0 <Not Equal Operator>
		@NotOperator = 131,                              // 0 <Not Operator>
		@ObjectBlock = 132,                              // 0 <Object Block>
		@ObjectDecl = 133,                               // 0 <Object Decl>
		@ObjectDecls = 134,                              // 0 <Object Decls>
		@OrOperator = 135,                               // 0 <Or Operator>
		@ParameterArray = 136,                           // 0 <Parameter Array>
		@ParameterList = 137,                            // 0 <Parameter List>
		@ParameterName = 138,                            // 0 <Parameter Name>
		@PluralID = 139,                                 // 0 <Plural ID>
		@PlusOperator = 140,                             // 0 <Plus Operator>
		@PostDecOperator = 141,                          // 0 <Post Dec Operator>
		@PostDecrement = 142,                            // 0 <Post Decrement>
		@PostIncOperator = 143,                          // 0 <Post Inc Operator>
		@PostIncrement = 144,                            // 0 <Post Increment>
		@PreDecOperator = 145,                           // 0 <Pre Dec Operator>
		@PreDecrement = 146,                             // 0 <Pre Decrement>
		@PreIncOperator = 147,                           // 0 <Pre Inc Operator>
		@PreIncrement = 148,                             // 0 <Pre Increment>
		@PrintProc = 149,                                // 0 <Print Proc>
		@Program = 150,                                  // 0 <Program>
		@ProgramCode = 151,                              // 0 <Program Code>
		@ProgramTest = 152,                              // 0 <Program Test>
		@QualifiedID = 153,                              // 0 <Qualified ID>
		@QualifiedList = 154,                            // 0 <Qualified List>
		@RemainderExpression = 155,                      // 0 <Remainder Expression>
		@ReturnProc = 156,                               // 0 <Return Proc>
		@SearchChain = 157,                              // 0 <Search Chain>
		@Statement = 158,                                // 0 <Statement>
		@StatementorBlock = 159,                         // 0 <Statement or Block>
		@Statements = 160,                               // 0 <Statements>
		@SubExpression = 161,                            // 0 <Sub Expression>
		@TestBlock = 162,                                // 0 <Test Block>
		@TestDecl = 163,                                 // 0 <Test Decl>
		@TestDecls = 164,                                // 0 <Test Decls>
		@TestExecute = 165,                              // 0 <Test Execute>
		@TestSuiteArray = 166,                           // 0 <Test Suite Array>
		@TestSuiteDecl = 167,                            // 0 <Test Suite Decl>
		@TypeOfFunc = 168,                               // 0 <TypeOf Func>
		@UnaryChain = 169,                               // 0 <Unary Chain>
		@UnsetProc = 170,                                // 0 <Unset Proc>
		@UntilControl = 171,                             // 0 <Until Control>
		@ValidID = 172,                                  // 0 <Valid ID>
		@Value = 173,                                    // 0 <Value>
		@VariableFunctions = 174,                        // 0 <Variable Functions>
		@VariableStatements = 175,                       // 0 <Variable Statements>
		@WhileControl = 176,                             // 0 <While Control>
		@WhileExpression = 177                           // 0 <While Expression>
	}
}
