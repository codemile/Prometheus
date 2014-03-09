
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
		@ContainsTerm_CONTAINS = 37,                     // <Contains Term> ::= <Contains Term> CONTAINS <Quantifier Type> <Boolean Chain>
		@ContainsTerm = 38,                              // <Contains Term> ::= <Boolean Chain>
		@QuantifierType_Quantifier = 39,                 // <Quantifier Type> ::= Quantifier
		@QuantifierType = 40,                            // <Quantifier Type> ::= 
		@BooleanChain = 41,                              // <Boolean Chain> ::= <Gt Operator>
		@GtOperator_Gt = 42,                             // <Gt Operator> ::= <Gt Operator> '>' <Lt Operator>
		@GtOperator = 43,                                // <Gt Operator> ::= <Lt Operator>
		@LtOperator_Lt = 44,                             // <Lt Operator> ::= <Lt Operator> '<' <Gte Operator>
		@LtOperator = 45,                                // <Lt Operator> ::= <Gte Operator>
		@GteOperator_GtEq = 46,                          // <Gte Operator> ::= <Gte Operator> '>=' <Lte Operator>
		@GteOperator = 47,                               // <Gte Operator> ::= <Lte Operator>
		@LteOperator_LtEq = 48,                          // <Lte Operator> ::= <Lte Operator> '<=' <Equal Operator>
		@LteOperator = 49,                               // <Lte Operator> ::= <Equal Operator>
		@EqualOperator_EqEq = 50,                        // <Equal Operator> ::= <Equal Operator> '==' <Not Equal Operator>
		@EqualOperator = 51,                             // <Equal Operator> ::= <Not Equal Operator>
		@NotEqualOperator_ExclamEq = 52,                 // <Not Equal Operator> ::= <Not Equal Operator> '!=' <And Operator>
		@NotEqualOperator_LtGt = 53,                     // <Not Equal Operator> ::= <Not Equal Operator> '<>' <And Operator>
		@NotEqualOperator = 54,                          // <Not Equal Operator> ::= <And Operator>
		@AndOperator_AND = 55,                           // <And Operator> ::= <And Operator> AND <Or Operator>
		@AndOperator_AmpAmp = 56,                        // <And Operator> ::= <And Operator> '&&' <Or Operator>
		@AndOperator = 57,                               // <And Operator> ::= <Or Operator>
		@OrOperator_OR = 58,                             // <Or Operator> ::= <Or Operator> OR <Math Chain>
		@OrOperator_PipePipe = 59,                       // <Or Operator> ::= <Or Operator> '||' <Math Chain>
		@OrOperator = 60,                                // <Or Operator> ::= <Math Chain>
		@MathChain = 61,                                 // <Math Chain> ::= <Add Expression>
		@AddExpression_Plus = 62,                        // <Add Expression> ::= <Add Expression> '+' <Sub Expression>
		@AddExpression = 63,                             // <Add Expression> ::= <Sub Expression>
		@SubExpression_Minus = 64,                       // <Sub Expression> ::= <Sub Expression> '-' <Multiply Expression>
		@SubExpression = 65,                             // <Sub Expression> ::= <Multiply Expression>
		@MultiplyExpression_Times = 66,                  // <Multiply Expression> ::= <Multiply Expression> '*' <Divide Expression>
		@MultiplyExpression = 67,                        // <Multiply Expression> ::= <Divide Expression>
		@DivideExpression_Div = 68,                      // <Divide Expression> ::= <Divide Expression> '/' <Remainder Expression>
		@DivideExpression = 69,                          // <Divide Expression> ::= <Remainder Expression>
		@RemainderExpression_Percent = 70,               // <Remainder Expression> ::= <Remainder Expression> '%' <Unary Chain>
		@RemainderExpression = 71,                       // <Remainder Expression> ::= <Unary Chain>
		@UnaryChain = 72,                                // <Unary Chain> ::= <Not Operator>
		@NotOperator_Exclam = 73,                        // <Not Operator> ::= '!' <Value>
		@NotOperator_NOT = 74,                           // <Not Operator> ::= NOT <Value>
		@NotOperator = 75,                               // <Not Operator> ::= <Bit Invert Operator>
		@BitInvertOperator_Tilde = 76,                   // <Bit Invert Operator> ::= '~' <Value>
		@BitInvertOperator = 77,                         // <Bit Invert Operator> ::= <Neg Operator>
		@NegOperator_Minus = 78,                         // <Neg Operator> ::= '-' <Value>
		@NegOperator = 79,                               // <Neg Operator> ::= <Plus Operator>
		@PlusOperator_Plus = 80,                         // <Plus Operator> ::= '+' <Value>
		@PlusOperator = 81,                              // <Plus Operator> ::= <Pre Dec Operator>
		@PreDecOperator_MinusMinus = 82,                 // <Pre Dec Operator> ::= '--' <Qualified ID>
		@PreDecOperator = 83,                            // <Pre Dec Operator> ::= <Post Dec Operator>
		@PostDecOperator_MinusMinus = 84,                // <Post Dec Operator> ::= <Qualified ID> '--'
		@PostDecOperator = 85,                           // <Post Dec Operator> ::= <Pre Inc Operator>
		@PreIncOperator_PlusPlus = 86,                   // <Pre Inc Operator> ::= '++' <Qualified ID>
		@PreIncOperator = 87,                            // <Pre Inc Operator> ::= <Post Inc Operator>
		@PostIncOperator_PlusPlus = 88,                  // <Post Inc Operator> ::= <Qualified ID> '++'
		@PostIncOperator = 89,                           // <Post Inc Operator> ::= <Each Operator>
		@EachOperator = 90,                              // <Each Operator> ::= <Each Control>
		@EachOperator2 = 91,                             // <Each Operator> ::= <Type Chain>
		@TypeChain = 92,                                 // <Type Chain> ::= <Is Operator>
		@IsOperator_IS = 93,                             // <Is Operator> ::= <Qualified ID> IS <Qualified ID>
		@IsOperator_IS2 = 94,                            // <Is Operator> ::= <Qualified ID> IS <Types>
		@IsOperator = 95,                                // <Is Operator> ::= <Is Not Operator>
		@IsNotOperator_IS_NOT = 96,                      // <Is Not Operator> ::= <Qualified ID> IS NOT <Qualified ID>
		@IsNotOperator_IS_NOT2 = 97,                     // <Is Not Operator> ::= <Qualified ID> IS NOT <Types>
		@IsNotOperator = 98,                             // <Is Not Operator> ::= <Value>
		@Types_number = 99,                              // <Types> ::= number
		@Types_integer = 100,                            // <Types> ::= integer
		@Types_float = 101,                              // <Types> ::= float
		@Types_string = 102,                             // <Types> ::= string
		@Types_regex = 103,                              // <Types> ::= regex
		@Types_function = 104,                           // <Types> ::= function
		@Types_closure = 105,                            // <Types> ::= closure
		@Types_object = 106,                             // <Types> ::= object
		@Types_class = 107,                              // <Types> ::= class
		@Types_array = 108,                              // <Types> ::= array
		@Types_Undefined = 109,                          // <Types> ::= Undefined
		@Types_package = 110,                            // <Types> ::= package
		@ValidID_Identifier = 111,                       // <Valid ID> ::= Identifier
		@MemberID_MemberName = 112,                      // <Member ID> ::= MemberName
		@ClassNameID = 113,                              // <ClassName ID> ::= <Valid ID> <ClassName List>
		@ClassNameList = 114,                            // <ClassName List> ::= <Member ID> <ClassName List>
		@ClassNameList2 = 115,                           // <ClassName List> ::= 
		@QualifiedID = 116,                              // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 117,                            // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 118,          // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 119,                           // <Qualified List> ::= 
		@Value_StringDouble = 120,                       // <Value> ::= StringDouble
		@Value_StringSingle = 121,                       // <Value> ::= StringSingle
		@Value_RegExpSlash = 122,                        // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 123,                         // <Value> ::= RegExpPipe
		@Value_Numeric = 124,                            // <Value> ::= Numeric
		@Value_Decimal = 125,                            // <Value> ::= Decimal
		@Value_Boolean = 126,                            // <Value> ::= Boolean
		@Value_Undefined = 127,                          // <Value> ::= Undefined
		@Value = 128,                                    // <Value> ::= <Array Literal>
		@Value2 = 129,                                   // <Value> ::= <Qualified ID>
		@Value3 = 130,                                   // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 131,                      // <Value> ::= '(' <Expression> ')'
		@Value4 = 132,                                   // <Value> ::= <Call Expression>
		@Value5 = 133,                                   // <Value> ::= <All Functions>
		@VariableStatements = 134,                       // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 135,                      // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 136,                      // <Variable Statements> ::= <Post Increment>
		@VariableStatements4 = 137,                      // <Variable Statements> ::= <Pre Increment>
		@VariableStatements5 = 138,                      // <Variable Statements> ::= <Post Decrement>
		@VariableStatements6 = 139,                      // <Variable Statements> ::= <Pre Decrement>
		@ArrayLiteral_LBracket_RBracket = 140,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 141,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 142,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 143,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 144,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 145,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 146,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 147,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@PostIncrement_PlusPlus = 148,                   // <Post Increment> ::= <Qualified ID> '++'
		@PreIncrement_PlusPlus = 149,                    // <Pre Increment> ::= '++' <Qualified ID>
		@PostDecrement_MinusMinus = 150,                 // <Post Decrement> ::= <Qualified ID> '--'
		@PreDecrement_MinusMinus = 151,                  // <Pre Decrement> ::= '--' <Qualified ID>
		@PackageDetails = 152,                           // <Package Details> ::= <Package ID> <Import Decls>
		@ImportDecls = 153,                              // <Import Decls> ::= <Import Decl>
		@ImportDecls2 = 154,                             // <Import Decls> ::= <Import Decls> <Import Decl>
		@ImportDecls3 = 155,                             // <Import Decls> ::= 
		@PackageID_package = 156,                        // <Package ID> ::= package <Qualified ID> <End>
		@ImportDecl_use_StringDouble = 157,              // <Import Decl> ::= use StringDouble <End>
		@ImportDecl_use_StringSingle = 158,              // <Import Decl> ::= use StringSingle <End>
		@ImportDecl_use = 159,                           // <Import Decl> ::= use <Qualified ID> <End>
		@ObjectDecls = 160,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 161,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecls3 = 162,                             // <Object Decls> ::= 
		@ObjectDecl_object = 163,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block>
		@ObjectBlock = 164,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 165,                   // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
		@BaseClassID = 166,                              // <BaseClass ID> ::= <Valid ID>
		@FunctionDecl_function_Identifier = 167,         // <Function Decl> ::= function Identifier <Function Parameters> <Block>
		@FunctionBlock = 168,                            // <Function Block> ::= 
		@FunctionExpression_function = 169,              // <Function Expression> ::= function <Function Parameters> <Block>
		@FunctionParameters = 170,                       // <Function Parameters> ::= <Parameter Array>
		@FunctionParameters2 = 171,                      // <Function Parameters> ::= <Parameter Array> <With Array>
		@WithArray_with_LParen_RParen = 172,             // <With Array> ::= with '(' <Parameter List> ')'
		@ParameterArray_LParen_RParen = 173,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 174,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 175,                           // <Parameter Array> ::= 
		@ParameterList = 176,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 177,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 178,                 // <Parameter Name> ::= Identifier
		@CallExpression = 179,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 180,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 181,                        // <New Expression> ::= new <ClassName ID> <Argument Array>
		@ArgumentArray_LParen_RParen = 182,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 183,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 184,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 185,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 186,                              // <Flow Control> ::= <If Control>
		@FlowControl2 = 187,                             // <Flow Control> ::= <While Control>
		@FlowControl3 = 188,                             // <Flow Control> ::= <Until Control>
		@FlowControl4 = 189,                             // <Flow Control> ::= <Do While Control>
		@FlowControl5 = 190,                             // <Flow Control> ::= <Do Until Control>
		@FlowControl6 = 191,                             // <Flow Control> ::= <For Control>
		@FlowControl7 = 192,                             // <Flow Control> ::= <Each Control>
		@FlowControl8 = 193,                             // <Flow Control> ::= <Break Control> <End>
		@FlowControl9 = 194,                             // <Flow Control> ::= <Continue Control> <End>
		@IfControl_if_LParen_RParen = 195,               // <If Control> ::= if '(' <Expression> ')' <Block>
		@IfControl_if_LParen_RParen_else = 196,          // <If Control> ::= if '(' <Expression> ')' <Block> else <Block>
		@WhileControl_while = 197,                       // <While Control> ::= while <While Expression> <Block>
		@UntilControl_until = 198,                       // <Until Control> ::= until <While Expression> <Block>
		@DoWhileControl_do_while = 199,                  // <Do While Control> ::= do <Block> while <While Expression>
		@DoUntilControl_do_until = 200,                  // <Do Until Control> ::= do <Block> until <While Expression>
		@WhileExpression_LParen_RParen = 201,            // <While Expression> ::= '(' <Expression> ')'
		@ForControl_for = 202,                           // <For Control> ::= for <For Declare> <For Expression> <For Step> <Block>
		@ForDeclare_LParen = 203,                        // <For Declare> ::= '(' <Variable Statements> <End>
		@ForDeclare_LParen2 = 204,                       // <For Declare> ::= '(' <End>
		@ForExpression = 205,                            // <For Expression> ::= <Expression> <End>
		@ForExpression2 = 206,                           // <For Expression> ::= <End>
		@ForStep_RParen = 207,                           // <For Step> ::= <Expression> ')'
		@ForStep_RParen2 = 208,                          // <For Step> ::= ')'
		@EachControl_each = 209,                         // <Each Control> ::= each <Plural ID> <Block>
		@PluralID_LParen_RParen = 210,                   // <Plural ID> ::= '(' <Expression> ')'
		@PluralID_LParen_as_Identifier_RParen = 211,     // <Plural ID> ::= '(' <Expression> as Identifier ')'
		@BreakControl_break = 212,                       // <Break Control> ::= break
		@ContinueControl_continue = 213,                 // <Continue Control> ::= continue
		@AllProcedures = 214,                            // <All Procedures> ::= <Unset Proc>
		@AllProcedures2 = 215,                           // <All Procedures> ::= <Print Proc>
		@AllProcedures3 = 216,                           // <All Procedures> ::= <Return Proc>
		@AllProcedures4 = 217,                           // <All Procedures> ::= <Assert Proc>
		@AllProcedures5 = 218,                           // <All Procedures> ::= <Fail Proc>
		@AllProcedures6 = 219,                           // <All Procedures> ::= <List Vars>
		@UnsetProc_unset = 220,                          // <Unset Proc> ::= unset <Qualified ID>
		@PrintProc_print = 221,                          // <Print Proc> ::= print <Expression>
		@ReturnProc_return = 222,                        // <Return Proc> ::= return <Expression>
		@ReturnProc_return2 = 223,                       // <Return Proc> ::= return
		@AssertProc_assert = 224,                        // <Assert Proc> ::= assert <Expression>
		@FailProc_fail = 225,                            // <Fail Proc> ::= fail <Expression>
		@FailProc_fail2 = 226,                           // <Fail Proc> ::= fail
		@ListVars_vars = 227,                            // <List Vars> ::= vars
		@AllFunctions = 228,                             // <All Functions> ::= <Variable Functions>
		@VariableFunctions = 229,                        // <Variable Functions> ::= <Isset Func>
		@VariableFunctions2 = 230,                       // <Variable Functions> ::= <TypeOf Func>
		@IssetFunc_isset = 231,                          // <Isset Func> ::= isset <Qualified ID>
		@TypeOfFunc_typeof_LParen_RParen = 232           // <TypeOf Func> ::= typeof '(' <Expression> ')'
	}
}
