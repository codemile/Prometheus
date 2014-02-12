
namespace Prometheus.Grammar
{
	/// <summary>
	/// This enum is generated at compile time by the GOLD template generator.
	///
	/// Do not make changes to this file.
	/// </summary>
	public enum GrammarSymbol
	{
		@EOF = 0,                                        // 3 (EOF)
		@Error = 1,                                      // 7 (Error)
		@Comment = 2,                                    // 2 Comment
		@NewLine = 3,                                    // 2 NewLine
		@Whitespace = 4,                                 // 2 Whitespace
		@TimesDiv = 5,                                   // 5 '*/'
		@DivTimes = 6,                                   // 4 '/*'
		@DivDiv = 7,                                     // 6 '//'
		@Exclam = 8,                                     // 1 '!'
		@ExclamEq = 9,                                   // 1 '!='
		@AmpAmp = 10,                                    // 1 '&&'
		@LParen = 11,                                    // 1 '('
		@RParen = 12,                                    // 1 ')'
		@Times = 13,                                     // 1 '*'
		@Plus = 14,                                      // 1 '+'
		@PlusPlus = 15,                                  // 1 '++'
		@Comma = 16,                                     // 1 ','
		@Minus = 17,                                     // 1 '-'
		@MinusMinus = 18,                                // 1 '--'
		@Div = 19,                                       // 1 '/'
		@ColonColon = 20,                                // 1 '::'
		@Semi = 21,                                      // 1 ';'
		@Lt = 22,                                        // 1 '<'
		@LtEq = 23,                                      // 1 '<='
		@LtGt = 24,                                      // 1 '<>'
		@Eq = 25,                                        // 1 '='
		@EqEq = 26,                                      // 1 '=='
		@Gt = 27,                                        // 1 '>'
		@GtEq = 28,                                      // 1 '>='
		@ACCEPT = 29,                                    // 1 ACCEPT
		@AND = 30,                                       // 1 AND
		@Boolean = 31,                                   // 1 Boolean
		@BREAK = 32,                                     // 1 BREAK
		@CONTAINS = 33,                                  // 1 CONTAINS
		@CONTINUE = 34,                                  // 1 CONTINUE
		@Decimal = 35,                                   // 1 Decimal
		@DO = 36,                                        // 1 DO
		@ELSE = 37,                                      // 1 ELSE
		@FOR = 38,                                       // 1 FOR
		@function = 39,                                  // 1 function
		@HAS = 40,                                       // 1 HAS
		@Identifier = 41,                                // 1 Identifier
		@IF = 42,                                        // 1 IF
		@INCLUDE = 43,                                   // 1 INCLUDE
		@MemberName = 44,                                // 1 MemberName
		@new = 45,                                       // 1 new
		@NOT = 46,                                       // 1 NOT
		@Number = 47,                                    // 1 Number
		@object = 48,                                    // 1 object
		@OBJECTS = 49,                                   // 1 OBJECTS
		@OR = 50,                                        // 1 OR
		@PRINT = 51,                                     // 1 PRINT
		@RegExpPipe = 52,                                // 1 RegExpPipe
		@RegExpSlash = 53,                               // 1 RegExpSlash
		@REJECT = 54,                                    // 1 REJECT
		@RETURN = 55,                                    // 1 RETURN
		@SCOPE = 56,                                     // 1 SCOPE
		@STEP = 57,                                      // 1 STEP
		@StringDouble = 58,                              // 1 StringDouble
		@StringSingle = 59,                              // 1 StringSingle
		@TO = 60,                                        // 1 TO
		@UNSET = 61,                                     // 1 UNSET
		@UNTIL = 62,                                     // 1 UNTIL
		@VAR = 63,                                       // 1 VAR
		@VARS = 64,                                      // 1 VARS
		@WHILE = 65,                                     // 1 WHILE
		@LBracket = 66,                                  // 1 '['
		@RBracket = 67,                                  // 1 ']'
		@LBrace = 68,                                    // 1 '{'
		@PipePipe = 69,                                  // 1 '||'
		@RBrace = 70,                                    // 1 '}'
		@Tilde = 71,                                     // 1 '~'
		@AcceptProc = 72,                                // 0 <AcceptProc>
		@AddExpression = 73,                             // 0 <AddExpression>
		@AndOperator = 74,                               // 0 <AndOperator>
		@ArgumentList = 75,                              // 0 <Argument List>
		@Arguments = 76,                                 // 0 <Arguments>
		@ArrayList = 77,                                 // 0 <Array List>
		@ArrayLiteral = 78,                              // 0 <Array Literal>
		@Assignment = 79,                                // 0 <Assignment>
		@BaseClassID = 80,                               // 0 <BaseClass ID>
		@Block = 81,                                     // 0 <Block>
		@BlockorEnd = 82,                                // 0 <Block or End>
		@BooleanChain = 83,                              // 0 <BooleanChain>
		@BreakControl = 84,                              // 0 <BreakControl>
		@CallExpression = 85,                            // 0 <Call Expression>
		@CallInternal = 86,                              // 0 <CallInternal>
		@ClassNameID = 87,                               // 0 <ClassName ID>
		@ConstructParamsList = 88,                       // 0 <ConstructParams List>
		@ContainsTerm = 89,                              // 0 <ContainsTerm>
		@ContinueControl = 90,                           // 0 <ContinueControl>
		@Declare = 91,                                   // 0 <Declare>
		@Decrement = 92,                                 // 0 <Decrement>
		@DivideExpression = 93,                          // 0 <DivideExpression>
		@DoUntilControl = 94,                            // 0 <DoUntilControl>
		@DoWhileControl = 95,                            // 0 <DoWhileControl>
		@End = 96,                                       // 0 <End>
		@EndOpt = 97,                                    // 0 <End Opt>
		@EqualOperator = 98,                             // 0 <EqualOperator>
		@Expression = 99,                                // 0 <Expression>
		@FlowControl = 100,                              // 0 <FlowControl>
		@ForControl = 101,                               // 0 <ForControl>
		@FormalParameterList = 102,                      // 0 <Formal Parameter List>
		@FormalParameters = 103,                         // 0 <Formal Parameters>
		@ForStepControl = 104,                           // 0 <ForStepControl>
		@FunctionExpression = 105,                       // 0 <Function Expression>
		@GteOperator = 106,                              // 0 <GteOperator>
		@GtOperator = 107,                               // 0 <GtOperator>
		@IfControl = 108,                                // 0 <IfControl>
		@IncludeProc = 109,                              // 0 <IncludeProc>
		@Increment = 110,                                // 0 <Increment>
		@ListObjects = 111,                              // 0 <ListObjects>
		@ListVars = 112,                                 // 0 <ListVars>
		@LoopUntilControl = 113,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 114,                         // 0 <LoopWhileControl>
		@LteOperator = 115,                              // 0 <LteOperator>
		@LtOperator = 116,                               // 0 <LtOperator>
		@MathChain = 117,                                // 0 <MathChain>
		@MemberList = 118,                               // 0 <Member List>
		@MultiplyExpression = 119,                       // 0 <MultiplyExpression>
		@NewExpression = 120,                            // 0 <New Expression>
		@NotEqualOperator = 121,                         // 0 <NotEqualOperator>
		@ObjectDecl = 122,                               // 0 <Object Decl>
		@ObjectDecls = 123,                              // 0 <Object Decls>
		@OrOperator = 124,                               // 0 <OrOperator>
		@PrintProc = 125,                                // 0 <PrintProc>
		@Procedure = 126,                                // 0 <Procedure>
		@Program = 127,                                  // 0 <Program>
		@QualifiedID = 128,                              // 0 <Qualified ID>
		@RejectProc = 129,                               // 0 <RejectProc>
		@ReturnProc = 130,                               // 0 <ReturnProc>
		@ScopeProc = 131,                                // 0 <ScopeProc>
		@SearchChain = 132,                              // 0 <SearchChain>
		@Statement = 133,                                // 0 <Statement>
		@StatementorBlock = 134,                         // 0 <Statement or Block>
		@Statements = 135,                               // 0 <Statements>
		@SubExpression = 136,                            // 0 <SubExpression>
		@UnaryOperator = 137,                            // 0 <UnaryOperator>
		@UnsetProc = 138,                                // 0 <UnsetProc>
		@ValidID = 139,                                  // 0 <Valid ID>
		@Value = 140,                                    // 0 <Value>
		@VariableStatements = 141                        // 0 <Variable Statements>
	}
}
