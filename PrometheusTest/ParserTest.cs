using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus;
using Prometheus.Tokens.Blocks;
using Prometheus.Tokens.Commands;

namespace PrometheusTest
{
    [TestClass]
    public class ParserTest : PrometheusTest
    {
        /// <summary>
        /// Test basic parsing of a block.
        /// </summary>
        [TestMethod]
        public void Test_Blocks()
        {
            Parser p = new Parser();
            Context context = createContextString("Hello World", "This is my document.");
            Program program = p.Parse(context, "test", "{ set mathew='abcdef'; }");

            Assert.IsNotNull(program);
            Console.Out.WriteLine(program);
        }

        /// <summary>
        /// Make sure the constructor loads the table without any errors.
        /// </summary>
        [TestMethod]
        public void Test_Loading_Table()
        {
            Parser p = new Parser();
        }

        /// <summary>
        /// A basic parse of set commands.
        /// </summary>
        [TestMethod]
        public void Test_Parse()
        {
            Parser p = new Parser();
            Context context = createContextString("Hello World", "This is my document.");
            Program program = p.Parse(context, "test", "set mathew='abcdef'; set john=mathew; set smith=john;");

            Assert.IsNotNull(program);
            Console.Out.WriteLine(program);

            Assert.AreEqual(3, program.Main.Count);

            foreach (Command cmd in program.Main)
            {
                Assert.IsNotNull(cmd);
                Assert.IsTrue(cmd is SetCommand);
                Console.Out.WriteLine(cmd);
            }

            Assert.AreEqual("mathew", ((SetCommand)program.Main[0]).Variable.Name);
            Assert.AreEqual("john", ((SetCommand)program.Main[1]).Variable.Name);
            Assert.AreEqual("smith", ((SetCommand)program.Main[2]).Variable.Name);
        }
    }
}