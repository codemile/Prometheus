
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
		@OBJECTS = 50,                                   // 1 OBJECTS
		@OR = 51,                                        // 1 OR
		@PRINT = 52,                                     // 1 PRINT
		@RegExpPipe = 53,                                // 1 RegExpPipe
		@RegExpSlash = 54,                               // 1 RegExpSlash
		@REJECT = 55,                                    // 1 REJECT
		@RETURN = 56,                                    // 1 RETURN
		@SCOPE = 57,                                     // 1 SCOPE
		@STEP = 58,                                      // 1 STEP
		@StringDouble = 59,                              // 1 StringDouble
		@StringSingle = 60,                              // 1 StringSingle
		@TO = 61,                                        // 1 TO
		@UNSET = 62,                                     // 1 UNSET
		@UNTIL = 63,                                     // 1 UNTIL
		@VAR = 64,                                       // 1 VAR
		@VARS = 65,                                      // 1 VARS
		@WHILE = 66,                                     // 1 WHILE
		@LBracket = 67,                                  // 1 '['
		@RBracket = 68,                                  // 1 ']'
		@LBrace = 69,                                    // 1 '{'
		@PipePipe = 70,                                  // 1 '||'
		@RBrace = 71,                                    // 1 '}'
		@Tilde = 72,                                     // 1 '~'
		@AcceptProc = 73,                                // 0 <AcceptProc>
		@AddExpression = 74,                             // 0 <AddExpression>
		@AndOperator = 75,                               // 0 <AndOperator>
		@ArgumentList = 76,                              // 0 <Argument List>
		@Arguments = 77,                                 // 0 <Arguments>
		@ArrayIndexList = 78,                            // 0 <Array Index List>
		@ArrayList = 79,                                 // 0 <Array List>
		@ArrayLiteral = 80,                              // 0 <Array Literal>
		@ArrayOperator = 81,                             // 0 <ArrayOperator>
		@Assignment = 82,                                // 0 <Assignment>
		@BaseClassID = 83,                               // 0 <BaseClass ID>
		@BitInvertOperator = 84,                         // 0 <BitInvertOperator>
		@Block = 85,                                     // 0 <Block>
		@BlockorEnd = 86,                                // 0 <Block or End>
		@BooleanChain = 87,                              // 0 <BooleanChain>
		@BreakControl = 88,                              // 0 <BreakControl>
		@CallExpression = 89,                            // 0 <Call Expression>
		@CallInternal = 90,                              // 0 <CallInternal>
		@ClassNameID = 91,                               // 0 <ClassName ID>
		@ContainsTerm = 92,                              // 0 <ContainsTerm>
		@ContinueControl = 93,                           // 0 <ContinueControl>
		@Declare = 94,                                   // 0 <Declare>
		@Decrement = 95,                                 // 0 <Decrement>
		@DivideExpression = 96,                          // 0 <DivideExpression>
		@DoUntilControl = 97,                            // 0 <DoUntilControl>
		@DoWhileControl = 98,                            // 0 <DoWhileControl>
		@End = 99,                                       // 0 <End>
		@EndOpt = 100,                                   // 0 <End Opt>
		@EqualOperator = 101,                            // 0 <EqualOperator>
		@Expression = 102,                               // 0 <Expression>
		@FlowControl = 103,                              // 0 <FlowControl>
		@ForControl = 104,                               // 0 <ForControl>
		@ForStepControl = 105,                           // 0 <ForStepControl>
		@FunctionExpression = 106,                       // 0 <Function Expression>
		@GteOperator = 107,                              // 0 <GteOperator>
		@GtOperator = 108,                               // 0 <GtOperator>
		@IfControl = 109,                                // 0 <IfControl>
		@IncludeProc = 110,                              // 0 <IncludeProc>
		@Increment = 111,                                // 0 <Increment>
		@ListObjects = 112,                              // 0 <ListObjects>
		@ListVars = 113,                                 // 0 <ListVars>
		@LoopUntilControl = 114,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 115,                         // 0 <LoopWhileControl>
		@LteOperator = 116,                              // 0 <LteOperator>
		@LtOperator = 117,                               // 0 <LtOperator>
		@MathChain = 118,                                // 0 <MathChain>
		@MemberList = 119,                               // 0 <Member List>
		@MultiplyExpression = 120,                       // 0 <MultiplyExpression>
		@NegOperator = 121,                              // 0 <NegOperator>
		@NewExpression = 122,                            // 0 <New Expression>
		@NotEqualOperator = 123,                         // 0 <NotEqualOperator>
		@NotOperator = 124,                              // 0 <NotOperator>
		@ObjectDecl = 125,                               // 0 <Object Decl>
		@ObjectDecls = 126,                              // 0 <Object Decls>
		@OrOperator = 127,                               // 0 <OrOperator>
		@ParameterList = 128,                            // 0 <Parameter List>
		@ParameterName = 129,                            // 0 <Parameter Name>
		@Parameters = 130,                               // 0 <Parameters>
		@PlusOperator = 131,                             // 0 <PlusOperator>
		@PostDecOperator = 132,                          // 0 <PostDecOperator>
		@PostIncOperator = 133,                          // 0 <PostIncOperator>
		@PreDecOperator = 134,                           // 0 <PreDecOperator>
		@PreIncOperator = 135,                           // 0 <PreIncOperator>
		@PrintProc = 136,                                // 0 <PrintProc>
		@Procedure = 137,                                // 0 <Procedure>
		@Program = 138,                                  // 0 <Program>
		@QualifiedID = 139,                              // 0 <Qualified ID>
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
