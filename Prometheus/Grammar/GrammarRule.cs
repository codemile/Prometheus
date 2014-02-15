
namespace Prometheus.Grammar
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum GrammarRule
	{
		@Program = 0,                                    // <Program> ::= <Object Decls>
		@Program2 = 1,                                   // <Program> ::= <Object Decls> <Statements>
		@Program3 = 2,                                   // <Program> ::= <Statements>
		@Program4 = 3,                                   // <Program> ::= 
		@Block_LBrace_RBrace = 4,                        // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 5,                       // <Block> ::= '{' '}'
		@StatementorBlock = 6,                           // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 7,                          // <Statement or Block> ::= <Block>
		@Statements = 8,                                 // <Statements> ::= <Statement>
		@Statements2 = 9,                                // <Statements> ::= <Statements> <Statement>
		@Statements3 = 10,                               // <Statements> ::= <Block>
		@Statement = 11,                                 // <Statement> ::= <FlowControl>
		@Statement2 = 12,                                // <Statement> ::= <Variable Statements> <End>
		@Statement3 = 13,                                // <Statement> ::= <Function Decl> <End>
		@Statement4 = 14,                                // <Statement> ::= <Procedure> <End>
		@Statement5 = 15,                                // <Statement> ::= <Call Expression> <End>
		@Statement6 = 16,                                // <Statement> ::= <New Expression> <End>
		@Statement7 = 17,                                // <Statement> ::= <End>
		@End_Semi = 18,                                  // <End> ::= ';'
		@EndOpt = 19,                                    // <End Opt> ::= <End>
		@EndOpt2 = 20,                                   // <End Opt> ::= 
		@BlockorEnd = 21,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 22,                               // <Block or End> ::= <End>
		@Expression = 23,                                // <Expression> ::= <SearchChain>
		@SearchChain = 24,                               // <SearchChain> ::= <ContainsTerm>
		@ContainsTerm_CONTAINS = 25,                     // <ContainsTerm> ::= <ContainsTerm> CONTAINS <BooleanChain>
		@ContainsTerm_HAS = 26,                          // <ContainsTerm> ::= <ContainsTerm> HAS <BooleanChain>
		@ContainsTerm = 27,                              // <ContainsTerm> ::= <BooleanChain>
		@BooleanChain = 28,                              // <BooleanChain> ::= <GtOperator>
		@GtOperator_Gt = 29,                             // <GtOperator> ::= <GtOperator> '>' <LtOperator>
		@GtOperator = 30,                                // <GtOperator> ::= <LtOperator>
		@LtOperator_Lt = 31,                             // <LtOperator> ::= <LtOperator> '<' <GteOperator>
		@LtOperator = 32,                                // <LtOperator> ::= <GteOperator>
		@GteOperator_GtEq = 33,                          // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
		@GteOperator = 34,                               // <GteOperator> ::= <LteOperator>
		@LteOperator_LtEq = 35,                          // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
		@LteOperator = 36,                               // <LteOperator> ::= <EqualOperator>
		@EqualOperator_EqEq = 37,                        // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
		@EqualOperator = 38,                             // <EqualOperator> ::= <NotEqualOperator>
		@NotEqualOperator_ExclamEq = 39,                 // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
		@NotEqualOperator_LtGt = 40,                     // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
		@NotEqualOperator = 41,                          // <NotEqualOperator> ::= <AndOperator>
		@AndOperator_AND = 42,                           // <AndOperator> ::= <AndOperator> AND <OrOperator>
		@AndOperator_AmpAmp = 43,                        // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
		@AndOperator = 44,                               // <AndOperator> ::= <OrOperator>
		@OrOperator_OR = 45,                             // <OrOperator> ::= <OrOperator> OR <MathChain>
		@OrOperator_PipePipe = 46,                       // <OrOperator> ::= <OrOperator> '||' <MathChain>
		@OrOperator = 47,                                // <OrOperator> ::= <MathChain>
		@MathChain = 48,                                 // <MathChain> ::= <AddExpression>
		@AddExpression_Plus = 49,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 50,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 51,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 52,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 53,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 54,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 55,                      // <DivideExpression> ::= <DivideExpression> '/' <RemainderExpression>
		@DivideExpression = 56,                          // <DivideExpression> ::= <RemainderExpression>
		@RemainderExpression_Percent = 57,               // <RemainderExpression> ::= <RemainderExpression> '%' <UnaryChain>
		@RemainderExpression = 58,                       // <RemainderExpression> ::= <UnaryChain>
		@UnaryChain = 59,                                // <UnaryChain> ::= <NotOperator>
		@NotOperator_Exclam = 60,                        // <NotOperator> ::= '!' <Value>
		@NotOperator_NOT = 61,                           // <NotOperator> ::= NOT <Value>
		@NotOperator = 62,                               // <NotOperator> ::= <BitInvertOperator>
		@BitInvertOperator_Tilde = 63,                   // <BitInvertOperator> ::= '~' <Value>
		@BitInvertOperator = 64,                         // <BitInvertOperator> ::= <NegOperator>
		@NegOperator_Minus = 65,                         // <NegOperator> ::= '-' <Value>
		@NegOperator = 66,                               // <NegOperator> ::= <PlusOperator>
		@PlusOperator_Plus = 67,                         // <PlusOperator> ::= '+' <Value>
		@PlusOperator = 68,                              // <PlusOperator> ::= <PreDecOperator>
		@PreDecOperator_MinusMinus = 69,                 // <PreDecOperator> ::= '--' <Qualified ID>
		@PreDecOperator = 70,                            // <PreDecOperator> ::= <PostDecOperator>
		@PostDecOperator_MinusMinus = 71,                // <PostDecOperator> ::= <Qualified ID> '--'
		@PostDecOperator = 72,                           // <PostDecOperator> ::= <PreIncOperator>
		@PreIncOperator_PlusPlus = 73,                   // <PreIncOperator> ::= '++' <Qualified ID>
		@PreIncOperator = 74,                            // <PreIncOperator> ::= <PostIncOperator>
		@PostIncOperator_PlusPlus = 75,                  // <PostIncOperator> ::= <Qualified ID> '++'
		@PostIncOperator = 76,                           // <PostIncOperator> ::= <Value>
		@ValidID_Identifier = 77,                        // <Valid ID> ::= Identifier
		@MemberID_MemberName = 78,                       // <Member ID> ::= MemberName
		@QualifiedID = 79,                               // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 80,                             // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 81,           // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 82,                            // <Qualified List> ::= 
		@MemberList_MemberName = 83,                     // <Member List> ::= <Member List> MemberName
		@MemberList = 84,                                // <Member List> ::= 
		@Value_StringDouble = 85,                        // <Value> ::= StringDouble
		@Value_StringSingle = 86,                        // <Value> ::= StringSingle
		@Value_RegExpSlash = 87,                         // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 88,                          // <Value> ::= RegExpPipe
		@Value_Number = 89,                              // <Value> ::= Number
		@Value_Decimal = 90,                             // <Value> ::= Decimal
		@Value_Boolean = 91,                             // <Value> ::= Boolean
		@Value = 92,                                     // <Value> ::= <Array Literal>
		@Value2 = 93,                                    // <Value> ::= <Qualified ID>
		@Value3 = 94,                                    // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 95,                       // <Value> ::= '(' <Expression> ')'
		@Value4 = 96,                                    // <Value> ::= <Call Expression>
		@VariableStatements = 97,                        // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 98,                       // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 99,                       // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 100,                      // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 101,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 102,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 103,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 104,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 105,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 106,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 107,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 108,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 109,                       // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 110,                     // <Decrement> ::= <Qualified ID> '--'
		@ObjectDecls = 111,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 112,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_object = 113,                        // <Object Decl> ::= object <BaseClass ID> <Parameters> <Block> <End>
		@ObjectBlock = 114,                              // <Object Block> ::= 
		@BaseClassID_ColonColon = 115,                   // <BaseClass ID> ::= <Qualified ID> '::' <Qualified ID>
		@BaseClassID = 116,                              // <BaseClass ID> ::= <Qualified ID>
		@FunctionDecl_function_Identifier = 117,         // <Function Decl> ::= function Identifier <Parameters> <Block>
		@FunctionBlock = 118,                            // <Function Block> ::= 
		@FunctionExpression_function = 119,              // <Function Expression> ::= function <Parameters> <Block>
		@Parameters_LParen_RParen = 120,                 // <Parameters> ::= '(' ')'
		@Parameters_LParen_RParen2 = 121,                // <Parameters> ::= '(' <Parameter List> ')'
		@Parameters = 122,                               // <Parameters> ::= 
		@ParameterList = 123,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 124,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 125,                 // <Parameter Name> ::= Identifier
		@CallExpression = 126,                           // <Call Expression> ::= <Qualified ID> <Arguments>
		@CallExpression2 = 127,                          // <Call Expression> ::= <Call Expression> <Arguments>
		@NewExpression_new = 128,                        // <New Expression> ::= new <Qualified ID> <Arguments>
		@CallInternal = 129,                             // <CallInternal> ::= 
		@Arguments_LParen_RParen = 130,                  // <Arguments> ::= '(' ')'
		@Arguments_LParen_RParen2 = 131,                 // <Arguments> ::= '(' <Argument List> ')'
		@ArgumentList = 132,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 133,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 134,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 135,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 136,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 137,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 138,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 139,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 140,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 141,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 142,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 143,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 144,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 145,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 146,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 147,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 148,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 149,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 150,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 151,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 152,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 153,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 154,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 155,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 156,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 157,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 158,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 159,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 160,                               // <Procedure> ::= <ListVars>
		@UnsetProc_UNSET = 161,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 162,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 163,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 164,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 165,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 166,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 167,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 168                             // <ListVars> ::= VARS
	}
}
