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
        @NOT = 41, // 1 NOT
        @Number = 42, // 1 Number
        @OR = 43, // 1 OR
        @PRINT = 44, // 1 PRINT
        @RegExp = 45, // 1 RegExp
        @REJECT = 46, // 1 REJECT
        @RETURN = 47, // 1 RETURN
        @SCOPE = 48, // 1 SCOPE
        @STEP = 49, // 1 STEP
        @StringDouble = 50, // 1 StringDouble
        @StringSingle = 51, // 1 StringSingle
        @this = 52, // 1 this
        @TO = 53, // 1 TO
        @UNSET = 54, // 1 UNSET
        @UNTIL = 55, // 1 UNTIL
        @VAR = 56, // 1 VAR
        @VARS = 57, // 1 VARS
        @WHILE = 58, // 1 WHILE
        @LBrace = 59, // 1 '{'
        @PipePipe = 60, // 1 '||'
        @RBrace = 61, // 1 '}'
        @Tilde = 62, // 1 '~'
        @AcceptProc = 63, // 0 <AcceptProc>
        @AddExpression = 64, // 0 <AddExpression>
        @AndOperator = 65, // 0 <AndOperator>
        @ArgumentList = 66, // 0 <Argument List>
        @Arguments = 67, // 0 <Arguments>
        @Assignment = 68, // 0 <Assignment>
        @Block = 69, // 0 <Block>
        @BreakControl = 70, // 0 <BreakControl>
        @CallExpression = 71, // 0 <Call Expression>
        @CallInternal = 72, // 0 <CallInternal>
        @ContinueControl = 73, // 0 <ContinueControl>
        @Declare = 74, // 0 <Declare>
        @Decrement = 75, // 0 <Decrement>
        @DivideExpression = 76, // 0 <DivideExpression>
        @DoUntilControl = 77, // 0 <DoUntilControl>
        @DoWhileControl = 78, // 0 <DoWhileControl>
        @EqualOperator = 79, // 0 <EqualOperator>
        @Expression = 80, // 0 <Expression>
        @FlowControl = 81, // 0 <FlowControl>
        @ForControl = 82, // 0 <ForControl>
        @FormalParameterList = 83, // 0 <Formal Parameter List>
        @ForStepControl = 84, // 0 <ForStepControl>
        @FunctionDeclaration = 85, // 0 <Function Declaration>
        @FunctionExpression = 86, // 0 <Function Expression>
        @GteOperator = 87, // 0 <GteOperator>
        @GtOperator = 88, // 0 <GtOperator>
        @IfControl = 89, // 0 <IfControl>
        @IncludeProc = 90, // 0 <IncludeProc>
        @Increment = 91, // 0 <Increment>
        @ListVars = 92, // 0 <ListVars>
        @LoopUntilControl = 93, // 0 <LoopUntilControl>
        @LoopWhileControl = 94, // 0 <LoopWhileControl>
        @LteOperator = 95, // 0 <LteOperator>
        @LtOperator = 96, // 0 <LtOperator>
        @MultiplyExpression = 97, // 0 <MultiplyExpression>
        @NotEqualOperator = 98, // 0 <NotEqualOperator>
        @OrOperator = 99, // 0 <OrOperator>
        @PrintProc = 100, // 0 <PrintProc>
        @Procedure = 101, // 0 <Procedure>
        @Program = 102, // 0 <Program>
        @RejectProc = 103, // 0 <RejectProc>
        @ReturnProc = 104, // 0 <ReturnProc>
        @ScopeProc = 105, // 0 <ScopeProc>
        @Statement = 106, // 0 <Statement>
        @StatementorBlock = 107, // 0 <Statement or Block>
        @Statements = 108, // 0 <Statements>
        @SubExpression = 109, // 0 <SubExpression>
        @UnaryOperator = 110, // 0 <UnaryOperator>
        @UnsetProc = 111, // 0 <UnsetProc>
        @Value = 112, // 0 <Value>
        @Variable = 113, // 0 <Variable>
        @Variables = 114 // 0 <Variables>
    }
}