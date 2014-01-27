using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prometheus;
using Prometheus.Tokens;
using Prometheus.Tokens.Blocks;
using Prometheus.Tokens.Commands;

namespace PrometheusTest
{
    /// <summary>
    /// Base class used by tests.
    /// </summary>
    public abstract class PrometheusTest
    {
        /// <summary>
        /// Resource reader
        /// </summary>
        private Resources _resources;

        /// <summary>
        /// Constructor
        /// </summary>
        protected PrometheusTest()
        {
            _resources = new Resources(GetType(), "Data");
        }

        /// <summary>
        /// Creates a fragmented document from a string
        /// </summary>
        protected static Context CreateContextString(string pTitle, string pBody)
        {
/*
            DocumentFragmentWriter writer = new DocumentFragmentWriter(pTitle);

            HtmlConverter converter = new HtmlConverter();
            HtmlConverter.Convert(new List<iDocumentWriter> {writer}, pBody);

            iDocument doc = new DocumentReader(writer.Document);
            Assert.IsTrue(doc.getFragments(Fragment.BODY, DocumentCursor.None).Length > 0);

            return new Context(doc);
*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// Creates a ready to execute program from the source code.
        /// </summary>
        protected static Program CreateProgram(Context pContext, string pCode)
        {
            Compiler p = new Compiler();
            Program program = p.Parse(pContext, "test", pCode);
            Assert.IsNotNull(program);
            Assert.AreEqual(1, program.Main.Count);
            Assert.IsTrue(program.Main.Count > 0);

            return program;
        }

        /// <summary>
        /// Uses the parser to create a AddRef.
        /// </summary>
        protected static T CreateRef<T>(string pValue) where T : Token
        {
            Compiler p = new Compiler();
            Context context = CreateContextString("Hello World", "This is my document.");
            Program program = p.Parse(context, "test", string.Format("set Mathew = {0};", pValue));
            Assert.IsNotNull(program);
            Assert.AreEqual(1, program.Main.Count);

            //Console.Out.WriteLine(program);

            SetCommand cmd = program.Main[0] as SetCommand;
            Assert.IsNotNull(cmd);

            T value = cmd.Expression as T;
            Assert.IsNotNull(value);

            return value;
        }

        /// <summary>
        /// Creates a fragmented document to use in the context.
        /// </summary>
        protected Context CreateContext(string pTitle, string pResourceName)
        {
/*
            DocumentFragmentWriter writer = new DocumentFragmentWriter(pTitle);
            string html = _resources.ReadAsString(pResourceName);

            HtmlConverter converter = new HtmlConverter();
            HtmlConverter.Convert(new List<iDocumentWriter> {writer}, html);

            iDocument doc = new DocumentReader(writer.Document);
            Assert.IsTrue(doc.getFragments(Fragment.BODY, DocumentCursor.None).Length > 0);

            return new Context(doc);
*/
            throw new NotImplementedException();
        }
    }
}