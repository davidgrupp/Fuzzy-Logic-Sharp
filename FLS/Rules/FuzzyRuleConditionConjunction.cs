using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.Rules
{
	public class FuzzyRuleConditionConjunction
	{
		public FuzzyRuleToken Conjunction { get; set; }
		public FuzzyRuleCondition FirstCondition { get; set; }
		public FuzzyRuleCondition SecondCondition { get; set; }
	}
}
