
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
		@DivideExpression_Div = 54,                      // <DivideExpression> ::= <DivideExpression> '/' <UnaryOperator>
		@DivideExpression = 55,                          // <DivideExpression> ::= <UnaryOperator>
		@UnaryOperator_MinusMinus = 56,                  // <UnaryOperator> ::= '--' <Qualified ID>
		@UnaryOperator_PlusPlus = 57,                    // <UnaryOperator> ::= '++' <Qualified ID>
		@UnaryOperator_Minus = 58,                       // <UnaryOperator> ::= '-' <Value>
		@UnaryOperator_Plus = 59,                        // <UnaryOperator> ::= '+' <Value>
		@UnaryOperator_Exclam = 60,                      // <UnaryOperator> ::= '!' <Value>
		@UnaryOperator_Tilde = 61,                       // <UnaryOperator> ::= '~' <Value>
		@UnaryOperator_NOT = 62,                         // <UnaryOperator> ::= NOT <Value>
		@UnaryOperator = 63,                             // <UnaryOperator> ::= <Value>
		@ValidID_Identifier = 64,                        // <Valid ID> ::= Identifier
		@QualifiedID = 65,                               // <Qualified ID> ::= <Valid ID> <Member List>
		@ClassNameID_Identifier = 66,                    // <ClassName ID> ::= Identifier <Member List>
		@MemberList_MemberName = 67,                     // <Member List> ::= <Member List> MemberName
		@MemberList = 68,                                // <Member List> ::= 
		@Value_StringDouble = 69,                        // <Value> ::= StringDouble
		@Value_StringSingle = 70,                        // <Value> ::= StringSingle
		@Value_RegExpSlash = 71,                         // <Value> ::= RegExpSlash
		@Value_RegExpPipe = 72,                          // <Value> ::= RegExpPipe
		@Value_Number = 73,                              // <Value> ::= Number
		@Value_Decimal = 74,                             // <Value> ::= Decimal
		@Value_Boolean = 75,                             // <Value> ::= Boolean
		@Value = 76,                                     // <Value> ::= <Array Literal>
		@Value2 = 77,                                    // <Value> ::= <Qualified ID>
		@Value3 = 78,                                    // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 79,                       // <Value> ::= '(' <Expression> ')'
		@Value4 = 80,                                    // <Value> ::= <Call Expression>
		@VariableStatements = 81,                        // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 82,                       // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 83,                       // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 84,                       // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 85,            // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 86,           // <Array Literal> ::= '[' <Array List> ']'
		@ArrayList = 87,                                 // <Array List> ::= <Value>
		@ArrayList_Comma = 88,                           // <Array List> ::= <Array List> ',' <Value>
		@Declare_VAR_Identifier = 89,                    // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 90,                 // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 91,                // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 92,                             // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 93,                        // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 94,                      // <Decrement> ::= <Qualified ID> '--'
		@ObjectDecls = 95,                               // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 96,                              // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_object = 97,                         // <Object Decl> ::= object <BaseClass ID> <ConstructParams List> <Block> <End>
		@BaseClassID_ColonColon_Identifier = 98,         // <BaseClass ID> ::= <ClassName ID> '::' Identifier
		@BaseClassID_Identifier = 99,                    // <BaseClass ID> ::= Identifier
		@ConstructParamsList_LParen_RParen = 100,        // <ConstructParams List> ::= '(' ')'
		@ConstructParamsList_LParen_RParen2 = 101,       // <ConstructParams List> ::= '(' <Formal Parameter List> ')'
		@ConstructParamsList = 102,                      // <ConstructParams List> ::= 
		@FunctionExpression_function = 103,              // <Function Expression> ::= function <Formal Parameters> <Block>
		@FormalParameters_LParen_RParen = 104,           // <Formal Parameters> ::= '(' ')'
		@FormalParameters_LParen_RParen2 = 105,          // <Formal Parameters> ::= '(' <Formal Parameter List> ')'
		@FormalParameterList_Identifier = 106,           // <Formal Parameter List> ::= Identifier
		@FormalParameterList_Comma_Identifier = 107,     // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
		@CallExpression = 108,                           // <Call Expression> ::= <Qualified ID> <Arguments>
		@CallExpression2 = 109,                          // <Call Expression> ::= <Call Expression> <Arguments>
		@NewExpression_new = 110,                        // <New Expression> ::= new <ClassName ID> <Arguments>
		@CallInternal = 111,                             // <CallInternal> ::= 
		@Arguments_LParen_RParen = 112,                  // <Arguments> ::= '(' ')'
		@Arguments_LParen_RParen2 = 113,                 // <Arguments> ::= '(' <Argument List> ')'
		@ArgumentList = 114,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 115,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 116,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 117,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 118,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 119,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 120,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 121,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 122,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 123,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 124,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 125,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 126,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 127,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 128,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 129,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 130,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 131,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 132,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 133,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 134,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 135,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 136,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 137,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 138,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 139,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 140,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 141,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 142,                               // <Procedure> ::= <ListVars>
		@Procedure9 = 143,                               // <Procedure> ::= <ListObjects>
		@UnsetProc_UNSET = 144,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 145,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 146,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 147,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 148,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 149,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 150,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 151,                            // <ListVars> ::= VARS
		@ListObjects_OBJECTS = 152                       // <ListObjects> ::= OBJECTS
	}
}
