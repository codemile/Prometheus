namespace Prometheus.Grammar
{
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
        @AmpAmp = 10, // 1 '&&'
        @LParen = 11, // 1 '('
        @RParen = 12, // 1 ')'
        @Times = 13, // 1 '*'
        @Plus = 14, // 1 '+'
        @PlusPlus = 15, // 1 '++'
        @Comma = 16, // 1 ','
        @Minus = 17, // 1 '-'
        @MinusMinus = 18, // 1 '--'
        @Div = 19, // 1 '/'
        @Semi = 20, // 1 ';'
        @Lt = 21, // 1 '<'
        @LtEq = 22, // 1 '<='
        @LtGt = 23, // 1 '<>'
        @Eq = 24, // 1 '='
        @EqEq = 25, // 1 '=='
        @Gt = 26, // 1 '>'
        @GtEq = 27, // 1 '>='
        @ACCEPT = 28, // 1 ACCEPT
        @AND = 29, // 1 AND
        @Boolean = 30, // 1 Boolean
        @BREAK = 31, // 1 BREAK
        @CONTINUE = 32, // 1 CONTINUE
        @Decimal = 33, // 1 Decimal
        @DO = 34, // 1 DO
        @ELSE = 35, // 1 ELSE
        @FOR = 36, // 1 FOR
        @function = 37, // 1 function
        @Identifier = 38, // 1 Identifier
        @IF = 39, // 1 IF
        @INCLUDE = 40, // 1 INCLUDE
        @MemberName = 41, // 1 MemberName
        @new = 42, // 1 new
        @NOT = 43, // 1 NOT
        @Number = 44, // 1 Number
        @OBJECTS = 45, // 1 OBJECTS
        @OR = 46, // 1 OR
        @PRINT = 47, // 1 PRINT
        @RegExp = 48, // 1 RegExp
        @REJECT = 49, // 1 REJECT
        @RETURN = 50, // 1 RETURN
        @SCOPE = 51, // 1 SCOPE
        @STEP = 52, // 1 STEP
        @StringDouble = 53, // 1 StringDouble
        @StringSingle = 54, // 1 StringSingle
        @TO = 55, // 1 TO
        @Type = 56, // 1 Type
        @UNSET = 57, // 1 UNSET
        @UNTIL = 58, // 1 UNTIL
        @VAR = 59, // 1 VAR
        @VARS = 60, // 1 VARS
        @WHILE = 61, // 1 WHILE
        @LBrace = 62, // 1 '{'
        @PipePipe = 63, // 1 '||'
        @RBrace = 64, // 1 '}'
        @Tilde = 65, // 1 '~'
        @AcceptProc = 66, // 0 <AcceptProc>
        @AddExpression = 67, // 0 <AddExpression>
        @AndOperator = 68, // 0 <AndOperator>
        @ArgumentList = 69, // 0 <Argument List>
        @Arguments = 70, // 0 <Arguments>
        @Assignment = 71, // 0 <Assignment>
        @BaseClass = 72, // 0 <Base Class>
        @Block = 73, // 0 <Block>
        @BlockorEnd = 74, // 0 <Block or End>
        @BreakControl = 75, // 0 <BreakControl>
        @CallExpression = 76, // 0 <Call Expression>
        @CallInternal = 77, // 0 <CallInternal>
        @ContinueControl = 78, // 0 <ContinueControl>
        @Declare = 79, // 0 <Declare>
        @Decrement = 80, // 0 <Decrement>
        @DivideExpression = 81, // 0 <DivideExpression>
        @DoUntilControl = 82, // 0 <DoUntilControl>
        @DoWhileControl = 83, // 0 <DoWhileControl>
        @End = 84, // 0 <End>
        @EndOpt = 85, // 0 <End Opt>
        @EqualOperator = 86, // 0 <EqualOperator>
        @Expression = 87, // 0 <Expression>
        @FlowControl = 88, // 0 <FlowControl>
        @ForControl = 89, // 0 <ForControl>
        @FormalParameterList = 90, // 0 <Formal Parameter List>
        @ForStepControl = 91, // 0 <ForStepControl>
        @FunctionDeclaration = 92, // 0 <Function Declaration>
        @FunctionExpression = 93, // 0 <Function Expression>
        @GteOperator = 94, // 0 <GteOperator>
        @GtOperator = 95, // 0 <GtOperator>
        @IfControl = 96, // 0 <IfControl>
        @IncludeProc = 97, // 0 <IncludeProc>
        @Increment = 98, // 0 <Increment>
        @ListObjects = 99, // 0 <ListObjects>
        @ListVars = 100, // 0 <ListVars>
        @LoopUntilControl = 101, // 0 <LoopUntilControl>
        @LoopWhileControl = 102, // 0 <LoopWhileControl>
        @LteOperator = 103, // 0 <LteOperator>
        @LtOperator = 104, // 0 <LtOperator>
        @MemberList = 105, // 0 <Member List>
        @MultiplyExpression = 106, // 0 <MultiplyExpression>
        @NewExpression = 107, // 0 <New Expression>
        @NotEqualOperator = 108, // 0 <NotEqualOperator>
        @ObjectDecl = 109, // 0 <Object Decl>
        @ObjectDecls = 110, // 0 <Object Decls>
        @OrOperator = 111, // 0 <OrOperator>
        @PrintProc = 112, // 0 <PrintProc>
        @Procedure = 113, // 0 <Procedure>
        @Program = 114, // 0 <Program>
        @QualifiedID = 115, // 0 <Qualified ID>
        @RejectProc = 116, // 0 <RejectProc>
        @ReturnProc = 117, // 0 <ReturnProc>
        @ScopeProc = 118, // 0 <ScopeProc>
        @Statement = 119, // 0 <Statement>
        @StatementorBlock = 120, // 0 <Statement or Block>
        @Statements = 121, // 0 <Statements>
        @SubExpression = 122, // 0 <SubExpression>
        @UnaryOperator = 123, // 0 <UnaryOperator>
        @UnsetProc = 124, // 0 <UnsetProc>
        @ValidID = 125, // 0 <Valid ID>
        @Value = 126, // 0 <Value>
        @VariableStatements = 127 // 0 <Variable Statements>
    }
}