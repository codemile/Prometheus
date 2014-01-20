using Markdown.Documents;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PrometheusTest.Tokens.Documents
{
    [TestClass]
    public class DocumentFactoryTest : BaseDocumentTest
    {
        [TestMethod]
        public void Clear_Empty()
        {
            Assert.AreEqual("", DocumentFactory.Clean("       "));
            Assert.AreEqual("", DocumentFactory.Clean("\t\t\t\t"));
            Assert.AreEqual("", DocumentFactory.Clean("\r\r\n\n"));
            Assert.AreEqual("", DocumentFactory.Clean("   \t  \t  \r\n  \t \t  \r"));
        }

        [TestMethod]
        public void Clear_Simple()
        {
            string[] worlds =
            {
                "Hello World",
                " Hello World ",
                "   Hello   World   ",
                "\t\tHello\tWorld\t\t",
                "\t \t\t \tHello\t\t \tWorld\t\t",
                "Hello\r\nWorld",
                "\r\nHello  \r\nWorld",
                "\tHello\r\n\tWorld\r\n"
            };

            foreach (string hello in worlds)
            {
                string clean = DocumentFactory.Clean(hello);
                Assert.AreEqual("Hello World", clean, string.Format("[{0}]", hello));
            }
        }
    }
}