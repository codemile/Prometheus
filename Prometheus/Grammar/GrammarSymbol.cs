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
        @new = 41, // 1 new
        @NOT = 42, // 1 NOT
        @Number = 43, // 1 Number
        @OR = 44, // 1 OR
        @PRINT = 45, // 1 PRINT
        @RegExp = 46, // 1 RegExp
        @REJECT = 47, // 1 REJECT
        @RETURN = 48, // 1 RETURN
        @SCOPE = 49, // 1 SCOPE
        @STEP = 50, // 1 STEP
        @StringDouble = 51, // 1 StringDouble
        @StringSingle = 52, // 1 StringSingle
        @this = 53, // 1 this
        @TO = 54, // 1 TO
        @Type = 55, // 1 Type
        @UNSET = 56, // 1 UNSET
        @UNTIL = 57, // 1 UNTIL
        @VAR = 58, // 1 VAR
        @VARS = 59, // 1 VARS
        @WHILE = 60, // 1 WHILE
        @LBrace = 61, // 1 '{'
        @PipePipe = 62, // 1 '||'
        @RBrace = 63, // 1 '}'
        @Tilde = 64, // 1 '~'
        @AcceptProc = 65, // 0 <AcceptProc>
        @AddExpression = 66, // 0 <AddExpression>
        @AndOperator = 67, // 0 <AndOperator>
        @ArgumentList = 68, // 0 <Argument List>
        @Arguments = 69, // 0 <Arguments>
        @Assignment = 70, // 0 <Assignment>
        @BaseClass = 71, // 0 <Base Class>
        @Block = 72, // 0 <Block>
        @BlockorEnd = 73, // 0 <Block or End>
        @BreakControl = 74, // 0 <BreakControl>
        @CallExpression = 75, // 0 <Call Expression>
        @CallInternal = 76, // 0 <CallInternal>
        @ContinueControl = 77, // 0 <ContinueControl>
        @Declare = 78, // 0 <Declare>
        @Decrement = 79, // 0 <Decrement>
        @DivideExpression = 80, // 0 <DivideExpression>
        @DoUntilControl = 81, // 0 <DoUntilControl>
        @DoWhileControl = 82, // 0 <DoWhileControl>
        @End = 83, // 0 <End>
        @EndOpt = 84, // 0 <End Opt>
        @EqualOperator = 85, // 0 <EqualOperator>
        @Expression = 86, // 0 <Expression>
        @FlowControl = 87, // 0 <FlowControl>
        @ForControl = 88, // 0 <ForControl>
        @FormalParameterList = 89, // 0 <Formal Parameter List>
        @ForStepControl = 90, // 0 <ForStepControl>
        @FunctionDeclaration = 91, // 0 <Function Declaration>
        @FunctionExpression = 92, // 0 <Function Expression>
        @GteOperator = 93, // 0 <GteOperator>
        @GtOperator = 94, // 0 <GtOperator>
        @IfControl = 95, // 0 <IfControl>
        @IncludeProc = 96, // 0 <IncludeProc>
        @Increment = 97, // 0 <Increment>
        @ListVars = 98, // 0 <ListVars>
        @LoopUntilControl = 99, // 0 <LoopUntilControl>
        @LoopWhileControl = 100, // 0 <LoopWhileControl>
        @LteOperator = 101, // 0 <LteOperator>
        @LtOperator = 102, // 0 <LtOperator>
        @MultiplyExpression = 103, // 0 <MultiplyExpression>
        @NewExpression = 104, // 0 <New Expression>
        @NotEqualOperator = 105, // 0 <NotEqualOperator>
        @ObjectDecl = 106, // 0 <Object Decl>
        @OrOperator = 107, // 0 <OrOperator>
        @PrintProc = 108, // 0 <PrintProc>
        @Procedure = 109, // 0 <Procedure>
        @Program = 110, // 0 <Program>
        @RejectProc = 111, // 0 <RejectProc>
        @ReturnProc = 112, // 0 <ReturnProc>
        @ScopeProc = 113, // 0 <ScopeProc>
        @Statement = 114, // 0 <Statement>
        @StatementorBlock = 115, // 0 <Statement or Block>
        @Statements = 116, // 0 <Statements>
        @SubExpression = 117, // 0 <SubExpression>
        @UnaryOperator = 118, // 0 <UnaryOperator>
        @UnsetProc = 119, // 0 <UnsetProc>
        @Value = 120, // 0 <Value>
        @Variable = 121, // 0 <Variable>
        @Variables = 122 // 0 <Variables>
    }
}