using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.MembershipFunctions
{
	public interface IMembershipFunction : IFuzzyRuleToken
	{
		Double Fuzzify(Double inputValue);
	}
}
