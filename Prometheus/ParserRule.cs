
namespace Prometheus
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum ParserRule
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
		@Program2 = 38,                                  // <Program> ::= <Block>
		@Block_LBrace_RBrace = 39,                       // <Block> ::= '{' <Statements> '}'
		@Statements = 40,                                // <Statements> ::= <Statement>
		@Statements2 = 41,                               // <Statements> ::= <Statements> <Statement>
		@IfBlock_if_LParen_RParen = 42,                  // <IfBlock> ::= if '(' <Expression> ')' <Block>
		@IfElseBlock_if_LParen_RParen_else = 43,         // <IfElseBlock> ::= if '(' <Expression> ')' <Block> else <Block>
		@Statement = 44,                                 // <Statement> ::= <SetCommand>
		@Statement2 = 45,                                // <Statement> ::= <UnsetCommand>
		@Statement3 = 46,                                // <Statement> ::= <RejectCommand>
		@Statement4 = 47,                                // <Statement> ::= <AcceptCommand>
		@Statement5 = 48,                                // <Statement> ::= <ScopeCommand>
		@Statement6 = 49,                                // <Statement> ::= <IncludeCommand>
		@Statement7 = 50,                                // <Statement> ::= <AssertCommand>
		@Statement8 = 51,                                // <Statement> ::= <DebugCommand>
		@Statement9 = 52,                                // <Statement> ::= <TraceCommand>
		@SetCommand_set_Eq_Semi = 53,                    // <SetCommand> ::= set <Variable> '=' <Expression> ';'
		@UnsetCommand_unset_Semi = 54,                   // <UnsetCommand> ::= unset <Variable> ';'
		@IncludeCommand_include_Semi = 55,               // <IncludeCommand> ::= include <Expression> ';'
		@AssertCommand_assert_Semi = 56,                 // <AssertCommand> ::= assert <Expression> <Expression> ';'
		@DebugCommand_debug_Semi = 57,                   // <DebugCommand> ::= debug <Expression> ';'
		@TraceCommand_trace_Semi = 58,                   // <TraceCommand> ::= trace <Expression> <Expression> ';'
		@ScopeCommand_scope_Semi = 59,                   // <ScopeCommand> ::= scope <Expression> ';'
		@RejectCommand_reject_Semi = 60,                 // <RejectCommand> ::= reject <Expression> ';'
		@AcceptCommand_accept_Semi = 61                  // <AcceptCommand> ::= accept <Expression> ';'
	}
}
