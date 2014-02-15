
namespace Prometheus.Grammar
{
	// ReSharper disable UnusedMember.Global
	// ReSharper disable CSharpWarnings::CS1591
	// ReSharper disable InconsistentNaming

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
		@Percent = 10,                                   // 1 '%'
		@AmpAmp = 11,                                    // 1 '&&'
		@LParen = 12,                                    // 1 '('
		@RParen = 13,                                    // 1 ')'
		@Times = 14,                                     // 1 '*'
		@Plus = 15,                                      // 1 '+'
		@PlusPlus = 16,                                  // 1 '++'
		@Comma = 17,                                     // 1 ','
		@Minus = 18,                                     // 1 '-'
		@MinusMinus = 19,                                // 1 '--'
		@Div = 20,                                       // 1 '/'
		@ColonColon = 21,                                // 1 '::'
		@Semi = 22,                                      // 1 ';'
		@Lt = 23,                                        // 1 '<'
		@LtEq = 24,                                      // 1 '<='
		@LtGt = 25,                                      // 1 '<>'
		@Eq = 26,                                        // 1 '='
		@EqEq = 27,                                      // 1 '=='
		@Gt = 28,                                        // 1 '>'
		@GtEq = 29,                                      // 1 '>='
		@ACCEPT = 30,                                    // 1 ACCEPT
		@AND = 31,                                       // 1 AND
		@Boolean = 32,                                   // 1 Boolean
		@BREAK = 33,                                     // 1 BREAK
		@CONTAINS = 34,                                  // 1 CONTAINS
		@CONTINUE = 35,                                  // 1 CONTINUE
		@Decimal = 36,                                   // 1 Decimal
		@DO = 37,                                        // 1 DO
		@ELSE = 38,                                      // 1 ELSE
		@FOR = 39,                                       // 1 FOR
		@function = 40,                                  // 1 function
		@HAS = 41,                                       // 1 HAS
		@Identifier = 42,                                // 1 Identifier
		@IF = 43,                                        // 1 IF
		@INCLUDE = 44,                                   // 1 INCLUDE
		@MemberName = 45,                                // 1 MemberName
		@new = 46,                                       // 1 new
		@NOT = 47,                                       // 1 NOT
		@Number = 48,                                    // 1 Number
		@object = 49,                                    // 1 object
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
		@ArrayLiteral = 77,                              // 0 <Array Literal>
		@ArrayLiteralList = 78,                          // 0 <Array Literal List>
		@Assignment = 79,                                // 0 <Assignment>
		@BaseClassID = 80,                               // 0 <BaseClass ID>
		@BitInvertOperator = 81,                         // 0 <BitInvertOperator>
		@Block = 82,                                     // 0 <Block>
		@BlockorEnd = 83,                                // 0 <Block or End>
		@BooleanChain = 84,                              // 0 <BooleanChain>
		@BreakControl = 85,                              // 0 <BreakControl>
		@CallExpression = 86,                            // 0 <Call Expression>
		@CallInternal = 87,                              // 0 <CallInternal>
		@ContainsTerm = 88,                              // 0 <ContainsTerm>
		@ContinueControl = 89,                           // 0 <ContinueControl>
		@Declare = 90,                                   // 0 <Declare>
		@Decrement = 91,                                 // 0 <Decrement>
		@DivideExpression = 92,                          // 0 <DivideExpression>
		@DoUntilControl = 93,                            // 0 <DoUntilControl>
		@DoWhileControl = 94,                            // 0 <DoWhileControl>
		@End = 95,                                       // 0 <End>
		@EndOpt = 96,                                    // 0 <End Opt>
		@EqualOperator = 97,                             // 0 <EqualOperator>
		@Expression = 98,                                // 0 <Expression>
		@FlowControl = 99,                               // 0 <FlowControl>
		@ForControl = 100,                               // 0 <ForControl>
		@ForStepControl = 101,                           // 0 <ForStepControl>
		@FunctionBlock = 102,                            // 0 <Function Block>
		@FunctionDecl = 103,                             // 0 <Function Decl>
		@FunctionExpression = 104,                       // 0 <Function Expression>
		@GteOperator = 105,                              // 0 <GteOperator>
		@GtOperator = 106,                               // 0 <GtOperator>
		@IfControl = 107,                                // 0 <IfControl>
		@IncludeProc = 108,                              // 0 <IncludeProc>
		@Increment = 109,                                // 0 <Increment>
		@ListVars = 110,                                 // 0 <ListVars>
		@LoopUntilControl = 111,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 112,                         // 0 <LoopWhileControl>
		@LteOperator = 113,                              // 0 <LteOperator>
		@LtOperator = 114,                               // 0 <LtOperator>
		@MathChain = 115,                                // 0 <MathChain>
		@MemberID = 116,                                 // 0 <Member ID>
		@MemberList = 117,                               // 0 <Member List>
		@MultiplyExpression = 118,                       // 0 <MultiplyExpression>
		@NegOperator = 119,                              // 0 <NegOperator>
		@NewExpression = 120,                            // 0 <New Expression>
		@NotEqualOperator = 121,                         // 0 <NotEqualOperator>
		@NotOperator = 122,                              // 0 <NotOperator>
		@ObjectBlock = 123,                              // 0 <Object Block>
		@ObjectDecl = 124,                               // 0 <Object Decl>
		@ObjectDecls = 125,                              // 0 <Object Decls>
		@OrOperator = 126,                               // 0 <OrOperator>
		@ParameterList = 127,                            // 0 <Parameter List>
		@ParameterName = 128,                            // 0 <Parameter Name>
		@Parameters = 129,                               // 0 <Parameters>
		@PlusOperator = 130,                             // 0 <PlusOperator>
		@PostDecOperator = 131,                          // 0 <PostDecOperator>
		@PostIncOperator = 132,                          // 0 <PostIncOperator>
		@PreDecOperator = 133,                           // 0 <PreDecOperator>
		@PreIncOperator = 134,                           // 0 <PreIncOperator>
		@PrintProc = 135,                                // 0 <PrintProc>
		@Procedure = 136,                                // 0 <Procedure>
		@Program = 137,                                  // 0 <Program>
		@QualifiedID = 138,                              // 0 <Qualified ID>
		@QualifiedList = 139,                            // 0 <Qualified List>
		@RejectProc = 140,                               // 0 <RejectProc>
		@RemainderExpression = 141,                      // 0 <RemainderExpression>
		@ReturnProc = 142,                               // 0 <ReturnProc>
		@ScopeProc = 143,                                // 0 <ScopeProc>
		@SearchChain = 144,                              // 0 <SearchChain>
		@Statement = 145,                                // 0 <Statement>
		@StatementorBlock = 146,                         // 0 <Statement or Block>
		@Statements = 147,                               // 0 <Statements>
		@SubExpression = 148,                            // 0 <SubExpression>
		@UnaryChain = 149,                               // 0 <UnaryChain>
		@UnsetProc = 150,                                // 0 <UnsetProc>
		@ValidID = 151,                                  // 0 <Valid ID>
		@Value = 152,                                    // 0 <Value>
		@VariableStatements = 153                        // 0 <Variable Statements>
	}
}
