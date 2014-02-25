
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
		@ProgramTest = 2,                                // <Program Test> ::= <Test Suite Decl> <Import Decls> <Test Decls> <Test Execute>
		@ProgramTest2 = 3,                               // <Program Test> ::= <Test Suite Decl> <Import Decls> <Statements> <Test Decls> <Test Execute>
		@ProgramTest3 = 4,                               // <Program Test> ::= <Test Suite Decl> <Import Decls> <Statements> <Test Decls> <Test Execute> <Statements>
		@ProgramCode = 5,                                // <Program Code> ::= <Import Decls> <Object Decls>
		@ProgramCode2 = 6,                               // <Program Code> ::= <Import Decls> <Object Decls> <Statements>
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
		@TestDecl_test = 29,                             // <Test Decl> ::= test <Valid ID> <Block> <End>
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
		@EachOperator2 = 90,                             // <Each Operator> ::= <Value>
		@ValidID_Identifier = 91,                        // <Valid ID> ::= Identifier
		@MemberID_MemberName = 92,                       // <Member ID> ::= MemberName
		@ClassNameID = 93,                               // <ClassName ID> ::= <Valid ID> <ClassName List>
		@ClassNameList = 94,                             // <ClassName List> ::= <Member ID> <ClassName List>
		@ClassNameList2 = 95,                            // <ClassName List> ::= 
		@NameSpace = 96,                                 // <NameSpace> ::= 
		@QualifiedID = 97,                               // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 98,                             // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 99,           // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 100,                           // <Qualified List> ::= 
		@Value_StringDouble = 101,                       // <Value> ::= StringDouble
		@Value_StringSingle = 102,                       // <Value> ::= StringSingle
		@Value_RegExpSlash = 103,                        // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 104,                         // <Value> ::= RegExpPipe
		@Value_Number = 105,                             // <Value> ::= Number
		@Value_Decimal = 106,                            // <Value> ::= Decimal
		@Value_Boolean = 107,                            // <Value> ::= Boolean
		@Value_Undefined = 108,                          // <Value> ::= Undefined
		@Value = 109,                                    // <Value> ::= <Array Literal>
		@Value2 = 110,                                   // <Value> ::= <Qualified ID>
		@Value3 = 111,                                   // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 112,                      // <Value> ::= '(' <Expression> ')'
		@Value4 = 113,                                   // <Value> ::= <Call Expression>
		@Value5 = 114,                                   // <Value> ::= <All Functions>
		@VariableStatements = 115,                       // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 116,                      // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 117,                      // <Variable Statements> ::= <Post Increment>
		@VariableStatements4 = 118,                      // <Variable Statements> ::= <Pre Increment>
		@VariableStatements5 = 119,                      // <Variable Statements> ::= <Post Decrement>
		@VariableStatements6 = 120,                      // <Variable Statements> ::= <Pre Decrement>
		@ArrayLiteral_LBracket_RBracket = 121,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 122,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 123,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 124,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 125,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 126,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 127,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 128,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@PostIncrement_PlusPlus = 129,                   // <Post Increment> ::= <Qualified ID> '++'
		@PreIncrement_PlusPlus = 130,                    // <Pre Increment> ::= '++' <Qualified ID>
		@PostDecrement_MinusMinus = 131,                 // <Post Decrement> ::= <Qualified ID> '--'
		@PreDecrement_MinusMinus = 132,                  // <Pre Decrement> ::= '--' <Qualified ID>
		@ImportDecls = 133,                              // <Import Decls> ::= <Import Decl>
		@ImportDecls2 = 134,                             // <Import Decls> ::= <Import Decls> <Import Decl>
		@ImportDecls3 = 135,                             // <Import Decls> ::= 
		@ImportDecl_use_StringDouble = 136,              // <Import Decl> ::= use StringDouble <End>
		@ObjectDecls = 137,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 138,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecls3 = 139,                             // <Object Decls> ::= 
		@ObjectDecl_object = 140,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block> <End>
		@ObjectBlock = 141,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 142,                   // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
		@BaseClassID = 143,                              // <BaseClass ID> ::= <Valid ID>
		@FunctionDecl_function_Identifier = 144,         // <Function Decl> ::= function Identifier <Parameter Array> <Block>
		@FunctionBlock = 145,                            // <Function Block> ::= 
		@FunctionExpression_function = 146,              // <Function Expression> ::= function <Parameter Array> <Block>
		@ParameterArray_LParen_RParen = 147,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 148,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 149,                           // <Parameter Array> ::= 
		@ParameterList = 150,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 151,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 152,                 // <Parameter Name> ::= Identifier
		@CallExpression = 153,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 154,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 155,                        // <New Expression> ::= new <ClassName ID> <Argument Array>
		@ArgumentArray_LParen_RParen = 156,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 157,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 158,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 159,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 160,                              // <Flow Control> ::= <If Control>
		@FlowControl2 = 161,                             // <Flow Control> ::= <Do While Control>
		@FlowControl3 = 162,                             // <Flow Control> ::= <Do Until Control>
		@FlowControl4 = 163,                             // <Flow Control> ::= <Loop While Control>
		@FlowControl5 = 164,                             // <Flow Control> ::= <Loop Until Control>
		@FlowControl6 = 165,                             // <Flow Control> ::= <For Control>
		@FlowControl7 = 166,                             // <Flow Control> ::= <Each Control>
		@FlowControl8 = 167,                             // <Flow Control> ::= <Break Control> <End>
		@FlowControl9 = 168,                             // <Flow Control> ::= <Continue Control> <End>
		@IfControl_if_LParen_RParen = 169,               // <If Control> ::= if '(' <Expression> ')' <Block>
		@IfControl_if_LParen_RParen_else = 170,          // <If Control> ::= if '(' <Expression> ')' <Block> else <Block>
		@DoWhileControl_while_LParen_RParen = 171,       // <Do While Control> ::= while '(' <Expression> ')' <Block>
		@DoUntilControl_until_LParen_RParen = 172,       // <Do Until Control> ::= until '(' <Expression> ')' <Block>
		@LoopWhileControl_do_while_LParen_RParen = 173,  // <Loop While Control> ::= do <Block> while '(' <Expression> ')'
		@LoopUntilControl_do_until_LParen_RParen = 174,  // <Loop Until Control> ::= do <Block> until '(' <Expression> ')'
		@ForControl_for = 175,                           // <For Control> ::= for <For Declare> <For Expression> <For Step> <Block>
		@ForDeclare_LParen = 176,                        // <For Declare> ::= '(' <Variable Statements> <End>
		@ForDeclare_LParen2 = 177,                       // <For Declare> ::= '(' <End>
		@ForExpression = 178,                            // <For Expression> ::= <Expression> <End>
		@ForExpression2 = 179,                           // <For Expression> ::= <End>
		@ForStep_RParen = 180,                           // <For Step> ::= <Expression> ')'
		@ForStep_RParen2 = 181,                          // <For Step> ::= ')'
		@EachControl_each = 182,                         // <Each Control> ::= each <Plural ID> <Block>
		@PluralID = 183,                                 // <Plural ID> ::= <Expression>
		@PluralID_as_Identifier = 184,                   // <Plural ID> ::= <Expression> as Identifier
		@BreakControl_break = 185,                       // <Break Control> ::= break
		@ContinueControl_continue = 186,                 // <Continue Control> ::= continue
		@AllProcedures = 187,                            // <All Procedures> ::= <Unset Proc>
		@AllProcedures2 = 188,                           // <All Procedures> ::= <Print Proc>
		@AllProcedures3 = 189,                           // <All Procedures> ::= <Return Proc>
		@AllProcedures4 = 190,                           // <All Procedures> ::= <Assert Proc>
		@AllProcedures5 = 191,                           // <All Procedures> ::= <Fail Proc>
		@AllProcedures6 = 192,                           // <All Procedures> ::= <List Vars>
		@UnsetProc_unset = 193,                          // <Unset Proc> ::= unset <Qualified ID>
		@PrintProc_print = 194,                          // <Print Proc> ::= print <Expression>
		@ReturnProc_return = 195,                        // <Return Proc> ::= return <Expression>
		@ReturnProc_return2 = 196,                       // <Return Proc> ::= return
		@AssertProc_assert = 197,                        // <Assert Proc> ::= assert <Expression>
		@FailProc_fail = 198,                            // <Fail Proc> ::= fail <Expression>
		@FailProc_fail2 = 199,                           // <Fail Proc> ::= fail
		@ListVars_vars = 200,                            // <List Vars> ::= vars
		@AllFunctions = 201,                             // <All Functions> ::= <Variable Functions>
		@VariableFunctions = 202,                        // <Variable Functions> ::= <Isset Func>
		@VariableFunctions2 = 203,                       // <Variable Functions> ::= <TypeOf Func>
		@IssetFunc_isset = 204,                          // <Isset Func> ::= isset <Qualified ID>
		@TypeOfFunc_typeof = 205                         // <TypeOf Func> ::= typeof <Expression>
	}
}
