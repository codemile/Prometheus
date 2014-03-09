
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
		@array = 31,                                     // 1 array
		@as = 32,                                        // 1 as
		@assert = 33,                                    // 1 assert
		@Boolean = 34,                                   // 1 Boolean
		@break = 35,                                     // 1 break
		@class = 36,                                     // 1 class
		@closure = 37,                                   // 1 closure
		@CONTAINS = 38,                                  // 1 CONTAINS
		@continue = 39,                                  // 1 continue
		@Decimal = 40,                                   // 1 Decimal
		@do = 41,                                        // 1 do
		@each = 42,                                      // 1 each
		@else = 43,                                      // 1 else
		@fail = 44,                                      // 1 fail
		@float = 45,                                     // 1 float
		@for = 46,                                       // 1 for
		@function = 47,                                  // 1 function
		@HAS = 48,                                       // 1 HAS
		@Identifier = 49,                                // 1 Identifier
		@if = 50,                                        // 1 if
		@integer = 51,                                   // 1 integer
		@IS = 52,                                        // 1 IS
		@isset = 53,                                     // 1 isset
		@MemberName = 54,                                // 1 MemberName
		@new = 55,                                       // 1 new
		@NOT = 56,                                       // 1 NOT
		@number = 57,                                    // 1 number
		@Numeric = 58,                                   // 1 Numeric
		@object = 59,                                    // 1 object
		@OR = 60,                                        // 1 OR
		@package = 61,                                   // 1 package
		@print = 62,                                     // 1 print
		@regex = 63,                                     // 1 regex
		@RegExpPipe = 64,                                // 1 RegExpPipe
		@RegExpSlash = 65,                               // 1 RegExpSlash
		@return = 66,                                    // 1 return
		@string = 67,                                    // 1 string
		@StringDouble = 68,                              // 1 StringDouble
		@StringSingle = 69,                              // 1 StringSingle
		@test = 70,                                      // 1 test
		@tests = 71,                                     // 1 tests
		@typeof = 72,                                    // 1 typeof
		@Undefined = 73,                                 // 1 Undefined
		@unset = 74,                                     // 1 unset
		@until = 75,                                     // 1 until
		@use = 76,                                       // 1 use
		@VAR = 77,                                       // 1 VAR
		@vars = 78,                                      // 1 vars
		@while = 79,                                     // 1 while
		@with = 80,                                      // 1 with
		@LBracket = 81,                                  // 1 '['
		@RBracket = 82,                                  // 1 ']'
		@LBrace = 83,                                    // 1 '{'
		@PipePipe = 84,                                  // 1 '||'
		@RBrace = 85,                                    // 1 '}'
		@Tilde = 86,                                     // 1 '~'
		@AddExpression = 87,                             // 0 <Add Expression>
		@AllFunctions = 88,                              // 0 <All Functions>
		@AllProcedures = 89,                             // 0 <All Procedures>
		@AndOperator = 90,                               // 0 <And Operator>
		@ArgumentArray = 91,                             // 0 <Argument Array>
		@ArgumentList = 92,                              // 0 <Argument List>
		@ArrayLiteral = 93,                              // 0 <Array Literal>
		@ArrayLiteralList = 94,                          // 0 <Array Literal List>
		@AssertProc = 95,                                // 0 <Assert Proc>
		@Assignment = 96,                                // 0 <Assignment>
		@BaseClassID = 97,                               // 0 <BaseClass ID>
		@BitInvertOperator = 98,                         // 0 <Bit Invert Operator>
		@Block = 99,                                     // 0 <Block>
		@BooleanChain = 100,                             // 0 <Boolean Chain>
		@BreakControl = 101,                             // 0 <Break Control>
		@CallExpression = 102,                           // 0 <Call Expression>
		@ClassNameID = 103,                              // 0 <ClassName ID>
		@ClassNameList = 104,                            // 0 <ClassName List>
		@ContainsTerm = 105,                             // 0 <Contains Term>
		@ContinueControl = 106,                          // 0 <Continue Control>
		@Declare = 107,                                  // 0 <Declare>
		@DivideExpression = 108,                         // 0 <Divide Expression>
		@DoUntilControl = 109,                           // 0 <Do Until Control>
		@DoWhileControl = 110,                           // 0 <Do While Control>
		@EachControl = 111,                              // 0 <Each Control>
		@EachOperator = 112,                             // 0 <Each Operator>
		@End = 113,                                      // 0 <End>
		@EndOpt = 114,                                   // 0 <End Opt>
		@EqualOperator = 115,                            // 0 <Equal Operator>
		@Expression = 116,                               // 0 <Expression>
		@FailProc = 117,                                 // 0 <Fail Proc>
		@FlowControl = 118,                              // 0 <Flow Control>
		@ForControl = 119,                               // 0 <For Control>
		@ForDeclare = 120,                               // 0 <For Declare>
		@ForExpression = 121,                            // 0 <For Expression>
		@ForStep = 122,                                  // 0 <For Step>
		@FunctionBlock = 123,                            // 0 <Function Block>
		@FunctionDecl = 124,                             // 0 <Function Decl>
		@FunctionExpression = 125,                       // 0 <Function Expression>
		@FunctionParameters = 126,                       // 0 <Function Parameters>
		@GtOperator = 127,                               // 0 <Gt Operator>
		@GteOperator = 128,                              // 0 <Gte Operator>
		@IfControl = 129,                                // 0 <If Control>
		@ImportDecl = 130,                               // 0 <Import Decl>
		@ImportDecls = 131,                              // 0 <Import Decls>
		@IsNotOperator = 132,                            // 0 <Is Not Operator>
		@IsOperator = 133,                               // 0 <Is Operator>
		@IssetFunc = 134,                                // 0 <Isset Func>
		@ListVars = 135,                                 // 0 <List Vars>
		@LtOperator = 136,                               // 0 <Lt Operator>
		@LteOperator = 137,                              // 0 <Lte Operator>
		@MathChain = 138,                                // 0 <Math Chain>
		@MemberID = 139,                                 // 0 <Member ID>
		@MultiplyExpression = 140,                       // 0 <Multiply Expression>
		@NegOperator = 141,                              // 0 <Neg Operator>
		@NewExpression = 142,                            // 0 <New Expression>
		@NotEqualOperator = 143,                         // 0 <Not Equal Operator>
		@NotOperator = 144,                              // 0 <Not Operator>
		@ObjectBlock = 145,                              // 0 <Object Block>
		@ObjectDecl = 146,                               // 0 <Object Decl>
		@ObjectDecls = 147,                              // 0 <Object Decls>
		@OrOperator = 148,                               // 0 <Or Operator>
		@PackageDetails = 149,                           // 0 <Package Details>
		@PackageID = 150,                                // 0 <Package ID>
		@ParameterArray = 151,                           // 0 <Parameter Array>
		@ParameterList = 152,                            // 0 <Parameter List>
		@ParameterName = 153,                            // 0 <Parameter Name>
		@PluralID = 154,                                 // 0 <Plural ID>
		@PlusOperator = 155,                             // 0 <Plus Operator>
		@PostDecOperator = 156,                          // 0 <Post Dec Operator>
		@PostDecrement = 157,                            // 0 <Post Decrement>
		@PostIncOperator = 158,                          // 0 <Post Inc Operator>
		@PostIncrement = 159,                            // 0 <Post Increment>
		@PreDecOperator = 160,                           // 0 <Pre Dec Operator>
		@PreDecrement = 161,                             // 0 <Pre Decrement>
		@PreIncOperator = 162,                           // 0 <Pre Inc Operator>
		@PreIncrement = 163,                             // 0 <Pre Increment>
		@PrintProc = 164,                                // 0 <Print Proc>
		@Program = 165,                                  // 0 <Program>
		@ProgramCode = 166,                              // 0 <Program Code>
		@ProgramTest = 167,                              // 0 <Program Test>
		@QualifiedID = 168,                              // 0 <Qualified ID>
		@QualifiedList = 169,                            // 0 <Qualified List>
		@RemainderExpression = 170,                      // 0 <Remainder Expression>
		@ReturnProc = 171,                               // 0 <Return Proc>
		@SearchChain = 172,                              // 0 <Search Chain>
		@Statement = 173,                                // 0 <Statement>
		@StatementorBlock = 174,                         // 0 <Statement or Block>
		@Statements = 175,                               // 0 <Statements>
		@SubExpression = 176,                            // 0 <Sub Expression>
		@TestBlock = 177,                                // 0 <Test Block>
		@TestDecl = 178,                                 // 0 <Test Decl>
		@TestDecls = 179,                                // 0 <Test Decls>
		@TestExecute = 180,                              // 0 <Test Execute>
		@TestSuiteArray = 181,                           // 0 <Test Suite Array>
		@TestSuiteDecl = 182,                            // 0 <Test Suite Decl>
		@TypeChain = 183,                                // 0 <Type Chain>
		@TypeOfFunc = 184,                               // 0 <TypeOf Func>
		@Types = 185,                                    // 0 <Types>
		@UnaryChain = 186,                               // 0 <Unary Chain>
		@UnsetProc = 187,                                // 0 <Unset Proc>
		@UntilControl = 188,                             // 0 <Until Control>
		@ValidID = 189,                                  // 0 <Valid ID>
		@Value = 190,                                    // 0 <Value>
		@VariableFunctions = 191,                        // 0 <Variable Functions>
		@VariableStatements = 192,                       // 0 <Variable Statements>
		@WhileControl = 193,                             // 0 <While Control>
		@WhileExpression = 194,                          // 0 <While Expression>
		@WithArray = 195                                 // 0 <With Array>
	}
}
