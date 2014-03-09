
namespace Prometheus.Grammar
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum GrammarRule
	{
		@Program = 0,                                    // <Program> ::= <Program Test>
		@Program2 = 1,                                   // <Program> ::= <Program Code>
		@ProgramTest = 2,                                // <Program Test> ::= <Package Details> <Test Suite Decl> <Test Decls> <Test Execute>
		@ProgramTest2 = 3,                               // <Program Test> ::= <Package Details> <Test Suite Decl> <Statements> <Test Decls> <Test Execute>
		@ProgramTest3 = 4,                               // <Program Test> ::= <Package Details> <Test Suite Decl> <Statements> <Test Decls> <Test Execute> <Statements>
		@ProgramCode = 5,                                // <Program Code> ::= <Package Details> <Object Decls>
		@ProgramCode2 = 6,                               // <Program Code> ::= <Package Details> <Object Decls> <Statements>
		@Block_LBrace_RBrace = 7,                        // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 8,                       // <Block> ::= '{' '}'
		@StatementorBlock = 9,                           // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 10,                         // <Statement or Block> ::= <Block>
		@Statements = 11,                                // <Statements> ::= <Statement or Block>
		@Statements2 = 12,                               // <Statements> ::= <Statements> <Statement or Block>
		@Statement = 13,                                 // <Statement> ::= <Flow Control>
		@Statement2 = 14,                                // <Statement> ::= <Function Decl>
		@Statement3 = 15,                                // <Statement> ::= <All Procedures> <End>
		@Statement4 = 16,                                // <Statement> ::= <All Functions> <End>
		@Statement5 = 17,                                // <Statement> ::= <Variable Statements> <End>
		@Statement6 = 18,                                // <Statement> ::= <Call Expression> <End>
		@Statement7 = 19,                                // <Statement> ::= <New Expression> <End>
		@Statement8 = 20,                                // <Statement> ::= <End>
		@TestSuiteDecl_tests = 21,                       // <Test Suite Decl> ::= tests <End>
		@TestSuiteDecl_tests_LBracket_RBracket = 22,     // <Test Suite Decl> ::= tests '[' <Test Suite Array> ']' <End>
		@TestSuiteArray = 23,                            // <Test Suite Array> ::= <Valid ID>
		@TestSuiteArray_Comma = 24,                      // <Test Suite Array> ::= <Valid ID> ',' <Test Suite Array>
		@TestSuiteArray2 = 25,                           // <Test Suite Array> ::= 
		@TestDecls = 26,                                 // <Test Decls> ::= <Test Decl>
		@TestDecls2 = 27,                                // <Test Decls> ::= <Test Decls> <Test Decl>
		@TestDecls3 = 28,                                // <Test Decls> ::= 
		@TestDecl_test = 29,                             // <Test Decl> ::= test <Valid ID> <Block>
		@TestBlock = 30,                                 // <Test Block> ::= 
		@TestExecute = 31,                               // <Test Execute> ::= 
		@End_Semi = 32,                                  // <End> ::= ';'
		@EndOpt = 33,                                    // <End Opt> ::= <End>
		@EndOpt2 = 34,                                   // <End Opt> ::= 
		@Expression = 35,                                // <Expression> ::= <Search Chain>
		@SearchChain = 36,                               // <Search Chain> ::= <Contains Term>
		@ContainsTerm_CONTAINS = 37,                     // <Contains Term> ::= <Contains Term> CONTAINS <Boolean Chain>
		@ContainsTerm_HAS = 38,                          // <Contains Term> ::= <Contains Term> HAS <Boolean Chain>
		@ContainsTerm = 39,                              // <Contains Term> ::= <Boolean Chain>
		@BooleanChain = 40,                              // <Boolean Chain> ::= <Gt Operator>
		@GtOperator_Gt = 41,                             // <Gt Operator> ::= <Gt Operator> '>' <Lt Operator>
		@GtOperator = 42,                                // <Gt Operator> ::= <Lt Operator>
		@LtOperator_Lt = 43,                             // <Lt Operator> ::= <Lt Operator> '<' <Gte Operator>
		@LtOperator = 44,                                // <Lt Operator> ::= <Gte Operator>
		@GteOperator_GtEq = 45,                          // <Gte Operator> ::= <Gte Operator> '>=' <Lte Operator>
		@GteOperator = 46,                               // <Gte Operator> ::= <Lte Operator>
		@LteOperator_LtEq = 47,                          // <Lte Operator> ::= <Lte Operator> '<=' <Equal Operator>
		@LteOperator = 48,                               // <Lte Operator> ::= <Equal Operator>
		@EqualOperator_EqEq = 49,                        // <Equal Operator> ::= <Equal Operator> '==' <Not Equal Operator>
		@EqualOperator = 50,                             // <Equal Operator> ::= <Not Equal Operator>
		@NotEqualOperator_ExclamEq = 51,                 // <Not Equal Operator> ::= <Not Equal Operator> '!=' <And Operator>
		@NotEqualOperator_LtGt = 52,                     // <Not Equal Operator> ::= <Not Equal Operator> '<>' <And Operator>
		@NotEqualOperator = 53,                          // <Not Equal Operator> ::= <And Operator>
		@AndOperator_AND = 54,                           // <And Operator> ::= <And Operator> AND <Or Operator>
		@AndOperator_AmpAmp = 55,                        // <And Operator> ::= <And Operator> '&&' <Or Operator>
		@AndOperator = 56,                               // <And Operator> ::= <Or Operator>
		@OrOperator_OR = 57,                             // <Or Operator> ::= <Or Operator> OR <Math Chain>
		@OrOperator_PipePipe = 58,                       // <Or Operator> ::= <Or Operator> '||' <Math Chain>
		@OrOperator = 59,                                // <Or Operator> ::= <Math Chain>
		@MathChain = 60,                                 // <Math Chain> ::= <Add Expression>
		@AddExpression_Plus = 61,                        // <Add Expression> ::= <Add Expression> '+' <Sub Expression>
		@AddExpression = 62,                             // <Add Expression> ::= <Sub Expression>
		@SubExpression_Minus = 63,                       // <Sub Expression> ::= <Sub Expression> '-' <Multiply Expression>
		@SubExpression = 64,                             // <Sub Expression> ::= <Multiply Expression>
		@MultiplyExpression_Times = 65,                  // <Multiply Expression> ::= <Multiply Expression> '*' <Divide Expression>
		@MultiplyExpression = 66,                        // <Multiply Expression> ::= <Divide Expression>
		@DivideExpression_Div = 67,                      // <Divide Expression> ::= <Divide Expression> '/' <Remainder Expression>
		@DivideExpression = 68,                          // <Divide Expression> ::= <Remainder Expression>
		@RemainderExpression_Percent = 69,               // <Remainder Expression> ::= <Remainder Expression> '%' <Unary Chain>
		@RemainderExpression = 70,                       // <Remainder Expression> ::= <Unary Chain>
		@UnaryChain = 71,                                // <Unary Chain> ::= <Not Operator>
		@NotOperator_Exclam = 72,                        // <Not Operator> ::= '!' <Value>
		@NotOperator_NOT = 73,                           // <Not Operator> ::= NOT <Value>
		@NotOperator = 74,                               // <Not Operator> ::= <Bit Invert Operator>
		@BitInvertOperator_Tilde = 75,                   // <Bit Invert Operator> ::= '~' <Value>
		@BitInvertOperator = 76,                         // <Bit Invert Operator> ::= <Neg Operator>
		@NegOperator_Minus = 77,                         // <Neg Operator> ::= '-' <Value>
		@NegOperator = 78,                               // <Neg Operator> ::= <Plus Operator>
		@PlusOperator_Plus = 79,                         // <Plus Operator> ::= '+' <Value>
		@PlusOperator = 80,                              // <Plus Operator> ::= <Pre Dec Operator>
		@PreDecOperator_MinusMinus = 81,                 // <Pre Dec Operator> ::= '--' <Qualified ID>
		@PreDecOperator = 82,                            // <Pre Dec Operator> ::= <Post Dec Operator>
		@PostDecOperator_MinusMinus = 83,                // <Post Dec Operator> ::= <Qualified ID> '--'
		@PostDecOperator = 84,                           // <Post Dec Operator> ::= <Pre Inc Operator>
		@PreIncOperator_PlusPlus = 85,                   // <Pre Inc Operator> ::= '++' <Qualified ID>
		@PreIncOperator = 86,                            // <Pre Inc Operator> ::= <Post Inc Operator>
		@PostIncOperator_PlusPlus = 87,                  // <Post Inc Operator> ::= <Qualified ID> '++'
		@PostIncOperator = 88,                           // <Post Inc Operator> ::= <Each Operator>
		@EachOperator = 89,                              // <Each Operator> ::= <Each Control>
		@EachOperator2 = 90,                             // <Each Operator> ::= <Type Chain>
		@TypeChain = 91,                                 // <Type Chain> ::= <Is Operator>
		@IsOperator_IS = 92,                             // <Is Operator> ::= <Qualified ID> IS <Qualified ID>
		@IsOperator_IS2 = 93,                            // <Is Operator> ::= <Qualified ID> IS <Types>
		@IsOperator = 94,                                // <Is Operator> ::= <Is Not Operator>
		@IsNotOperator_IS_NOT = 95,                      // <Is Not Operator> ::= <Qualified ID> IS NOT <Qualified ID>
		@IsNotOperator_IS_NOT2 = 96,                     // <Is Not Operator> ::= <Qualified ID> IS NOT <Types>
		@IsNotOperator = 97,                             // <Is Not Operator> ::= <Value>
		@Types_number = 98,                              // <Types> ::= number
		@Types_integer = 99,                             // <Types> ::= integer
		@Types_float = 100,                              // <Types> ::= float
		@Types_string = 101,                             // <Types> ::= string
		@Types_regex = 102,                              // <Types> ::= regex
		@Types_function = 103,                           // <Types> ::= function
		@Types_closure = 104,                            // <Types> ::= closure
		@Types_object = 105,                             // <Types> ::= object
		@Types_class = 106,                              // <Types> ::= class
		@Types_array = 107,                              // <Types> ::= array
		@Types_Undefined = 108,                          // <Types> ::= Undefined
		@Types_package = 109,                            // <Types> ::= package
		@ValidID_Identifier = 110,                       // <Valid ID> ::= Identifier
		@MemberID_MemberName = 111,                      // <Member ID> ::= MemberName
		@ClassNameID = 112,                              // <ClassName ID> ::= <Valid ID> <ClassName List>
		@ClassNameList = 113,                            // <ClassName List> ::= <Member ID> <ClassName List>
		@ClassNameList2 = 114,                           // <ClassName List> ::= 
		@QualifiedID = 115,                              // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 116,                            // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 117,          // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 118,                           // <Qualified List> ::= 
		@Value_StringDouble = 119,                       // <Value> ::= StringDouble
		@Value_StringSingle = 120,                       // <Value> ::= StringSingle
		@Value_RegExpSlash = 121,                        // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 122,                         // <Value> ::= RegExpPipe
		@Value_Numeric = 123,                            // <Value> ::= Numeric
		@Value_Decimal = 124,                            // <Value> ::= Decimal
		@Value_Boolean = 125,                            // <Value> ::= Boolean
		@Value_Undefined = 126,                          // <Value> ::= Undefined
		@Value = 127,                                    // <Value> ::= <Array Literal>
		@Value2 = 128,                                   // <Value> ::= <Qualified ID>
		@Value3 = 129,                                   // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 130,                      // <Value> ::= '(' <Expression> ')'
		@Value4 = 131,                                   // <Value> ::= <Call Expression>
		@Value5 = 132,                                   // <Value> ::= <All Functions>
		@VariableStatements = 133,                       // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 134,                      // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 135,                      // <Variable Statements> ::= <Post Increment>
		@VariableStatements4 = 136,                      // <Variable Statements> ::= <Pre Increment>
		@VariableStatements5 = 137,                      // <Variable Statements> ::= <Post Decrement>
		@VariableStatements6 = 138,                      // <Variable Statements> ::= <Pre Decrement>
		@ArrayLiteral_LBracket_RBracket = 139,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 140,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 141,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 142,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 143,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 144,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 145,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 146,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@PostIncrement_PlusPlus = 147,                   // <Post Increment> ::= <Qualified ID> '++'
		@PreIncrement_PlusPlus = 148,                    // <Pre Increment> ::= '++' <Qualified ID>
		@PostDecrement_MinusMinus = 149,                 // <Post Decrement> ::= <Qualified ID> '--'
		@PreDecrement_MinusMinus = 150,                  // <Pre Decrement> ::= '--' <Qualified ID>
		@PackageDetails = 151,                           // <Package Details> ::= <Package ID> <Import Decls>
		@ImportDecls = 152,                              // <Import Decls> ::= <Import Decl>
		@ImportDecls2 = 153,                             // <Import Decls> ::= <Import Decls> <Import Decl>
		@ImportDecls3 = 154,                             // <Import Decls> ::= 
		@PackageID_package = 155,                        // <Package ID> ::= package <Qualified ID> <End>
		@ImportDecl_use_StringDouble = 156,              // <Import Decl> ::= use StringDouble <End>
		@ImportDecl_use_StringSingle = 157,              // <Import Decl> ::= use StringSingle <End>
		@ImportDecl_use = 158,                           // <Import Decl> ::= use <Qualified ID> <End>
		@ObjectDecls = 159,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 160,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecls3 = 161,                             // <Object Decls> ::= 
		@ObjectDecl_object = 162,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block>
		@ObjectBlock = 163,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 164,                   // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
		@BaseClassID = 165,                              // <BaseClass ID> ::= <Valid ID>
		@FunctionDecl_function_Identifier = 166,         // <Function Decl> ::= function Identifier <Function Parameters> <Block>
		@FunctionBlock = 167,                            // <Function Block> ::= 
		@FunctionExpression_function = 168,              // <Function Expression> ::= function <Function Parameters> <Block>
		@FunctionParameters = 169,                       // <Function Parameters> ::= <Parameter Array>
		@FunctionParameters2 = 170,                      // <Function Parameters> ::= <Parameter Array> <With Array>
		@WithArray_with_LParen_RParen = 171,             // <With Array> ::= with '(' <Parameter List> ')'
		@ParameterArray_LParen_RParen = 172,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 173,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 174,                           // <Parameter Array> ::= 
		@ParameterList = 175,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 176,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 177,                 // <Parameter Name> ::= Identifier
		@CallExpression = 178,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 179,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 180,                        // <New Expression> ::= new <ClassName ID> <Argument Array>
		@ArgumentArray_LParen_RParen = 181,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 182,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 183,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 184,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 185,                              // <Flow Control> ::= <If Control>
		@FlowControl2 = 186,                             // <Flow Control> ::= <While Control>
		@FlowControl3 = 187,                             // <Flow Control> ::= <Until Control>
		@FlowControl4 = 188,                             // <Flow Control> ::= <Do While Control>
		@FlowControl5 = 189,                             // <Flow Control> ::= <Do Until Control>
		@FlowControl6 = 190,                             // <Flow Control> ::= <For Control>
		@FlowControl7 = 191,                             // <Flow Control> ::= <Each Control>
		@FlowControl8 = 192,                             // <Flow Control> ::= <Break Control> <End>
		@FlowControl9 = 193,                             // <Flow Control> ::= <Continue Control> <End>
		@IfControl_if_LParen_RParen = 194,               // <If Control> ::= if '(' <Expression> ')' <Block>
		@IfControl_if_LParen_RParen_else = 195,          // <If Control> ::= if '(' <Expression> ')' <Block> else <Block>
		@WhileControl_while = 196,                       // <While Control> ::= while <While Expression> <Block>
		@UntilControl_until = 197,                       // <Until Control> ::= until <While Expression> <Block>
		@DoWhileControl_do_while = 198,                  // <Do While Control> ::= do <Block> while <While Expression>
		@DoUntilControl_do_until = 199,                  // <Do Until Control> ::= do <Block> until <While Expression>
		@WhileExpression_LParen_RParen = 200,            // <While Expression> ::= '(' <Expression> ')'
		@ForControl_for = 201,                           // <For Control> ::= for <For Declare> <For Expression> <For Step> <Block>
		@ForDeclare_LParen = 202,                        // <For Declare> ::= '(' <Variable Statements> <End>
		@ForDeclare_LParen2 = 203,                       // <For Declare> ::= '(' <End>
		@ForExpression = 204,                            // <For Expression> ::= <Expression> <End>
		@ForExpression2 = 205,                           // <For Expression> ::= <End>
		@ForStep_RParen = 206,                           // <For Step> ::= <Expression> ')'
		@ForStep_RParen2 = 207,                          // <For Step> ::= ')'
		@EachControl_each = 208,                         // <Each Control> ::= each <Plural ID> <Block>
		@PluralID_LParen_RParen = 209,                   // <Plural ID> ::= '(' <Expression> ')'
		@PluralID_LParen_as_Identifier_RParen = 210,     // <Plural ID> ::= '(' <Expression> as Identifier ')'
		@BreakControl_break = 211,                       // <Break Control> ::= break
		@ContinueControl_continue = 212,                 // <Continue Control> ::= continue
		@AllProcedures = 213,                            // <All Procedures> ::= <Unset Proc>
		@AllProcedures2 = 214,                           // <All Procedures> ::= <Print Proc>
		@AllProcedures3 = 215,                           // <All Procedures> ::= <Return Proc>
		@AllProcedures4 = 216,                           // <All Procedures> ::= <Assert Proc>
		@AllProcedures5 = 217,                           // <All Procedures> ::= <Fail Proc>
		@AllProcedures6 = 218,                           // <All Procedures> ::= <List Vars>
		@UnsetProc_unset = 219,                          // <Unset Proc> ::= unset <Qualified ID>
		@PrintProc_print = 220,                          // <Print Proc> ::= print <Expression>
		@ReturnProc_return = 221,                        // <Return Proc> ::= return <Expression>
		@ReturnProc_return2 = 222,                       // <Return Proc> ::= return
		@AssertProc_assert = 223,                        // <Assert Proc> ::= assert <Expression>
		@FailProc_fail = 224,                            // <Fail Proc> ::= fail <Expression>
		@FailProc_fail2 = 225,                           // <Fail Proc> ::= fail
		@ListVars_vars = 226,                            // <List Vars> ::= vars
		@AllFunctions = 227,                             // <All Functions> ::= <Variable Functions>
		@VariableFunctions = 228,                        // <Variable Functions> ::= <Isset Func>
		@VariableFunctions2 = 229,                       // <Variable Functions> ::= <TypeOf Func>
		@IssetFunc_isset = 230,                          // <Isset Func> ::= isset <Qualified ID>
		@TypeOfFunc_typeof_LParen_RParen = 231           // <TypeOf Func> ::= typeof '(' <Expression> ')'
	}
}
