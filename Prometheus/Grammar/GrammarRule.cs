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
        @End_Semi = 47, // <End> ::= ';'
        @EndOpt = 48, // <End Opt> ::= <End>
        @EndOpt2 = 49, // <End Opt> ::= 
        @BlockorEnd = 50, // <Block or End> ::= <Block>
        @BlockorEnd2 = 51, // <Block or End> ::= <End>
        @Program = 52, // <Program> ::= <Object Decl>
        @Program2 = 53, // <Program> ::= <Object Decl> <Statements>
        @Program3 = 54, // <Program> ::= <Statements>
        @Program4 = 55, // <Program> ::= 
        @Block_LBrace_RBrace = 56, // <Block> ::= '{' <Statements> '}'
        @Block_LBrace_RBrace2 = 57, // <Block> ::= '{' '}'
        @StatementorBlock = 58, // <Statement or Block> ::= <Statement>
        @StatementorBlock2 = 59, // <Statement or Block> ::= <Block>
        @Statements = 60, // <Statements> ::= <Statement>
        @Statements2 = 61, // <Statements> ::= <Statements> <Statement>
        @Statements3 = 62, // <Statements> ::= <Block>
        @Statement = 63, // <Statement> ::= <FlowControl>
        @Statement2 = 64, // <Statement> ::= <Variables> <End>
        @Statement3 = 65, // <Statement> ::= <Procedure> <End>
        @Statement4 = 66, // <Statement> ::= <Call Expression> <End>
        @Statement5 = 67, // <Statement> ::= <New Expression> <End>
        @Statement6 = 68, // <Statement> ::= <End>
        @ObjectDecl_Identifier = 69, // <Object Decl> ::= <Base Class> Identifier <Block>
        @ObjectDecl_Identifier_LParen_RParen = 70, // <Object Decl> ::= <Base Class> Identifier '(' ')' <Block>
        @ObjectDecl_Identifier_LParen_RParen2 = 71,
        // <Object Decl> ::= <Base Class> Identifier '(' <Formal Parameter List> ')' <Block>
        @BaseClass_Type = 72, // <Base Class> ::= Type
        @BaseClass_Identifier = 73, // <Base Class> ::= Identifier
        @FunctionDeclaration_function_Identifier_LParen_RParen = 74,
        // <Function Declaration> ::= function Identifier '(' <Formal Parameter List> ')' <Block>
        @FunctionDeclaration_function_Identifier_LParen_RParen2 = 75,
        // <Function Declaration> ::= function Identifier '(' ')' <Block>
        @FunctionExpression_function_LParen_RParen = 76, // <Function Expression> ::= function '(' ')' <Block>
        @FunctionExpression_function_LParen_RParen2 = 77,
        // <Function Expression> ::= function '(' <Formal Parameter List> ')' <Block>
        @FormalParameterList_Identifier = 78, // <Formal Parameter List> ::= Identifier
        @FormalParameterList_Comma_Identifier = 79,
        // <Formal Parameter List> ::= <Formal Parameter List> ',' Identifier
        @CallExpression = 80, // <Call Expression> ::= <Variable> <Arguments>
        @CallExpression2 = 81, // <Call Expression> ::= <Call Expression> <Arguments>
        @NewExpression_new_Identifier = 82, // <New Expression> ::= new Identifier <Arguments>
        @CallInternal = 83, // <CallInternal> ::= 
        @Arguments_LParen_RParen = 84, // <Arguments> ::= '(' ')'
        @Arguments_LParen_RParen2 = 85, // <Arguments> ::= '(' <Argument List> ')'
        @ArgumentList = 86, // <Argument List> ::= <Expression>
        @ArgumentList_Comma = 87, // <Argument List> ::= <Argument List> ',' <Expression>
        @FlowControl = 88, // <FlowControl> ::= <IfControl>
        @FlowControl2 = 89, // <FlowControl> ::= <DoWhileControl>
        @FlowControl3 = 90, // <FlowControl> ::= <DoUntilControl>
        @FlowControl4 = 91, // <FlowControl> ::= <LoopWhileControl>
        @FlowControl5 = 92, // <FlowControl> ::= <LoopUntilControl>
        @FlowControl6 = 93, // <FlowControl> ::= <ForControl>
        @FlowControl7 = 94, // <FlowControl> ::= <ForStepControl>
        @FlowControl8 = 95, // <FlowControl> ::= <BreakControl>
        @FlowControl9 = 96, // <FlowControl> ::= <ContinueControl>
        @IfControl_IF_LParen_RParen = 97, // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block>
        @IfControl_IF_LParen_RParen_ELSE = 98,
        // <IfControl> ::= IF '(' <Expression> ')' <Statement or Block> ELSE <Statement or Block>
        @DoWhileControl_WHILE_LParen_RParen = 99,
        // <DoWhileControl> ::= WHILE '(' <Expression> ')' <Statement or Block>
        @DoUntilControl_UNTIL_LParen_RParen = 100,
        // <DoUntilControl> ::= UNTIL '(' <Expression> ')' <Statement or Block>
        @LoopWhileControl_DO_WHILE_LParen_RParen = 101,
        // <LoopWhileControl> ::= DO <Statement or Block> WHILE '(' <Expression> ')'
        @LoopUntilControl_DO_UNTIL_LParen_RParen = 102,
        // <LoopUntilControl> ::= DO <Statement or Block> UNTIL '(' <Expression> ')'
        @ForControl_FOR_Identifier_Eq_TO = 103,
        // <ForControl> ::= FOR Identifier '=' <Expression> TO <Expression> <Statement or Block>
        @ForStepControl_FOR_Identifier_Eq_TO_STEP = 104,
        // <ForStepControl> ::= FOR Identifier '=' <Expression> TO <Expression> STEP <Expression> <Statement or Block>
        @BreakControl_BREAK = 105, // <BreakControl> ::= BREAK
        @ContinueControl_CONTINUE = 106, // <ContinueControl> ::= CONTINUE
        @Variables = 107, // <Variables> ::= <Declare>
        @Variables2 = 108, // <Variables> ::= <Assignment>
        @Variables3 = 109, // <Variables> ::= <ListVars>
        @Variables4 = 110, // <Variables> ::= <Increment>
        @Variables5 = 111, // <Variables> ::= <Decrement>
        @Declare_VAR_Identifier = 112, // <Declare> ::= VAR Identifier
        @Declare_VAR_Identifier_Eq = 113, // <Declare> ::= VAR Identifier '=' <Expression>
        @Declare_VAR_Identifier_Eq2 = 114, // <Declare> ::= VAR Identifier '=' <New Expression>
        @Assignment_Identifier_Eq = 115, // <Assignment> ::= Identifier '=' <Expression>
        @ListVars_VARS = 116, // <ListVars> ::= VARS
        @Increment_Identifier_PlusPlus = 117, // <Increment> ::= Identifier '++'
        @Decrement_Identifier_MinusMinus = 118, // <Decrement> ::= Identifier '--'
        @Procedure = 119, // <Procedure> ::= <UnsetProc>
        @Procedure2 = 120, // <Procedure> ::= <RejectProc>
        @Procedure3 = 121, // <Procedure> ::= <AcceptProc>
        @Procedure4 = 122, // <Procedure> ::= <ScopeProc>
        @Procedure5 = 123, // <Procedure> ::= <IncludeProc>
        @Procedure6 = 124, // <Procedure> ::= <PrintProc>
        @Procedure7 = 125, // <Procedure> ::= <ReturnProc>
        @UnsetProc_UNSET_Identifier = 126, // <UnsetProc> ::= UNSET Identifier
        @RejectProc_REJECT = 127, // <RejectProc> ::= REJECT <Expression>
        @AcceptProc_ACCEPT = 128, // <AcceptProc> ::= ACCEPT <Expression>
        @ScopeProc_SCOPE = 129, // <ScopeProc> ::= SCOPE <Expression>
        @IncludeProc_INCLUDE = 130, // <IncludeProc> ::= INCLUDE <Expression>
        @PrintProc_PRINT = 131, // <PrintProc> ::= PRINT <Expression>
        @ReturnProc_RETURN = 132 // <ReturnProc> ::= RETURN <Expression>
    }
}