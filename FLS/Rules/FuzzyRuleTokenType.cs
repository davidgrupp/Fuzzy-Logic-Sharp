using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.Rules
{
	public enum FuzzyRuleTokenType : int
	{
		If = 1,
		Then = 2,
		Is = 3,
		Not = 4,
		And = 5,
		Or = 6,
		Variable = 7,
		Function = 8,
		Unknown = 0,
	}
}
