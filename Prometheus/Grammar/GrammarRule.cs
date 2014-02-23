namespace Prometheus.Grammar
{
    /// <summary>
    /// This enum is generated at compile time by the GOLD template generator.
    /// Do not make changes to this file.
    /// </summary>
    public enum GrammarRule
    {
        @Program = 0, // <Program> ::= <Program Test>
        @Program2 = 1, // <Program> ::= <Program Code>
        @ProgramTest = 2, // <Program Test> ::= <TestSuite Decl> <Import Decls> <Test Decls> <Test Execute>
        @ProgramTest2 = 3,
        // <Program Test> ::= <TestSuite Decl> <Import Decls> <Statements> <Test Decls> <Test Execute>
        @ProgramTest3 = 4,
        // <Program Test> ::= <TestSuite Decl> <Import Decls> <Statements> <Test Decls> <Test Execute> <Statements>
        @ProgramCode = 5, // <Program Code> ::= <Import Decls> <Object Decls>
        @ProgramCode2 = 6, // <Program Code> ::= <Import Decls> <Object Decls> <Statements>
        @Block_LBrace_RBrace = 7, // <Block> ::= '{' <Statements> '}'
        @Block_LBrace_RBrace2 = 8, // <Block> ::= '{' '}'
        @StatementorBlock = 9, // <Statement or Block> ::= <Statement>
        @StatementorBlock2 = 10, // <Statement or Block> ::= <Block>
        @Statements = 11, // <Statements> ::= <Statement or Block>
        @Statements2 = 12, // <Statements> ::= <Statements> <Statement or Block>
        @Statement = 13, // <Statement> ::= <FlowControl> <End>
        @Statement2 = 14, // <Statement> ::= <Function Decl> <End>
        @Statement3 = 15, // <Statement> ::= <Procedure> <End>
        @Statement4 = 16, // <Statement> ::= <Variable Statements> <End>
        @Statement5 = 17, // <Statement> ::= <Call Expression> <End>
        @Statement6 = 18, // <Statement> ::= <New Expression> <End>
        @Statement7 = 19, // <Statement> ::= <End>
        @TestSuiteDecl_tests = 20, // <TestSuite Decl> ::= tests <End>
        @TestSuiteDecl_tests_LBracket_RBracket = 21, // <TestSuite Decl> ::= tests '[' <TestSuite Array> ']' <End>
        @TestSuiteArray = 22, // <TestSuite Array> ::= <Valid ID>
        @TestSuiteArray_Comma = 23, // <TestSuite Array> ::= <Valid ID> ',' <TestSuite Array>
        @TestSuiteArray2 = 24, // <TestSuite Array> ::= 
        @TestDecls = 25, // <Test Decls> ::= <Test Decl>
        @TestDecls2 = 26, // <Test Decls> ::= <Test Decls> <Test Decl>
        @TestDecls3 = 27, // <Test Decls> ::= 
        @TestDecl_test = 28, // <Test Decl> ::= test <Valid ID> <Block> <End>
        @TestBlock = 29, // <Test Block> ::= 
        @TestExecute = 30, // <Test Execute> ::= 
        @End_Semi = 31, // <End> ::= ';'
        @EndOpt = 32, // <End Opt> ::= <End>
        @EndOpt2 = 33, // <End Opt> ::= 
        @BlockorEnd = 34, // <Block or End> ::= <Block>
        @BlockorEnd2 = 35, // <Block or End> ::= <End>
        @Expression = 36, // <Expression> ::= <SearchChain>
        @SearchChain = 37, // <SearchChain> ::= <ContainsTerm>
        @ContainsTerm_CONTAINS = 38, // <ContainsTerm> ::= <ContainsTerm> CONTAINS <BooleanChain>
        @ContainsTerm_HAS = 39, // <ContainsTerm> ::= <ContainsTerm> HAS <BooleanChain>
        @ContainsTerm = 40, // <ContainsTerm> ::= <BooleanChain>
        @BooleanChain = 41, // <BooleanChain> ::= <GtOperator>
        @GtOperator_Gt = 42, // <GtOperator> ::= <GtOperator> '>' <LtOperator>
        @GtOperator = 43, // <GtOperator> ::= <LtOperator>
        @LtOperator_Lt = 44, // <LtOperator> ::= <LtOperator> '<' <GteOperator>
        @LtOperator = 45, // <LtOperator> ::= <GteOperator>
        @GteOperator_GtEq = 46, // <GteOperator> ::= <GteOperator> '>=' <LteOperator>
        @GteOperator = 47, // <GteOperator> ::= <LteOperator>
        @LteOperator_LtEq = 48, // <LteOperator> ::= <LteOperator> '<=' <EqualOperator>
        @LteOperator = 49, // <LteOperator> ::= <EqualOperator>
        @EqualOperator_EqEq = 50, // <EqualOperator> ::= <EqualOperator> '==' <NotEqualOperator>
        @EqualOperator = 51, // <EqualOperator> ::= <NotEqualOperator>
        @NotEqualOperator_ExclamEq = 52, // <NotEqualOperator> ::= <NotEqualOperator> '!=' <AndOperator>
        @NotEqualOperator_LtGt = 53, // <NotEqualOperator> ::= <NotEqualOperator> '<>' <AndOperator>
        @NotEqualOperator = 54, // <NotEqualOperator> ::= <AndOperator>
        @AndOperator_AND = 55, // <AndOperator> ::= <AndOperator> AND <OrOperator>
        @AndOperator_AmpAmp = 56, // <AndOperator> ::= <AndOperator> '&&' <OrOperator>
        @AndOperator = 57, // <AndOperator> ::= <OrOperator>
        @OrOperator_OR = 58, // <OrOperator> ::= <OrOperator> OR <MathChain>
        @OrOperator_PipePipe = 59, // <OrOperator> ::= <OrOperator> '||' <MathChain>
        @OrOperator = 60, // <OrOperator> ::= <MathChain>
        @MathChain = 61, // <MathChain> ::= <AddExpression>
        @AddExpression_Plus = 62, // <AddExpression> ::= <AddExpression> '+' <SubExpression>
        @AddExpression = 63, // <AddExpression> ::= <SubExpression>
        @SubExpression_Minus = 64, // <SubExpression> ::= <SubExpression> '-' <MultiplyExpression>
        @SubExpression = 65, // <SubExpression> ::= <MultiplyExpression>
        @MultiplyExpression_Times = 66, // <MultiplyExpression> ::= <MultiplyExpression> '*' <DivideExpression>
        @MultiplyExpression = 67, // <MultiplyExpression> ::= <DivideExpression>
        @DivideExpression_Div = 68, // <DivideExpression> ::= <DivideExpression> '/' <RemainderExpression>
        @DivideExpression = 69, // <DivideExpression> ::= <RemainderExpression>
        @RemainderExpression_Percent = 70, // <RemainderExpression> ::= <RemainderExpression> '%' <UnaryChain>
        @RemainderExpression = 71, // <RemainderExpression> ::= <UnaryChain>
        @UnaryChain = 72, // <UnaryChain> ::= <NotOperator>
        @NotOperator_Exclam = 73, // <NotOperator> ::= '!' <Value>
        @NotOperator_NOT = 74, // <NotOperator> ::= NOT <Value>
        @NotOperator = 75, // <NotOperator> ::= <BitInvertOperator>
        @BitInvertOperator_Tilde = 76, // <BitInvertOperator> ::= '~' <Value>
        @BitInvertOperator = 77, // <BitInvertOperator> ::= <NegOperator>
        @NegOperator_Minus = 78, // <NegOperator> ::= '-' <Value>
        @NegOperator = 79, // <NegOperator> ::= <PlusOperator>
        @PlusOperator_Plus = 80, // <PlusOperator> ::= '+' <Value>
        @PlusOperator = 81, // <PlusOperator> ::= <PreDecOperator>
        @PreDecOperator_MinusMinus = 82, // <PreDecOperator> ::= '--' <Qualified ID>
        @PreDecOperator = 83, // <PreDecOperator> ::= <PostDecOperator>
        @PostDecOperator_MinusMinus = 84, // <PostDecOperator> ::= <Qualified ID> '--'
        @PostDecOperator = 85, // <PostDecOperator> ::= <PreIncOperator>
        @PreIncOperator_PlusPlus = 86, // <PreIncOperator> ::= '++' <Qualified ID>
        @PreIncOperator = 87, // <PreIncOperator> ::= <PostIncOperator>
        @PostIncOperator_PlusPlus = 88, // <PostIncOperator> ::= <Qualified ID> '++'
        @PostIncOperator = 89, // <PostIncOperator> ::= <EachOperator>
        @EachOperator = 90, // <EachOperator> ::= <EachControl>
        @EachOperator2 = 91, // <EachOperator> ::= <Value>
        @ValidID_Identifier = 92, // <Valid ID> ::= Identifier
        @MemberID_MemberName = 93, // <Member ID> ::= MemberName
        @ClassNameID = 94, // <ClassName ID> ::= <Valid ID> <ClassName List>
        @ClassNameList = 95, // <ClassName List> ::= <Member ID> <ClassName List>
        @ClassNameList2 = 96, // <ClassName List> ::= 
        @NameSpace = 97, // <NameSpace> ::= 
        @QualifiedID = 98, // <Qualified ID> ::= <Valid ID> <Qualified List>
        @QualifiedList = 99, // <Qualified List> ::= <Member ID> <Qualified List>
        @QualifiedList_LBracket_RBracket = 100, // <Qualified List> ::= '[' <Value> ']' <Qualified List>
        @QualifiedList2 = 101, // <Qualified List> ::= 
        @Value_StringDouble = 102, // <Value> ::= StringDouble
        @Value_StringSingle = 103, // <Value> ::= StringSingle
        @Value_RegExpSlash = 104, // <Value> ::= RegExpSlash
        @Value_RegExpPipe = 105, // <Value> ::= RegExpPipe
        @Value_Number = 106, // <Value> ::= Number
        @Value_Decimal = 107, // <Value> ::= Decimal
        @Value_Boolean = 108, // <Value> ::= Boolean
        @Value_Undefined = 109, // <Value> ::= Undefined
        @Value = 110, // <Value> ::= <Array Literal>
        @Value2 = 111, // <Value> ::= <Qualified ID>
        @Value3 = 112, // <Value> ::= <Function Expression>
        @Value_LParen_RParen = 113, // <Value> ::= '(' <Expression> ')'
        @Value4 = 114, // <Value> ::= <Call Expression>
        @VariableStatements = 115, // <Variable Statements> ::= <Declare>
        @VariableStatements2 = 116, // <Variable Statements> ::= <Assignment>
        @VariableStatements3 = 117, // <Variable Statements> ::= <PostIncrement>
        @VariableStatements4 = 118, // <Variable Statements> ::= <PreIncrement>
        @VariableStatements5 = 119, // <Variable Statements> ::= <PostDecrement>
        @VariableStatements6 = 120, // <Variable Statements> ::= <PreDecrement>
        @ArrayLiteral_LBracket_RBracket = 121, // <Array Literal> ::= '[' ']'
        @ArrayLiteral_LBracket_RBracket2 = 122, // <Array Literal> ::= '[' <Array Literal List> ']'
        @ArrayLiteralList = 123, // <Array Literal List> ::= <Value>
        @ArrayLiteralList_Comma = 124, // <Array Literal List> ::= <Array Literal List> ',' <Value>
        @Declare_VAR_Identifier = 125, // <Declare> ::= VAR Identifier
        @Declare_VAR_Identifier_Eq = 126, // <Declare> ::= VAR Identifier '=' <Expression>
        @Declare_VAR_Identifier_Eq2 = 127, // <Declare> ::= VAR Identifier '=' <New Expression>
        @Assignment_Eq = 128, // <Assignment> ::= <Qualified ID> '=' <Expression>
        @PostIncrement_PlusPlus = 129, // <PostIncrement> ::= <Qualified ID> '++'
        @PreIncrement_PlusPlus = 130, // <PreIncrement> ::= '++' <Qualified ID>
        @PostDecrement_MinusMinus = 131, // <PostDecrement> ::= <Qualified ID> '--'
        @PreDecrement_MinusMinus = 132, // <PreDecrement> ::= '--' <Qualified ID>
        @ImportDecls = 133, // <Import Decls> ::= <Import Decl>
        @ImportDecls2 = 134, // <Import Decls> ::= <Import Decls> <Import Decl>
        @ImportDecls3 = 135, // <Import Decls> ::= 
        @ImportDecl_use_StringDouble = 136, // <Import Decl> ::= use StringDouble <End>
        @ObjectDecls = 137, // <Object Decls> ::= <Object Decl>
        @ObjectDecls2 = 138, // <Object Decls> ::= <Object Decls> <Object Decl>
        @ObjectDecls3 = 139, // <Object Decls> ::= 
        @ObjectDecl_object = 140, // <Object Decl> ::= object <BaseClass ID> <Parameter Array> <Block> <End>
        @ObjectBlock = 141, // <Object Block> ::= 
        @BaseClassID_ColonColon = 142, // <BaseClass ID> ::= <ClassName ID> '::' <Valid ID>
        @BaseClassID = 143, // <BaseClass ID> ::= <Valid ID>
        @FunctionDecl_function_Identifier = 144, // <Function Decl> ::= function Identifier <Parameter Array> <Block>
        @FunctionBlock = 145, // <Function Block> ::= 
        @FunctionExpression_function = 146, // <Function Expression> ::= function <Parameter Array> <Block>
        @ParameterArray_LParen_RParen = 147, // <Parameter Array> ::= '(' ')'
        @ParameterArray_LParen_RParen2 = 148, // <Parameter Array> ::= '(' <Parameter List> ')'
        @ParameterArray = 149, // <Parameter Array> ::= 
        @ParameterList = 150, // <Parameter List> ::= <Parameter Name>
        @ParameterList_Comma = 151, // <Parameter List> ::= <Parameter List> ',' <Parameter Name>
        @ParameterName_Identifier = 152, // <Parameter Name> ::= Identifier
        @CallExpression = 153, // <Call Expression> ::= <Qualified ID> <Argument Array>
        @CallExpression2 = 154, // <Call Expression> ::= <Call Expression> <Argument Array>
        @NewExpression_new = 155, // <New Expression> ::= new <ClassName ID> <Argument Array>
        @ArgumentArray_LParen_RParen = 156, // <Argument Array> ::= '(' ')'
        @ArgumentArray_LParen_RParen2 = 157, // <Argument Array> ::= '(' <Argument List> ')'
        @ArgumentList = 158, // <Argument List> ::= <Expression>
        @ArgumentList_Comma = 159, // <Argument List> ::= <Argument List> ',' <Expression>
        @FlowControl = 160, // <FlowControl> ::= <IfControl>
        @FlowControl2 = 161, // <FlowControl> ::= <DoWhileControl>
        @FlowControl3 = 162, // <FlowControl> ::= <DoUntilControl>
        @FlowControl4 = 163, // <FlowControl> ::= <LoopWhileControl>
        @FlowControl5 = 164, // <FlowControl> ::= <LoopUntilControl>
        @FlowControl6 = 165, // <FlowControl> ::= <ForControl>
        @FlowControl7 = 166, // <FlowControl> ::= <EachControl>
        @FlowControl8 = 167, // <FlowControl> ::= <BreakControl>
        @FlowControl9 = 168, // <FlowControl> ::= <ContinueControl>
        @IfControl_if_LParen_RParen = 169, // <IfControl> ::= if '(' <Expression> ')' <Block>
        @IfControl_if_LParen_RParen_else = 170, // <IfControl> ::= if '(' <Expression> ')' <Block> else <Block>
        @DoWhileControl_while_LParen_RParen = 171, // <DoWhileControl> ::= while '(' <Expression> ')' <Block>
        @DoUntilControl_until_LParen_RParen = 172, // <DoUntilControl> ::= until '(' <Expression> ')' <Block>
        @LoopWhileControl_do_while_LParen_RParen = 173, // <LoopWhileControl> ::= do <Block> while '(' <Expression> ')'
        @LoopUntilControl_do_until_LParen_RParen = 174, // <LoopUntilControl> ::= do <Block> until '(' <Expression> ')'
        @ForControl_for_LParen_RParen = 175,
        // <ForControl> ::= for '(' <ForDeclare> <ForExpression> <ForStep> ')' <Block>
        @ForDeclare = 176, // <ForDeclare> ::= <Variable Statements> <End>
        @ForDeclare2 = 177, // <ForDeclare> ::= <End>
        @ForExpression = 178, // <ForExpression> ::= <Expression> <End>
        @ForExpression2 = 179, // <ForExpression> ::= <End>
        @ForStep = 180, // <ForStep> ::= <Variable Statements>
        @ForStep2 = 181, // <ForStep> ::= 
        @EachControl_each = 182, // <EachControl> ::= each <Plural ID> <Block>
        @PluralID = 183, // <Plural ID> ::= <Expression>
        @PluralID_as_Identifier = 184, // <Plural ID> ::= <Expression> as Identifier
        @BreakControl_BREAK = 185, // <BreakControl> ::= BREAK
        @ContinueControl_CONTINUE = 186, // <ContinueControl> ::= CONTINUE
        @Procedure = 187, // <Procedure> ::= <UnsetProc>
        @Procedure2 = 188, // <Procedure> ::= <PrintProc>
        @Procedure3 = 189, // <Procedure> ::= <ReturnProc>
        @Procedure4 = 190, // <Procedure> ::= <AssertProc>
        @Procedure5 = 191, // <Procedure> ::= <FailProc>
        @Procedure6 = 192, // <Procedure> ::= <ListVars>
        @Procedure7 = 193, // <Procedure> ::= <Call Generic>
        @UnsetProc_UNSET = 194, // <UnsetProc> ::= UNSET <Qualified ID>
        @PrintProc_PRINT = 195, // <PrintProc> ::= PRINT <Expression>
        @ReturnProc_RETURN = 196, // <ReturnProc> ::= RETURN <Expression>
        @ReturnProc_RETURN2 = 197, // <ReturnProc> ::= RETURN
        @AssertProc_ASSERT = 198, // <AssertProc> ::= ASSERT <Expression>
        @FailProc_FAIL = 199, // <FailProc> ::= FAIL <Expression>
        @FailProc_FAIL2 = 200, // <FailProc> ::= FAIL
        @ListVars_VARS = 201, // <ListVars> ::= VARS
        @CallGeneric_Identifier = 202 // <Call Generic> ::= Identifier <Argument Array>
    }
}