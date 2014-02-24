
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
		@BlockorEnd = 89,                                // 0 <Block or End>
		@BooleanChain = 90,                              // 0 <Boolean Chain>
		@BreakControl = 91,                              // 0 <Break Control>
		@CallExpression = 92,                            // 0 <Call Expression>
		@CallGeneric = 93,                               // 0 <Call Generic>
		@ClassNameID = 94,                               // 0 <ClassName ID>
		@ClassNameList = 95,                             // 0 <ClassName List>
		@ContainsTerm = 96,                              // 0 <Contains Term>
		@ContinueControl = 97,                           // 0 <Continue Control>
		@Declare = 98,                                   // 0 <Declare>
		@DivideExpression = 99,                          // 0 <Divide Expression>
		@DoUntilControl = 100,                           // 0 <Do Until Control>
		@DoWhileControl = 101,                           // 0 <Do While Control>
		@EachControl = 102,                              // 0 <Each Control>
		@EachOperator = 103,                             // 0 <Each Operator>
		@End = 104,                                      // 0 <End>
		@EndOpt = 105,                                   // 0 <End Opt>
		@EqualOperator = 106,                            // 0 <Equal Operator>
		@Expression = 107,                               // 0 <Expression>
		@FailProc = 108,                                 // 0 <Fail Proc>
		@FlowControl = 109,                              // 0 <Flow Control>
		@ForControl = 110,                               // 0 <For Control>
		@ForDeclare = 111,                               // 0 <For Declare>
		@ForExpression = 112,                            // 0 <For Expression>
		@ForStep = 113,                                  // 0 <For Step>
		@FunctionBlock = 114,                            // 0 <Function Block>
		@FunctionDecl = 115,                             // 0 <Function Decl>
		@FunctionExpression = 116,                       // 0 <Function Expression>
		@GtOperator = 117,                               // 0 <Gt Operator>
		@GteOperator = 118,                              // 0 <Gte Operator>
		@IfControl = 119,                                // 0 <If Control>
		@ImportDecl = 120,                               // 0 <Import Decl>
		@ImportDecls = 121,                              // 0 <Import Decls>
		@IssetFunc = 122,                                // 0 <Isset Func>
		@ListVars = 123,                                 // 0 <List Vars>
		@LoopUntilControl = 124,                         // 0 <Loop Until Control>
		@LoopWhileControl = 125,                         // 0 <Loop While Control>
		@LtOperator = 126,                               // 0 <Lt Operator>
		@LteOperator = 127,                              // 0 <Lte Operator>
		@MathChain = 128,                                // 0 <Math Chain>
		@MemberID = 129,                                 // 0 <Member ID>
		@MultiplyExpression = 130,                       // 0 <Multiply Expression>
		@NameSpace = 131,                                // 0 <NameSpace>
		@NegOperator = 132,                              // 0 <Neg Operator>
		@NewExpression = 133,                            // 0 <New Expression>
		@NotEqualOperator = 134,                         // 0 <Not Equal Operator>
		@NotOperator = 135,                              // 0 <Not Operator>
		@ObjectBlock = 136,                              // 0 <Object Block>
		@ObjectDecl = 137,                               // 0 <Object Decl>
		@ObjectDecls = 138,                              // 0 <Object Decls>
		@OrOperator = 139,                               // 0 <Or Operator>
		@ParameterArray = 140,                           // 0 <Parameter Array>
		@ParameterList = 141,                            // 0 <Parameter List>
		@ParameterName = 142,                            // 0 <Parameter Name>
		@PluralID = 143,                                 // 0 <Plural ID>
		@PlusOperator = 144,                             // 0 <Plus Operator>
		@PostDecOperator = 145,                          // 0 <Post Dec Operator>
		@PostDecrement = 146,                            // 0 <Post Decrement>
		@PostIncOperator = 147,                          // 0 <Post Inc Operator>
		@PostIncrement = 148,                            // 0 <Post Increment>
		@PreDecOperator = 149,                           // 0 <Pre Dec Operator>
		@PreDecrement = 150,                             // 0 <Pre Decrement>
		@PreIncOperator = 151,                           // 0 <Pre Inc Operator>
		@PreIncrement = 152,                             // 0 <Pre Increment>
		@PrintProc = 153,                                // 0 <Print Proc>
		@Program = 154,                                  // 0 <Program>
		@ProgramCode = 155,                              // 0 <Program Code>
		@ProgramTest = 156,                              // 0 <Program Test>
		@QualifiedID = 157,                              // 0 <Qualified ID>
		@QualifiedList = 158,                            // 0 <Qualified List>
		@RemainderExpression = 159,                      // 0 <Remainder Expression>
		@ReturnProc = 160,                               // 0 <Return Proc>
		@SearchChain = 161,                              // 0 <Search Chain>
		@Statement = 162,                                // 0 <Statement>
		@StatementorBlock = 163,                         // 0 <Statement or Block>
		@Statements = 164,                               // 0 <Statements>
		@SubExpression = 165,                            // 0 <Sub Expression>
		@TestBlock = 166,                                // 0 <Test Block>
		@TestDecl = 167,                                 // 0 <Test Decl>
		@TestDecls = 168,                                // 0 <Test Decls>
		@TestExecute = 169,                              // 0 <Test Execute>
		@TestSuiteArray = 170,                           // 0 <Test Suite Array>
		@TestSuiteDecl = 171,                            // 0 <Test Suite Decl>
		@TypeOfFunc = 172,                               // 0 <TypeOf Func>
		@UnaryChain = 173,                               // 0 <Unary Chain>
		@UnsetProc = 174,                                // 0 <Unset Proc>
		@ValidID = 175,                                  // 0 <Valid ID>
		@Value = 176,                                    // 0 <Value>
		@VariableFunctions = 177,                        // 0 <Variable Functions>
		@VariableStatements = 178                        // 0 <Variable Statements>
	}
}
