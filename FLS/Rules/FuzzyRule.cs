using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace FLS.Rules
{
	/// <summary>
	/// A Fuzzy Rule.
	/// </summary>
	public class FuzzyRule
	{
		#region Private Properties

		private double _value = 0;

		#endregion


		#region Public Properties

		/// <summary>
		/// The value of the rule's premise after the evaluation process.
		/// </summary>
		public double Value
		{
			get { return _value; }
			set { this._value = value; }
		}

		public Premise Premise { get; set; }

		public Conclusion Conclusion { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Determines if the current list of tokens is a valid rule.
		/// </summary>
		/// <returns>true if valid, false if invalid</returns>
		public Boolean IsValid()
		{
			var premiseIsNotNull = null != Premise;
			var conclusionIsNotNull = null != Conclusion;
			if (premiseIsNotNull && conclusionIsNotNull)
			{
				var premiseHasAtLeastOneCondition = 0 < Premise.Count;
				var premiseIsValid = Premise.All(c => null != c && null != c.Variable && null != c.Operator && null != c.MembershipFunction);
				var conclusionIsValid = null != Conclusion.Variable && null != Conclusion.Operator && null != Conclusion.MembershipFunction;
				return premiseHasAtLeastOneCondition && premiseIsValid && conclusionIsValid;
			}
			else
			{
				return false;
			}
		}

		#endregion

	}
}
