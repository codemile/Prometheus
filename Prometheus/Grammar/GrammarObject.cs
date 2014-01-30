using System;
using Prometheus.Nodes;
using Prometheus.Objects;

namespace Prometheus.Grammar
{
	/// <summary>
	///
	/// </summary>
	public class GrammarObject
	{
		/// <summary>
		/// An array of executable Prometheus objects where 
		/// the index matches the enum for that statement.
		/// </summary>
		private readonly PrometheusObject[] _objects;

		/// <summary>
		/// Creates an instance of a statement class using a string.
		/// </summary>
		private PrometheusObject Create(string pName)
		{
		    Type type = Type.GetType(pName);
			return (type == null) ? null : (PrometheusObject)Activator.CreateInstance(type);
		}

		/// <summary>
		/// Constructor
		/// </summary>
		public GrammarObject()
		{
			_objects = new PrometheusObject[70];

			_objects[0] = Create(@"Prometheus.Objects.EOFObject");
			_objects[1] = Create(@"Prometheus.Objects.ErrorObject");
			_objects[2] = Create(@"Prometheus.Objects.CommentObject");
			_objects[3] = Create(@"Prometheus.Objects.NewLineObject");
			_objects[4] = Create(@"Prometheus.Objects.WhitespaceObject");
			_objects[5] = Create(@"Prometheus.Objects.TimesDivObject");
			_objects[6] = Create(@"Prometheus.Objects.DivTimesObject");
			_objects[7] = Create(@"Prometheus.Objects.DivDivObject");
			_objects[8] = Create(@"Prometheus.Objects.ExclamObject");
			_objects[9] = Create(@"Prometheus.Objects.ExclamEqObject");
			_objects[10] = Create(@"Prometheus.Objects.AmpAmpObject");
			_objects[11] = Create(@"Prometheus.Objects.LParenObject");
			_objects[12] = Create(@"Prometheus.Objects.RParenObject");
			_objects[13] = Create(@"Prometheus.Objects.TimesObject");
			_objects[14] = Create(@"Prometheus.Objects.PlusObject");
			_objects[15] = Create(@"Prometheus.Objects.MinusObject");
			_objects[16] = Create(@"Prometheus.Objects.DivObject");
			_objects[17] = Create(@"Prometheus.Objects.LtObject");
			_objects[18] = Create(@"Prometheus.Objects.LtEqObject");
			_objects[19] = Create(@"Prometheus.Objects.LtGtObject");
			_objects[20] = Create(@"Prometheus.Objects.EqObject");
			_objects[21] = Create(@"Prometheus.Objects.EqEqObject");
			_objects[22] = Create(@"Prometheus.Objects.GtObject");
			_objects[23] = Create(@"Prometheus.Objects.GtEqObject");
			_objects[24] = Create(@"Prometheus.Objects.acceptObject");
			_objects[25] = Create(@"Prometheus.Objects.andObject");
			_objects[26] = Create(@"Prometheus.Objects.BooleanObject");
			_objects[27] = Create(@"Prometheus.Objects.containsObject");
			_objects[28] = Create(@"Prometheus.Objects.elseObject");
			_objects[29] = Create(@"Prometheus.Objects.FloatObject");
			_objects[30] = Create(@"Prometheus.Objects.hasObject");
			_objects[31] = Create(@"Prometheus.Objects.IdentifierObject");
			_objects[32] = Create(@"Prometheus.Objects.ifObject");
			_objects[33] = Create(@"Prometheus.Objects.includeObject");
			_objects[34] = Create(@"Prometheus.Objects.IntegerObject");
			_objects[35] = Create(@"Prometheus.Objects.notObject");
			_objects[36] = Create(@"Prometheus.Objects.orObject");
			_objects[37] = Create(@"Prometheus.Objects.printObject");
			_objects[38] = Create(@"Prometheus.Objects.rejectObject");
			_objects[39] = Create(@"Prometheus.Objects.scopeObject");
			_objects[40] = Create(@"Prometheus.Objects.setObject");
			_objects[41] = Create(@"Prometheus.Objects.StringDoubleObject");
			_objects[42] = Create(@"Prometheus.Objects.StringSingleObject");
			_objects[43] = Create(@"Prometheus.Objects.unsetObject");
			_objects[44] = Create(@"Prometheus.Objects.LBraceObject");
			_objects[45] = Create(@"Prometheus.Objects.PipePipeObject");
			_objects[46] = Create(@"Prometheus.Objects.RBraceObject");
			_objects[47] = Create(@"Prometheus.Objects.TildeObject");
			_objects[48] = Create(@"Prometheus.Objects.AcceptCommandObject");
			_objects[49] = Create(@"Prometheus.Objects.AddExpressionObject");
			_objects[50] = Create(@"Prometheus.Objects.BlockObject");
			_objects[51] = Create(@"Prometheus.Objects.DivideExpressionObject");
			_objects[52] = Create(@"Prometheus.Objects.ExpressionObject");
			_objects[53] = Create(@"Prometheus.Objects.IfBlockObject");
			_objects[54] = Create(@"Prometheus.Objects.IfElseBlockObject");
			_objects[55] = Create(@"Prometheus.Objects.IncludeCommandObject");
			_objects[56] = Create(@"Prometheus.Objects.MultiplyExpressionObject");
			_objects[57] = Create(@"Prometheus.Objects.PrintCommandObject");
			_objects[58] = Create(@"Prometheus.Objects.ProgramObject");
			_objects[59] = Create(@"Prometheus.Objects.RejectCommandObject");
			_objects[60] = Create(@"Prometheus.Objects.ScopeCommandObject");
			_objects[61] = Create(@"Prometheus.Objects.SearchTermObject");
			_objects[62] = Create(@"Prometheus.Objects.SetCommandObject");
			_objects[63] = Create(@"Prometheus.Objects.StatementObject");
			_objects[64] = Create(@"Prometheus.Objects.StatementsObject");
			_objects[65] = Create(@"Prometheus.Objects.SubExpressionObject");
			_objects[66] = Create(@"Prometheus.Objects.UnaryOperatorObject");
			_objects[67] = Create(@"Prometheus.Objects.UnsetCommandObject");
			_objects[68] = Create(@"Prometheus.Objects.ValueObject");
			_objects[69] = Create(@"Prometheus.Objects.VariableObject");
		}

		/// <summary>
		/// Finds the object that can be executed as an expression.
		/// </summary>
	    public PrometheusObject getObject(Node pNode)
	    {
	        return _objects[(int)pNode.Type];
	    }
	}
}
