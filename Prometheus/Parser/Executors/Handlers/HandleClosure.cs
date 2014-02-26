using System.Collections.Generic;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;

namespace Prometheus.Parser.Executors.Handlers
{
    /// <summary>
    /// Handles the creation of a closure function, or creates a closure object from a child node to
    /// prevent that node from being executed.
    /// For example; when creating a declaration the constructor function is turned into a closure to
    /// prevent it from being executed from the declaration is parsed.
    /// </summary>
    public class HandleClosure : ExecutorHandler
    {
        /// <summary>
        /// Declaration types that contain an executable block of code (like a function or object constructor). The block
        /// of code is parented to a new node of the value type. This allows that block of code to be stored, and not executed
        /// by the parser until the declaration is used.
        /// </summary>
        private static readonly Dictionary<GrammarSymbol, GrammarSymbol> _declarations =
            new Dictionary
                <GrammarSymbol, GrammarSymbol>();

        private static readonly HashSet<GrammarSymbol> _nodeTypes = new HashSet<GrammarSymbol>
                                                                    {
                                                                        GrammarSymbol.ForDeclare,
                                                                        GrammarSymbol.ForExpression,
                                                                        GrammarSymbol.ForStep,
                                                                        GrammarSymbol.WhileExpression


                                                                        //GrammarSymbol.ObjectBlock,
                                                                        //GrammarSymbol.FunctionExpression
                                                                    };

        /// <summary>
        /// Constructor
        /// </summary>
        public HandleClosure(iExecutor pExecutor)
            : base(pExecutor, _nodeTypes)
        {
        }

        /// <summary>
        /// Handle execution of a node.
        /// </summary>
        public override DataType Handle(Node pNode)
        {
            return pNode.Children.Count == 0
                ? new FunctionType(HandleStatements.Create(pNode))
                : new FunctionType(pNode.FirstChild());
/*

            if (pNode.Type != GrammarSymbol.FunctionExpression
                || pNode.Children.Count == 1)
            {
                return new FunctionType(pNode.FirstChild());
            }

            ArrayType arguments = Executor.WalkDownChildren(pNode.Children[0]).Cast<ArrayType>();
            Node func = pNode.Children[1];

            return new FunctionType(func, arguments);
*/
        }

        /// <summary>
        /// Creates declaration types.
        /// </summary>
/*
        public override bool OptimizeChild(Node pParent, Node pChild1)
        {
            // TODO: FunctionBlock is no longer required.
            if (pChild1.Type != GrammarSymbol.FunctionDecl 
                || pChild1.Children.Count == 0)
            {
                return false;
            }

            Node paramArray = pChild1.Children[0];
            if (paramArray.Children.Any(pChild=>pChild.Type != GrammarSymbol.ParameterName))
            {
                return false;
            }

            IEnumerable<IdentifierType> parameters = from name in paramArray.Children
                                                     select name.FirstData().Cast<IdentifierType>();
            Node func = pChild1.Children[1];

            FunctionType funcType = new FunctionType(func, parameters);
            pChild1.Children.Clear();
            pChild1.Data.Add(funcType);

            return true;
        }
*/

/*
        public override bool OptimizeNode(Node pNode)
        {
            if (!_declarations.ContainsKey(pNode.Type) 
                || pNode.HasChild(_declarations[pNode.Type]))
            {
                return false;
            }

            Node block = pNode.FindChild(GrammarSymbol.Block);
            pNode.Children.Remove(block);
            pNode.Children.Add(new Node(_declarations[pNode.Type], block.Location, new[] { block }));

            return true;
        }
*/
    }
}