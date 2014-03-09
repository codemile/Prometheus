using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Prometheus.Exceptions.Executor;
using Prometheus.Nodes.Types.Attributes;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Nodes.Types
{
    /// <summary>
    /// Boxes string values
    /// </summary>
    [DataTypeInfo("String")]
    [DataTypeInfo("RegEx")]
    public class StringType : DataType, iSearchNeedle, iSearchHaystack
    {
        /// <summary>
        /// Compile flags
        /// </summary>
        [Flags]
        public enum eFLAGS
        {
            /// <summary>
            /// No flags
            /// </summary>
            NONE = 0,

            /// <summary>
            /// Ignore text case
            /// </summary>
            IGNORE_CASE = 1 << 0,

            /// <summary>
            /// Except to term change so don't cache
            /// </summary>
            NO_CACHING = 1 << 1,

            /// <summary>
            /// Only match first position
            /// </summary>
            MATCH_FIRST = 1 << 2
        }

        /// <summary>
        /// The matching mode
        /// </summary>
        public enum eMODE
        {
            /// <summary>
            /// Anywhere in the haystack
            /// </summary>
            ANYWHERE,

            /// <summary>
            /// Between word boundaries only
            /// </summary>
            WORD_BOUNDARIES
        }

        /// <summary>
        /// The matching flags
        /// </summary>
        public readonly eFLAGS Flags;

        /// <summary>
        /// Handle this string as a regex
        /// </summary>
        public readonly bool IsRegex;

        /// <summary>
        /// The matching mode
        /// </summary>
        public readonly eMODE Mode;

        /// <summary>
        /// String value
        /// </summary>
        public readonly string Value;

        /// <summary>
        /// The compiled version of this string as a search term.
        /// </summary>
        private Regex _regex;

        /// <summary>
        /// True if ignoring case.
        /// </summary>
        public bool IgnoreCase
        {
            get { return Flags.HasFlag(eFLAGS.IGNORE_CASE); }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StringType(string pValue)
        {
            Value = pValue;
            Mode = eMODE.ANYWHERE;
            Flags = 0;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public StringType(bool pIsRegex, string pValue, eMODE pMode, eFLAGS pFlags)
        {
            IsRegex = pIsRegex;
            Value = pValue;
            Mode = pMode;
            Flags = pFlags;
        }

        /// <summary>
        /// Concat constructor
        /// </summary>
        /// <param name="pValue1">Left value</param>
        /// <param name="pValue2">Right value</param>
        public StringType(StringType pValue1, StringType pValue2)
        {
            if (pValue1.Mode != pValue2.Mode)
            {
                throw new DataTypeException(string.Format("Cannot concatenate strings of different boundaries."));
            }

            Value = pValue1.Value + pValue2.Value;
            Mode = pValue1.Mode;
            Flags = pValue1.Flags & pValue2.Flags;
        }

        /// <summary>
        /// Does this haystack contain the needle
        /// </summary>
        /// <param name="pNeedle">The needle to find</param>
        /// <returns>True</returns>
        public bool Contains(iSearchNeedle pNeedle)
        {
            return pNeedle.isFound(Value);
        }

        /// <summary>
        /// Is this term found in the haystack
        /// </summary>
        /// <param name="pHaystack">The string to search</param>
        /// <returns>True if found</returns>
        public bool isFound(string pHaystack)
        {
            if (_regex != null)
            {
                return _regex.IsMatch(pHaystack);
            }

            if (Mode == eMODE.ANYWHERE && !IsRegex)
            {
                StringComparison c = (Flags & eFLAGS.IGNORE_CASE) == eFLAGS.IGNORE_CASE
                    ? StringComparison.CurrentCultureIgnoreCase
                    : StringComparison.CurrentCulture;
                return pHaystack.IndexOf(Value, c) >= 0;
            }

            string str = ((Flags & eFLAGS.IGNORE_CASE) == eFLAGS.IGNORE_CASE ? "(?is)" : "(?s)");

            if (Mode == eMODE.WORD_BOUNDARIES)
            {
                str += RegexFactory.WordBoundaries(Value);
            }
            else
            {
                str += Value;
            }

            _regex = new Regex(str);

            return _regex.IsMatch(pHaystack);
        }

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            string quotes;
            if (IsRegex)
            {
                quotes = (Mode == eMODE.ANYWHERE) ? "/" : "|";
            }
            else
            {
                quotes = (Mode == eMODE.ANYWHERE) ? "\"" : "'";
            }
            string flags = Flags.HasFlag(eFLAGS.IGNORE_CASE) ? "i" : "";
            flags += Flags.HasFlag(eFLAGS.NO_CACHING) ? "c" : "";
            flags += Flags.HasFlag(eFLAGS.MATCH_FIRST) ? "f" : "";
            return string.Format("{0}{1}{0}{2}", quotes, Value, flags);
        }

        /// <summary>
        /// Compiles this string to a regex.
        /// </summary>
        public Regex Compile()
        {
            if (_regex != null)
            {
                return _regex;
            }

            string str = ((Flags & eFLAGS.IGNORE_CASE) == eFLAGS.IGNORE_CASE ? "(?is)" : "(?s)");
            string term = IsRegex ? Value : Regex.Escape(Value);

            if (Mode == eMODE.WORD_BOUNDARIES)
            {
                str += RegexFactory.WordBoundaries(term);
            }
            else
            {
                str += term;
            }

            _regex = new Regex(str);
            return _regex;
        }

        /// <summary>
        /// The different possible types for this data type.
        /// </summary>
        public override IEnumerable<string> GetTypes()
        {
            return IsRegex
                ? new[] {"regex", "string"}
                : new[] {"string"};
        }
    }
}