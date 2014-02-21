
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
		@ProgramTest = 2,                                // <Program Test> ::= <TestSuite Decl> <Import Decls> <Test Decls> <Test Execute>
		@ProgramTest2 = 3,                               // <Program Test> ::= <TestSuite Decl> <Import Decls> <Statements> <Test Decls> <Test Execute>
		@ProgramTest3 = 4,                               // <Program Test> ::= <TestSuite Decl> <Import Decls> <Statements> <Test Decls> <Test Execute> <Statements>
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
		@TestDecls3 = 27,                                // <Test Decls> ::= 
		@TestDecl_test = 28,                             // <Test Decl> ::= test <Valid ID> <Block> <End>
		@TestBlock = 29,                                 // <Test Block> ::= 
		@TestExecute = 30,                               // <Test Execute> ::= 
		@End_Semi = 31,                                  // <End> ::= ';'
		@EndOpt = 32,                                    // <End Opt> ::= <End>
		@EndOpt2 = 33,                                   // <End Opt> ::= 
		@BlockorEnd = 34,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 35,                               // <Block or End> ::= <End>
		@Expression = 36,                                // <Expression> ::= <SearchChain>
		@SearchChain = 37,                               // <SearchChain> ::= <ContainsTerm>
		@ContainsTerm_CONTAINS = 38,                     // <ContainsTerm> ::= <ContainsTerm> CONTAINS <BooleanChain>
		@ContainsTerm_HAS = 39,                          // <ContainsTerm> ::= <ContainsTerm> HAS <BooleanChain>
		@ContainsTerm = 40,                              // <ContainsTerm> ::= <BooleanChain>
		@BooleanChain = 41,                              // <BooleanChain> ::= <GtOperator>
		@GtOperator_Gt = 42,                             // <GtOperator> ::= <GtOperator> '>' <LtOperator>
		@GtOperator = 43,                                // <GtOperator> ::= <LtOperator>
		@LtOperator_Lt = 44,                             // <LtOperator> ::= <LtOperator> '<' <GteOperator>
		@LtOperator = 45,                                // <LtOperator> ::= <GteOperator>
		@GteOperator_GtEq = 46,                          // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
		@GteOperator = 47,                               // <GteOperator> ::= <LteOperator>
		@LteOperator_LtEq = 48,                          // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
		@LteOperator = 49,                               // <LteOperator> ::= <EqualOperator>
		@EqualOperator_EqEq = 50,                        // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
		@EqualOperator = 51,                             // <EqualOperator> ::= <NotEqualOperator>
		@NotEqualOperator_ExclamEq = 52,                 // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
		@NotEqualOperator_LtGt = 53,                     // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
		@NotEqualOperator = 54,                          // <NotEqualOperator> ::= <AndOperator>
		@AndOperator_AND = 55,                           // <AndOperator> ::= <AndOperator> AND <OrOperator>
		@AndOperator_AmpAmp = 56,                        // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
		@AndOperator = 57,                               // <AndOperator> ::= <OrOperator>
		@OrOperator_OR = 58,                             // <OrOperator> ::= <OrOperator> OR <MathChain>
		@OrOperator_PipePipe = 59,                       // <OrOperator> ::= <OrOperator> '||' <MathChain>
		@OrOperator = 60,                                // <OrOperator> ::= <MathChain>
		@MathChain = 61,                                 // <MathChain> ::= <AddExpression>
		@AddExpression_Plus = 62,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 63,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 64,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 65,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 66,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 67,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 68,                      // <DivideExpression> ::= <DivideExpression> '/' <RemainderExpression>
		@DivideExpression = 69,                          // <DivideExpression> ::= <RemainderExpression>
		@RemainderExpression_Percent = 70,               // <RemainderExpression> ::= <RemainderExpression> '%' <UnaryChain>
		@RemainderExpression = 71,                       // <RemainderExpression> ::= <UnaryChain>
		@UnaryChain = 72,                                // <UnaryChain> ::= <NotOperator>
		@NotOperator_Exclam = 73,                        // <NotOperator> ::= '!' <Value>
		@NotOperator_NOT = 74,                           // <NotOperator> ::= NOT <Value>
		@NotOperator = 75,                               // <NotOperator> ::= <BitInvertOperator>
		@BitInvertOperator_Tilde = 76,                   // <BitInvertOperator> ::= '~' <Value>
		@BitInvertOperator = 77,                         // <BitInvertOperator> ::= <NegOperator>
		@NegOperator_Minus = 78,                         // <NegOperator> ::= '-' <Value>
		@NegOperator = 79,                               // <NegOperator> ::= <PlusOperator>
		@PlusOperator_Plus = 80,                         // <PlusOperator> ::= '+' <Value>
		@PlusOperator = 81,                              // <PlusOperator> ::= <PreDecOperator>
		@PreDecOperator_MinusMinus = 82,                 // <PreDecOperator> ::= '--' <Qualified ID>
		@PreDecOperator = 83,                            // <PreDecOperator> ::= <PostDecOperator>
		@PostDecOperator_MinusMinus = 84,                // <PostDecOperator> ::= <Qualified ID> '--'
		@PostDecOperator = 85,                           // <PostDecOperator> ::= <PreIncOperator>
		@PreIncOperator_PlusPlus = 86,                   // <PreIncOperator> ::= '++' <Qualified ID>
		@PreIncOperator = 87,                            // <PreIncOperator> ::= <PostIncOperator>
		@PostIncOperator_PlusPlus = 88,                  // <PostIncOperator> ::= <Qualified ID> '++'
		@PostIncOperator = 89,                           // <PostIncOperator> ::= <Value>
		@ValidID_Identifier = 90,                        // <Valid ID> ::= Identifier
		@MemberID_MemberName = 91,                       // <Member ID> ::= MemberName
		@ClassNameID = 92,                               // <ClassName ID> ::= <Valid ID> <ClassName List>
		@ClassNameList = 93,                             // <ClassName List> ::= <Member ID> <ClassName List>
		@ClassNameList2 = 94,                            // <ClassName List> ::= 
		@NameSpace = 95,                                 // <NameSpace> ::= 
		@QualifiedID = 96,                               // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 97,                             // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 98,           // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 99,                            // <Qualified List> ::= 
		@Value_StringDouble = 100,                       // <Value> ::= StringDouble
		@Value_StringSingle = 101,                       // <Value> ::= StringSingle
		@Value_RegExpSlash = 102,                        // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 103,                         // <Value> ::= RegExpPipe
		@Value_Number = 104,                             // <Value> ::= Number
		@Value_Decimal = 105,                            // <Value> ::= Decimal
		@Value_Boolean = 106,                            // <Value> ::= Boolean
		@Value_Undefined = 107,                          // <Value> ::= Undefined
		@Value = 108,                                    // <Value> ::= <Array Literal>
		@Value2 = 109,                                   // <Value> ::= <Qualified ID>
		@Value3 = 110,                                   // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 111,                      // <Value> ::= '(' <Expression> ')'
		@Value4 = 112,                                   // <Value> ::= <Call Expression>
		@VariableStatements = 113,                       // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 114,                      // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 115,                      // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 116,                      // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 117,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 118,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 119,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 120,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 121,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 122,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 123,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 124,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 125,                       // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 126,                     // <Decrement> ::= <Qualified ID> '--'
		@ImportDecls = 127,                              // <Import Decls> ::= <Import Decl>
		@ImportDecls2 = 128,                             // <Import Decls> ::= <Import Decls> <Import Decl>
		@ImportDecls3 = 129,                             // <Import Decls> ::= 
		@ImportDecl_use_StringDouble = 130,              // <Import Decl> ::= use StringDouble <End>
		@ObjectDecls = 131,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 132,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecls3 = 133,                             // <Object Decls> ::= 
		@ObjectDecl_object = 134,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block> <End>
		@ObjectBlock = 135,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 136,                   // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
		@BaseClassID = 137,                              // <BaseClass ID> ::= <Valid ID>
		@FunctionDecl_function_Identifier = 138,         // <Function Decl> ::= function Identifier <Parameter Array> <Block>
		@FunctionBlock = 139,                            // <Function Block> ::= 
		@FunctionExpression_function = 140,              // <Function Expression> ::= function <Parameter Array> <Block>
		@ParameterArray_LParen_RParen = 141,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 142,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 143,                           // <Parameter Array> ::= 
		@ParameterList = 144,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 145,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 146,                 // <Parameter Name> ::= Identifier
		@CallExpression = 147,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 148,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 149,                        // <New Expression> ::= new <ClassName ID> <Argument Array>
		@ArgumentArray_LParen_RParen = 150,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 151,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 152,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 153,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 154,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 155,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 156,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 157,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 158,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 159,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 160,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 161,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 162,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 163,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 164,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 165,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 166,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 167,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 168,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 169,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 170,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 171,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 172,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 173,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 174,                               // <Procedure> ::= <ReturnProc>
		@Procedure3 = 175,                               // <Procedure> ::= <ListVars>
		@Procedure4 = 176,                               // <Procedure> ::= <Generic0Args>
		@Procedure5 = 177,                               // <Procedure> ::= <Generic1Args>
		@Procedure6 = 178,                               // <Procedure> ::= <GenericNArgs>
		@UnsetProc_UNSET = 179,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@ReturnProc_RETURN = 180,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 181,                            // <ListVars> ::= VARS
		@Generic0Args_Identifier = 182,                  // <Generic0Args> ::= Identifier
		@Generic1Args_Identifier = 183,                  // <Generic1Args> ::= Identifier <Expression>
		@GenericNArgs_Identifier = 184                   // <GenericNArgs> ::= Identifier <Argument Array>
	}
}
