
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
		@Statement = 13,                                 // <Statement> ::= <Flow Control> <End>
		@Statement2 = 14,                                // <Statement> ::= <Function Decl> <End>
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
		@BlockorEnd = 35,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 36,                               // <Block or End> ::= <End>
		@Expression = 37,                                // <Expression> ::= <Search Chain>
		@SearchChain = 38,                               // <Search Chain> ::= <Contains Term>
		@ContainsTerm_CONTAINS = 39,                     // <Contains Term> ::= <Contains Term> CONTAINS <Boolean Chain>
		@ContainsTerm_HAS = 40,                          // <Contains Term> ::= <Contains Term> HAS <Boolean Chain>
		@ContainsTerm = 41,                              // <Contains Term> ::= <Boolean Chain>
		@BooleanChain = 42,                              // <Boolean Chain> ::= <Gt Operator>
		@GtOperator_Gt = 43,                             // <Gt Operator> ::= <Gt Operator> '>' <Lt Operator>
		@GtOperator = 44,                                // <Gt Operator> ::= <Lt Operator>
		@LtOperator_Lt = 45,                             // <Lt Operator> ::= <Lt Operator> '<' <Gte Operator>
		@LtOperator = 46,                                // <Lt Operator> ::= <Gte Operator>
		@GteOperator_GtEq = 47,                          // <Gte Operator> ::= <Gte Operator> '>=' <Lte Operator>
		@GteOperator = 48,                               // <Gte Operator> ::= <Lte Operator>
		@LteOperator_LtEq = 49,                          // <Lte Operator> ::= <Lte Operator> '<=' <Equal Operator>
		@LteOperator = 50,                               // <Lte Operator> ::= <Equal Operator>
		@EqualOperator_EqEq = 51,                        // <Equal Operator> ::= <Equal Operator> '==' <Not Equal Operator>
		@EqualOperator = 52,                             // <Equal Operator> ::= <Not Equal Operator>
		@NotEqualOperator_ExclamEq = 53,                 // <Not Equal Operator> ::= <Not Equal Operator> '!=' <And Operator>
		@NotEqualOperator_LtGt = 54,                     // <Not Equal Operator> ::= <Not Equal Operator> '<>' <And Operator>
		@NotEqualOperator = 55,                          // <Not Equal Operator> ::= <And Operator>
		@AndOperator_AND = 56,                           // <And Operator> ::= <And Operator> AND <Or Operator>
		@AndOperator_AmpAmp = 57,                        // <And Operator> ::= <And Operator> '&&' <Or Operator>
		@AndOperator = 58,                               // <And Operator> ::= <Or Operator>
		@OrOperator_OR = 59,                             // <Or Operator> ::= <Or Operator> OR <Math Chain>
		@OrOperator_PipePipe = 60,                       // <Or Operator> ::= <Or Operator> '||' <Math Chain>
		@OrOperator = 61,                                // <Or Operator> ::= <Math Chain>
		@MathChain = 62,                                 // <Math Chain> ::= <Add Expression>
		@AddExpression_Plus = 63,                        // <Add Expression> ::= <Add Expression> '+' <Sub Expression>
		@AddExpression = 64,                             // <Add Expression> ::= <Sub Expression>
		@SubExpression_Minus = 65,                       // <Sub Expression> ::= <Sub Expression> '-' <Multiply Expression>
		@SubExpression = 66,                             // <Sub Expression> ::= <Multiply Expression>
		@MultiplyExpression_Times = 67,                  // <Multiply Expression> ::= <Multiply Expression> '*' <Divide Expression>
		@MultiplyExpression = 68,                        // <Multiply Expression> ::= <Divide Expression>
		@DivideExpression_Div = 69,                      // <Divide Expression> ::= <Divide Expression> '/' <Remainder Expression>
		@DivideExpression = 70,                          // <Divide Expression> ::= <Remainder Expression>
		@RemainderExpression_Percent = 71,               // <Remainder Expression> ::= <Remainder Expression> '%' <Unary Chain>
		@RemainderExpression = 72,                       // <Remainder Expression> ::= <Unary Chain>
		@UnaryChain = 73,                                // <Unary Chain> ::= <Not Operator>
		@NotOperator_Exclam = 74,                        // <Not Operator> ::= '!' <Value>
		@NotOperator_NOT = 75,                           // <Not Operator> ::= NOT <Value>
		@NotOperator = 76,                               // <Not Operator> ::= <Bit Invert Operator>
		@BitInvertOperator_Tilde = 77,                   // <Bit Invert Operator> ::= '~' <Value>
		@BitInvertOperator = 78,                         // <Bit Invert Operator> ::= <Neg Operator>
		@NegOperator_Minus = 79,                         // <Neg Operator> ::= '-' <Value>
		@NegOperator = 80,                               // <Neg Operator> ::= <Plus Operator>
		@PlusOperator_Plus = 81,                         // <Plus Operator> ::= '+' <Value>
		@PlusOperator = 82,                              // <Plus Operator> ::= <Pre Dec Operator>
		@PreDecOperator_MinusMinus = 83,                 // <Pre Dec Operator> ::= '--' <Qualified ID>
		@PreDecOperator = 84,                            // <Pre Dec Operator> ::= <Post Dec Operator>
		@PostDecOperator_MinusMinus = 85,                // <Post Dec Operator> ::= <Qualified ID> '--'
		@PostDecOperator = 86,                           // <Post Dec Operator> ::= <Pre Inc Operator>
		@PreIncOperator_PlusPlus = 87,                   // <Pre Inc Operator> ::= '++' <Qualified ID>
		@PreIncOperator = 88,                            // <Pre Inc Operator> ::= <Post Inc Operator>
		@PostIncOperator_PlusPlus = 89,                  // <Post Inc Operator> ::= <Qualified ID> '++'
		@PostIncOperator = 90,                           // <Post Inc Operator> ::= <Each Operator>
		@EachOperator = 91,                              // <Each Operator> ::= <Each Control>
		@EachOperator2 = 92,                             // <Each Operator> ::= <Value>
		@ValidID_Identifier = 93,                        // <Valid ID> ::= Identifier
		@MemberID_MemberName = 94,                       // <Member ID> ::= MemberName
		@ClassNameID = 95,                               // <ClassName ID> ::= <Valid ID> <ClassName List>
		@ClassNameList = 96,                             // <ClassName List> ::= <Member ID> <ClassName List>
		@ClassNameList2 = 97,                            // <ClassName List> ::= 
		@NameSpace = 98,                                 // <NameSpace> ::= 
		@QualifiedID = 99,                               // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 100,                            // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 101,          // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 102,                           // <Qualified List> ::= 
		@Value_StringDouble = 103,                       // <Value> ::= StringDouble
		@Value_StringSingle = 104,                       // <Value> ::= StringSingle
		@Value_RegExpSlash = 105,                        // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 106,                         // <Value> ::= RegExpPipe
		@Value_Number = 107,                             // <Value> ::= Number
		@Value_Decimal = 108,                            // <Value> ::= Decimal
		@Value_Boolean = 109,                            // <Value> ::= Boolean
		@Value_Undefined = 110,                          // <Value> ::= Undefined
		@Value = 111,                                    // <Value> ::= <Array Literal>
		@Value2 = 112,                                   // <Value> ::= <Qualified ID>
		@Value3 = 113,                                   // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 114,                      // <Value> ::= '(' <Expression> ')'
		@Value4 = 115,                                   // <Value> ::= <Call Expression>
		@Value5 = 116,                                   // <Value> ::= <All Functions>
		@VariableStatements = 117,                       // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 118,                      // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 119,                      // <Variable Statements> ::= <Post Increment>
		@VariableStatements4 = 120,                      // <Variable Statements> ::= <Pre Increment>
		@VariableStatements5 = 121,                      // <Variable Statements> ::= <Post Decrement>
		@VariableStatements6 = 122,                      // <Variable Statements> ::= <Pre Decrement>
		@ArrayLiteral_LBracket_RBracket = 123,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 124,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 125,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 126,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 127,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 128,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 129,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 130,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@PostIncrement_PlusPlus = 131,                   // <Post Increment> ::= <Qualified ID> '++'
		@PreIncrement_PlusPlus = 132,                    // <Pre Increment> ::= '++' <Qualified ID>
		@PostDecrement_MinusMinus = 133,                 // <Post Decrement> ::= <Qualified ID> '--'
		@PreDecrement_MinusMinus = 134,                  // <Pre Decrement> ::= '--' <Qualified ID>
		@ImportDecls = 135,                              // <Import Decls> ::= <Import Decl>
		@ImportDecls2 = 136,                             // <Import Decls> ::= <Import Decls> <Import Decl>
		@ImportDecls3 = 137,                             // <Import Decls> ::= 
		@ImportDecl_use_StringDouble = 138,              // <Import Decl> ::= use StringDouble <End>
		@ObjectDecls = 139,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 140,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecls3 = 141,                             // <Object Decls> ::= 
		@ObjectDecl_object = 142,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block> <End>
		@ObjectBlock = 143,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 144,                   // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
		@BaseClassID = 145,                              // <BaseClass ID> ::= <Valid ID>
		@FunctionDecl_function_Identifier = 146,         // <Function Decl> ::= function Identifier <Parameter Array> <Block>
		@FunctionBlock = 147,                            // <Function Block> ::= 
		@FunctionExpression_function = 148,              // <Function Expression> ::= function <Parameter Array> <Block>
		@ParameterArray_LParen_RParen = 149,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 150,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 151,                           // <Parameter Array> ::= 
		@ParameterList = 152,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 153,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 154,                 // <Parameter Name> ::= Identifier
		@CallExpression = 155,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 156,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 157,                        // <New Expression> ::= new <ClassName ID> <Argument Array>
		@ArgumentArray_LParen_RParen = 158,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 159,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 160,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 161,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 162,                              // <Flow Control> ::= <If Control>
		@FlowControl2 = 163,                             // <Flow Control> ::= <Do While Control>
		@FlowControl3 = 164,                             // <Flow Control> ::= <Do Until Control>
		@FlowControl4 = 165,                             // <Flow Control> ::= <Loop While Control>
		@FlowControl5 = 166,                             // <Flow Control> ::= <Loop Until Control>
		@FlowControl6 = 167,                             // <Flow Control> ::= <For Control>
		@FlowControl7 = 168,                             // <Flow Control> ::= <Each Control>
		@FlowControl8 = 169,                             // <Flow Control> ::= <Break Control>
		@FlowControl9 = 170,                             // <Flow Control> ::= <Continue Control>
		@IfControl_if_LParen_RParen = 171,               // <If Control> ::= if '(' <Expression> ')' <Block>
		@IfControl_if_LParen_RParen_else = 172,          // <If Control> ::= if '(' <Expression> ')' <Block> else <Block>
		@DoWhileControl_while_LParen_RParen = 173,       // <Do While Control> ::= while '(' <Expression> ')' <Block>
		@DoUntilControl_until_LParen_RParen = 174,       // <Do Until Control> ::= until '(' <Expression> ')' <Block>
		@LoopWhileControl_do_while_LParen_RParen = 175,  // <Loop While Control> ::= do <Block> while '(' <Expression> ')'
		@LoopUntilControl_do_until_LParen_RParen = 176,  // <Loop Until Control> ::= do <Block> until '(' <Expression> ')'
		@ForControl_for_LParen_RParen = 177,             // <For Control> ::= for '(' <For Declare> <For Expression> <For Step> ')' <Block>
		@ForDeclare = 178,                               // <For Declare> ::= <Variable Statements> <End>
		@ForDeclare2 = 179,                              // <For Declare> ::= <End>
		@ForExpression = 180,                            // <For Expression> ::= <Expression> <End>
		@ForExpression2 = 181,                           // <For Expression> ::= <End>
		@ForStep = 182,                                  // <For Step> ::= <Variable Statements>
		@ForStep2 = 183,                                 // <For Step> ::= 
		@EachControl_each = 184,                         // <Each Control> ::= each <Plural ID> <Block>
		@PluralID = 185,                                 // <Plural ID> ::= <Expression>
		@PluralID_as_Identifier = 186,                   // <Plural ID> ::= <Expression> as Identifier
		@BreakControl_break = 187,                       // <Break Control> ::= break
		@ContinueControl_continue = 188,                 // <Continue Control> ::= continue
		@AllProcedures = 189,                            // <All Procedures> ::= <Unset Proc>
		@AllProcedures2 = 190,                           // <All Procedures> ::= <Print Proc>
		@AllProcedures3 = 191,                           // <All Procedures> ::= <Return Proc>
		@AllProcedures4 = 192,                           // <All Procedures> ::= <Assert Proc>
		@AllProcedures5 = 193,                           // <All Procedures> ::= <Fail Proc>
		@AllProcedures6 = 194,                           // <All Procedures> ::= <List Vars>
		@UnsetProc_unset = 195,                          // <Unset Proc> ::= unset <Qualified ID>
		@PrintProc_print = 196,                          // <Print Proc> ::= print <Expression>
		@ReturnProc_return = 197,                        // <Return Proc> ::= return <Expression>
		@ReturnProc_return2 = 198,                       // <Return Proc> ::= return
		@AssertProc_assert = 199,                        // <Assert Proc> ::= assert <Expression>
		@FailProc_fail = 200,                            // <Fail Proc> ::= fail <Expression>
		@FailProc_fail2 = 201,                           // <Fail Proc> ::= fail
		@ListVars_vars = 202,                            // <List Vars> ::= vars
		@CallGeneric_Identifier = 203,                   // <Call Generic> ::= Identifier <Argument Array>
		@AllFunctions = 204,                             // <All Functions> ::= <Variable Functions>
		@VariableFunctions = 205,                        // <Variable Functions> ::= <Isset Func>
		@VariableFunctions2 = 206,                       // <Variable Functions> ::= <TypeOf Func>
		@IssetFunc_isset = 207,                          // <Isset Func> ::= isset <Qualified ID>
		@TypeOfFunc_typeof = 208                         // <TypeOf Func> ::= typeof <Expression>
	}
}
