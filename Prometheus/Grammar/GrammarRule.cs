
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
		@ProgramTest = 2,                                // <Program Test> ::= <TestSuite Decl> <Test Decls> <Test Execute>
		@ProgramTest2 = 3,                               // <Program Test> ::= <TestSuite Decl> <Statements> <Test Decls> <Test Execute>
		@ProgramTest3 = 4,                               // <Program Test> ::= <TestSuite Decl> <Statements> <Test Decls> <Test Execute> <Statements>
		@ProgramCode = 5,                                // <Program Code> ::= <Import Decls> <Object Decls>
		@ProgramCode2 = 6,                               // <Program Code> ::= <Import Decls> <Object Decls> <Statements>
		@Block_LBrace_RBrace = 7,                        // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 8,                       // <Block> ::= '{' '}'
		@StatementorBlock = 9,                           // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 10,                         // <Statement or Block> ::= <Block>
		@Statements = 11,                                // <Statements> ::= <Statement or Block>
		@Statements2 = 12,                               // <Statements> ::= <Statements> <Statement or Block>
		@Statement = 13,                                 // <Statement> ::= <FlowControl> <End>
		@Statement2 = 14,                                // <Statement> ::= <Variable Statements> <End>
		@Statement3 = 15,                                // <Statement> ::= <Function Decl> <End>
		@Statement4 = 16,                                // <Statement> ::= <Procedure> <End>
		@Statement5 = 17,                                // <Statement> ::= <Call Expression> <End>
		@Statement6 = 18,                                // <Statement> ::= <New Expression> <End>
		@Statement7 = 19,                                // <Statement> ::= <End>
		@TestSuiteDecl_tests = 20,                       // <TestSuite Decl> ::= tests <End>
		@TestSuiteDecl_tests_LBracket_RBracket = 21,     // <TestSuite Decl> ::= tests '[' <TestSuite Array> ']' <End>
		@TestSuiteArray = 22,                            // <TestSuite Array> ::= <Valid ID>
		@TestSuiteArray_Comma = 23,                      // <TestSuite Array> ::= <Valid ID> ',' <TestSuite Array>
		@TestSuiteArray2 = 24,                           // <TestSuite Array> ::= 
		@TestDecls = 25,                                 // <Test Decls> ::= <Test Decl>
		@TestDecls2 = 26,                                // <Test Decls> ::= <Test Decls> <Test Decl>
		@TestDecl_test = 27,                             // <Test Decl> ::= test <Valid ID> <Block> <End>
		@TestBlock = 28,                                 // <Test Block> ::= 
		@TestExecute = 29,                               // <Test Execute> ::= 
		@End_Semi = 30,                                  // <End> ::= ';'
		@EndOpt = 31,                                    // <End Opt> ::= <End>
		@EndOpt2 = 32,                                   // <End Opt> ::= 
		@BlockorEnd = 33,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 34,                               // <Block or End> ::= <End>
		@Expression = 35,                                // <Expression> ::= <SearchChain>
		@SearchChain = 36,                               // <SearchChain> ::= <ContainsTerm>
		@ContainsTerm_CONTAINS = 37,                     // <ContainsTerm> ::= <ContainsTerm> CONTAINS <BooleanChain>
		@ContainsTerm_HAS = 38,                          // <ContainsTerm> ::= <ContainsTerm> HAS <BooleanChain>
		@ContainsTerm = 39,                              // <ContainsTerm> ::= <BooleanChain>
		@BooleanChain = 40,                              // <BooleanChain> ::= <GtOperator>
		@GtOperator_Gt = 41,                             // <GtOperator> ::= <GtOperator> '>' <LtOperator>
		@GtOperator = 42,                                // <GtOperator> ::= <LtOperator>
		@LtOperator_Lt = 43,                             // <LtOperator> ::= <LtOperator> '<' <GteOperator>
		@LtOperator = 44,                                // <LtOperator> ::= <GteOperator>
		@GteOperator_GtEq = 45,                          // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
		@GteOperator = 46,                               // <GteOperator> ::= <LteOperator>
		@LteOperator_LtEq = 47,                          // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
		@LteOperator = 48,                               // <LteOperator> ::= <EqualOperator>
		@EqualOperator_EqEq = 49,                        // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
		@EqualOperator = 50,                             // <EqualOperator> ::= <NotEqualOperator>
		@NotEqualOperator_ExclamEq = 51,                 // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
		@NotEqualOperator_LtGt = 52,                     // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
		@NotEqualOperator = 53,                          // <NotEqualOperator> ::= <AndOperator>
		@AndOperator_AND = 54,                           // <AndOperator> ::= <AndOperator> AND <OrOperator>
		@AndOperator_AmpAmp = 55,                        // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
		@AndOperator = 56,                               // <AndOperator> ::= <OrOperator>
		@OrOperator_OR = 57,                             // <OrOperator> ::= <OrOperator> OR <MathChain>
		@OrOperator_PipePipe = 58,                       // <OrOperator> ::= <OrOperator> '||' <MathChain>
		@OrOperator = 59,                                // <OrOperator> ::= <MathChain>
		@MathChain = 60,                                 // <MathChain> ::= <AddExpression>
		@AddExpression_Plus = 61,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 62,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 63,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 64,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 65,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 66,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 67,                      // <DivideExpression> ::= <DivideExpression> '/' <RemainderExpression>
		@DivideExpression = 68,                          // <DivideExpression> ::= <RemainderExpression>
		@RemainderExpression_Percent = 69,               // <RemainderExpression> ::= <RemainderExpression> '%' <UnaryChain>
		@RemainderExpression = 70,                       // <RemainderExpression> ::= <UnaryChain>
		@UnaryChain = 71,                                // <UnaryChain> ::= <NotOperator>
		@NotOperator_Exclam = 72,                        // <NotOperator> ::= '!' <Value>
		@NotOperator_NOT = 73,                           // <NotOperator> ::= NOT <Value>
		@NotOperator = 74,                               // <NotOperator> ::= <BitInvertOperator>
		@BitInvertOperator_Tilde = 75,                   // <BitInvertOperator> ::= '~' <Value>
		@BitInvertOperator = 76,                         // <BitInvertOperator> ::= <NegOperator>
		@NegOperator_Minus = 77,                         // <NegOperator> ::= '-' <Value>
		@NegOperator = 78,                               // <NegOperator> ::= <PlusOperator>
		@PlusOperator_Plus = 79,                         // <PlusOperator> ::= '+' <Value>
		@PlusOperator = 80,                              // <PlusOperator> ::= <PreDecOperator>
		@PreDecOperator_MinusMinus = 81,                 // <PreDecOperator> ::= '--' <Qualified ID>
		@PreDecOperator = 82,                            // <PreDecOperator> ::= <PostDecOperator>
		@PostDecOperator_MinusMinus = 83,                // <PostDecOperator> ::= <Qualified ID> '--'
		@PostDecOperator = 84,                           // <PostDecOperator> ::= <PreIncOperator>
		@PreIncOperator_PlusPlus = 85,                   // <PreIncOperator> ::= '++' <Qualified ID>
		@PreIncOperator = 86,                            // <PreIncOperator> ::= <PostIncOperator>
		@PostIncOperator_PlusPlus = 87,                  // <PostIncOperator> ::= <Qualified ID> '++'
		@PostIncOperator = 88,                           // <PostIncOperator> ::= <Value>
		@ValidID_Identifier = 89,                        // <Valid ID> ::= Identifier
		@MemberID_MemberName = 90,                       // <Member ID> ::= MemberName
		@ClassNameID = 91,                               // <ClassName ID> ::= <Valid ID> <ClassName List>
		@ClassNameList = 92,                             // <ClassName List> ::= <Member ID> <ClassName List>
		@ClassNameList2 = 93,                            // <ClassName List> ::= 
		@NameSpace = 94,                                 // <NameSpace> ::= 
		@QualifiedID = 95,                               // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 96,                             // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 97,           // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 98,                            // <Qualified List> ::= 
		@Value_StringDouble = 99,                        // <Value> ::= StringDouble
		@Value_StringSingle = 100,                       // <Value> ::= StringSingle
		@Value_RegExpSlash = 101,                        // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 102,                         // <Value> ::= RegExpPipe
		@Value_Number = 103,                             // <Value> ::= Number
		@Value_Decimal = 104,                            // <Value> ::= Decimal
		@Value_Boolean = 105,                            // <Value> ::= Boolean
		@Value = 106,                                    // <Value> ::= <Array Literal>
		@Value2 = 107,                                   // <Value> ::= <Qualified ID>
		@Value3 = 108,                                   // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 109,                      // <Value> ::= '(' <Expression> ')'
		@Value4 = 110,                                   // <Value> ::= <Call Expression>
		@VariableStatements = 111,                       // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 112,                      // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 113,                      // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 114,                      // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 115,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 116,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 117,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 118,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 119,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 120,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 121,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 122,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 123,                       // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 124,                     // <Decrement> ::= <Qualified ID> '--'
		@ImportDecls = 125,                              // <Import Decls> ::= <Import Decl>
		@ImportDecls2 = 126,                             // <Import Decls> ::= <Import Decls> <Import Decl>
		@ImportDecls3 = 127,                             // <Import Decls> ::= 
		@ImportDecl_use_StringDouble = 128,              // <Import Decl> ::= use StringDouble <End>
		@ObjectDecls = 129,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 130,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecls3 = 131,                             // <Object Decls> ::= 
		@ObjectDecl_object = 132,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block> <End>
		@ObjectBlock = 133,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 134,                   // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
		@BaseClassID = 135,                              // <BaseClass ID> ::= <Valid ID>
		@FunctionDecl_function_Identifier = 136,         // <Function Decl> ::= function Identifier <Parameter Array> <Block>
		@FunctionBlock = 137,                            // <Function Block> ::= 
		@FunctionExpression_function = 138,              // <Function Expression> ::= function <Parameter Array> <Block>
		@ParameterArray_LParen_RParen = 139,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 140,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 141,                           // <Parameter Array> ::= 
		@ParameterList = 142,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 143,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 144,                 // <Parameter Name> ::= Identifier
		@CallExpression = 145,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 146,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 147,                        // <New Expression> ::= new <ClassName ID> <Argument Array>
		@CallInternal = 148,                             // <CallInternal> ::= 
		@ArgumentArray_LParen_RParen = 149,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 150,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 151,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 152,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 153,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 154,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 155,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 156,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 157,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 158,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 159,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 160,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 161,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 162,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 163,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 164,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 165,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 166,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 167,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 168,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 169,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 170,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 171,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 172,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 173,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 174,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 175,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 176,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 177,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 178,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 179,                               // <Procedure> ::= <AssertProc>
		@Procedure9 = 180,                               // <Procedure> ::= <ListVars>
		@UnsetProc_UNSET = 181,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 182,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 183,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 184,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 185,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 186,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 187,                        // <ReturnProc> ::= RETURN <Expression>
		@AssertProc_ASSERT = 188,                        // <AssertProc> ::= ASSERT <Expression>
		@ListVars_VARS = 189                             // <ListVars> ::= VARS
	}
}
