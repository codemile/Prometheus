
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
		@Value = 45,                                     // <Value> ::= <Array Literal>
		@Value2 = 46,                                    // <Value> ::= <Qualified ID>
		@Value3 = 47,                                    // <Value> ::= <Function Expression>
		@Value_LParen_RParen = 48,                       // <Value> ::= '(' <Expression> ')'
		@Value4 = 49,                                    // <Value> ::= <Call Expression>
		@VariableStatements = 50,                        // <Variable Statements> ::= <Declare>
		@VariableStatements2 = 51,                       // <Variable Statements> ::= <Assignment>
		@VariableStatements3 = 52,                       // <Variable Statements> ::= <Increment>
		@VariableStatements4 = 53,                       // <Variable Statements> ::= <Decrement>
		@ArrayLiteral_LBracket_RBracket = 54,            // <Array Literal> ::= '[' ']'
		@ArrayLiteral_LBracket_RBracket2 = 55,           // <Array Literal> ::= '[' <Array List> ']'
		@ArrayList = 56,                                 // <Array List> ::= <Value>
		@ArrayList_Comma = 57,                           // <Array List> ::= <Array List> ',' <Value>
		@Declare_VAR_Identifier = 58,                    // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 59,                 // <Declare> ::= VAR Identifier '=' <Expression>
		@Declare_VAR_Identifier_Eq2 = 60,                // <Declare> ::= VAR Identifier '=' <New Expression>
		@Assignment_Eq = 61,                             // <Assignment> ::= <Qualified ID> '=' <Expression>
		@Increment_PlusPlus = 62,                        // <Increment> ::= <Qualified ID> '++'
		@Decrement_MinusMinus = 63,                      // <Decrement> ::= <Qualified ID> '--'
		@End_Semi = 64,                                  // <End> ::= ';'
		@EndOpt = 65,                                    // <End Opt> ::= <End>
		@EndOpt2 = 66,                                   // <End Opt> ::= 
		@BlockorEnd = 67,                                // <Block or End> ::= <Block>
		@BlockorEnd2 = 68,                               // <Block or End> ::= <End>
		@Program = 69,                                   // <Program> ::= <Object Decls>
		@Program2 = 70,                                  // <Program> ::= <Object Decls> <Statements>
		@Program3 = 71,                                  // <Program> ::= <Statements>
		@Program4 = 72,                                  // <Program> ::= 
		@Block_LBrace_RBrace = 73,                       // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 74,                      // <Block> ::= '{' '}'
		@StatementorBlock = 75,                          // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 76,                         // <Statement or Block> ::= <Block>
		@Statements = 77,                                // <Statements> ::= <Statement>
		@Statements2 = 78,                               // <Statements> ::= <Statements> <Statement>
		@Statements3 = 79,                               // <Statements> ::= <Block>
		@Statement = 80,                                 // <Statement> ::= <FlowControl>
		@Statement2 = 81,                                // <Statement> ::= <Variable Statements> <End>
		@Statement3 = 82,                                // <Statement> ::= <Procedure> <End>
		@Statement4 = 83,                                // <Statement> ::= <Call Expression> <End>
		@Statement5 = 84,                                // <Statement> ::= <New Expression> <End>
		@Statement6 = 85,                                // <Statement> ::= <End>
		@ObjectDecls = 86,                               // <Object Decls> ::= <Object Decl>
		@ObjectDecls2 = 87,                              // <Object Decls> ::= <Object Decls> <Object Decl>
		@ObjectDecl_Identifier = 88,                     // <Object Decl> ::= <Base Class> Identifier <Block> <End>
		@ObjectDecl_Identifier_LParen_RParen = 89,       // <Object Decl> ::= <Base Class> Identifier '(' ')' <Block> <End>
		@ObjectDecl_Identifier_LParen_RParen2 = 90,      // <Object Decl> ::= <Base Class> Identifier '(' <Formal Parameter List> ')' <Block> <End>
		@BaseClass_Type = 91,                            // <Base Class> ::= Type
		@BaseClass = 92,                                 // <Base Class> ::= <Qualified ID>
		@FunctionDeclaration_function_Identifier_LParen_RParen = 93,  // <Function Declaration> ::= function Identifier '(' <Formal Parameter List> ')' <Block>
		@FunctionDeclaration_function_Identifier_LParen_RParen2 = 94,  // <Function Declaration> ::= function Identifier '(' ')' <Block>
		@FunctionExpression_function_LParen_RParen = 95,  // <Function Expression> ::= function '(' ')' <Block>
		@FunctionExpression_function_LParen_RParen2 = 96,  // <Function Expression> ::= function '(' <Formal Parameter List> ')' <Block>
		@FormalParameterList_Identifier = 97,            // <Formal Parameter List> ::= Identifier
		@FormalParameterList_Comma_Identifier = 98,      // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
		@CallExpression = 99,                            // <Call Expression> ::= <Qualified ID> <Arguments>
		@CallExpression2 = 100,                          // <Call Expression> ::= <Call Expression> <Arguments>
		@NewExpression_new = 101,                        // <New Expression> ::= new <Qualified ID> <Arguments>
		@CallInternal = 102,                             // <CallInternal> ::= 
		@Arguments_LParen_RParen = 103,                  // <Arguments> ::= '(' ')'
		@Arguments_LParen_RParen2 = 104,                 // <Arguments> ::= '(' <Argument List> ')'
		@ArgumentList = 105,                             // <Argument List> ::= <Expression>
		@ArgumentList_Comma = 106,                       // <Argument List> ::= <Argument List> ',' <Expression>
		@FlowControl = 107,                              // <FlowControl> ::= <IfControl>
		@FlowControl2 = 108,                             // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 109,                             // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 110,                             // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 111,                             // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 112,                             // <FlowControl> ::= <ForControl>
		@FlowControl7 = 113,                             // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 114,                             // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 115,                             // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 116,               // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 117,          // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 118,       // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 119,       // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 120,  // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 121,  // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 122,          // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 123,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 124,                       // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 125,                 // <ContinueControl> ::= CONTINUE
		@Procedure = 126,                                // <Procedure> ::= <UnsetProc>
		@Procedure2 = 127,                               // <Procedure> ::= <RejectProc>
		@Procedure3 = 128,                               // <Procedure> ::= <AcceptProc>
		@Procedure4 = 129,                               // <Procedure> ::= <ScopeProc>
		@Procedure5 = 130,                               // <Procedure> ::= <IncludeProc>
		@Procedure6 = 131,                               // <Procedure> ::= <PrintProc>
		@Procedure7 = 132,                               // <Procedure> ::= <ReturnProc>
		@Procedure8 = 133,                               // <Procedure> ::= <ListVars>
		@Procedure9 = 134,                               // <Procedure> ::= <ListObjects>
		@UnsetProc_UNSET = 135,                          // <UnsetProc> ::= UNSET <Qualified ID>
		@RejectProc_REJECT = 136,                        // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 137,                        // <AcceptProc> ::= ACCEPT <Expression>
		@ScopeProc_SCOPE = 138,                          // <ScopeProc> ::= SCOPE <Expression>
		@IncludeProc_INCLUDE = 139,                      // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 140,                          // <PrintProc> ::= PRINT <Expression>
		@ReturnProc_RETURN = 141,                        // <ReturnProc> ::= RETURN <Expression>
		@ListVars_VARS = 142,                            // <ListVars> ::= VARS
		@ListObjects_OBJECTS = 143                       // <ListObjects> ::= OBJECTS
	}
}
