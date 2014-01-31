
namespace Prometheus.Grammar
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum GrammarRule
	{
		@Expression_Gt = 0,                              // <Expression> ::= <Expression> '>' <AddExpression>
		@Expression_Lt = 1,                              // <Expression> ::= <Expression> '<' <AddExpression>
		@Expression_LtEq = 2,                            // <Expression> ::= <Expression> '<=' <AddExpression>
		@Expression_GtEq = 3,                            // <Expression> ::= <Expression> '>=' <AddExpression>
		@Expression_EqEq = 4,                            // <Expression> ::= <Expression> '==' <AddExpression>
		@Expression_LtGt = 5,                            // <Expression> ::= <Expression> '<>' <AddExpression>
		@Expression_ExclamEq = 6,                        // <Expression> ::= <Expression> '!=' <AddExpression>
		@Expression_AmpAmp = 7,                          // <Expression> ::= <Expression> '&&' <AddExpression>
		@Expression_and = 8,                             // <Expression> ::= <Expression> and <AddExpression>
		@Expression_PipePipe = 9,                        // <Expression> ::= <Expression> '||' <AddExpression>
		@Expression_or = 10,                             // <Expression> ::= <Expression> or <AddExpression>
		@Expression = 11,                                // <Expression> ::= <AddExpression>
		@AddExpression_Plus = 12,                        // <AddExpression> ::= <AddExpression> '+' <SubExpression>
		@AddExpression = 13,                             // <AddExpression> ::= <SubExpression>
		@SubExpression_Minus = 14,                       // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
		@SubExpression = 15,                             // <SubExpression> ::= <MultiplyExpression>
		@MultiplyExpression_Times = 16,                  // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
		@MultiplyExpression = 17,                        // <MultiplyExpression> ::= <DivideExpression>
		@DivideExpression_Div = 18,                      // <DivideExpression> ::= <DivideExpression> '/' <UnaryOperator>
		@DivideExpression = 19,                          // <DivideExpression> ::= <UnaryOperator>
		@UnaryOperator_MinusMinus = 20,                  // <UnaryOperator> ::= '--' <Variable>
		@UnaryOperator_PlusPlus = 21,                    // <UnaryOperator> ::= '++' <Variable>
		@UnaryOperator_Minus = 22,                       // <UnaryOperator> ::= '-' <Value>
		@UnaryOperator_Plus = 23,                        // <UnaryOperator> ::= '+' <Value>
		@UnaryOperator_Exclam = 24,                      // <UnaryOperator> ::= '!' <Value>
		@UnaryOperator_Tilde = 25,                       // <UnaryOperator> ::= '~' <Value>
		@UnaryOperator_not = 26,                         // <UnaryOperator> ::= not <Value>
		@UnaryOperator = 27,                             // <UnaryOperator> ::= <Value>
		@Variable_Identifier = 28,                       // <Variable> ::= Identifier
		@Value = 29,                                     // <Value> ::= <Variable>
		@Value_StringDouble = 30,                        // <Value> ::= StringDouble
		@Value_StringSingle = 31,                        // <Value> ::= StringSingle
		@Value_Integer = 32,                             // <Value> ::= Integer
		@Value_Float = 33,                               // <Value> ::= Float
		@Value_Boolean = 34,                             // <Value> ::= Boolean
		@Value2 = 35,                                    // <Value> ::= <Function>
		@Value_LParen_RParen = 36,                       // <Value> ::= '(' <Expression> ')'
		@Program = 37,                                   // <Program> ::= <Statements>
		@Statements = 38,                                // <Statements> ::= <Statement>
		@Statements2 = 39,                               // <Statements> ::= <Statements> <Statement>
		@Statement = 40,                                 // <Statement> ::= <Assignment>
		@Statement2 = 41,                                // <Statement> ::= <Procedure>
		@Statement3 = 42,                                // <Statement> ::= <Function>
		@Statement4 = 43,                                // <Statement> ::= <Increment>
		@Statement5 = 44,                                // <Statement> ::= <Decrement>
		@Function = 45,                                  // <Function> ::= <UpperFunc>
		@Function2 = 46,                                 // <Function> ::= <LowerFunc>
		@Function3 = 47,                                 // <Function> ::= <TrimFunc>
		@Procedure = 48,                                 // <Procedure> ::= <UnsetProc>
		@Procedure2 = 49,                                // <Procedure> ::= <RejectProc>
		@Procedure3 = 50,                                // <Procedure> ::= <AcceptProc>
		@Procedure4 = 51,                                // <Procedure> ::= <ScopeProc>
		@Procedure5 = 52,                                // <Procedure> ::= <IncludeProc>
		@Procedure6 = 53,                                // <Procedure> ::= <PrintProc>
		@IfControl_IF_LParen_RParen_END = 54,            // <IfControl> ::= IF '(' <Value> ')' <Statements> END
		@IfElseControl_IF_LParen_RParen_ELSE_END = 55,   // <IfElseControl> ::= IF '(' <Value> ')' <Statements> ELSE <Statements> END
		@WhileControl_WHILE_LParen_RParen_ENDWHILE = 56,  // <WhileControl> ::= WHILE '(' <Value> ')' <Statements> ENDWHILE
		@DoControl_DO_WHILE_LParen_RParen = 57,          // <DoControl> ::= DO <Statements> WHILE '(' <Value> ')'
		@Assignment_Eq = 58,                             // <Assignment> ::= <Variable> '=' <Value>
		@Increment_PlusPlus = 59,                        // <Increment> ::= <Variable> '++'
		@Decrement_MinusMinus = 60,                      // <Decrement> ::= <Variable> '--'
		@UnsetProc_UNSET = 61,                           // <UnsetProc> ::= UNSET <Variable>
		@IncludeProc_INCLUDE = 62,                       // <IncludeProc> ::= INCLUDE <Value>
		@PrintProc_PRINT = 63,                           // <PrintProc> ::= PRINT <Value>
		@ScopeProc_SCOPE = 64,                           // <ScopeProc> ::= SCOPE <Variable>
		@RejectProc_REJECT = 65,                         // <RejectProc> ::= REJECT <Value>
		@AcceptProc_ACCEPT = 66,                         // <AcceptProc> ::= ACCEPT <Value>
		@UpperFunc_UPPER = 67,                           // <UpperFunc> ::= UPPER <Value>
		@LowerFunc_LOWER = 68,                           // <LowerFunc> ::= LOWER <Value>
		@TrimFunc_TRIM = 69                              // <TrimFunc> ::= TRIM <Value>
	}
}
