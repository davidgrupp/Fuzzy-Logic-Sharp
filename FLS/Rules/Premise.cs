using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace FLS.Rules
{
	/// <summary>
	/// The if-part of the rule
	/// </summary>
	public class Premise : List<FuzzyRuleCondition>
	{
		public Premise(FuzzyRuleCondition condition)
		{
			this.Add(condition);
		}
		public Premise(IEnumerable<FuzzyRuleCondition> conditions)
		{
			foreach (var condition in conditions)
			{
				Add(condition);
			}
		}


	}
}
