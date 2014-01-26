using System;
using System.Collections.Generic;
using Markdown.Documents;

namespace Prometheus
{
    /// <summary>
    /// Defines the state of the current program.
    /// </summary>
    public class Context
    {
        /// <summary>
        /// The statuses for allowing the rule.
        /// </summary>
        public enum StatusType
        {
            NONE,
            ACCEPTED,
            REJECTED,
            ERROR
        }

        /// <summary>
        /// A list of fragments to search.
        /// </summary>
        private readonly List<string> _scope;

        /// <summary>
        /// A cache of the current fragments by scope.
        /// </summary>
        private List<Fragment> _fragments;

        /// <summary>
        /// The last known exception.
        /// </summary>
        public Exception LastError { get; set; }

        /// <summary>
        /// The current status.
        /// </summary>
        public StatusType Status { get; set; }

        /// <summary>
        /// The current document.
        /// </summary>
        private iDocument _document { get; set; }

        /// <summary>
        /// Adds a fragment type to the scope of the current search.
        /// </summary>
        private void AddScope(string pFragmentType)
        {
            _scope.Add(pFragmentType);
            _fragments = null;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Context(iDocument pDocument)
        {
            _scope = new List<string>();
            _document = pDocument;
            _fragments = null;
            Status = StatusType.NONE;

            // define default scope
            AddScope("title");
            AddScope("body");
        }

        /// <summary>
        /// Clears all fragment types from the current scope.
        /// If there are not types for the current scope, then nothing
        /// will match.
        /// </summary>
        public void ClearScope()
        {
            _scope.Clear();
            _fragments = null;
        }

        /// <summary>
        /// Removes a fragment type from the current scope.
        /// </summary>
        public void RemoveScope(string pFragmentType)
        {
            _scope.Remove(pFragmentType);
            _fragments = null;
        }

        /// <summary>
        /// Returns a list of fragments for the current scope.
        /// </summary>
        public IEnumerable<Fragment> getFragments(DocumentCursor pCursor)
        {
            if (_fragments == null)
            {
                _fragments = new List<Fragment>();
                foreach (string scope in _scope)
                {
                    _fragments.AddRange(_document.getFragments(scope, pCursor));
                }
            }
            return _fragments;
        }
    }
}