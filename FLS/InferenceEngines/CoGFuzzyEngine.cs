using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Linq;
using FLS.Rules;
using FLS.Constants;
using FLS.MembershipFunctions;

namespace FLS
{
	/// <summary>
	/// A Center of Gravity fuzzy logic engine.
	/// </summary>
	public class CoGFuzzyEngine : BaseFuzzyEngine
	{
		#region Public Methods

		public override Double Defuzzify(Object inputValues)
		{
			if (_rules.Any(r => false == r.IsValid()))
				throw new Exception(ErrorMessages.RulesAreInvalid);

			if (_rules.Any(r => r.Premise.Any(c => false == c.MembershipFunction is ICoGMembershipFunction)
				|| false == r.Conclusion.MembershipFunction is ICoGMembershipFunction))
				throw new Exception(ErrorMessages.MembershipFunctionsCoG);

			SetVariableInputValues(inputValues);

			double finalValue = 0;
			double premiseValuesSum = 0;

			foreach (FuzzyRule fuzzyRule in _rules)
			{
				var premiseValue = Evaluate(fuzzyRule.Premise);

				var ruleConclusionVar = fuzzyRule.Conclusion.Variable;
				ICoGMembershipFunction membershipFunction = ruleConclusionVar.MembershipFunctions.First(mf => mf.Name == fuzzyRule.Conclusion.MembershipFunction.Name) as ICoGMembershipFunction;

				var centriod = membershipFunction.Centroid();
				finalValue += premiseValue * centriod;

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
