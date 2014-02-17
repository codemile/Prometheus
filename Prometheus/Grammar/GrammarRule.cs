
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
		@ProgramCode = 5,                                // <Program Code> ::= <Object Decls>
		@ProgramCode2 = 6,                               // <Program Code> ::= <Object Decls> <Statements>
		@ProgramCode3 = 7,                               // <Program Code> ::= <Statements>
		@ProgramCode4 = 8,                               // <Program Code> ::= 
		@Block_LBrace_RBrace = 9,                        // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 10,                      // <Block> ::= '{' '}'
		@StatementorBlock = 11,                          // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 12,                         // <Statement or Block> ::= <Block>
		@Statements = 13,                                // <Statements> ::= <Statement>
		@Statements2 = 14,                               // <Statements> ::= <Statements> <Statement>
		@Statements3 = 15,                               // <Statements> ::= <Block>
		@Statement = 16,                                 // <Statement> ::= <FlowControl>
		@Statement2 = 17,                                // <Statement> ::= <Variable Statements> <End>
		@Statement3 = 18,                                // <Statement> ::= <Function Decl> <End>
		@Statement4 = 19,                                // <Statement> ::= <Procedure> <End>
		@Statement5 = 20,                                // <Statement> ::= <Call Expression> <End>
		@Statement6 = 21,                                // <Statement> ::= <New Expression> <End>
		@Statement7 = 22,                                // <Statement> ::= <End>
		@TestSuiteDecl_tests = 23,                       // <TestSuite Decl> ::= tests <End>
		@TestSuiteDecl_tests_LBracket_RBracket = 24,     // <TestSuite Decl> ::= tests '[' <TestSuite Array> ']' <End>
		@TestSuiteArray = 25,                            // <TestSuite Array> ::= <Valid ID>
		@TestSuiteArray_Comma = 26,                      // <TestSuite Array> ::= <Valid ID> ',' <TestSuite Array>
		@TestSuiteArray2 = 27,                           // <TestSuite Array> ::= 
		@TestDecls = 28,                                 // <Test Decls> ::= <Test Decl>
		@TestDecls2 = 29,                                // <Test Decls> ::= <Test Decls> <Test Decl>
		@TestDecl_test = 30,                             // <Test Decl> ::= test <Valid ID> <Block> <End>
		@TestBlock = 31,                                 // <Test Block> ::= 
		@TestExecute = 32,                               // <Test Execute> ::= 
		@End_Semi = 33,                                  // <End> ::= ';'
		@EndOpt = 34,                                    // <End Opt> ::= <End>
		@EndOpt2 = 35,                                   // <End Opt> ::= 
		@BlockorEnd = 36,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 37,                               // <Block or End> ::= <End>
		@Expression = 38,                                // <Expression> ::= <SearchChain>
		@SearchChain = 39,                               // <SearchChain> ::= <ContainsTerm>
		@ContainsTerm_CONTAINS = 40,                     // <ContainsTerm> ::= <ContainsTerm> CONTAINS <BooleanChain>
		@ContainsTerm_HAS = 41,                          // <ContainsTerm> ::= <ContainsTerm> HAS <BooleanChain>
		@ContainsTerm = 42,                              // <ContainsTerm> ::= <BooleanChain>
		@BooleanChain = 43,                              // <BooleanChain> ::= <GtOperator>
		@GtOperator_Gt = 44,                             // <GtOperator> ::= <GtOperator> '>' <LtOperator>
		@GtOperator = 45,                                // <GtOperator> ::= <LtOperator>
		@LtOperator_Lt = 46,                             // <LtOperator> ::= <LtOperator> '<' <GteOperator>
		@LtOperator = 47,                                // <LtOperator> ::= <GteOperator>
		@GteOperator_GtEq = 48,                          // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
		@GteOperator = 49,                               // <GteOperator> ::= <LteOperator>
		@LteOperator_LtEq = 50,                          // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
		@LteOperator = 51,                               // <LteOperator> ::= <EqualOperator>
		@EqualOperator_EqEq = 52,                        // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
		@EqualOperator = 53,                             // <EqualOperator> ::= <NotEqualOperator>
		@NotEqualOperator_ExclamEq = 54,                 // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
		@NotEqualOperator_LtGt = 55,                     // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
		@NotEqualOperator = 56,                          // <NotEqualOperator> ::= <AndOperator>
		@AndOperator_AND = 57,                           // <AndOperator> ::= <AndOperator> AND <OrOperator>
		@AndOperator_AmpAmp = 58,                        // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
		@AndOperator = 59,                               // <AndOperator> ::= <OrOperator>
		@OrOperator_OR = 60,                             // <OrOperator> ::= <OrOperator> OR <MathChain>
		@OrOperator_PipePipe = 61,                       // <OrOperator> ::= <OrOperator> '||' <MathChain>
		@OrOperator = 62,                                // <OrOperator> ::= <MathChain>
		@MathChain = 63,                                 // <MathChain> ::= <AddExpression>
		@AddExpression_Plus = 64,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 65,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 66,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 67,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 68,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 69,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 70,                      // <DivideExpression> ::= <DivideExpression> '/' <RemainderExpression>
		@DivideExpression = 71,                          // <DivideExpression> ::= <RemainderExpression>
		@RemainderExpression_Percent = 72,               // <RemainderExpression> ::= <RemainderExpression> '%' <UnaryChain>
		@RemainderExpression = 73,                       // <RemainderExpression> ::= <UnaryChain>
		@UnaryChain = 74,                                // <UnaryChain> ::= <NotOperator>
		@NotOperator_Exclam = 75,                        // <NotOperator> ::= '!' <Value>
		@NotOperator_NOT = 76,                           // <NotOperator> ::= NOT <Value>
		@NotOperator = 77,                               // <NotOperator> ::= <BitInvertOperator>
		@BitInvertOperator_Tilde = 78,                   // <BitInvertOperator> ::= '~' <Value>
		@BitInvertOperator = 79,                         // <BitInvertOperator> ::= <NegOperator>
		@NegOperator_Minus = 80,                         // <NegOperator> ::= '-' <Value>
		@NegOperator = 81,                               // <NegOperator> ::= <PlusOperator>
		@PlusOperator_Plus = 82,                         // <PlusOperator> ::= '+' <Value>
		@PlusOperator = 83,                              // <PlusOperator> ::= <PreDecOperator>
		@PreDecOperator_MinusMinus = 84,                 // <PreDecOperator> ::= '--' <Qualified ID>
		@PreDecOperator = 85,                            // <PreDecOperator> ::= <PostDecOperator>
		@PostDecOperator_MinusMinus = 86,                // <PostDecOperator> ::= <Qualified ID> '--'
		@PostDecOperator = 87,                           // <PostDecOperator> ::= <PreIncOperator>
		@PreIncOperator_PlusPlus = 88,                   // <PreIncOperator> ::= '++' <Qualified ID>
		@PreIncOperator = 89,                            // <PreIncOperator> ::= <PostIncOperator>
		@PostIncOperator_PlusPlus = 90,                  // <PostIncOperator> ::= <Qualified ID> '++'
		@PostIncOperator = 91,                           // <PostIncOperator> ::= <Value>
		@ValidID_Identifier = 92,                        // <Valid ID> ::= Identifier
		@MemberID_MemberName = 93,                       // <Member ID> ::= MemberName
		@QualifiedID = 94,                               // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 95,                             // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 96,           // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 97,                            // <Qualified List> ::= 
		@MemberList_MemberName = 98,                     // <Member List> ::= <Member List> MemberName
		@MemberList = 99,                                // <Member List> ::= 
		@Value_StringDouble = 100,                       // <Value> ::= StringDouble
		@Value_StringSingle = 101,                       // <Value> ::= StringSingle
		@Value_RegExpSlash = 102,                        // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 103,                         // <Value> ::= RegExpPipe
		@Value_Number = 104,                             // <Value> ::= Number
		@Value_Decimal = 105,                            // <Value> ::= Decimal
		@Value_Boolean = 106,                            // <Value> ::= Boolean
		@Value = 107,                                    // <Value> ::= <Array Literal>
		@Value2 = 108,                                   // <Value> ::= <Qualified ID>
		@Value3 = 109,                                   // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 110,                      // <Value> ::= '(' <Expression> ')'
		@Value4 = 111,                                   // <Value> ::= <Call Expression>
		@VariableStatements = 112,                       // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 113,                      // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 114,                      // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 115,                      // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 116,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 117,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 118,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 119,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 120,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 121,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 122,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 123,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 124,                       // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 125,                     // <Decrement> ::= <Qualified ID> '--'
		@ObjectDecls = 126,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 127,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_object = 128,                        // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block> <End>
		@ObjectBlock = 129,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 130,                   // <BaseClass ID> ::= <Qualified ID> '::' <Qualified ID>
		@BaseClassID = 131,                              // <BaseClass ID> ::= <Qualified ID>
		@FunctionDecl_function_Identifier = 132,         // <Function Decl> ::= function Identifier <Parameter Array> <Block>
		@FunctionBlock = 133,                            // <Function Block> ::= 
		@FunctionExpression_function = 134,              // <Function Expression> ::= function <Parameter Array> <Block>
		@ParameterArray_LParen_RParen = 135,             // <Parameter Array> ::= '(' ')'
		@ParameterArray_LParen_RParen2 = 136,            // <Parameter Array> ::= '(' <Parameter List> ')'
		@ParameterArray = 137,                           // <Parameter Array> ::= 
		@ParameterList = 138,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 139,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 140,                 // <Parameter Name> ::= Identifier
		@CallExpression = 141,                           // <Call Expression> ::= <Qualified ID> <Argument Array>
		@CallExpression2 = 142,                          // <Call Expression> ::= <Call Expression> <Argument Array>
		@NewExpression_new = 143,                        // <New Expression> ::= new <Qualified ID> <Argument Array>
		@CallInternal = 144,                             // <CallInternal> ::= 
		@ArgumentArray_LParen_RParen = 145,              // <Argument Array> ::= '(' ')'
		@ArgumentArray_LParen_RParen2 = 146,             // <Argument Array> ::= '(' <Argument List> ')'
		@ArgumentList = 147,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 148,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 149,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 150,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 151,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 152,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 153,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 154,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 155,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 156,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 157,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 158,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 159,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 160,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 161,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 162,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 163,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 164,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 165,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 166,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 167,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 168,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 169,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 170,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 171,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 172,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 173,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 174,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 175,                               // <Procedure> ::= <ListVars>
		@UnsetProc_UNSET = 176,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 177,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 178,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 179,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 180,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 181,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 182,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 183                             // <ListVars> ::= VARS
	}
}
