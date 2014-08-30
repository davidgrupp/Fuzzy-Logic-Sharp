using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FLS.Rules;
using FLS.MembershipFunctions;

namespace FLS
{
	/// <summary>
	/// A linguistic variable.
	/// </summary>
	public class LinguisticVariable : FuzzyRuleToken
	{
		#region Private Properties

		private MembershipFunctionCollection _membershipFunctions;
		private Double _inputValue = 0;

		#endregion

		#region Constructors

		public LinguisticVariable(string name)
			: base(name, FuzzyRuleTokenType.Variable)
		{
			_membershipFunctions = new MembershipFunctionCollection();
		}

		#endregion

		#region Public Properties

		/// <summary>
		/// A collection of the variable's membership functions.
		/// </summary>
		public MembershipFunctionCollection MembershipFunctions
		{
			get { return _membershipFunctions; }
			set { _membershipFunctions = value; }
		}

		public double InputValue
		{
			get { return _inputValue; }
			set { _inputValue = value; }
		}

		#endregion

	}
}
