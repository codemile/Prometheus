
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
		@SearchTerm_has = 20,                            // <SearchTerm> ::= has <UnaryOperator>
		@SearchTerm_contains = 21,                       // <SearchTerm> ::= contains <UnaryOperator>
		@SearchTerm = 22,                                // <SearchTerm> ::= <UnaryOperator>
		@UnaryOperator_Minus = 23,                       // <UnaryOperator> ::= '-' <Value>
		@UnaryOperator_Plus = 24,                        // <UnaryOperator> ::= '+' <Value>
		@UnaryOperator_Exclam = 25,                      // <UnaryOperator> ::= '!' <Value>
		@UnaryOperator_Tilde = 26,                       // <UnaryOperator> ::= '~' <Value>
		@UnaryOperator_not = 27,                         // <UnaryOperator> ::= not <Value>
		@UnaryOperator = 28,                             // <UnaryOperator> ::= <Value>
		@Variable_Identifier = 29,                       // <Variable> ::= Identifier
		@Value = 30,                                     // <Value> ::= <Variable>
		@Value_StringDouble = 31,                        // <Value> ::= StringDouble
		@Value_StringSingle = 32,                        // <Value> ::= StringSingle
		@Value_Integer = 33,                             // <Value> ::= Integer
		@Value_Float = 34,                               // <Value> ::= Float
		@Value_Boolean = 35,                             // <Value> ::= Boolean
		@Value_LParen_RParen = 36,                       // <Value> ::= '(' <Expression> ')'
		@Program = 37,                                   // <Program> ::= <Statements>
		@Statements = 38,                                // <Statements> ::= <Statement>
		@Statements2 = 39,                               // <Statements> ::= <Statements> <Statement>
		@IfControl_IF_LParen_RParen_END_IF = 40,         // <IfControl> ::= IF '(' <Expression> ')' <Statements> END IF
		@IfElseControl_IF_LParen_RParen_ELSE_END_IF = 41,  // <IfElseControl> ::= IF '(' <Expression> ')' <Statements> ELSE <Statements> END IF
		@WhileControl_WHILE_LParen_RParen_END_WHILE = 42,  // <WhileControl> ::= WHILE '(' <Expression> ')' <Statements> END WHILE
		@DoControl_DO_WHILE_LParen_RParen = 43,          // <DoControl> ::= DO <Statements> WHILE '(' <Expression> ')'
		@Statement = 44,                                 // <Statement> ::= <SetCommand>
		@Statement2 = 45,                                // <Statement> ::= <UnsetCommand>
		@Statement3 = 46,                                // <Statement> ::= <RejectCommand>
		@Statement4 = 47,                                // <Statement> ::= <AcceptCommand>
		@Statement5 = 48,                                // <Statement> ::= <ScopeCommand>
		@Statement6 = 49,                                // <Statement> ::= <IncludeCommand>
		@Statement7 = 50,                                // <Statement> ::= <PrintCommand>
		@Statement8 = 51,                                // <Statement> ::= <UpperCommand>
		@Statement9 = 52,                                // <Statement> ::= <LowerCommand>
		@Statement10 = 53,                               // <Statement> ::= <TrimCommand>
		@Statement11 = 54,                               // <Statement> ::= <Expression>
		@SetCommand_SET_Eq = 55,                         // <SetCommand> ::= SET <Variable> '=' <Expression>
		@UnsetCommand_UNSET = 56,                        // <UnsetCommand> ::= UNSET <Variable>
		@IncludeCommand_INCLUDE = 57,                    // <IncludeCommand> ::= INCLUDE <Expression>
		@PrintCommand_PRINT_LParen_RParen = 58,          // <PrintCommand> ::= PRINT '(' <Statement> ')'
		@UpperCommand_UPPER_LParen_RParen = 59,          // <UpperCommand> ::= UPPER '(' <Statement> ')'
		@LowerCommand_LOWER_LParen_RParen = 60,          // <LowerCommand> ::= LOWER '(' <Statement> ')'
		@TrimCommand_TRIM_LParen_RParen = 61,            // <TrimCommand> ::= TRIM '(' <Statement> ')'
		@ScopeCommand_SCOPE_LParen_RParen = 62,          // <ScopeCommand> ::= SCOPE '(' <Statement> ')'
		@RejectCommand_REJECT_LParen_RParen = 63,        // <RejectCommand> ::= REJECT '(' <Statement> ')'
		@AcceptCommand_ACCEPT_LParen_RParen = 64         // <AcceptCommand> ::= ACCEPT '(' <Statement> ')'
	}
}
