using System.Collections.Generic;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser;

namespace Prometheus.Storage
{
    /// <summary>
    /// Defines a memory space for an executing block. Variables
    /// declared in the block are disposed when the block finished.
    /// The cursor keeps a reference to the currently executing
    /// block/space.
    /// </summary>
    public class CursorSpace : StackSpace
    {
        /// <summary>
        /// The parser's cursor
        /// </summary>
        private Cursor _cursor;

        /// <summary>
        /// Constructor
        /// </summary>
        public CursorSpace(Cursor pCursor)
            : base(pCursor.Stack)
        {
            _cursor = pCursor;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public CursorSpace(Cursor pCursor, Dictionary<string, DataType> pStorage)
            : base(pCursor.Stack, pStorage)
        {
            _cursor = pCursor;
        }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        public override void Dispose()
        {
            _cursor.Stack = Parent;
            _cursor = null;
            base.Dispose();
        }
    }
}