
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
		@DivideExpression_Div = 18,                      // <DivideExpression> ::= <DivideExpression> '/' <SearchTerm>
		@DivideExpression = 19,                          // <DivideExpression> ::= <SearchTerm>
		@SearchTerm_HAS = 20,                            // <SearchTerm> ::= HAS <UnaryOperator>
		@SearchTerm_CONTAINS = 21,                       // <SearchTerm> ::= CONTAINS <UnaryOperator>
		@SearchTerm_STARTS_WITH = 22,                    // <SearchTerm> ::= STARTS WITH <UnaryOperator>
		@SearchTerm_ENDS_WITH = 23,                      // <SearchTerm> ::= ENDS WITH <UnaryOperator>
		@SearchTerm = 24,                                // <SearchTerm> ::= <UnaryOperator>
		@UnaryOperator_Minus = 25,                       // <UnaryOperator> ::= '-' <Value>
		@UnaryOperator_Plus = 26,                        // <UnaryOperator> ::= '+' <Value>
		@UnaryOperator_Exclam = 27,                      // <UnaryOperator> ::= '!' <Value>
		@UnaryOperator_Tilde = 28,                       // <UnaryOperator> ::= '~' <Value>
		@UnaryOperator_not = 29,                         // <UnaryOperator> ::= not <Value>
		@UnaryOperator = 30,                             // <UnaryOperator> ::= <Value>
		@Variable_Identifier = 31,                       // <Variable> ::= Identifier
		@Value = 32,                                     // <Value> ::= <Variable>
		@Value_StringDouble = 33,                        // <Value> ::= StringDouble
		@Value_StringSingle = 34,                        // <Value> ::= StringSingle
		@Value_Integer = 35,                             // <Value> ::= Integer
		@Value_Float = 36,                               // <Value> ::= Float
		@Value_Boolean = 37,                             // <Value> ::= Boolean
		@Value_LParen_RParen = 38,                       // <Value> ::= '(' <Expression> ')'
		@Program = 39,                                   // <Program> ::= <Statements>
		@Statements = 40,                                // <Statements> ::= <Statement>
		@Statements2 = 41,                               // <Statements> ::= <Statements> <Statement>
		@IfControl_IF_LParen_RParen_END = 42,            // <IfControl> ::= IF '(' <Expression> ')' <Statements> END
		@IfElseControl_IF_LParen_RParen_ELSE_END = 43,   // <IfElseControl> ::= IF '(' <Expression> ')' <Statements> ELSE <Statements> END
		@WhileControl_WHILE_LParen_RParen_ENDWHILE = 44,  // <WhileControl> ::= WHILE '(' <Expression> ')' <Statements> ENDWHILE
		@DoControl_DO_WHILE_LParen_RParen = 45,          // <DoControl> ::= DO <Statements> WHILE '(' <Expression> ')'
		@Statement_LParen_RParen = 46,                   // <Statement> ::= '(' <Statement> ')'
		@Statement = 47,                                 // <Statement> ::= <SetCommand>
		@Statement2 = 48,                                // <Statement> ::= <UnsetCommand>
		@Statement3 = 49,                                // <Statement> ::= <RejectCommand>
		@Statement4 = 50,                                // <Statement> ::= <AcceptCommand>
		@Statement5 = 51,                                // <Statement> ::= <ScopeCommand>
		@Statement6 = 52,                                // <Statement> ::= <IncludeCommand>
		@Statement7 = 53,                                // <Statement> ::= <PrintCommand>
		@Statement8 = 54,                                // <Statement> ::= <UpperCommand>
		@Statement9 = 55,                                // <Statement> ::= <LowerCommand>
		@Statement10 = 56,                               // <Statement> ::= <TrimCommand>
		@Statement11 = 57,                               // <Statement> ::= <Expression>
		@SetCommand_SET_Eq = 58,                         // <SetCommand> ::= SET <Variable> '=' <Expression>
		@UnsetCommand_UNSET = 59,                        // <UnsetCommand> ::= UNSET <Variable>
		@IncludeCommand_INCLUDE = 60,                    // <IncludeCommand> ::= INCLUDE <Expression>
		@PrintCommand_PRINT = 61,                        // <PrintCommand> ::= PRINT <Statement>
		@UpperCommand_UPPER = 62,                        // <UpperCommand> ::= UPPER <Statement>
		@LowerCommand_LOWER = 63,                        // <LowerCommand> ::= LOWER <Statement>
		@TrimCommand_TRIM = 64,                          // <TrimCommand> ::= TRIM <Statement>
		@ScopeCommand_SCOPE = 65,                        // <ScopeCommand> ::= SCOPE <Variable>
		@RejectCommand_REJECT = 66,                      // <RejectCommand> ::= REJECT <Expression>
		@AcceptCommand_ACCEPT = 67                       // <AcceptCommand> ::= ACCEPT <Expression>
	}
}
