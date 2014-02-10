
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
		@MemberList_MemberName = 38,                     // <Member List> ::= <Member List> MemberName
		@MemberList = 39,                                // <Member List> ::= 
		@Value_StringDouble = 40,                        // <Value> ::= StringDouble
		@Value_StringSingle = 41,                        // <Value> ::= StringSingle
		@Value_Number = 42,                              // <Value> ::= Number
		@Value_Decimal = 43,                             // <Value> ::= Decimal
		@Value_Boolean = 44,                             // <Value> ::= Boolean
		@Value = 45,                                     // <Value> ::= <Qualified ID>
		@Value2 = 46,                                    // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 47,                       // <Value> ::= '(' <Expression> ')'
		@Value3 = 48,                                    // <Value> ::= <Call Expression>
		@VariableStatements = 49,                        // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 50,                       // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 51,                       // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 52,                       // <Variable Statements> ::= <Decrement>
		@Declare_VAR_Identifier = 53,                    // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 54,                 // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 55,                // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 56,                             // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 57,                        // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 58,                      // <Decrement> ::= <Qualified ID> '--'
		@End_Semi = 59,                                  // <End> ::= ';'
		@EndOpt = 60,                                    // <End Opt> ::= <End>
		@EndOpt2 = 61,                                   // <End Opt> ::= 
		@BlockorEnd = 62,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 63,                               // <Block or End> ::= <End>
		@Program = 64,                                   // <Program> ::= <Object Decls>
		@Program2 = 65,                                  // <Program> ::= <Object Decls> <Statements>
		@Program3 = 66,                                  // <Program> ::= <Statements>
		@Program4 = 67,                                  // <Program> ::= 
		@Block_LBrace_RBrace = 68,                       // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 69,                      // <Block> ::= '{' '}'
		@StatementorBlock = 70,                          // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 71,                         // <Statement or Block> ::= <Block>
		@Statements = 72,                                // <Statements> ::= <Statement>
		@Statements2 = 73,                               // <Statements> ::= <Statements> <Statement>
		@Statements3 = 74,                               // <Statements> ::= <Block>
		@Statement = 75,                                 // <Statement> ::= <FlowControl>
		@Statement2 = 76,                                // <Statement> ::= <Variable Statements> <End>
		@Statement3 = 77,                                // <Statement> ::= <Procedure> <End>
		@Statement4 = 78,                                // <Statement> ::= <Call Expression> <End>
		@Statement5 = 79,                                // <Statement> ::= <New Expression> <End>
		@Statement6 = 80,                                // <Statement> ::= <End>
		@ObjectDecls = 81,                               // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 82,                              // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_Identifier = 83,                     // <Object Decl> ::= <Base Class> Identifier <Block> <End>
		@ObjectDecl_Identifier_LParen_RParen = 84,       // <Object Decl> ::= <Base Class> Identifier '(' ')' <Block> <End>
		@ObjectDecl_Identifier_LParen_RParen2 = 85,      // <Object Decl> ::= <Base Class> Identifier '(' <Formal Parameter List> ')' <Block> <End>
		@BaseClass_Type = 86,                            // <Base Class> ::= Type
		@BaseClass = 87,                                 // <Base Class> ::= <Qualified ID>
		@FunctionDeclaration_function_Identifier_LParen_RParen = 88,  // <Function Declaration> ::= function Identifier '(' <Formal Parameter List> ')' <Block>
		@FunctionDeclaration_function_Identifier_LParen_RParen2 = 89,  // <Function Declaration> ::= function Identifier '(' ')' <Block>
		@FunctionExpression_function_LParen_RParen = 90,  // <Function Expression> ::= function '(' ')' <Block>
		@FunctionExpression_function_LParen_RParen2 = 91,  // <Function Expression> ::= function '(' <Formal Parameter List> ')' <Block>
		@FormalParameterList_Identifier = 92,            // <Formal Parameter List> ::= Identifier
		@FormalParameterList_Comma_Identifier = 93,      // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
		@CallExpression = 94,                            // <Call Expression> ::= <Qualified ID> <Arguments>
		@CallExpression2 = 95,                           // <Call Expression> ::= <Call Expression> <Arguments>
		@NewExpression_new_Identifier = 96,              // <New Expression> ::= new Identifier <Arguments>
		@CallInternal = 97,                              // <CallInternal> ::= 
		@Arguments_LParen_RParen = 98,                   // <Arguments> ::= '(' ')'
		@Arguments_LParen_RParen2 = 99,                  // <Arguments> ::= '(' <Argument List> ')'
		@ArgumentList = 100,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 101,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 102,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 103,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 104,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 105,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 106,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 107,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 108,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 109,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 110,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 111,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 112,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 113,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 114,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 115,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 116,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 117,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 118,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 119,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 120,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 121,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 122,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 123,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 124,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 125,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 126,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 127,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 128,                               // <Procedure> ::= <ListVars>
		@Procedure9 = 129,                               // <Procedure> ::= <ListObjects>
		@UnsetProc_UNSET = 130,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 131,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 132,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 133,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 134,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 135,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 136,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 137,                            // <ListVars> ::= VARS
		@ListObjects_OBJECTS = 138                       // <ListObjects> ::= OBJECTS
	}
}
