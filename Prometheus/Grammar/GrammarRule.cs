
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
		@ValidID_this = 37,                              // <Valid ID> ::= this
		@ValidID_base = 38,                              // <Valid ID> ::= base
		@QualifiedID = 39,                               // <Qualified ID> ::= <Valid ID> <Member List>
		@MemberList_MemberName = 40,                     // <Member List> ::= <Member List> MemberName
		@MemberList = 41,                                // <Member List> ::= 
		@Value_StringDouble = 42,                        // <Value> ::= StringDouble
		@Value_StringSingle = 43,                        // <Value> ::= StringSingle
		@Value_Number = 44,                              // <Value> ::= Number
		@Value_Decimal = 45,                             // <Value> ::= Decimal
		@Value_Boolean = 46,                             // <Value> ::= Boolean
		@Value = 47,                                     // <Value> ::= <Qualified ID>
		@Value2 = 48,                                    // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 49,                       // <Value> ::= '(' <Expression> ')'
		@Value3 = 50,                                    // <Value> ::= <Call Expression>
		@VariableStatements = 51,                        // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 52,                       // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 53,                       // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 54,                       // <Variable Statements> ::= <Decrement>
		@Declare_VAR_Identifier = 55,                    // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 56,                 // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 57,                // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 58,                             // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 59,                        // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 60,                      // <Decrement> ::= <Qualified ID> '--'
		@End_Semi = 61,                                  // <End> ::= ';'
		@EndOpt = 62,                                    // <End Opt> ::= <End>
		@EndOpt2 = 63,                                   // <End Opt> ::= 
		@BlockorEnd = 64,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 65,                               // <Block or End> ::= <End>
		@Program = 66,                                   // <Program> ::= <Object Decls>
		@Program2 = 67,                                  // <Program> ::= <Object Decls> <Statements>
		@Program3 = 68,                                  // <Program> ::= <Statements>
		@Program4 = 69,                                  // <Program> ::= 
		@Block_LBrace_RBrace = 70,                       // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 71,                      // <Block> ::= '{' '}'
		@StatementorBlock = 72,                          // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 73,                         // <Statement or Block> ::= <Block>
		@Statements = 74,                                // <Statements> ::= <Statement>
		@Statements2 = 75,                               // <Statements> ::= <Statements> <Statement>
		@Statements3 = 76,                               // <Statements> ::= <Block>
		@Statement = 77,                                 // <Statement> ::= <FlowControl>
		@Statement2 = 78,                                // <Statement> ::= <Variable Statements> <End>
		@Statement3 = 79,                                // <Statement> ::= <Procedure> <End>
		@Statement4 = 80,                                // <Statement> ::= <Call Expression> <End>
		@Statement5 = 81,                                // <Statement> ::= <New Expression> <End>
		@Statement6 = 82,                                // <Statement> ::= <End>
		@ObjectDecls = 83,                               // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 84,                              // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_Identifier = 85,                     // <Object Decl> ::= <Base Class> Identifier <Block>
		@ObjectDecl_Identifier_LParen_RParen = 86,       // <Object Decl> ::= <Base Class> Identifier '(' ')' <Block>
		@ObjectDecl_Identifier_LParen_RParen2 = 87,      // <Object Decl> ::= <Base Class> Identifier '(' <Formal Parameter List> ')' <Block>
		@BaseClass_Type = 88,                            // <Base Class> ::= Type
		@BaseClass_Identifier = 89,                      // <Base Class> ::= Identifier
		@FunctionDeclaration_function_Identifier_LParen_RParen = 90,  // <Function Declaration> ::= function Identifier '(' <Formal Parameter List> ')' <Block>
		@FunctionDeclaration_function_Identifier_LParen_RParen2 = 91,  // <Function Declaration> ::= function Identifier '(' ')' <Block>
		@FunctionExpression_function_LParen_RParen = 92,  // <Function Expression> ::= function '(' ')' <Block>
		@FunctionExpression_function_LParen_RParen2 = 93,  // <Function Expression> ::= function '(' <Formal Parameter List> ')' <Block>
		@FormalParameterList_Identifier = 94,            // <Formal Parameter List> ::= Identifier
		@FormalParameterList_Comma_Identifier = 95,      // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
		@CallExpression = 96,                            // <Call Expression> ::= <Qualified ID> <Arguments>
		@CallExpression2 = 97,                           // <Call Expression> ::= <Call Expression> <Arguments>
		@NewExpression_new_Identifier = 98,              // <New Expression> ::= new Identifier <Arguments>
		@CallInternal = 99,                              // <CallInternal> ::= 
		@Arguments_LParen_RParen = 100,                  // <Arguments> ::= '(' ')'
		@Arguments_LParen_RParen2 = 101,                 // <Arguments> ::= '(' <Argument List> ')'
		@ArgumentList = 102,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 103,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 104,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 105,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 106,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 107,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 108,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 109,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 110,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 111,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 112,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 113,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 114,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 115,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 116,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 117,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 118,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 119,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 120,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 121,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 122,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 123,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 124,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 125,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 126,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 127,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 128,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 129,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 130,                               // <Procedure> ::= <ListVars>
		@Procedure9 = 131,                               // <Procedure> ::= <ListObjects>
		@UnsetProc_UNSET = 132,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 133,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 134,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 135,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 136,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 137,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 138,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 139,                            // <ListVars> ::= VARS
		@ListObjects_OBJECTS = 140                       // <ListObjects> ::= OBJECTS
	}
}
