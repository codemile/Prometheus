
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
		@Expression_PipePipe = 8,                        // <Expression> ::= <Expression> '||' <AddExpression>
		@Expression_AND = 9,                             // <Expression> ::= <Expression> AND <AddExpression>
		@Expression_OR = 10,                             // <Expression> ::= <Expression> OR <AddExpression>
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
		@UnaryOperator_NOT = 26,                         // <UnaryOperator> ::= NOT <Value>
		@UnaryOperator = 27,                             // <UnaryOperator> ::= <Value>
		@Variable_Identifier = 28,                       // <Variable> ::= Identifier
		@Value_StringDouble = 29,                        // <Value> ::= StringDouble
		@Value_StringSingle = 30,                        // <Value> ::= StringSingle
		@Value_Number = 31,                              // <Value> ::= Number
		@Value_Decimal = 32,                             // <Value> ::= Decimal
		@Value = 33,                                     // <Value> ::= <Variable>
		@Value2 = 34,                                    // <Value> ::= <Function>
		@Value_LParen_RParen = 35,                       // <Value> ::= '(' <Expression> ')'
		@Program = 36,                                   // <Program> ::= <Statements>
		@Statements = 37,                                // <Statements> ::= <Statement>
		@Statements2 = 38,                               // <Statements> ::= <Statements> <Statement>
		@Statement_NewLine = 39,                         // <Statement> ::= <Assignment> NewLine
		@Statement_NewLine2 = 40,                        // <Statement> ::= <Procedure> NewLine
		@Statement_NewLine3 = 41,                        // <Statement> ::= <Function> NewLine
		@Statement_NewLine4 = 42,                        // <Statement> ::= <Increment> NewLine
		@Statement_NewLine5 = 43,                        // <Statement> ::= <Decrement> NewLine
		@Statement_NewLine6 = 44,                        // <Statement> ::= NewLine
		@Function = 45,                                  // <Function> ::= <UpperFunc>
		@Function2 = 46,                                 // <Function> ::= <LowerFunc>
		@Function3 = 47,                                 // <Function> ::= <TrimFunc>
		@Procedure = 48,                                 // <Procedure> ::= <UnsetProc>
		@Procedure2 = 49,                                // <Procedure> ::= <RejectProc>
		@Procedure3 = 50,                                // <Procedure> ::= <AcceptProc>
		@Procedure4 = 51,                                // <Procedure> ::= <ScopeProc>
		@Procedure5 = 52,                                // <Procedure> ::= <IncludeProc>
		@Procedure6 = 53,                                // <Procedure> ::= <PrintProc>
		@IfControl_IF_NewLine_NewLine_END_NewLine = 54,  // <IfControl> ::= IF <Expression> NewLine <Statements> NewLine END NewLine
		@IfElseControl_IF_NewLine_NewLine_ELSE_NewLine_END_NewLine = 55,  // <IfElseControl> ::= IF <Expression> NewLine <Statements> NewLine ELSE NewLine <Statements> END NewLine
		@WhileControl_WHILE_NewLine_NewLine_END_NewLine = 56,  // <WhileControl> ::= WHILE <Expression> NewLine <Statements> NewLine END NewLine
		@DoControl_DO_NewLine_NewLine_WHILE_NewLine = 57,  // <DoControl> ::= DO NewLine <Statements> NewLine WHILE <Expression> NewLine
		@Assignment_VAR_Identifier_Eq = 58,              // <Assignment> ::= VAR Identifier '=' <Expression>
		@Increment_Identifier_PlusPlus = 59,             // <Increment> ::= Identifier '++'
		@Decrement_Identifier_MinusMinus = 60,           // <Decrement> ::= Identifier '--'
		@UnsetProc_UNSET_Identifier = 61,                // <UnsetProc> ::= UNSET Identifier
		@IncludeProc_INCLUDE = 62,                       // <IncludeProc> ::= INCLUDE <Expression>
		@PrintProc_PRINT = 63,                           // <PrintProc> ::= PRINT <Expression>
		@ScopeProc_SCOPE = 64,                           // <ScopeProc> ::= SCOPE <Expression>
		@RejectProc_REJECT = 65,                         // <RejectProc> ::= REJECT <Expression>
		@AcceptProc_ACCEPT = 66,                         // <AcceptProc> ::= ACCEPT <Expression>
		@UpperFunc_UPPER_LParen_RParen = 67,             // <UpperFunc> ::= UPPER '(' <Expression> ')'
		@LowerFunc_LOWER_LParen_RParen = 68,             // <LowerFunc> ::= LOWER '(' <Expression> ')'
		@TrimFunc_TRIM_LParen_RParen = 69                // <TrimFunc> ::= TRIM '(' <Expression> ')'
	}
}
