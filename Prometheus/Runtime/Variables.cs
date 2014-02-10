using System;
using Prometheus.Exceptions.Executor;
using Prometheus.Grammar;
using Prometheus.Nodes;
using Prometheus.Nodes.Types;
using Prometheus.Nodes.Types.Bases;
using Prometheus.Parser.Executors;
using Prometheus.Parser.Executors.Attributes;
using Prometheus.Storage;

namespace Prometheus.Runtime
{
    /// <summary>
    /// Handles symbols related to variable management
    /// </summary>
    public class Variables : ExecutorGrammar
    {
        /// <summary>
        /// Will convert a function expression into a closure function with a reference
        /// to the current "this" object.
        /// </summary>
        private ClosureType CreateClosure(Node pFunc)
        {
            if (pFunc.Type != GrammarSymbol.FunctionExpression)
            {
                throw new UnexpectedErrorException("Was expecting node for closure");
            }
            AliasType aThis = (AliasType)Executor.Cursor.Stack.Get("this");
            ClosureType closureType = new ClosureType(aThis, pFunc);
            return closureType;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Variables(Executor pExecutor)
            : base(pExecutor)
        {
        }

        /// <summary>
        /// Assigns a value to an Identifier
        /// </summary>
        /// <param name="pQualifiedType">The variable name</param>
        /// <param name="pDataType">The value to assign</param>
        [ExecuteSymbol(GrammarSymbol.Assignment)]
        public iDataType Assignment(QualifiedType pQualifiedType, iDataType pDataType)
        {
/*
            pFunc = CreateClosure(pFunc);
            Executor.Cursor.Set(pQualified, pFunc);
            return pFunc;
*/
            throw new NotImplementedException();
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Decrement)]
        public iDataType Dec(QualifiedType pQualifiedType)
        {
            string member = pQualifiedType.Parts[pQualifiedType.Parts.Length - 1];
            MemorySpace memory = Executor.Cursor.Resolve(pQualifiedType);
            iDataType d = memory.Get(member);
            d = d is FloatType
                ? (iDataType)new FloatType(((FloatType)d).Value - 1)
                : new IntegerType(((IntegerType)d).Value - 1);
            memory.Set(member, d);
            return d;
        }

        /// <summary>
        /// Declares a variable with a value
        /// </summary>
        /// <param name="pIdentifierType">Name of the variable</param>
        /// <param name="pValue">The value</param>
        /// <returns>The value assigned</returns>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public void Declare(IdentifierType pIdentifierType, iDataType pValue)
        {
            throw new NotImplementedException();
/*
            pValue = CreateClosure(pValue);
            Executor.Cursor.Stack.Create(pIdentifier.Name, pValue);
*/
        }

        /// <summary>
        /// Declares a variable without a value
        /// </summary>
        /// <param name="pIdentifierType">Name of the variable</param>
        /// <returns>The value assigned</returns>
        [ExecuteSymbol(GrammarSymbol.Declare)]
        public void Declare(IdentifierType pIdentifierType)
        {
            Declare(pIdentifierType, UndefinedType.UNDEFINED);
        }

        /// <summary>
        /// Increment
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Increment)]
        public iDataType Inc(QualifiedType pQualifiedType)
        {
            string member = pQualifiedType.Parts[pQualifiedType.Parts.Length - 1];
            MemorySpace memory = Executor.Cursor.Resolve(pQualifiedType);
            iDataType d = memory.Get(member);
            d = d is FloatType
                ? (iDataType)new FloatType(((FloatType)d).Value + 1)
                : new IntegerType(((IntegerType)d).Value + 1);
            memory.Set(member, d);
            return d;
        }

        /// <summary>
        /// Decrement
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.ListVars)]
        public void ListVars()
        {
            Executor.Cursor.Stack.Print();
        }

        /// <summary>
        /// Returns the value of a variable.
        /// </summary>
        /// <param name="pQualifier">The variable name</param>
        /// <returns>The value or undefined.</returns>
        [ExecuteSymbol(GrammarSymbol.QualifiedID)]
        public iDataType Qualified(QualifiedType pQualifier)
        {
            return Executor.Cursor.Get(pQualifier);
        }

        /// <summary>
        /// Returns the value of data stored in the source code.
        /// </summary>
        [ExecuteSymbol(GrammarSymbol.Value)]
        public iDataType Value(iDataType pValue)
        {
            return pValue;
        }
    }
}