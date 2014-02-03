
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
		@UnaryOperator_MinusMinus = 28,                  // <UnaryOperator> ::= '--' <Variable>
		@UnaryOperator_PlusPlus = 29,                    // <UnaryOperator> ::= '++' <Variable>
		@UnaryOperator_Minus = 30,                       // <UnaryOperator> ::= '-' <Value>
		@UnaryOperator_Plus = 31,                        // <UnaryOperator> ::= '+' <Value>
		@UnaryOperator_Exclam = 32,                      // <UnaryOperator> ::= '!' <Value>
		@UnaryOperator_Tilde = 33,                       // <UnaryOperator> ::= '~' <Value>
		@UnaryOperator_NOT = 34,                         // <UnaryOperator> ::= NOT <Value>
		@UnaryOperator = 35,                             // <UnaryOperator> ::= <Value>
		@Variable_Identifier = 36,                       // <Variable> ::= Identifier
		@Value_StringDouble = 37,                        // <Value> ::= StringDouble
		@Value_StringSingle = 38,                        // <Value> ::= StringSingle
		@Value_Number = 39,                              // <Value> ::= Number
		@Value_Decimal = 40,                             // <Value> ::= Decimal
		@Value_Boolean = 41,                             // <Value> ::= Boolean
		@Value = 42,                                     // <Value> ::= <Variable>
		@Value2 = 43,                                    // <Value> ::= <Function>
		@Value_LParen_RParen = 44,                       // <Value> ::= '(' <Expression> ')'
		@Program = 45,                                   // <Program> ::= <Statements>
		@Program2 = 46,                                  // <Program> ::= 
		@Block_LBrace_RBrace = 47,                       // <Block> ::= '{' <Statements> '}'
		@Block_LBrace_RBrace2 = 48,                      // <Block> ::= '{' '}'
		@StatementorBlock = 49,                          // <Statement or Block> ::= <Statement>
		@StatementorBlock2 = 50,                         // <Statement or Block> ::= <Block>
		@Statements = 51,                                // <Statements> ::= <Statement>
		@Statements2 = 52,                               // <Statements> ::= <Statements> <Statement>
		@Statements3 = 53,                               // <Statements> ::= <Block>
		@Statement = 54,                                 // <Statement> ::= <FlowControl>
		@Statement_Semi = 55,                            // <Statement> ::= <Variables> ';'
		@Statement_Semi2 = 56,                           // <Statement> ::= <Procedure> ';'
		@Statement_Semi3 = 57,                           // <Statement> ::= <Function> ';'
		@FlowControl = 58,                               // <FlowControl> ::= <IfControl>
		@FlowControl2 = 59,                              // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 60,                              // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 61,                              // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 62,                              // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 63,                              // <FlowControl> ::= <ForControl>
		@FlowControl7 = 64,                              // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 65,                              // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 66,                              // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_LParen_RParen = 67,                // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
		@IfControl_IF_LParen_RParen_ELSE = 68,           // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
		@DoWhileControl_WHILE_LParen_RParen = 69,        // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
		@DoUntilControl_UNTIL_LParen_RParen = 70,        // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
		@LoopWhileControl_DO_WHILE_LParen_RParen = 71,   // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
		@LoopUntilControl_DO_UNTIL_LParen_RParen = 72,   // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
		@ForControl_FOR_Identifier_Eq_TO = 73,           // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
		@ForStepControl_FOR_Identifier_Eq_TO_STEP = 74,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
		@BreakControl_BREAK = 75,                        // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 76,                  // <ContinueControl> ::= CONTINUE
		@Variables = 77,                                 // <Variables> ::= <Declare>
		@Variables2 = 78,                                // <Variables> ::= <Assignment>
		@Variables3 = 79,                                // <Variables> ::= <ListVars>
		@Variables4 = 80,                                // <Variables> ::= <Increment>
		@Variables5 = 81,                                // <Variables> ::= <Decrement>
		@Declare_VAR_Identifier = 82,                    // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 83,                 // <Declare> ::= VAR Identifier '=' <Expression>
		@Assignment_Identifier_Eq = 84,                  // <Assignment> ::= Identifier '=' <Expression>
		@ListVars_VARS = 85,                             // <ListVars> ::= VARS
		@Increment_Identifier_PlusPlus = 86,             // <Increment> ::= Identifier '++'
		@Decrement_Identifier_MinusMinus = 87,           // <Decrement> ::= Identifier '--'
		@Procedure = 88,                                 // <Procedure> ::= <UnsetProc>
		@Procedure2 = 89,                                // <Procedure> ::= <RejectProc>
		@Procedure3 = 90,                                // <Procedure> ::= <AcceptProc>
		@Procedure4 = 91,                                // <Procedure> ::= <ScopeProc>
		@Procedure5 = 92,                                // <Procedure> ::= <IncludeProc>
		@Procedure6 = 93,                                // <Procedure> ::= <PrintProc>
		@UnsetProc_UNSET_Identifier = 94,                // <UnsetProc> ::= UNSET Identifier
		@IncludeProc_INCLUDE = 95,                       // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 96,                           // <PrintProc> ::= PRINT <Expression>
		@ScopeProc_SCOPE = 97,                           // <ScopeProc> ::= SCOPE <Expression>
		@RejectProc_REJECT = 98,                         // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 99,                         // <AcceptProc> ::= ACCEPT <Expression>
		@Function = 100,                                 // <Function> ::= <UpperFunc>
		@Function2 = 101,                                // <Function> ::= <LowerFunc>
		@Function3 = 102,                                // <Function> ::= <TrimFunc>
		@UpperFunc_UPPER_LParen_RParen = 103,            // <UpperFunc> ::= UPPER '(' <Expression> ')'
		@LowerFunc_LOWER_LParen_RParen = 104,            // <LowerFunc> ::= LOWER '(' <Expression> ')'
		@TrimFunc_TRIM_LParen_RParen = 105               // <TrimFunc> ::= TRIM '(' <Expression> ')'
	}
}
