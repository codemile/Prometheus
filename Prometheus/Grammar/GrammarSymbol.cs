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
        @assert = 32, // 1 assert
        @Boolean = 33, // 1 Boolean
        @break = 34, // 1 break
        @CONTAINS = 35, // 1 CONTAINS
        @continue = 36, // 1 continue
        @Decimal = 37, // 1 Decimal
        @do = 38, // 1 do
        @each = 39, // 1 each
        @else = 40, // 1 else
        @fail = 41, // 1 fail
        @for = 42, // 1 for
        @function = 43, // 1 function
        @HAS = 44, // 1 HAS
        @Identifier = 45, // 1 Identifier
        @if = 46, // 1 if
        @isset = 47, // 1 isset
        @MemberName = 48, // 1 MemberName
        @new = 49, // 1 new
        @NOT = 50, // 1 NOT
        @Number = 51, // 1 Number
        @object = 52, // 1 object
        @OR = 53, // 1 OR
        @package = 54, // 1 package
        @print = 55, // 1 print
        @RegExpPipe = 56, // 1 RegExpPipe
        @RegExpSlash = 57, // 1 RegExpSlash
        @return = 58, // 1 return
        @StringDouble = 59, // 1 StringDouble
        @StringSingle = 60, // 1 StringSingle
        @test = 61, // 1 test
        @tests = 62, // 1 tests
        @typeof = 63, // 1 typeof
        @Undefined = 64, // 1 Undefined
        @unset = 65, // 1 unset
        @until = 66, // 1 until
        @use = 67, // 1 use
        @VAR = 68, // 1 VAR
        @vars = 69, // 1 vars
        @while = 70, // 1 while
        @with = 71, // 1 with
        @LBracket = 72, // 1 '['
        @RBracket = 73, // 1 ']'
        @LBrace = 74, // 1 '{'
        @PipePipe = 75, // 1 '||'
        @RBrace = 76, // 1 '}'
        @Tilde = 77, // 1 '~'
        @AddExpression = 78, // 0 <Add Expression>
        @AllFunctions = 79, // 0 <All Functions>
        @AllProcedures = 80, // 0 <All Procedures>
        @AndOperator = 81, // 0 <And Operator>
        @ArgumentArray = 82, // 0 <Argument Array>
        @ArgumentList = 83, // 0 <Argument List>
        @ArrayLiteral = 84, // 0 <Array Literal>
        @ArrayLiteralList = 85, // 0 <Array Literal List>
        @AssertProc = 86, // 0 <Assert Proc>
        @Assignment = 87, // 0 <Assignment>
        @BaseClassID = 88, // 0 <BaseClass ID>
        @BitInvertOperator = 89, // 0 <Bit Invert Operator>
        @Block = 90, // 0 <Block>
        @BooleanChain = 91, // 0 <Boolean Chain>
        @BreakControl = 92, // 0 <Break Control>
        @CallExpression = 93, // 0 <Call Expression>
        @ClassNameID = 94, // 0 <ClassName ID>
        @ClassNameList = 95, // 0 <ClassName List>
        @ContainsTerm = 96, // 0 <Contains Term>
        @ContinueControl = 97, // 0 <Continue Control>
        @Declare = 98, // 0 <Declare>
        @DivideExpression = 99, // 0 <Divide Expression>
        @DoUntilControl = 100, // 0 <Do Until Control>
        @DoWhileControl = 101, // 0 <Do While Control>
        @EachControl = 102, // 0 <Each Control>
        @EachOperator = 103, // 0 <Each Operator>
        @End = 104, // 0 <End>
        @EndOpt = 105, // 0 <End Opt>
        @EqualOperator = 106, // 0 <Equal Operator>
        @Expression = 107, // 0 <Expression>
        @FailProc = 108, // 0 <Fail Proc>
        @FlowControl = 109, // 0 <Flow Control>
        @ForControl = 110, // 0 <For Control>
        @ForDeclare = 111, // 0 <For Declare>
        @ForExpression = 112, // 0 <For Expression>
        @ForStep = 113, // 0 <For Step>
        @FunctionBlock = 114, // 0 <Function Block>
        @FunctionDecl = 115, // 0 <Function Decl>
        @FunctionExpression = 116, // 0 <Function Expression>
        @FunctionParameters = 117, // 0 <Function Parameters>
        @GtOperator = 118, // 0 <Gt Operator>
        @GteOperator = 119, // 0 <Gte Operator>
        @IfControl = 120, // 0 <If Control>
        @ImportDecl = 121, // 0 <Import Decl>
        @ImportDecls = 122, // 0 <Import Decls>
        @IssetFunc = 123, // 0 <Isset Func>
        @ListVars = 124, // 0 <List Vars>
        @LtOperator = 125, // 0 <Lt Operator>
        @LteOperator = 126, // 0 <Lte Operator>
        @MathChain = 127, // 0 <Math Chain>
        @MemberID = 128, // 0 <Member ID>
        @MultiplyExpression = 129, // 0 <Multiply Expression>
        @NegOperator = 130, // 0 <Neg Operator>
        @NewExpression = 131, // 0 <New Expression>
        @NotEqualOperator = 132, // 0 <Not Equal Operator>
        @NotOperator = 133, // 0 <Not Operator>
        @ObjectBlock = 134, // 0 <Object Block>
        @ObjectDecl = 135, // 0 <Object Decl>
        @ObjectDecls = 136, // 0 <Object Decls>
        @OrOperator = 137, // 0 <Or Operator>
        @PackageDetails = 138, // 0 <Package Details>
        @PackageID = 139, // 0 <Package ID>
        @ParameterArray = 140, // 0 <Parameter Array>
        @ParameterList = 141, // 0 <Parameter List>
        @ParameterName = 142, // 0 <Parameter Name>
        @PluralID = 143, // 0 <Plural ID>
        @PlusOperator = 144, // 0 <Plus Operator>
        @PostDecOperator = 145, // 0 <Post Dec Operator>
        @PostDecrement = 146, // 0 <Post Decrement>
        @PostIncOperator = 147, // 0 <Post Inc Operator>
        @PostIncrement = 148, // 0 <Post Increment>
        @PreDecOperator = 149, // 0 <Pre Dec Operator>
        @PreDecrement = 150, // 0 <Pre Decrement>
        @PreIncOperator = 151, // 0 <Pre Inc Operator>
        @PreIncrement = 152, // 0 <Pre Increment>
        @PrintProc = 153, // 0 <Print Proc>
        @Program = 154, // 0 <Program>
        @ProgramCode = 155, // 0 <Program Code>
        @ProgramTest = 156, // 0 <Program Test>
        @QualifiedID = 157, // 0 <Qualified ID>
        @QualifiedList = 158, // 0 <Qualified List>
        @RemainderExpression = 159, // 0 <Remainder Expression>
        @ReturnProc = 160, // 0 <Return Proc>
        @SearchChain = 161, // 0 <Search Chain>
        @Statement = 162, // 0 <Statement>
        @StatementorBlock = 163, // 0 <Statement or Block>
        @Statements = 164, // 0 <Statements>
        @SubExpression = 165, // 0 <Sub Expression>
        @TestBlock = 166, // 0 <Test Block>
        @TestDecl = 167, // 0 <Test Decl>
        @TestDecls = 168, // 0 <Test Decls>
        @TestExecute = 169, // 0 <Test Execute>
        @TestSuiteArray = 170, // 0 <Test Suite Array>
        @TestSuiteDecl = 171, // 0 <Test Suite Decl>
        @TypeOfFunc = 172, // 0 <TypeOf Func>
        @UnaryChain = 173, // 0 <Unary Chain>
        @UnsetProc = 174, // 0 <Unset Proc>
        @UntilControl = 175, // 0 <Until Control>
        @ValidID = 176, // 0 <Valid ID>
        @Value = 177, // 0 <Value>
        @VariableFunctions = 178, // 0 <Variable Functions>
        @VariableStatements = 179, // 0 <Variable Statements>
        @WhileControl = 180, // 0 <While Control>
        @WhileExpression = 181, // 0 <While Expression>
        @WithArray = 182 // 0 <With Array>
    }
}