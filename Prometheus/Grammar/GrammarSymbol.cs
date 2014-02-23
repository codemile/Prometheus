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
        @StringDouble = 57, // 1 StringDouble
        @StringSingle = 58, // 1 StringSingle
        @test = 59, // 1 test
        @tests = 60, // 1 tests
        @Undefined = 61, // 1 Undefined
        @UNSET = 62, // 1 UNSET
        @until = 63, // 1 until
        @use = 64, // 1 use
        @VAR = 65, // 1 VAR
        @VARS = 66, // 1 VARS
        @while = 67, // 1 while
        @LBracket = 68, // 1 '['
        @RBracket = 69, // 1 ']'
        @LBrace = 70, // 1 '{'
        @PipePipe = 71, // 1 '||'
        @RBrace = 72, // 1 '}'
        @Tilde = 73, // 1 '~'
        @AddExpression = 74, // 0 <AddExpression>
        @AndOperator = 75, // 0 <AndOperator>
        @ArgumentArray = 76, // 0 <Argument Array>
        @ArgumentList = 77, // 0 <Argument List>
        @ArrayLiteral = 78, // 0 <Array Literal>
        @ArrayLiteralList = 79, // 0 <Array Literal List>
        @AssertProc = 80, // 0 <AssertProc>
        @Assignment = 81, // 0 <Assignment>
        @BaseClassID = 82, // 0 <BaseClass ID>
        @BitInvertOperator = 83, // 0 <BitInvertOperator>
        @Block = 84, // 0 <Block>
        @BlockorEnd = 85, // 0 <Block or End>
        @BooleanChain = 86, // 0 <BooleanChain>
        @BreakControl = 87, // 0 <BreakControl>
        @CallExpression = 88, // 0 <Call Expression>
        @CallGeneric = 89, // 0 <Call Generic>
        @ClassNameID = 90, // 0 <ClassName ID>
        @ClassNameList = 91, // 0 <ClassName List>
        @ContainsTerm = 92, // 0 <ContainsTerm>
        @ContinueControl = 93, // 0 <ContinueControl>
        @Declare = 94, // 0 <Declare>
        @DivideExpression = 95, // 0 <DivideExpression>
        @DoUntilControl = 96, // 0 <DoUntilControl>
        @DoWhileControl = 97, // 0 <DoWhileControl>
        @EachControl = 98, // 0 <EachControl>
        @EachOperator = 99, // 0 <EachOperator>
        @End = 100, // 0 <End>
        @EndOpt = 101, // 0 <End Opt>
        @EqualOperator = 102, // 0 <EqualOperator>
        @Expression = 103, // 0 <Expression>
        @FailProc = 104, // 0 <FailProc>
        @FlowControl = 105, // 0 <FlowControl>
        @ForControl = 106, // 0 <ForControl>
        @ForDeclare = 107, // 0 <ForDeclare>
        @ForExpression = 108, // 0 <ForExpression>
        @ForStep = 109, // 0 <ForStep>
        @FunctionBlock = 110, // 0 <Function Block>
        @FunctionDecl = 111, // 0 <Function Decl>
        @FunctionExpression = 112, // 0 <Function Expression>
        @GteOperator = 113, // 0 <GteOperator>
        @GtOperator = 114, // 0 <GtOperator>
        @IfControl = 115, // 0 <IfControl>
        @ImportDecl = 116, // 0 <Import Decl>
        @ImportDecls = 117, // 0 <Import Decls>
        @ListVars = 118, // 0 <ListVars>
        @LoopUntilControl = 119, // 0 <LoopUntilControl>
        @LoopWhileControl = 120, // 0 <LoopWhileControl>
        @LteOperator = 121, // 0 <LteOperator>
        @LtOperator = 122, // 0 <LtOperator>
        @MathChain = 123, // 0 <MathChain>
        @MemberID = 124, // 0 <Member ID>
        @MultiplyExpression = 125, // 0 <MultiplyExpression>
        @NameSpace = 126, // 0 <NameSpace>
        @NegOperator = 127, // 0 <NegOperator>
        @NewExpression = 128, // 0 <New Expression>
        @NotEqualOperator = 129, // 0 <NotEqualOperator>
        @NotOperator = 130, // 0 <NotOperator>
        @ObjectBlock = 131, // 0 <Object Block>
        @ObjectDecl = 132, // 0 <Object Decl>
        @ObjectDecls = 133, // 0 <Object Decls>
        @OrOperator = 134, // 0 <OrOperator>
        @ParameterArray = 135, // 0 <Parameter Array>
        @ParameterList = 136, // 0 <Parameter List>
        @ParameterName = 137, // 0 <Parameter Name>
        @PluralID = 138, // 0 <Plural ID>
        @PlusOperator = 139, // 0 <PlusOperator>
        @PostDecOperator = 140, // 0 <PostDecOperator>
        @PostDecrement = 141, // 0 <PostDecrement>
        @PostIncOperator = 142, // 0 <PostIncOperator>
        @PostIncrement = 143, // 0 <PostIncrement>
        @PreDecOperator = 144, // 0 <PreDecOperator>
        @PreDecrement = 145, // 0 <PreDecrement>
        @PreIncOperator = 146, // 0 <PreIncOperator>
        @PreIncrement = 147, // 0 <PreIncrement>
        @PrintProc = 148, // 0 <PrintProc>
        @Procedure = 149, // 0 <Procedure>
        @Program = 150, // 0 <Program>
        @ProgramCode = 151, // 0 <Program Code>
        @ProgramTest = 152, // 0 <Program Test>
        @QualifiedID = 153, // 0 <Qualified ID>
        @QualifiedList = 154, // 0 <Qualified List>
        @RemainderExpression = 155, // 0 <RemainderExpression>
        @ReturnProc = 156, // 0 <ReturnProc>
        @SearchChain = 157, // 0 <SearchChain>
        @Statement = 158, // 0 <Statement>
        @StatementorBlock = 159, // 0 <Statement or Block>
        @Statements = 160, // 0 <Statements>
        @SubExpression = 161, // 0 <SubExpression>
        @TestBlock = 162, // 0 <Test Block>
        @TestDecl = 163, // 0 <Test Decl>
        @TestDecls = 164, // 0 <Test Decls>
        @TestExecute = 165, // 0 <Test Execute>
        @TestSuiteArray = 166, // 0 <TestSuite Array>
        @TestSuiteDecl = 167, // 0 <TestSuite Decl>
        @UnaryChain = 168, // 0 <UnaryChain>
        @UnsetProc = 169, // 0 <UnsetProc>
        @ValidID = 170, // 0 <Valid ID>
        @Value = 171, // 0 <Value>
        @VariableStatements = 172 // 0 <Variable Statements>
    }
}