namespace Prometheus.Grammar
{
    /// <summary>
    /// This enum is generated at compile time by the GOLD template generator.
    /// Do not make changes to this file.
    /// </summary>
    public enum GrammarRule
    {
        @Expression = 0, // <Expression> ::= <GtOperator>
        @GtOperator_Gt = 1, // <GtOperator> ::= <GtOperator> '>' <LtOperator>
        @GtOperator = 2, // <GtOperator> ::= <LtOperator>
        @LtOperator_Lt = 3, // <LtOperator> ::= <LtOperator> '<' <GteOperator>
        @LtOperator = 4, // <LtOperator> ::= <GteOperator>
        @GteOperator_GtEq = 5, // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
        @GteOperator = 6, // <GteOperator> ::= <LteOperator>
        @LteOperator_LtEq = 7, // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
        @LteOperator = 8, // <LteOperator> ::= <EqualOperator>
        @EqualOperator_EqEq = 9, // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
        @EqualOperator = 10, // <EqualOperator> ::= <NotEqualOperator>
        @NotEqualOperator_ExclamEq = 11, // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
        @NotEqualOperator_LtGt = 12, // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
        @NotEqualOperator = 13, // <NotEqualOperator> ::= <AndOperator>
        @AndOperator_AND = 14, // <AndOperator> ::= <AndOperator> AND <OrOperator>
        @AndOperator_AmpAmp = 15, // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
        @AndOperator = 16, // <AndOperator> ::= <OrOperator>
        @OrOperator_OR = 17, // <OrOperator> ::= <OrOperator> OR <AddExpression>
        @OrOperator_PipePipe = 18, // <OrOperator> ::= <OrOperator> '||' <AddExpression>
        @OrOperator = 19, // <OrOperator> ::= <AddExpression>
        @AddExpression_Plus = 20, // <AddExpression> ::= <AddExpression> '+' <SubExpression>
        @AddExpression = 21, // <AddExpression> ::= <SubExpression>
        @SubExpression_Minus = 22, // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
        @SubExpression = 23, // <SubExpression> ::= <MultiplyExpression>
        @MultiplyExpression_Times = 24, // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
        @MultiplyExpression = 25, // <MultiplyExpression> ::= <DivideExpression>
        @DivideExpression_Div = 26, // <DivideExpression> ::= <DivideExpression> '/' <UnaryOperator>
        @DivideExpression = 27, // <DivideExpression> ::= <UnaryOperator>
        @UnaryOperator_MinusMinus = 28, // <UnaryOperator> ::= '--' <Variable>
        @UnaryOperator_PlusPlus = 29, // <UnaryOperator> ::= '++' <Variable>
        @UnaryOperator_Minus = 30, // <UnaryOperator> ::= '-' <Value>
        @UnaryOperator_Plus = 31, // <UnaryOperator> ::= '+' <Value>
        @UnaryOperator_Exclam = 32, // <UnaryOperator> ::= '!' <Value>
        @UnaryOperator_Tilde = 33, // <UnaryOperator> ::= '~' <Value>
        @UnaryOperator_NOT = 34, // <UnaryOperator> ::= NOT <Value>
        @UnaryOperator = 35, // <UnaryOperator> ::= <Value>
        @Variable_Identifier = 36, // <Variable> ::= Identifier
        @Variable_this = 37, // <Variable> ::= this
        @Value_StringDouble = 38, // <Value> ::= StringDouble
        @Value_StringSingle = 39, // <Value> ::= StringSingle
        @Value_Number = 40, // <Value> ::= Number
        @Value_Decimal = 41, // <Value> ::= Decimal
        @Value_Boolean = 42, // <Value> ::= Boolean
        @Value = 43, // <Value> ::= <Variable>
        @Value2 = 44, // <Value> ::= <Function Expression>
        @Value_LParen_RParen = 45, // <Value> ::= '(' <Expression> ')'
        @Value3 = 46, // <Value> ::= <Call Expression>
        @Program = 47, // <Program> ::= <Statements>
        @Program2 = 48, // <Program> ::= 
        @Block_LBrace_RBrace = 49, // <Block> ::= '{' <Statements> '}'
        @Block_LBrace_RBrace2 = 50, // <Block> ::= '{' '}'
        @StatementorBlock = 51, // <Statement or Block> ::= <Statement>
        @StatementorBlock2 = 52, // <Statement or Block> ::= <Block>
        @Statements = 53, // <Statements> ::= <Statement>
        @Statements2 = 54, // <Statements> ::= <Statements> <Statement>
        @Statements3 = 55, // <Statements> ::= <Block>
        @Statement = 56, // <Statement> ::= <FlowControl>
        @Statement_Semi = 57, // <Statement> ::= <Variables> ';'
        @Statement_Semi2 = 58, // <Statement> ::= <Procedure> ';'
        @Statement_Semi3 = 59, // <Statement> ::= <Call Expression> ';'
        @FunctionDeclaration_function_Identifier_LParen_RParen = 60,
        // <Function Declaration> ::= function Identifier '(' <Formal Parameter List> ')' <Block>
        @FunctionDeclaration_function_Identifier_LParen_RParen2 = 61,
        // <Function Declaration> ::= function Identifier '(' ')' <Block>
        @FunctionExpression_function_LParen_RParen = 62, // <Function Expression> ::= function '(' ')' <Block>
        @FunctionExpression_function_LParen_RParen2 = 63,
        // <Function Expression> ::= function '(' <Formal Parameter List> ')' <Block>
        @FormalParameterList_Identifier = 64, // <Formal Parameter List> ::= Identifier
        @FormalParameterList_Comma_Identifier = 65,
        // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
        @CallExpression = 66, // <Call Expression> ::= <Variable> <Arguments>
        @CallExpression2 = 67, // <Call Expression> ::= <Call Expression> <Arguments>
        @CallInternal = 68, // <CallInternal> ::= 
        @Arguments_LParen_RParen = 69, // <Arguments> ::= '(' ')'
        @Arguments_LParen_RParen2 = 70, // <Arguments> ::= '(' <Argument List> ')'
        @ArgumentList = 71, // <Argument List> ::= <Expression>
        @ArgumentList_Comma = 72, // <Argument List> ::= <Argument List> ',' <Expression>
        @FlowControl = 73, // <FlowControl> ::= <IfControl>
        @FlowControl2 = 74, // <FlowControl> ::= <DoWhileControl>
        @FlowControl3 = 75, // <FlowControl> ::= <DoUntilControl>
        @FlowControl4 = 76, // <FlowControl> ::= <LoopWhileControl>
        @FlowControl5 = 77, // <FlowControl> ::= <LoopUntilControl>
        @FlowControl6 = 78, // <FlowControl> ::= <ForControl>
        @FlowControl7 = 79, // <FlowControl> ::= <ForStepControl>
        @FlowControl8 = 80, // <FlowControl> ::= <BreakControl>
        @FlowControl9 = 81, // <FlowControl> ::= <ContinueControl>
        @IfControl_IF_LParen_RParen = 82, // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
        @IfControl_IF_LParen_RParen_ELSE = 83,
        // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
        @DoWhileControl_WHILE_LParen_RParen = 84,
        // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
        @DoUntilControl_UNTIL_LParen_RParen = 85,
        // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
        @LoopWhileControl_DO_WHILE_LParen_RParen = 86,
        // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
        @LoopUntilControl_DO_UNTIL_LParen_RParen = 87,
        // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
        @ForControl_FOR_Identifier_Eq_TO = 88,
        // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
        @ForStepControl_FOR_Identifier_Eq_TO_STEP = 89,
        // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
        @BreakControl_BREAK = 90, // <BreakControl> ::= BREAK
        @ContinueControl_CONTINUE = 91, // <ContinueControl> ::= CONTINUE
        @Variables = 92, // <Variables> ::= <Declare>
        @Variables2 = 93, // <Variables> ::= <Assignment>
        @Variables3 = 94, // <Variables> ::= <ListVars>
        @Variables4 = 95, // <Variables> ::= <Increment>
        @Variables5 = 96, // <Variables> ::= <Decrement>
        @Declare_VAR_Identifier = 97, // <Declare> ::= VAR Identifier
        @Declare_VAR_Identifier_Eq = 98, // <Declare> ::= VAR Identifier '=' <Expression>
        @Assignment_Identifier_Eq = 99, // <Assignment> ::= Identifier '=' <Expression>
        @ListVars_VARS = 100, // <ListVars> ::= VARS
        @Increment_Identifier_PlusPlus = 101, // <Increment> ::= Identifier '++'
        @Decrement_Identifier_MinusMinus = 102, // <Decrement> ::= Identifier '--'
        @Procedure = 103, // <Procedure> ::= <UnsetProc>
        @Procedure2 = 104, // <Procedure> ::= <RejectProc>
        @Procedure3 = 105, // <Procedure> ::= <AcceptProc>
        @Procedure4 = 106, // <Procedure> ::= <ScopeProc>
        @Procedure5 = 107, // <Procedure> ::= <IncludeProc>
        @Procedure6 = 108, // <Procedure> ::= <PrintProc>
        @Procedure7 = 109, // <Procedure> ::= <ReturnProc>
        @UnsetProc_UNSET_Identifier = 110, // <UnsetProc> ::= UNSET Identifier
        @RejectProc_REJECT = 111, // <RejectProc> ::= REJECT <Expression>
        @AcceptProc_ACCEPT = 112, // <AcceptProc> ::= ACCEPT <Expression>
        @ScopeProc_SCOPE = 113, // <ScopeProc> ::= SCOPE <Expression>
        @IncludeProc_INCLUDE = 114, // <IncludeProc> ::= INCLUDE <Expression>
        @PrintProc_PRINT = 115, // <PrintProc> ::= PRINT <Expression>
        @ReturnProc_RETURN = 116 // <ReturnProc> ::= RETURN <Expression>
    }
}