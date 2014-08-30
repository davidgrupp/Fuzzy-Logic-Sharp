using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS
{
	public interface IFuzzyEngine
	{
		FuzzyRuleCollection Rules { get; }
		Double Defuzzify(object inputValues);
	}
}
