using FLS.MembershipFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.Rules
{
	public class FuzzyRuleClause
	{
		public FuzzyRuleClause(LinguisticVariable variable, IFuzzyRuleToken @operator, IMembershipFunction function)
		{
			Variable = variable;
			Operator = @operator;
			MembershipFunction = function;
		}

		public LinguisticVariable Variable { get; set; }
		public IFuzzyRuleToken Operator { get; set; }
		public IMembershipFunction MembershipFunction { get; set; }
	}
}
