
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
		@ClassNameID = 93,                               // 0 <ClassName ID>
		@ClassNameList = 94,                             // 0 <ClassName List>
		@ContainsTerm = 95,                              // 0 <Contains Term>
		@ContinueControl = 96,                           // 0 <Continue Control>
		@Declare = 97,                                   // 0 <Declare>
		@DivideExpression = 98,                          // 0 <Divide Expression>
		@DoUntilControl = 99,                            // 0 <Do Until Control>
		@DoWhileControl = 100,                           // 0 <Do While Control>
		@EachControl = 101,                              // 0 <Each Control>
		@EachOperator = 102,                             // 0 <Each Operator>
		@End = 103,                                      // 0 <End>
		@EndOpt = 104,                                   // 0 <End Opt>
		@EqualOperator = 105,                            // 0 <Equal Operator>
		@Expression = 106,                               // 0 <Expression>
		@FailProc = 107,                                 // 0 <Fail Proc>
		@FlowControl = 108,                              // 0 <Flow Control>
		@ForControl = 109,                               // 0 <For Control>
		@ForDeclare = 110,                               // 0 <For Declare>
		@ForExpression = 111,                            // 0 <For Expression>
		@ForStep = 112,                                  // 0 <For Step>
		@FunctionBlock = 113,                            // 0 <Function Block>
		@FunctionDecl = 114,                             // 0 <Function Decl>
		@FunctionExpression = 115,                       // 0 <Function Expression>
		@GtOperator = 116,                               // 0 <Gt Operator>
		@GteOperator = 117,                              // 0 <Gte Operator>
		@IfControl = 118,                                // 0 <If Control>
		@ImportDecl = 119,                               // 0 <Import Decl>
		@ImportDecls = 120,                              // 0 <Import Decls>
		@IssetFunc = 121,                                // 0 <Isset Func>
		@ListVars = 122,                                 // 0 <List Vars>
		@LoopUntilControl = 123,                         // 0 <Loop Until Control>
		@LoopWhileControl = 124,                         // 0 <Loop While Control>
		@LtOperator = 125,                               // 0 <Lt Operator>
		@LteOperator = 126,                              // 0 <Lte Operator>
		@MathChain = 127,                                // 0 <Math Chain>
		@MemberID = 128,                                 // 0 <Member ID>
		@MultiplyExpression = 129,                       // 0 <Multiply Expression>
		@NameSpace = 130,                                // 0 <NameSpace>
		@NegOperator = 131,                              // 0 <Neg Operator>
		@NewExpression = 132,                            // 0 <New Expression>
		@NotEqualOperator = 133,                         // 0 <Not Equal Operator>
		@NotOperator = 134,                              // 0 <Not Operator>
		@ObjectBlock = 135,                              // 0 <Object Block>
		@ObjectDecl = 136,                               // 0 <Object Decl>
		@ObjectDecls = 137,                              // 0 <Object Decls>
		@OrOperator = 138,                               // 0 <Or Operator>
		@ParameterArray = 139,                           // 0 <Parameter Array>
		@ParameterList = 140,                            // 0 <Parameter List>
		@ParameterName = 141,                            // 0 <Parameter Name>
		@PluralID = 142,                                 // 0 <Plural ID>
		@PlusOperator = 143,                             // 0 <Plus Operator>
		@PostDecOperator = 144,                          // 0 <Post Dec Operator>
		@PostDecrement = 145,                            // 0 <Post Decrement>
		@PostIncOperator = 146,                          // 0 <Post Inc Operator>
		@PostIncrement = 147,                            // 0 <Post Increment>
		@PreDecOperator = 148,                           // 0 <Pre Dec Operator>
		@PreDecrement = 149,                             // 0 <Pre Decrement>
		@PreIncOperator = 150,                           // 0 <Pre Inc Operator>
		@PreIncrement = 151,                             // 0 <Pre Increment>
		@PrintProc = 152,                                // 0 <Print Proc>
		@Program = 153,                                  // 0 <Program>
		@ProgramCode = 154,                              // 0 <Program Code>
		@ProgramTest = 155,                              // 0 <Program Test>
		@QualifiedID = 156,                              // 0 <Qualified ID>
		@QualifiedList = 157,                            // 0 <Qualified List>
		@RemainderExpression = 158,                      // 0 <Remainder Expression>
		@ReturnProc = 159,                               // 0 <Return Proc>
		@SearchChain = 160,                              // 0 <Search Chain>
		@Statement = 161,                                // 0 <Statement>
		@StatementorBlock = 162,                         // 0 <Statement or Block>
		@Statements = 163,                               // 0 <Statements>
		@SubExpression = 164,                            // 0 <Sub Expression>
		@TestBlock = 165,                                // 0 <Test Block>
		@TestDecl = 166,                                 // 0 <Test Decl>
		@TestDecls = 167,                                // 0 <Test Decls>
		@TestExecute = 168,                              // 0 <Test Execute>
		@TestSuiteArray = 169,                           // 0 <Test Suite Array>
		@TestSuiteDecl = 170,                            // 0 <Test Suite Decl>
		@TypeOfFunc = 171,                               // 0 <TypeOf Func>
		@UnaryChain = 172,                               // 0 <Unary Chain>
		@UnsetProc = 173,                                // 0 <Unset Proc>
		@ValidID = 174,                                  // 0 <Valid ID>
		@Value = 175,                                    // 0 <Value>
		@VariableFunctions = 176,                        // 0 <Variable Functions>
		@VariableStatements = 177                        // 0 <Variable Statements>
	}
}
