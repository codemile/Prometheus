
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
		@CONTAINS = 37,                                  // 1 CONTAINS
		@continue = 38,                                  // 1 continue
		@Decimal = 39,                                   // 1 Decimal
		@do = 40,                                        // 1 do
		@each = 41,                                      // 1 each
		@else = 42,                                      // 1 else
		@fail = 43,                                      // 1 fail
		@float = 44,                                     // 1 float
		@for = 45,                                       // 1 for
		@function = 46,                                  // 1 function
		@HAS = 47,                                       // 1 HAS
		@Identifier = 48,                                // 1 Identifier
		@if = 49,                                        // 1 if
		@integer = 50,                                   // 1 integer
		@IS = 51,                                        // 1 IS
		@isset = 52,                                     // 1 isset
		@MemberName = 53,                                // 1 MemberName
		@new = 54,                                       // 1 new
		@NOT = 55,                                       // 1 NOT
		@number = 56,                                    // 1 number
		@Numeric = 57,                                   // 1 Numeric
		@object = 58,                                    // 1 object
		@OR = 59,                                        // 1 OR
		@package = 60,                                   // 1 package
		@print = 61,                                     // 1 print
		@regex = 62,                                     // 1 regex
		@RegExpPipe = 63,                                // 1 RegExpPipe
		@RegExpSlash = 64,                               // 1 RegExpSlash
		@return = 65,                                    // 1 return
		@string = 66,                                    // 1 string
		@StringDouble = 67,                              // 1 StringDouble
		@StringSingle = 68,                              // 1 StringSingle
		@test = 69,                                      // 1 test
		@tests = 70,                                     // 1 tests
		@typeof = 71,                                    // 1 typeof
		@Undefined = 72,                                 // 1 Undefined
		@unset = 73,                                     // 1 unset
		@until = 74,                                     // 1 until
		@use = 75,                                       // 1 use
		@VAR = 76,                                       // 1 VAR
		@vars = 77,                                      // 1 vars
		@while = 78,                                     // 1 while
		@with = 79,                                      // 1 with
		@LBracket = 80,                                  // 1 '['
		@RBracket = 81,                                  // 1 ']'
		@LBrace = 82,                                    // 1 '{'
		@PipePipe = 83,                                  // 1 '||'
		@RBrace = 84,                                    // 1 '}'
		@Tilde = 85,                                     // 1 '~'
		@AddExpression = 86,                             // 0 <Add Expression>
		@AllFunctions = 87,                              // 0 <All Functions>
		@AllProcedures = 88,                             // 0 <All Procedures>
		@AndOperator = 89,                               // 0 <And Operator>
		@ArgumentArray = 90,                             // 0 <Argument Array>
		@ArgumentList = 91,                              // 0 <Argument List>
		@ArrayLiteral = 92,                              // 0 <Array Literal>
		@ArrayLiteralList = 93,                          // 0 <Array Literal List>
		@AssertProc = 94,                                // 0 <Assert Proc>
		@Assignment = 95,                                // 0 <Assignment>
		@BaseClassID = 96,                               // 0 <BaseClass ID>
		@BitInvertOperator = 97,                         // 0 <Bit Invert Operator>
		@Block = 98,                                     // 0 <Block>
		@BooleanChain = 99,                              // 0 <Boolean Chain>
		@BreakControl = 100,                             // 0 <Break Control>
		@CallExpression = 101,                           // 0 <Call Expression>
		@ClassNameID = 102,                              // 0 <ClassName ID>
		@ClassNameList = 103,                            // 0 <ClassName List>
		@ContainsTerm = 104,                             // 0 <Contains Term>
		@ContinueControl = 105,                          // 0 <Continue Control>
		@Declare = 106,                                  // 0 <Declare>
		@DivideExpression = 107,                         // 0 <Divide Expression>
		@DoUntilControl = 108,                           // 0 <Do Until Control>
		@DoWhileControl = 109,                           // 0 <Do While Control>
		@EachControl = 110,                              // 0 <Each Control>
		@EachOperator = 111,                             // 0 <Each Operator>
		@End = 112,                                      // 0 <End>
		@EndOpt = 113,                                   // 0 <End Opt>
		@EqualOperator = 114,                            // 0 <Equal Operator>
		@Expression = 115,                               // 0 <Expression>
		@FailProc = 116,                                 // 0 <Fail Proc>
		@FlowControl = 117,                              // 0 <Flow Control>
		@ForControl = 118,                               // 0 <For Control>
		@ForDeclare = 119,                               // 0 <For Declare>
		@ForExpression = 120,                            // 0 <For Expression>
		@ForStep = 121,                                  // 0 <For Step>
		@FunctionBlock = 122,                            // 0 <Function Block>
		@FunctionDecl = 123,                             // 0 <Function Decl>
		@FunctionExpression = 124,                       // 0 <Function Expression>
		@FunctionParameters = 125,                       // 0 <Function Parameters>
		@GtOperator = 126,                               // 0 <Gt Operator>
		@GteOperator = 127,                              // 0 <Gte Operator>
		@IfControl = 128,                                // 0 <If Control>
		@ImportDecl = 129,                               // 0 <Import Decl>
		@ImportDecls = 130,                              // 0 <Import Decls>
		@IsNotOperator = 131,                            // 0 <Is Not Operator>
		@IsOperator = 132,                               // 0 <Is Operator>
		@IssetFunc = 133,                                // 0 <Isset Func>
		@ListVars = 134,                                 // 0 <List Vars>
		@LtOperator = 135,                               // 0 <Lt Operator>
		@LteOperator = 136,                              // 0 <Lte Operator>
		@MathChain = 137,                                // 0 <Math Chain>
		@MemberID = 138,                                 // 0 <Member ID>
		@MultiplyExpression = 139,                       // 0 <Multiply Expression>
		@NegOperator = 140,                              // 0 <Neg Operator>
		@NewExpression = 141,                            // 0 <New Expression>
		@NotEqualOperator = 142,                         // 0 <Not Equal Operator>
		@NotOperator = 143,                              // 0 <Not Operator>
		@ObjectBlock = 144,                              // 0 <Object Block>
		@ObjectDecl = 145,                               // 0 <Object Decl>
		@ObjectDecls = 146,                              // 0 <Object Decls>
		@OrOperator = 147,                               // 0 <Or Operator>
		@PackageDetails = 148,                           // 0 <Package Details>
		@PackageID = 149,                                // 0 <Package ID>
		@ParameterArray = 150,                           // 0 <Parameter Array>
		@ParameterList = 151,                            // 0 <Parameter List>
		@ParameterName = 152,                            // 0 <Parameter Name>
		@PluralID = 153,                                 // 0 <Plural ID>
		@PlusOperator = 154,                             // 0 <Plus Operator>
		@PostDecOperator = 155,                          // 0 <Post Dec Operator>
		@PostDecrement = 156,                            // 0 <Post Decrement>
		@PostIncOperator = 157,                          // 0 <Post Inc Operator>
		@PostIncrement = 158,                            // 0 <Post Increment>
		@PreDecOperator = 159,                           // 0 <Pre Dec Operator>
		@PreDecrement = 160,                             // 0 <Pre Decrement>
		@PreIncOperator = 161,                           // 0 <Pre Inc Operator>
		@PreIncrement = 162,                             // 0 <Pre Increment>
		@PrintProc = 163,                                // 0 <Print Proc>
		@Program = 164,                                  // 0 <Program>
		@ProgramCode = 165,                              // 0 <Program Code>
		@ProgramTest = 166,                              // 0 <Program Test>
		@QualifiedID = 167,                              // 0 <Qualified ID>
		@QualifiedList = 168,                            // 0 <Qualified List>
		@RemainderExpression = 169,                      // 0 <Remainder Expression>
		@ReturnProc = 170,                               // 0 <Return Proc>
		@SearchChain = 171,                              // 0 <Search Chain>
		@Statement = 172,                                // 0 <Statement>
		@StatementorBlock = 173,                         // 0 <Statement or Block>
		@Statements = 174,                               // 0 <Statements>
		@SubExpression = 175,                            // 0 <Sub Expression>
		@TestBlock = 176,                                // 0 <Test Block>
		@TestDecl = 177,                                 // 0 <Test Decl>
		@TestDecls = 178,                                // 0 <Test Decls>
		@TestExecute = 179,                              // 0 <Test Execute>
		@TestSuiteArray = 180,                           // 0 <Test Suite Array>
		@TestSuiteDecl = 181,                            // 0 <Test Suite Decl>
		@TypeChain = 182,                                // 0 <Type Chain>
		@TypeOfFunc = 183,                               // 0 <TypeOf Func>
		@Types = 184,                                    // 0 <Types>
		@UnaryChain = 185,                               // 0 <Unary Chain>
		@UnsetProc = 186,                                // 0 <Unset Proc>
		@UntilControl = 187,                             // 0 <Until Control>
		@ValidID = 188,                                  // 0 <Valid ID>
		@Value = 189,                                    // 0 <Value>
		@VariableFunctions = 190,                        // 0 <Variable Functions>
		@VariableStatements = 191,                       // 0 <Variable Statements>
		@WhileControl = 192,                             // 0 <While Control>
		@WhileExpression = 193,                          // 0 <While Expression>
		@WithArray = 194                                 // 0 <With Array>
	}
}
