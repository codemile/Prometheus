namespace Prometheus.Grammar
{
    // ReSharper disable UnusedMember.Global
    // ReSharper disable CSharpWarnings::CS1591
    // ReSharper disable InconsistentNaming

    /// <summary>
    /// This enum is generated at compile time by the GOLD template generator.
    /// Do not make changes to this file.
    /// </summary>
    public enum GrammarSymbol
    {
        @EOF = 0, // 3 (EOF)
        @Error = 1, // 7 (Error)
        @Comment = 2, // 2 Comment
        @NewLine = 3, // 2 NewLine
        @Whitespace = 4, // 2 Whitespace
        @TimesDiv = 5, // 5 '*/'
        @DivTimes = 6, // 4 '/*'
        @DivDiv = 7, // 6 '//'
        @Exclam = 8, // 1 '!'
        @ExclamEq = 9, // 1 '!='
        @Percent = 10, // 1 '%'
        @AmpAmp = 11, // 1 '&&'
        @LParen = 12, // 1 '('
        @RParen = 13, // 1 ')'
        @Times = 14, // 1 '*'
        @Plus = 15, // 1 '+'
        @PlusPlus = 16, // 1 '++'
        @Comma = 17, // 1 ','
        @Minus = 18, // 1 '-'
        @MinusMinus = 19, // 1 '--'
        @Div = 20, // 1 '/'
        @ColonColon = 21, // 1 '::'
        @Semi = 22, // 1 ';'
        @Lt = 23, // 1 '<'
        @LtEq = 24, // 1 '<='
        @LtGt = 25, // 1 '<>'
        @Eq = 26, // 1 '='
        @EqEq = 27, // 1 '=='
        @Gt = 28, // 1 '>'
        @GtEq = 29, // 1 '>='
        @AND = 30, // 1 AND
        @as = 31, // 1 as
        @ASSERT = 32, // 1 ASSERT
        @Boolean = 33, // 1 Boolean
        @BREAK = 34, // 1 BREAK
        @CONTAINS = 35, // 1 CONTAINS
        @CONTINUE = 36, // 1 CONTINUE
        @Decimal = 37, // 1 Decimal
        @do = 38, // 1 do
        @each = 39, // 1 each
        @else = 40, // 1 else
        @FAIL = 41, // 1 FAIL
        @for = 42, // 1 for
        @function = 43, // 1 function
        @HAS = 44, // 1 HAS
        @Identifier = 45, // 1 Identifier
        @if = 46, // 1 if
        @MemberName = 47, // 1 MemberName
        @new = 48, // 1 new
        @NOT = 49, // 1 NOT
        @Number = 50, // 1 Number
        @object = 51, // 1 object
        @OR = 52, // 1 OR
        @PRINT = 53, // 1 PRINT
        @RegExpPipe = 54, // 1 RegExpPipe
        @RegExpSlash = 55, // 1 RegExpSlash
        @RETURN = 56, // 1 RETURN
        @step = 57, // 1 step
        @StringDouble = 58, // 1 StringDouble
        @StringSingle = 59, // 1 StringSingle
        @test = 60, // 1 test
        @tests = 61, // 1 tests
        @to = 62, // 1 to
        @Undefined = 63, // 1 Undefined
        @UNSET = 64, // 1 UNSET
        @until = 65, // 1 until
        @use = 66, // 1 use
        @VAR = 67, // 1 VAR
        @VARS = 68, // 1 VARS
        @while = 69, // 1 while
        @LBracket = 70, // 1 '['
        @RBracket = 71, // 1 ']'
        @LBrace = 72, // 1 '{'
        @PipePipe = 73, // 1 '||'
        @RBrace = 74, // 1 '}'
        @Tilde = 75, // 1 '~'
        @AddExpression = 76, // 0 <AddExpression>
        @AndOperator = 77, // 0 <AndOperator>
        @ArgumentArray = 78, // 0 <Argument Array>
        @ArgumentList = 79, // 0 <Argument List>
        @ArrayLiteral = 80, // 0 <Array Literal>
        @ArrayLiteralList = 81, // 0 <Array Literal List>
        @AssertProc = 82, // 0 <AssertProc>
        @Assignment = 83, // 0 <Assignment>
        @BaseClassID = 84, // 0 <BaseClass ID>
        @BitInvertOperator = 85, // 0 <BitInvertOperator>
        @Block = 86, // 0 <Block>
        @BlockorEnd = 87, // 0 <Block or End>
        @BooleanChain = 88, // 0 <BooleanChain>
        @BreakControl = 89, // 0 <BreakControl>
        @CallExpression = 90, // 0 <Call Expression>
        @CallGeneric = 91, // 0 <Call Generic>
        @ClassNameID = 92, // 0 <ClassName ID>
        @ClassNameList = 93, // 0 <ClassName List>
        @ContainsTerm = 94, // 0 <ContainsTerm>
        @ContinueControl = 95, // 0 <ContinueControl>
        @Declare = 96, // 0 <Declare>
        @DivideExpression = 97, // 0 <DivideExpression>
        @DoUntilControl = 98, // 0 <DoUntilControl>
        @DoWhileControl = 99, // 0 <DoWhileControl>
        @EachControl = 100, // 0 <EachControl>
        @End = 101, // 0 <End>
        @EndOpt = 102, // 0 <End Opt>
        @EqualOperator = 103, // 0 <EqualOperator>
        @Expression = 104, // 0 <Expression>
        @FailProc = 105, // 0 <FailProc>
        @FlowControl = 106, // 0 <FlowControl>
        @ForControl = 107, // 0 <ForControl>
        @ForStepControl = 108, // 0 <ForStepControl>
        @FunctionBlock = 109, // 0 <Function Block>
        @FunctionDecl = 110, // 0 <Function Decl>
        @FunctionExpression = 111, // 0 <Function Expression>
        @GteOperator = 112, // 0 <GteOperator>
        @GtOperator = 113, // 0 <GtOperator>
        @IfControl = 114, // 0 <IfControl>
        @ImportDecl = 115, // 0 <Import Decl>
        @ImportDecls = 116, // 0 <Import Decls>
        @ListVars = 117, // 0 <ListVars>
        @LoopUntilControl = 118, // 0 <LoopUntilControl>
        @LoopWhileControl = 119, // 0 <LoopWhileControl>
        @LteOperator = 120, // 0 <LteOperator>
        @LtOperator = 121, // 0 <LtOperator>
        @MathChain = 122, // 0 <MathChain>
        @MemberID = 123, // 0 <Member ID>
        @MultiplyExpression = 124, // 0 <MultiplyExpression>
        @NameSpace = 125, // 0 <NameSpace>
        @NegOperator = 126, // 0 <NegOperator>
        @NewExpression = 127, // 0 <New Expression>
        @NotEqualOperator = 128, // 0 <NotEqualOperator>
        @NotOperator = 129, // 0 <NotOperator>
        @ObjectBlock = 130, // 0 <Object Block>
        @ObjectDecl = 131, // 0 <Object Decl>
        @ObjectDecls = 132, // 0 <Object Decls>
        @OrOperator = 133, // 0 <OrOperator>
        @ParameterArray = 134, // 0 <Parameter Array>
        @ParameterList = 135, // 0 <Parameter List>
        @ParameterName = 136, // 0 <Parameter Name>
        @PlusOperator = 137, // 0 <PlusOperator>
        @PostDecOperator = 138, // 0 <PostDecOperator>
        @PostDecrement = 139, // 0 <PostDecrement>
        @PostIncOperator = 140, // 0 <PostIncOperator>
        @PostIncrement = 141, // 0 <PostIncrement>
        @PreDecOperator = 142, // 0 <PreDecOperator>
        @PreDecrement = 143, // 0 <PreDecrement>
        @PreIncOperator = 144, // 0 <PreIncOperator>
        @PreIncrement = 145, // 0 <PreIncrement>
        @PrintProc = 146, // 0 <PrintProc>
        @Procedure = 147, // 0 <Procedure>
        @Program = 148, // 0 <Program>
        @ProgramCode = 149, // 0 <Program Code>
        @ProgramTest = 150, // 0 <Program Test>
        @QualifiedID = 151, // 0 <Qualified ID>
        @QualifiedList = 152, // 0 <Qualified List>
        @RemainderExpression = 153, // 0 <RemainderExpression>
        @ReturnProc = 154, // 0 <ReturnProc>
        @SearchChain = 155, // 0 <SearchChain>
        @Statement = 156, // 0 <Statement>
        @StatementorBlock = 157, // 0 <Statement or Block>
        @Statements = 158, // 0 <Statements>
        @SubExpression = 159, // 0 <SubExpression>
        @TestBlock = 160, // 0 <Test Block>
        @TestDecl = 161, // 0 <Test Decl>
        @TestDecls = 162, // 0 <Test Decls>
        @TestExecute = 163, // 0 <Test Execute>
        @TestSuiteArray = 164, // 0 <TestSuite Array>
        @TestSuiteDecl = 165, // 0 <TestSuite Decl>
        @UnaryChain = 166, // 0 <UnaryChain>
        @UnsetProc = 167, // 0 <UnsetProc>
        @ValidID = 168, // 0 <Valid ID>
        @Value = 169, // 0 <Value>
        @VariableStatements = 170 // 0 <Variable Statements>
    }
}