using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.Rules
{
	/// <summary>
	/// Individual Token for a fuzzy rule
	/// </summary>
	public class FuzzyRuleToken : IFuzzyRuleToken
	{
		public FuzzyRuleToken()
		{

		}

		public FuzzyRuleToken(String value, FuzzyRuleTokenType type)
		{
			Name = value;
			Type = type;
		}


		public String Name { get; set; }
		public FuzzyRuleTokenType Type { get; set; }
	}



}
