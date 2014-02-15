
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
		@Statement3 = 13,                                // <Statement> ::= <Procedure> <End>
		@Statement4 = 14,                                // <Statement> ::= <Call Expression> <End>
		@Statement5 = 15,                                // <Statement> ::= <New Expression> <End>
		@Statement6 = 16,                                // <Statement> ::= <End>
		@End_Semi = 17,                                  // <End> ::= ';'
		@EndOpt = 18,                                    // <End Opt> ::= <End>
		@EndOpt2 = 19,                                   // <End Opt> ::= 
		@BlockorEnd = 20,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 21,                               // <Block or End> ::= <End>
		@Expression = 22,                                // <Expression> ::= <SearchChain>
		@SearchChain = 23,                               // <SearchChain> ::= <ContainsTerm>
		@ContainsTerm_CONTAINS = 24,                     // <ContainsTerm> ::= <ContainsTerm> CONTAINS <BooleanChain>
		@ContainsTerm_HAS = 25,                          // <ContainsTerm> ::= <ContainsTerm> HAS <BooleanChain>
		@ContainsTerm = 26,                              // <ContainsTerm> ::= <BooleanChain>
		@BooleanChain = 27,                              // <BooleanChain> ::= <GtOperator>
		@GtOperator_Gt = 28,                             // <GtOperator> ::= <GtOperator> '>' <LtOperator>
		@GtOperator = 29,                                // <GtOperator> ::= <LtOperator>
		@LtOperator_Lt = 30,                             // <LtOperator> ::= <LtOperator> '<' <GteOperator>
		@LtOperator = 31,                                // <LtOperator> ::= <GteOperator>
		@GteOperator_GtEq = 32,                          // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
		@GteOperator = 33,                               // <GteOperator> ::= <LteOperator>
		@LteOperator_LtEq = 34,                          // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
		@LteOperator = 35,                               // <LteOperator> ::= <EqualOperator>
		@EqualOperator_EqEq = 36,                        // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
		@EqualOperator = 37,                             // <EqualOperator> ::= <NotEqualOperator>
		@NotEqualOperator_ExclamEq = 38,                 // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
		@NotEqualOperator_LtGt = 39,                     // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
		@NotEqualOperator = 40,                          // <NotEqualOperator> ::= <AndOperator>
		@AndOperator_AND = 41,                           // <AndOperator> ::= <AndOperator> AND <OrOperator>
		@AndOperator_AmpAmp = 42,                        // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
		@AndOperator = 43,                               // <AndOperator> ::= <OrOperator>
		@OrOperator_OR = 44,                             // <OrOperator> ::= <OrOperator> OR <MathChain>
		@OrOperator_PipePipe = 45,                       // <OrOperator> ::= <OrOperator> '||' <MathChain>
		@OrOperator = 46,                                // <OrOperator> ::= <MathChain>
		@MathChain = 47,                                 // <MathChain> ::= <AddExpression>
		@AddExpression_Plus = 48,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 49,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 50,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 51,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 52,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 53,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 54,                      // <DivideExpression> ::= <DivideExpression> '/' <RemainderExpression>
		@DivideExpression = 55,                          // <DivideExpression> ::= <RemainderExpression>
		@RemainderExpression_Percent = 56,               // <RemainderExpression> ::= <RemainderExpression> '%' <UnaryChain>
		@RemainderExpression = 57,                       // <RemainderExpression> ::= <UnaryChain>
		@UnaryChain = 58,                                // <UnaryChain> ::= <NotOperator>
		@NotOperator_Exclam = 59,                        // <NotOperator> ::= '!' <Value>
		@NotOperator_NOT = 60,                           // <NotOperator> ::= NOT <Value>
		@NotOperator = 61,                               // <NotOperator> ::= <BitInvertOperator>
		@BitInvertOperator_Tilde = 62,                   // <BitInvertOperator> ::= '~' <Value>
		@BitInvertOperator = 63,                         // <BitInvertOperator> ::= <NegOperator>
		@NegOperator_Minus = 64,                         // <NegOperator> ::= '-' <Value>
		@NegOperator = 65,                               // <NegOperator> ::= <PlusOperator>
		@PlusOperator_Plus = 66,                         // <PlusOperator> ::= '+' <Value>
		@PlusOperator = 67,                              // <PlusOperator> ::= <PreDecOperator>
		@PreDecOperator_MinusMinus = 68,                 // <PreDecOperator> ::= '--' <Qualified ID>
		@PreDecOperator = 69,                            // <PreDecOperator> ::= <PostDecOperator>
		@PostDecOperator_MinusMinus = 70,                // <PostDecOperator> ::= <Qualified ID> '--'
		@PostDecOperator = 71,                           // <PostDecOperator> ::= <PreIncOperator>
		@PreIncOperator_PlusPlus = 72,                   // <PreIncOperator> ::= '++' <Qualified ID>
		@PreIncOperator = 73,                            // <PreIncOperator> ::= <PostIncOperator>
		@PostIncOperator_PlusPlus = 74,                  // <PostIncOperator> ::= <Qualified ID> '++'
		@PostIncOperator = 75,                           // <PostIncOperator> ::= <Value>
		@ValidID_Identifier = 76,                        // <Valid ID> ::= Identifier
		@MemberID_MemberName = 77,                       // <Member ID> ::= MemberName
		@QualifiedID = 78,                               // <Qualified ID> ::= <Valid ID> <Qualified List>
		@QualifiedList = 79,                             // <Qualified List> ::= <Member ID> <Qualified List>
		@QualifiedList_LBracket_RBracket = 80,           // <Qualified List> ::= '[' <Value> ']' <Qualified List>
		@QualifiedList2 = 81,                            // <Qualified List> ::= 
		@MemberList_MemberName = 82,                     // <Member List> ::= <Member List> MemberName
		@MemberList = 83,                                // <Member List> ::= 
		@Value_StringDouble = 84,                        // <Value> ::= StringDouble
		@Value_StringSingle = 85,                        // <Value> ::= StringSingle
		@Value_RegExpSlash = 86,                         // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 87,                          // <Value> ::= RegExpPipe
		@Value_Number = 88,                              // <Value> ::= Number
		@Value_Decimal = 89,                             // <Value> ::= Decimal
		@Value_Boolean = 90,                             // <Value> ::= Boolean
		@Value = 91,                                     // <Value> ::= <Array Literal>
		@Value2 = 92,                                    // <Value> ::= <Qualified ID>
		@Value3 = 93,                                    // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 94,                       // <Value> ::= '(' <Expression> ')'
		@Value4 = 95,                                    // <Value> ::= <Call Expression>
		@VariableStatements = 96,                        // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 97,                       // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 98,                       // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 99,                       // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 100,           // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 101,          // <Array Literal> ::= '[' <Array Literal List> ']'
		@ArrayLiteralList = 102,                         // <Array Literal List> ::= <Value>
		@ArrayLiteralList_Comma = 103,                   // <Array Literal List> ::= <Array Literal List> ',' <Value>
		@Declare_VAR_Identifier = 104,                   // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 105,                // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 106,               // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 107,                            // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 108,                       // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 109,                     // <Decrement> ::= <Qualified ID> '--'
		@ObjectDecls = 110,                              // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 111,                             // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_object = 112,                        // <Object Decl> ::= object <BaseClass ID> <Parameters> <Block> <End>
		@ObjectConstructor = 113,                        // <Object Constructor> ::= 
		@BaseClassID_ColonColon = 114,                   // <BaseClass ID> ::= <Qualified ID> '::' <Qualified ID>
		@BaseClassID = 115,                              // <BaseClass ID> ::= <Qualified ID>
		@FunctionExpression_function = 116,              // <Function Expression> ::= function <Parameters> <Block>
		@Parameters_LParen_RParen = 117,                 // <Parameters> ::= '(' ')'
		@Parameters_LParen_RParen2 = 118,                // <Parameters> ::= '(' <Parameter List> ')'
		@Parameters = 119,                               // <Parameters> ::= 
		@ParameterList = 120,                            // <Parameter List> ::= <Parameter Name>
		@ParameterList_Comma = 121,                      // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
		@ParameterName_Identifier = 122,                 // <Parameter Name> ::= Identifier
		@CallExpression = 123,                           // <Call Expression> ::= <Qualified ID> <Arguments>
		@CallExpression2 = 124,                          // <Call Expression> ::= <Call Expression> <Arguments>
		@NewExpression_new = 125,                        // <New Expression> ::= new <Qualified ID> <Arguments>
		@CallInternal = 126,                             // <CallInternal> ::= 
		@Arguments_LParen_RParen = 127,                  // <Arguments> ::= '(' ')'
		@Arguments_LParen_RParen2 = 128,                 // <Arguments> ::= '(' <Argument List> ')'
		@ArgumentList = 129,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 130,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 131,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 132,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 133,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 134,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 135,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 136,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 137,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 138,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 139,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 140,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 141,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 142,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 143,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 144,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 145,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 146,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 147,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 148,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 149,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 150,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 151,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 152,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 153,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 154,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 155,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 156,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 157,                               // <Procedure> ::= <ListVars>
		@UnsetProc_UNSET = 158,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 159,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 160,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 161,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 162,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 163,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 164,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 165                             // <ListVars> ::= VARS
	}
}
