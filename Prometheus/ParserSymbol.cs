namespace Prometheus
{
    /// <summary>
    /// This enum is generated at compile time by the GOLD template generator.
    /// Do not make changes to this file.
    /// </summary>
    public enum ParserSymbol
    {
        @EOF = 0, // (EOF)
        @Error = 1, // (Error)
        @Comment = 2, // Comment
        @NewLine = 3, // NewLine
        @Whitespace = 4, // Whitespace
        @TimesDiv = 5, // '*/'
        @DivTimes = 6, // '/*'
        @DivDiv = 7, // '//'
        @Exclam = 8, // '!'
        @ExclamEq = 9, // '!='
        @AmpAmp = 10, // '&&'
        @LParen = 11, // '('
        @RParen = 12, // ')'
        @Times = 13, // '*'
        @Plus = 14, // '+'
        @Minus = 15, // '-'
        @Div = 16, // '/'
        @Semi = 17, // ';'
        @Lt = 18, // '<'
        @LtEq = 19, // '<='
        @LtGt = 20, // '<>'
        @Eq = 21, // '='
        @EqEq = 22, // '=='
        @Gt = 23, // '>'
        @GtEq = 24, // '>='
        @accept = 25, // accept
        @and = 26, // and
        @assert = 27, // assert
        @Boolean = 28, // Boolean
        @contains = 29, // contains
        @debug = 30, // debug
        @else = 31, // else
        @Float = 32, // Float
        @has = 33, // has
        @Identifier = 34, // Identifier
        @if = 35, // if
        @include = 36, // include
        @Integer = 37, // Integer
        @not = 38, // not
        @or = 39, // or
        @reject = 40, // reject
        @scope = 41, // scope
        @set = 42, // set
        @StringDouble = 43, // StringDouble
        @StringSingle = 44, // StringSingle
        @trace = 45, // trace
        @unset = 46, // unset
        @LBrace = 47, // '{'
        @PipePipe = 48, // '||'
        @RBrace = 49, // '}'
        @Tilde = 50, // '~'
        @AcceptCommand = 51, // <AcceptCommand>
        @AddExpression = 52, // <AddExpression>
        @AssertCommand = 53, // <AssertCommand>
        @Block = 54, // <Block>
        @DebugCommand = 55, // <DebugCommand>
        @DivideExpression = 56, // <DivideExpression>
        @Expression = 57, // <Expression>
        @IfBlock = 58, // <IfBlock>
        @IfElseBlock = 59, // <IfElseBlock>
        @IncludeCommand = 60, // <IncludeCommand>
        @MultiplyExpression = 61, // <MultiplyExpression>
        @Program = 62, // <Program>
        @RejectCommand = 63, // <RejectCommand>
        @ScopeCommand = 64, // <ScopeCommand>
        @SearchTerm = 65, // <SearchTerm>
        @SetCommand = 66, // <SetCommand>
        @Statement = 67, // <Statement>
        @Statements = 68, // <Statements>
        @SubExpression = 69, // <SubExpression>
        @TraceCommand = 70, // <TraceCommand>
        @UnaryOperator = 71, // <UnaryOperator>
        @UnsetCommand = 72, // <UnsetCommand>
        @Value = 73, // <Value>
        @Variable = 74 // <Variable>
    }
}