using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Prometheus.Nodes
{
    /// <summary>
    /// The Inflector class takes a string and can manipulate it to handle word
    /// variations such as pluralizations or camelizing and is normally accessed
    /// statically.
    /// <remarks>This class is a modified version of the Inflector class from CakePHP 2.x</remarks>
    /// </summary>
    public sealed class Inflector
    {
        /// <summary>
        /// Holds the singleton
        /// </summary>
        private static Inflector _single;

        /// <summary>
        /// A collection of word caches.
        /// </summary>
        private readonly Dictionary<string, Dictionary<string, string>> _cache;

        /// <summary>
        /// Plural inflector rules
        /// </summary>
        private readonly Dictionary<string, string> _plural;

        /// <summary>
        /// Plural expressions that should be ignored.
        /// </summary>
        private readonly List<string> _pluralExceptions;

        /// <summary>
        /// Singular inflector rules.
        /// </summary>
        private readonly Dictionary<string, string> _singular;

        /// <summary>
        /// Singular expressions that should be ignored.
        /// </summary>
        private readonly List<string> _singularExceptions;

        /// <summary>
        /// A list of words that should not be inflected.
        /// </summary>
        private readonly List<string> _uninflected;

        /// <summary>
        /// Checks if a word matches a list of exception rules.
        /// </summary>
        /// <param name="pExceptions">A list of regular expressions to check.</param>
        /// <param name="pWord">The word to check.</param>
        /// <returns>True if it has an exception.</returns>
        private static bool Exception(IEnumerable<string> pExceptions, string pWord)
        {
            return pExceptions.Any(pRule=>Regex.Match(pWord, pRule).Success);
        }

        /// <summary>
        /// Gets a reference to the Inflector object instance.
        /// </summary>
        /// <returns>Gets a reference to the Inflector object instance.</returns>
        private static Inflector Instance()
        {
            return _single ?? (_single = new Inflector());
        }

        /// <summary>
        /// Checks the list of rules for a match, and then returns the word modified by that rule.
        /// </summary>
        /// <param name="pRules">The list of rule to replacement pairs.</param>
        /// <param name="pWord">The word to modified.</param>
        /// <returns>The Word is not changed if no rules are matched.</returns>
        private static string Replace(Dictionary<string, string> pRules, string pWord)
        {
            foreach (KeyValuePair<string, string> rule in pRules)
            {
                if (!Regex.Match(pWord, rule.Key).Success)
                {
                    continue;
                }
                Regex r = new Regex(rule.Key);
                return r.Replace(pWord, rule.Value, 1);
            }

            return pWord;
        }

        /// <summary>
        /// Looks up the Word in the cache or returns Null if none found.
        /// </summary>
        /// <param name="pType">The name of the cache collection to search.</param>
        /// <param name="pWord">The word to lookup.</param>
        /// <returns>Word in the cache or returns Null if none found.</returns>
        private string Cached(string pType, string pWord)
        {
            lock (_cache)
            {
                if (!_cache.ContainsKey(pType))
                {
                    _cache.Add(pType, new Dictionary<string, string>());
                }

                if (pWord.Length > 0)
                {
                    return !_cache[pType].ContainsKey(pWord) ? null : _cache[pType][pWord];
                }
            }
            return "";
        }

        /// <summary>
        /// Converts a word from one form to another.
        /// </summary>
        /// <param name="pRules">Regular expression rules for converting words.</param>
        /// <param name="pExceptions">List of regular expressions of words to ignore.</param>
        /// <param name="pCache">A cache of word value pairs.</param>
        /// <param name="pWord">The word to convert.</param>
        /// <returns>The converted word.</returns>
        private string Inflect(Dictionary<string, string> pRules, IEnumerable<string> pExceptions, string pCache,
                               string pWord)
        {
            // check if this word has been cached
            string str = Cached(pCache, pWord);
            if (str != null)
            {
                return str;
            }

            if (Exception(pExceptions, pWord))
            {
                Remember(pCache, pWord, pWord);
                return pWord;
            }

            if (Exception(_uninflected, pWord))
            {
                Remember(pCache, pWord, pWord);
                return pWord;
            }

            str = Replace(pRules, pWord);

            Remember(pCache, pWord, str);
            return str;
        }

        /// <summary>
        /// Adds a word to the cache.
        /// </summary>
        /// <param name="pType">The name of the cache collection to search.</param>
        /// <param name="pWord">The word to remember.</param>
        /// <param name="pOther">The value to associated with that word.</param>
        private void Remember(string pType, string pWord, string pOther)
        {
            lock (_cache)
            {
                if (!_cache.ContainsKey(pType))
                {
                    _cache.Add(pType, new Dictionary<string, string>());
                }

                if (pWord.Length > 0 && !_cache[pType].ContainsKey(pWord))
                {
                    _cache[pType].Add(pWord, pOther);
                }
            }
        }

        /// <summary>
        /// Private constructor for singleton.
        /// </summary>
        private Inflector()
        {
            _plural = new Dictionary<string, string>();
            _pluralExceptions = new List<string>();

            _singular = new Dictionary<string, string>();
            _singularExceptions = new List<string>();

            _uninflected = new List<string>();

            _cache = new Dictionary<string, Dictionary<string, string>>();

            _plural.Add("(?i)(.*)uiz$", "$1uizzes");
            _plural.Add("(?i)(.*)([m|l])ouse$", "$1$2ice");
            _plural.Add("(?i)(.*)(matr|vert|ind)(ix|ex)$", "$1$2ices");
            _plural.Add("(?i)(.*)(x|ch|ss|sh|us)$", "$1$2es");
            _plural.Add("(?i)(.*)([^aeiouy]|qu)y$", "$1$2ies");
            _plural.Add("(?i)(.*)(hive)$", "$1$2s");
            _plural.Add("(?i)(.*)(?:([^f])fe|([lr])f)$", "$1$2$3ves");
            _plural.Add("(?i)(.*)sis$", "$1ses");
            _plural.Add("(?i)(.*)([ti])um$", "$1$2a");
            _plural.Add("(?i)(.*)(p)erson$", "$1$2eople");
            _plural.Add("(?i)(.*)(m)an$", "$1$2en");
            _plural.Add("(?i)(.*)(c)hild$", "$1$2hildren");
            _plural.Add("(?i)(.*)(buffal|tomat)o$", "$1$2oes");
            _plural.Add("(?i)(.*)(alumn|bacill|cact|foc|fung|nucle|radi|stimul|syllab|termin|vir)us$", "$1$2i");
            _plural.Add("(?i)(.*)us$", "$1uses");
            _plural.Add("(?i)(.*)(alias)$", "$1$2es");
            _plural.Add("(?i)(.*)(ax|cris|test)is$", "$1$2es");
            _plural.Add("(?i)(.*)s$", "$1s");
            _plural.Add("(?i)^$", "");
            _plural.Add("(?i)(.*)$", "$1s");

            _pluralExceptions.Add("(?i).*[nrlm]ese$");
            _pluralExceptions.Add("(?i).*deer$");
            _pluralExceptions.Add("(?i).*fish$");
            _pluralExceptions.Add("(?i).*measles$");
            _pluralExceptions.Add("(?i).*ois$");
            _pluralExceptions.Add("(?i).*pox$");
            _pluralExceptions.Add("(?i).*sheep$");
            _pluralExceptions.Add("(?i)people$");

            Remember("pluralized", "atlas", "atlases");
            Remember("pluralized", "beef", "beefs");
            Remember("pluralized", "brother", "brothers");
            Remember("pluralized", "cafe", "cafes");
            Remember("pluralized", "child", "children");
            Remember("pluralized", "corpus", "corpuses");
            Remember("pluralized", "cow", "cows");
            Remember("pluralized", "ganglion", "ganglions");
            Remember("pluralized", "genie", "genies");
            Remember("pluralized", "genus", "genera");
            Remember("pluralized", "graffito", "graffiti");
            Remember("pluralized", "hoof", "hoofs");
            Remember("pluralized", "loaf", "loaves");
            Remember("pluralized", "man", "men");
            Remember("pluralized", "money", "monies");
            Remember("pluralized", "mongoose", "mongooses");
            Remember("pluralized", "move", "moves");
            Remember("pluralized", "mythos", "mythoi");
            Remember("pluralized", "niche", "niches");
            Remember("pluralized", "numen", "numina");
            Remember("pluralized", "occiput", "occiputs");
            Remember("pluralized", "octopus", "octopuses");
            Remember("pluralized", "opus", "opuses");
            Remember("pluralized", "ox", "oxen");
            Remember("pluralized", "person", "people");
            Remember("pluralized", "sex", "sexes");
            Remember("pluralized", "soliloquy", "soliloquies");
            Remember("pluralized", "trilby", "trilbys");
            Remember("pluralized", "turf", "turfs");

            _singular.Add("(?i)(.*)(s)tatuses$", "$1$2tatus");
            _singular.Add("(?i)(.*)(menu)s$", "$1$2");
            _singular.Add("(?i)(.*)(quiz)zes$", "$1$2");
            _singular.Add("(?i)(.*)(matr)ices$", "$1$2ix");
            _singular.Add("(?i)(.*)(vert|ind)ices$", "$1$2ex");
            _singular.Add("(?i)(.*)(alias)(es)*$", "$1$2");
            _singular.Add("(?i)(.*)(alumn|bacill|cact|foc|fung|nucle|radi|stimul|syllab|termin|viri?)i$", "$1$2us");
            _singular.Add("(?i)(.*)([ftw]ax)es", "$1$2");
            _singular.Add("(?i)(.*)(cris|ax|test)es$", "$1$2is");
            _singular.Add("(?i)(.*)(shoe|slave)s$", "$1$2");
            _singular.Add("(?i)(.*)(o)es$", "$1$2");
            _singular.Add("(?i)(.*)ouses$", "$1ouse");
            _singular.Add("(?i)(.*)([^a])uses$", "$1$2us");
            _singular.Add("(?i)(.*)([m|l])ice$", "$1$2ouse");
            _singular.Add("(?i)(.*)(x|ch|ss|sh)es$", "$1$2");
            _singular.Add("(?i)(.*)(m)ovies$", "$1$2ovie");
            _singular.Add("(?i)(.*)(s)eries$", "$1$2eries");
            _singular.Add("(?i)(.*)([^aeiouy]|qu)ies$", "$1$2y");
            _singular.Add("(?i)(.*)([lr])ves$", "$1$2f");
            _singular.Add("(?i)(.*)(tive)s$", "$1$2");
            _singular.Add("(?i)(.*)(hive)s$", "$1$2");
            _singular.Add("(?i)(.*)(drive)s$", "$1$2");
            _singular.Add("(?i)(.*)([^fo])ves$", "$1$2fe");
            _singular.Add("(?i)(.*)(^analy)ses$", "$1$2sis");
            _singular.Add("(?i)(.*)(analy|diagno|^ba|(p)arenthe|(p)rogno|(s)ynop|(t)he)ses$", "$1$2sis");
            _singular.Add("(?i)(.*)([ti])a$", "$1$2um");
            _singular.Add("(?i)(.*)(p)eople$", "$1$2erson");
            _singular.Add("(?i)(.*)(m)en$", "$1$2an");
            _singular.Add("(?i)(.*)(c)hildren$", "$1$2hild");
            _singular.Add("(?i)(.*)(n)ews$", "$1$2ews");
            _singular.Add("(?i)(.*)eaus$", "$1eau");
            _singular.Add("(?i)^(.*)(us)$", "$1$2");
            _singular.Add("(?i)(.*)s$", "$1");

            _singularExceptions.Add("(?i).*[nrlm]ese$");
            _singularExceptions.Add("(?i).*deer$");
            _singularExceptions.Add("(?i).*fish$");
            _singularExceptions.Add("(?i).*measles$");
            _singularExceptions.Add("(?i).*ois$");
            _singularExceptions.Add("(?i).*pox$");
            _singularExceptions.Add("(?i).*sheep$");
            _singularExceptions.Add("(?i).*ss$");

            Remember("singularized", "foes", "foe");
            Remember("singularized", "waves", "wave");
            Remember("singularized", "curves", "curve");

            _uninflected.Add("(?i)Amoyese$");
            _uninflected.Add("(?i)bison$");
            _uninflected.Add("(?i)Borghese$");
            _uninflected.Add("(?i)bream$");
            _uninflected.Add("(?i)breeches$");
            _uninflected.Add("(?i)britches$");
            _uninflected.Add("(?i)buffalo$");
            _uninflected.Add("(?i)cantus$");
            _uninflected.Add("(?i)carp$");
            _uninflected.Add("(?i)chassis$");
            _uninflected.Add("(?i)clippers$");
            _uninflected.Add("(?i)cod$");
            _uninflected.Add("(?i)coitus$");
            _uninflected.Add("(?i)Congoese$");
            _uninflected.Add("(?i)contretemps$");
            _uninflected.Add("(?i)corps$");
            _uninflected.Add("(?i)debris$");
            _uninflected.Add("(?i)diabetes$");
            _uninflected.Add("(?i)djinn$");
            _uninflected.Add("(?i)eland$");
            _uninflected.Add("(?i)elk$");
            _uninflected.Add("(?i)equipment$");
            _uninflected.Add("(?i)Faroese$");
            _uninflected.Add("(?i)flounder$");
            _uninflected.Add("(?i)Foochowese$");
            _uninflected.Add("(?i)gallows$");
            _uninflected.Add("(?i)Genevese$");
            _uninflected.Add("(?i)Genoese$");
            _uninflected.Add("(?i)Gilbertese$");
            _uninflected.Add("(?i)graffiti$");
            _uninflected.Add("(?i)headquarters$");
            _uninflected.Add("(?i)herpes$");
            _uninflected.Add("(?i)hijinks$");
            _uninflected.Add("(?i)Hottentotese$");
            _uninflected.Add("(?i)information$");
            _uninflected.Add("(?i)innings$");
            _uninflected.Add("(?i)jackanapes$");
            _uninflected.Add("(?i)Kiplingese$");
            _uninflected.Add("(?i)Kongoese$");
            _uninflected.Add("(?i)Lucchese$");
            _uninflected.Add("(?i)mackerel$");
            _uninflected.Add("(?i)Maltese$");
            _uninflected.Add("(?i).*?media$");
            _uninflected.Add("(?i)mews$");
            _uninflected.Add("(?i)moose$");
            _uninflected.Add("(?i)mumps$");
            _uninflected.Add("(?i)Nankingese$");
            _uninflected.Add("(?i)news$");
            _uninflected.Add("(?i)nexus$");
            _uninflected.Add("(?i)Niasese$");
            _uninflected.Add("(?i)Pekingese$");
            _uninflected.Add("(?i)Piedmontese$");
            _uninflected.Add("(?i)pincers$");
            _uninflected.Add("(?i)Pistoiese$");
            _uninflected.Add("(?i)pliers$");
            _uninflected.Add("(?i)Portuguese$");
            _uninflected.Add("(?i)proceedings$");
            _uninflected.Add("(?i)rabies$");
            _uninflected.Add("(?i)rice$");
            _uninflected.Add("(?i)rhinoceros$");
            _uninflected.Add("(?i)salmon$");
            _uninflected.Add("(?i)Sarawakese$");
            _uninflected.Add("(?i)scissors$");
            _uninflected.Add("(?i)sea[- ]bass$");
            _uninflected.Add("(?i)series$");
            _uninflected.Add("(?i)Shavese$");
            _uninflected.Add("(?i)shears$");
            _uninflected.Add("(?i)siemens$");
            _uninflected.Add("(?i)species$");
            _uninflected.Add("(?i)swine$");
            _uninflected.Add("(?i)testes$");
            _uninflected.Add("(?i)trousers$");
            _uninflected.Add("(?i)trout$");
            _uninflected.Add("(?i)tuna$");
            _uninflected.Add("(?i)Vermontese$");
            _uninflected.Add("(?i)Wenchowese$");
            _uninflected.Add("(?i)whiting$");
            _uninflected.Add("(?i)wildebeest$");
            _uninflected.Add("(?i)Yengeese$");
        }

        /// <summary>
        /// Returns the given lower_case_and_underscored_word as a CamelCased word.
        /// </summary>
        /// <param name="pWord">Word to camelize</param>
        /// <returns>Camelized word. LikeThis.</returns>
        public static string Camelize(string pWord)
        {
            Inflector _this = Instance();
            string str;
            if ((str = _this.Cached("camelized", pWord)) != null)
            {
                return str;
            }
            str = Humanize(pWord);
            str = str.Replace(" ", "");
            _this.Remember("camelized", pWord, str);
            return str;
        }

        /// <summary>
        /// Returns Cake model class name ("Person" for the database table "people".) for given database table.
        /// </summary>
        /// <param name="pWord">Name of database table to get class name for,</param>
        /// <returns>Class name.</returns>
        public static string Classify(string pWord)
        {
            Inflector _this = Instance();
            string str;
            if ((str = _this.Cached("classify", pWord)) != null)
            {
                return str;
            }
            str = Camelize(Singularize(pWord));
            _this.Remember("classify", pWord, str);
            return str;
        }

        /// <summary>
        /// Returns the given underscored_word_group as a Human Readable Word Group.
        /// (Underscores are replaced by spaces and capitalized following words.)
        /// </summary>
        /// <param name="pWord">String to be made more readable</param>
        /// <returns>Human-readable string</returns>
        public static string Humanize(string pWord)
        {
            Inflector _this = Instance();
            String str;
            if ((str = _this.Cached("humanize", pWord)) != null)
            {
                return str;
            }
            StringBuilder sb = new StringBuilder();
            string[] words = pWord.Replace("_", " ").Split(new[] {' '});
            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0)
                {
                    sb.Append(" ");
                }
                if (words[i].Length <= 0)
                {
                    continue;
                }
                sb.Append(char.ToUpper(words[i][0]));
                if (words[i].Length > 1)
                {
                    sb.Append(words[i].Substring(1));
                }
            }
            str = sb.ToString();

            _this.Remember("humanize", pWord, str);
            return str;
        }

        /// <summary>
        /// Return pWord in plural form.
        /// </summary>
        /// <param name="pWord">The word in singular form.</param>
        /// <returns>Word in plural.</returns>
        public static string Pluralize(string pWord)
        {
            Inflector _this = Instance();
            return _this.Inflect(_this._plural, _this._pluralExceptions, "pluralized", pWord);
        }

        /// <summary>
        /// Return pWord in singular form.
        /// </summary>
        /// <param name="pWord">Word in plural</param>
        /// <returns>Word in singular</returns>
        public static string Singularize(string pWord)
        {
            Inflector _this = Instance();
            return _this.Inflect(_this._singular, _this._singularExceptions, "singularized", pWord);
        }

        /// <summary>
        /// Returns corresponding table name for given model $className. ("people" for the model class "Person").
        /// </summary>
        /// <param name="pWord">Name of class to get database table name for.</param>
        /// <returns>Name of the database table for given class.</returns>
        public static string Tableize(string pWord)
        {
            Inflector _this = Instance();
            string str;
            if ((str = _this.Cached("tablize", pWord)) != null)
            {
                return str;
            }
            str = Pluralize(Underscore(pWord));
            _this.Remember("tablize", pWord, str);
            return str;
        }

        /// <summary>
        /// Returns the given camelCasedWord as an underscored_word.
        /// </summary>
        /// <param name="pWord">Camel-cased word to be "underscored".</param>
        /// <returns>Underscore-syntaxes version of the word.</returns>
        public static string Underscore(string pWord)
        {
            Inflector _this = Instance();
            String str;
            if ((str = _this.Cached("underscore", pWord)) != null)
            {
                return str;
            }
            str = Regex.Replace(pWord, "(?<=\\w)([A-Z])", "_$1").ToLower();
            _this.Remember("underscore", pWord, str);
            return str;
        }

        /// <summary>
        /// Returns camelBacked version of an underscored string.
        /// </summary>
        /// <param name="pWord">The word to variables.</param>
        /// <returns>string in variable form</returns>
        public static string Variable(string pWord)
        {
            Inflector _this = Instance();
            string str;
            if ((str = _this.Cached("variable", pWord)) != null)
            {
                return str;
            }
            str = Camelize(Underscore(pWord));
            if (str.Length <= 0)
            {
                return str;
            }
            char[] s = str.ToCharArray();
            s[0] = char.ToLower(s[0]);
            _this.Remember("variable", pWord, new string(s));
            return str;
        }
    }
}