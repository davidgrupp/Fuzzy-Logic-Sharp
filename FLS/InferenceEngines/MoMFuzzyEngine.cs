using FLS.Constants;
using FLS.MembershipFunctions;
using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS
{
	/// <summary>
	/// A Middle of Maximum fuzzy logic engine.
	/// </summary>
	public class MoMFuzzyEngine : BaseFuzzyEngine
	{
		#region Public Methods

		public override Double Defuzzify(Object inputValues)
		{
			if (_rules.Any(r => false == r.IsValid()))
				throw new Exception(ErrorMessages.RulesAreInvalid);

			if (_rules.Any(r => r.Premise.Any(c => false == c.MembershipFunction is IMoMMembershipFunction)
				|| false == r.Conclusion.MembershipFunction is IMoMMembershipFunction))
				throw new Exception(ErrorMessages.MembershipFunctionsCoG);

			SetVariableInputValues(inputValues);

			double finalValue = 0;
			double premiseValuesSum = 0;

			foreach (FuzzyRule fuzzyRule in _rules)
			{
				var premiseValue = Evaluate(fuzzyRule.Premise);

				var ruleConclusionVar = fuzzyRule.Conclusion.Variable;
				IMoMMembershipFunction membershipFunction = ruleConclusionVar.MembershipFunctions.First(mf => mf.Name == fuzzyRule.Conclusion.MembershipFunction.Name) as IMoMMembershipFunction;

				var midMaximum = membershipFunction.MiddleMaximum();
				finalValue += premiseValue * midMaximum;

				premiseValuesSum += premiseValue;
			}

			if (0 == finalValue && 0 == premiseValuesSum)
				return 0;
			else
				return finalValue / premiseValuesSum;
		}

		#endregion
	}
}
