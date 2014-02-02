
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
		@Statements = 46,                                // <Statements> ::= <Statement>
		@Statements2 = 47,                               // <Statements> ::= <Statements> <Statement>
		@Statement_NewLine = 48,                         // <Statement> ::= <FlowControl> NewLine
		@Statement_NewLine2 = 49,                        // <Statement> ::= <Variables> NewLine
		@Statement_NewLine3 = 50,                        // <Statement> ::= <Procedure> NewLine
		@Statement_NewLine4 = 51,                        // <Statement> ::= <Function> NewLine
		@Statement_NewLine5 = 52,                        // <Statement> ::= NewLine
		@FlowControl = 53,                               // <FlowControl> ::= <IfControl>
		@FlowControl2 = 54,                              // <FlowControl> ::= <DoWhileControl>
		@FlowControl3 = 55,                              // <FlowControl> ::= <DoUntilControl>
		@FlowControl4 = 56,                              // <FlowControl> ::= <LoopWhileControl>
		@FlowControl5 = 57,                              // <FlowControl> ::= <LoopUntilControl>
		@FlowControl6 = 58,                              // <FlowControl> ::= <ForControl>
		@FlowControl7 = 59,                              // <FlowControl> ::= <ForStepControl>
		@FlowControl8 = 60,                              // <FlowControl> ::= <BreakControl>
		@FlowControl9 = 61,                              // <FlowControl> ::= <ContinueControl>
		@IfControl_IF_THEN_NewLine = 62,                 // <IfControl> ::= IF <Expression> THEN NewLine <Statements> <ElseIfControl>
		@ElseIfControl_END_IF = 63,                      // <ElseIfControl> ::= END IF
		@ElseIfControl_ELSE_NewLine_END_IF = 64,         // <ElseIfControl> ::= ELSE NewLine <Statements> END IF
		@ElseIfControl_ELSEIF_THEN_NewLine = 65,         // <ElseIfControl> ::= ELSEIF <Expression> THEN NewLine <Statements> <ElseIfControl>
		@DoWhileControl_DO_WHILE_NewLine_LOOP = 66,      // <DoWhileControl> ::= DO WHILE <Expression> NewLine <Statements> LOOP
		@DoWhileControl_WHILE_NewLine_END_WHILE = 67,    // <DoWhileControl> ::= WHILE <Expression> NewLine <Statements> END WHILE
		@DoUntilControl_DO_UNTIL_NewLine_LOOP = 68,      // <DoUntilControl> ::= DO UNTIL <Expression> NewLine <Statements> LOOP
		@DoUntilControl_UNTIL_NewLine_END_UNTIL = 69,    // <DoUntilControl> ::= UNTIL <Expression> NewLine <Statements> END UNTIL
		@LoopWhileControl_DO_NewLine_LOOP_WHILE = 70,    // <LoopWhileControl> ::= DO NewLine <Statements> LOOP WHILE <Expression>
		@LoopUntilControl_DO_NewLine_LOOP_UNTIL = 71,    // <LoopUntilControl> ::= DO NewLine <Statements> LOOP UNTIL <Expression>
		@ForControl_FOR_Identifier_Eq_TO_NewLine_END_FOR = 72,  // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> NewLine <Statements> END FOR
		@ForStepControl_FOR_Identifier_Eq_TO_STEP_NewLine_END_FOR = 73,  // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> NewLine <Statements> END FOR
		@BreakControl_BREAK = 74,                        // <BreakControl> ::= BREAK
		@ContinueControl_CONTINUE = 75,                  // <ContinueControl> ::= CONTINUE
		@Variables = 76,                                 // <Variables> ::= <Declare>
		@Variables2 = 77,                                // <Variables> ::= <Assignment>
		@Variables3 = 78,                                // <Variables> ::= <ListVars>
		@Variables4 = 79,                                // <Variables> ::= <Increment>
		@Variables5 = 80,                                // <Variables> ::= <Decrement>
		@Declare_VAR_Identifier = 81,                    // <Declare> ::= VAR Identifier
		@Declare_VAR_Identifier_Eq = 82,                 // <Declare> ::= VAR Identifier '=' <Expression>
		@Assignment_Identifier_Eq = 83,                  // <Assignment> ::= Identifier '=' <Expression>
		@ListVars_VARS = 84,                             // <ListVars> ::= VARS
		@Increment_Identifier_PlusPlus = 85,             // <Increment> ::= Identifier '++'
		@Decrement_Identifier_MinusMinus = 86,           // <Decrement> ::= Identifier '--'
		@Procedure = 87,                                 // <Procedure> ::= <UnsetProc>
		@Procedure2 = 88,                                // <Procedure> ::= <RejectProc>
		@Procedure3 = 89,                                // <Procedure> ::= <AcceptProc>
		@Procedure4 = 90,                                // <Procedure> ::= <ScopeProc>
		@Procedure5 = 91,                                // <Procedure> ::= <IncludeProc>
		@Procedure6 = 92,                                // <Procedure> ::= <PrintProc>
		@UnsetProc_UNSET_Identifier = 93,                // <UnsetProc> ::= UNSET Identifier
		@IncludeProc_INCLUDE = 94,                       // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 95,                           // <PrintProc> ::= PRINT <Expression>
		@ScopeProc_SCOPE = 96,                           // <ScopeProc> ::= SCOPE <Expression>
		@RejectProc_REJECT = 97,                         // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 98,                         // <AcceptProc> ::= ACCEPT <Expression>
		@Function = 99,                                  // <Function> ::= <UpperFunc>
		@Function2 = 100,                                // <Function> ::= <LowerFunc>
		@Function3 = 101,                                // <Function> ::= <TrimFunc>
		@UpperFunc_UPPER_LParen_RParen = 102,            // <UpperFunc> ::= UPPER '(' <Expression> ')'
		@LowerFunc_LOWER_LParen_RParen = 103,            // <LowerFunc> ::= LOWER '(' <Expression> ')'
		@TrimFunc_TRIM_LParen_RParen = 104               // <TrimFunc> ::= TRIM '(' <Expression> ')'
	}
}
