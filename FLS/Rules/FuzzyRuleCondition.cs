using FLS.MembershipFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.Rules
{
	public class FuzzyRuleCondition : FuzzyRuleClause
	{
		public FuzzyRuleCondition(LinguisticVariable variable, IFuzzyRuleToken @operator, IMembershipFunction function)
			: base(variable, @operator, function)
		{
		}
		public FuzzyRuleConditionConjunction Conjunction { get; set; }
	}
}
