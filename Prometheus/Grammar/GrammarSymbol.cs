
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
		@RegExp = 52,                                    // 1 RegExp
		@REJECT = 53,                                    // 1 REJECT
		@RETURN = 54,                                    // 1 RETURN
		@SCOPE = 55,                                     // 1 SCOPE
		@STEP = 56,                                      // 1 STEP
		@StringDouble = 57,                              // 1 StringDouble
		@StringSingle = 58,                              // 1 StringSingle
		@TO = 59,                                        // 1 TO
		@UNSET = 60,                                     // 1 UNSET
		@UNTIL = 61,                                     // 1 UNTIL
		@VAR = 62,                                       // 1 VAR
		@VARS = 63,                                      // 1 VARS
		@WHILE = 64,                                     // 1 WHILE
		@LBracket = 65,                                  // 1 '['
		@RBracket = 66,                                  // 1 ']'
		@LBrace = 67,                                    // 1 '{'
		@PipePipe = 68,                                  // 1 '||'
		@RBrace = 69,                                    // 1 '}'
		@Tilde = 70,                                     // 1 '~'
		@AcceptProc = 71,                                // 0 <AcceptProc>
		@AddExpression = 72,                             // 0 <AddExpression>
		@AndOperator = 73,                               // 0 <AndOperator>
		@ArgumentList = 74,                              // 0 <Argument List>
		@Arguments = 75,                                 // 0 <Arguments>
		@ArrayList = 76,                                 // 0 <Array List>
		@ArrayLiteral = 77,                              // 0 <Array Literal>
		@Assignment = 78,                                // 0 <Assignment>
		@BaseClassID = 79,                               // 0 <BaseClass ID>
		@Block = 80,                                     // 0 <Block>
		@BlockorEnd = 81,                                // 0 <Block or End>
		@BooleanChain = 82,                              // 0 <BooleanChain>
		@BreakControl = 83,                              // 0 <BreakControl>
		@CallExpression = 84,                            // 0 <Call Expression>
		@CallInternal = 85,                              // 0 <CallInternal>
		@ClassNameID = 86,                               // 0 <ClassName ID>
		@ConstructParamsList = 87,                       // 0 <ConstructParams List>
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
		@FormalParameterList = 101,                      // 0 <Formal Parameter List>
		@FormalParameters = 102,                         // 0 <Formal Parameters>
		@ForStepControl = 103,                           // 0 <ForStepControl>
		@FunctionExpression = 104,                       // 0 <Function Expression>
		@GteOperator = 105,                              // 0 <GteOperator>
		@GtOperator = 106,                               // 0 <GtOperator>
		@IfControl = 107,                                // 0 <IfControl>
		@IncludeProc = 108,                              // 0 <IncludeProc>
		@Increment = 109,                                // 0 <Increment>
		@ListObjects = 110,                              // 0 <ListObjects>
		@ListVars = 111,                                 // 0 <ListVars>
		@LoopUntilControl = 112,                         // 0 <LoopUntilControl>
		@LoopWhileControl = 113,                         // 0 <LoopWhileControl>
		@LteOperator = 114,                              // 0 <LteOperator>
		@LtOperator = 115,                               // 0 <LtOperator>
		@MathChain = 116,                                // 0 <MathChain>
		@MemberList = 117,                               // 0 <Member List>
		@MultiplyExpression = 118,                       // 0 <MultiplyExpression>
		@NewExpression = 119,                            // 0 <New Expression>
		@NotEqualOperator = 120,                         // 0 <NotEqualOperator>
		@ObjectDecl = 121,                               // 0 <Object Decl>
		@ObjectDecls = 122,                              // 0 <Object Decls>
		@OrOperator = 123,                               // 0 <OrOperator>
		@PrintProc = 124,                                // 0 <PrintProc>
		@Procedure = 125,                                // 0 <Procedure>
		@Program = 126,                                  // 0 <Program>
		@QualifiedID = 127,                              // 0 <Qualified ID>
		@RejectProc = 128,                               // 0 <RejectProc>
		@ReturnProc = 129,                               // 0 <ReturnProc>
		@ScopeProc = 130,                                // 0 <ScopeProc>
		@SearchChain = 131,                              // 0 <SearchChain>
		@Statement = 132,                                // 0 <Statement>
		@StatementorBlock = 133,                         // 0 <Statement or Block>
		@Statements = 134,                               // 0 <Statements>
		@SubExpression = 135,                            // 0 <SubExpression>
		@UnaryOperator = 136,                            // 0 <UnaryOperator>
		@UnsetProc = 137,                                // 0 <UnsetProc>
		@ValidID = 138,                                  // 0 <Valid ID>
		@Value = 139,                                    // 0 <Value>
		@VariableStatements = 140                        // 0 <Variable Statements>
	}
}
