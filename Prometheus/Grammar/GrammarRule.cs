
namespace Prometheus.Grammar
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum GrammarRule
	{
		@Expression = 0,                                 // <Expression> ::= <GtOperator>
		@GtOperator_Gt = 1,                              // <GtOperator> ::= <GtOperator> '>' <LtOperator>
		@GtOperator = 2,                                 // <GtOperator> ::= <LtOperator>
		@LtOperator_Lt = 3,                              // <LtOperator> ::= <LtOperator> '<' <GteOperator>
		@LtOperator = 4,                                 // <LtOperator> ::= <GteOperator>
		@GteOperator_GtEq = 5,                           // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
		@GteOperator = 6,                                // <GteOperator> ::= <LteOperator>
		@LteOperator_LtEq = 7,                           // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
		@LteOperator = 8,                                // <LteOperator> ::= <EqualOperator>
		@EqualOperator_EqEq = 9,                         // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
		@EqualOperator = 10,                             // <EqualOperator> ::= <NotEqualOperator>
		@NotEqualOperator_ExclamEq = 11,                 // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
		@NotEqualOperator_LtGt = 12,                     // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
		@NotEqualOperator = 13,                          // <NotEqualOperator> ::= <AndOperator>
		@AndOperator_AND = 14,                           // <AndOperator> ::= <AndOperator> AND <OrOperator>
		@AndOperator_AmpAmp = 15,                        // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
		@AndOperator = 16,                               // <AndOperator> ::= <OrOperator>
		@OrOperator_OR = 17,                             // <OrOperator> ::= <OrOperator> OR <AddExpression>
		@OrOperator_PipePipe = 18,                       // <OrOperator> ::= <OrOperator> '||' <AddExpression>
		@OrOperator = 19,                                // <OrOperator> ::= <AddExpression>
		@AddExpression_Plus = 20,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 21,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 22,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 23,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 24,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 25,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 26,                      // <DivideExpression> ::= <DivideExpression> '/' <UnaryOperator>
		@DivideExpression = 27,                          // <DivideExpression> ::= <UnaryOperator>
		@UnaryOperator_MinusMinus = 28,                  // <UnaryOperator> ::= '--' <Qualified ID>
		@UnaryOperator_PlusPlus = 29,                    // <UnaryOperator> ::= '++' <Qualified ID>
		@UnaryOperator_Minus = 30,                       // <UnaryOperator> ::= '-' <Value>
		@UnaryOperator_Plus = 31,                        // <UnaryOperator> ::= '+' <Value>
		@UnaryOperator_Exclam = 32,                      // <UnaryOperator> ::= '!' <Value>
		@UnaryOperator_Tilde = 33,                       // <UnaryOperator> ::= '~' <Value>
		@UnaryOperator_NOT = 34,                         // <UnaryOperator> ::= NOT <Value>
		@UnaryOperator = 35,                             // <UnaryOperator> ::= <Value>
		@ValidID_Identifier = 36,                        // <Valid ID> ::= Identifier
		@QualifiedID = 37,                               // <Qualified ID> ::= <Valid ID> <Member List>
		@ClassNameID_Identifier = 38,                    // <ClassName ID> ::= Identifier <Member List>
		@MemberList_MemberName = 39,                     // <Member List> ::= <Member List> MemberName
		@MemberList = 40,                                // <Member List> ::= 
		@Value_StringDouble = 41,                        // <Value> ::= StringDouble
		@Value_StringSingle = 42,                        // <Value> ::= StringSingle
		@Value_Number = 43,                              // <Value> ::= Number
		@Value_Decimal = 44,                             // <Value> ::= Decimal
		@Value_Boolean = 45,                             // <Value> ::= Boolean
		@Value = 46,                                     // <Value> ::= <Array Literal>
		@Value2 = 47,                                    // <Value> ::= <Qualified ID>
		@Value3 = 48,                                    // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 49,                       // <Value> ::= '(' <Expression> ')'
		@Value4 = 50,                                    // <Value> ::= <Call Expression>
		@VariableStatements = 51,                        // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 52,                       // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 53,                       // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 54,                       // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 55,            // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 56,           // <Array Literal> ::= '[' <Array List> ']'
		@ArrayList = 57,                                 // <Array List> ::= <Value>
		@ArrayList_Comma = 58,                           // <Array List> ::= <Array List> ',' <Value>
		@Declare_VAR_Identifier = 59,                    // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 60,                 // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 61,                // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 62,                             // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 63,                        // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 64,                      // <Decrement> ::= <Qualified ID> '--'
		@End_Semi = 65,                                  // <End> ::= ';'
		@EndOpt = 66,                                    // <End Opt> ::= <End>
		@EndOpt2 = 67,                                   // <End Opt> ::= 
		@BlockorEnd = 68,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 69,                               // <Block or End> ::= <End>
		@Program = 70,                                   // <Program> ::= <Object Decls>
		@Program2 = 71,                                  // <Program> ::= <Object Decls> <Statements>
		@Program3 = 72,                                  // <Program> ::= <Statements>
		@Program4 = 73,                                  // <Program> ::= 
		@Block_LBrace_RBrace = 74,                       // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 75,                      // <Block> ::= '{' '}'
		@StatementorBlock = 76,                          // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 77,                         // <Statement or Block> ::= <Block>
		@Statements = 78,                                // <Statements> ::= <Statement>
		@Statements2 = 79,                               // <Statements> ::= <Statements> <Statement>
		@Statements3 = 80,                               // <Statements> ::= <Block>
		@Statement = 81,                                 // <Statement> ::= <FlowControl>
		@Statement2 = 82,                                // <Statement> ::= <Variable Statements> <End>
		@Statement3 = 83,                                // <Statement> ::= <Procedure> <End>
		@Statement4 = 84,                                // <Statement> ::= <Call Expression> <End>
		@Statement5 = 85,                                // <Statement> ::= <New Expression> <End>
		@Statement6 = 86,                                // <Statement> ::= <End>
		@ObjectDecls = 87,                               // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 88,                              // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_object = 89,                         // <Object Decl> ::= object <BaseClass ID> <ConstructParams List> <Block> <End>
		@BaseClassID_ColonColon_Identifier = 90,         // <BaseClass ID> ::= <ClassName ID> '::' Identifier
		@BaseClassID_Identifier = 91,                    // <BaseClass ID> ::= Identifier
		@ConstructParamsList_LParen_RParen = 92,         // <ConstructParams List> ::= '(' ')'
		@ConstructParamsList_LParen_RParen2 = 93,        // <ConstructParams List> ::= '(' <Formal Parameter List> ')'
		@ConstructParamsList = 94,                       // <ConstructParams List> ::= 
		@FunctionExpression_function = 95,               // <Function Expression> ::= function <Formal Parameters> <Block>
		@FormalParameters_LParen_RParen = 96,            // <Formal Parameters> ::= '(' ')'
		@FormalParameters_LParen_RParen2 = 97,           // <Formal Parameters> ::= '(' <Formal Parameter List> ')'
		@FormalParameterList_Identifier = 98,            // <Formal Parameter List> ::= Identifier
		@FormalParameterList_Comma_Identifier = 99,      // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
		@CallExpression = 100,                           // <Call Expression> ::= <Qualified ID> <Arguments>
		@CallExpression2 = 101,                          // <Call Expression> ::= <Call Expression> <Arguments>
		@NewExpression_new = 102,                        // <New Expression> ::= new <ClassName ID> <Arguments>
		@CallInternal = 103,                             // <CallInternal> ::= 
		@Arguments_LParen_RParen = 104,                  // <Arguments> ::= '(' ')'
		@Arguments_LParen_RParen2 = 105,                 // <Arguments> ::= '(' <Argument List> ')'
		@ArgumentList = 106,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 107,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 108,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 109,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 110,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 111,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 112,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 113,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 114,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 115,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 116,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 117,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 118,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 119,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 120,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 121,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 122,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 123,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 124,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 125,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 126,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 127,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 128,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 129,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 130,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 131,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 132,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 133,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 134,                               // <Procedure> ::= <ListVars>
		@Procedure9 = 135,                               // <Procedure> ::= <ListObjects>
		@UnsetProc_UNSET = 136,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 137,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 138,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 139,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 140,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 141,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 142,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 143,                            // <ListVars> ::= VARS
		@ListObjects_OBJECTS = 144                       // <ListObjects> ::= OBJECTS
	}
}
