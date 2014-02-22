
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
		@Statement2 = 14,                                // <Statement> ::= <Function Decl> <End>
		@Statement3 = 15,                                // <Statement> ::= <Procedure> <End>
		@Statement4 = 16,                                // <Statement> ::= <Variable Statements> <End>
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
		@VariableStatements3 = 115,                      // <Variable Statements> ::= <PostIncrement>
		@VariableStatements4 = 116,                      // <Variable Statements> ::= <PreIncrement>
		@VariableStatements5 = 117,                      // <Variable Statements> ::= <PostDecrement>
		@VariableStatements6 = 118,                      // <Variable Statements> ::= <PreDecrement>
		@ArrayLiteral_LBracket_RBracket = 119,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 120,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 121,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 122,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 123,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 124,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 125,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 126,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@PostIncrement_PlusPlus = 127,                   // <PostIncrement> ::= <Qualified ID> '++'
		@PreIncrement_PlusPlus = 128,                    // <PreIncrement> ::= '++' <Qualified ID>
		@PostDecrement_MinusMinus = 129,                 // <PostDecrement> ::= <Qualified ID> '--'
		@PreDecrement_MinusMinus = 130,                  // <PreDecrement> ::= '--' <Qualified ID>
		@ImportDecls = 131,                              // <Import Decls> ::= <Import Decl>
		@ImportDecls2 = 132,                             // <Import Decls> ::= <Import Decls> <Import Decl>
		@ImportDecls3 = 133,                             // <Import Decls> ::= 
		@ImportDecl_use_StringDouble = 134,              // <Import Decl> ::= use StringDouble <End>
		@ObjectDecls = 135,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 136,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecls3 = 137,                             // <Object Decls> ::= 
		@ObjectDecl_object = 138,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block> <End>
		@ObjectBlock = 139,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 140,                   // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
		@BaseClassID = 141,                              // <BaseClass ID> ::= <Valid ID>
		@FunctionDecl_function_Identifier = 142,         // <Function Decl> ::= function Identifier <Parameter Array> <Block>
		@FunctionBlock = 143,                            // <Function Block> ::= 
		@FunctionExpression_function = 144,              // <Function Expression> ::= function <Parameter Array> <Block>
		@ParameterArray_LParen_RParen = 145,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 146,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 147,                           // <Parameter Array> ::= 
		@ParameterList = 148,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 149,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 150,                 // <Parameter Name> ::= Identifier
		@CallExpression = 151,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 152,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 153,                        // <New Expression> ::= new <ClassName ID> <Argument Array>
		@ArgumentArray_LParen_RParen = 154,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 155,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 156,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 157,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 158,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 159,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 160,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 161,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 162,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 163,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 164,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 165,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 166,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 167,               // <IfControl> ::= IF '(' <Expression> ')' <Block>
		@IfControl_IF_LParen_RParen_ELSE = 168,          // <IfControl> ::= IF '(' <Expression> ')' <Block> ELSE <Block>
		@DoWhileControl_WHILE_LParen_RParen = 169,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Block>
		@DoUntilControl_UNTIL_LParen_RParen = 170,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 171,  // <LoopWhileControl> ::= DO <Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 172,  // <LoopUntilControl> ::= DO <Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 173,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 174,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Block>
		@BreakControl_BREAK = 175,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 176,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 177,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 178,                               // <Procedure> ::= <PrintProc>
		@Procedure3 = 179,                               // <Procedure> ::= <ReturnProc>
		@Procedure4 = 180,                               // <Procedure> ::= <AssertProc>
		@Procedure5 = 181,                               // <Procedure> ::= <FailProc>
		@Procedure6 = 182,                               // <Procedure> ::= <ListVars>
		@Procedure7 = 183,                               // <Procedure> ::= <Call Generic>
		@UnsetProc_UNSET = 184,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@PrintProc_PRINT = 185,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 186,                        // <ReturnProc> ::= RETURN <Expression>
		@ReturnProc_RETURN2 = 187,                       // <ReturnProc> ::= RETURN
		@AssertProc_ASSERT = 188,                        // <AssertProc> ::= ASSERT <Expression>
		@FailProc_FAIL = 189,                            // <FailProc> ::= FAIL <Expression>
		@FailProc_FAIL2 = 190,                           // <FailProc> ::= FAIL
		@ListVars_VARS = 191,                            // <ListVars> ::= VARS
		@CallGeneric_Identifier = 192                    // <Call Generic> ::= Identifier <Argument Array>
	}
}
