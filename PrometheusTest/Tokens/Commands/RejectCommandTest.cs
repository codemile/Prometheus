using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus;
using Prometheus.Tokens.Blocks;

namespace PrometheusTest.Tokens.Commands
{
    [TestClass]
    public class RejectCommandTest : BaseCommandTest
    {
        [TestMethod]
        public void Test_Always()
        {
            Context context = CreateContext("Hello World", "Html.FeedItem.html");
            Program prog = CreateProgram(context, "reject always;");
            prog.Run();
            Assert.AreEqual(Context.StatusType.REJECTED, context.Status);
        }

        [TestMethod]
        public void Test_Contains()
        {
            Context context = CreateContext("Hello World", "Html.FeedItem.html");
            Program prog = CreateProgram(context, "reject contains 'stock price hit a five-year high';");
            prog.Run();

            Assert.AreEqual(Context.StatusType.REJECTED, context.Status);
        }

        [TestMethod]
        public void Test_Has()
        {
            Context context = CreateContext("Hello World", "Html.FeedItem.html");
            Program prog = CreateProgram(context, "reject has 'stock price hit a five-year high';");
            prog.Run();

            Assert.AreEqual(Context.StatusType.REJECTED, context.Status);
        }

        [TestMethod]
        public void Test_Not_Found()
        {
            Context context = CreateContext("Hello World", "Html.FeedItem.html");
            Program prog = CreateProgram(context, "accept has 'mickey mouse';");
            prog.Run();

            Assert.AreEqual(Context.StatusType.NONE, context.Status);
        }
    }
}