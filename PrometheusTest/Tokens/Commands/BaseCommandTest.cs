namespace PrometheusTest.Tokens.Commands
{
    /// <summary>
    /// A base class for testing commands.
    /// </summary>
    public abstract class BaseCommandTest : PrometheusTest
    {
        /// <summary>
        /// Creates a one line program and returns the first statement.
        /// </summary>
        //public T CreateCommand<T>(string pCode) where T : AggCommand
        //{
        //    Parser p = new Parser();
        //    AggProgram program = p.Parse("test", pCode);
        //    Assert.IsNotNull(program);
        //    Assert.AreEqual(1, program.Main.Count);

        //    T cmd = program.Main[0] as T;
        //    Assert.IsNotNull(cmd);

        //    return cmd;
        //}
    }
}