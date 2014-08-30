#region License
//   FLS - Fuzzy Logic Sharp for .NET
//   Copyright 2014 David Grupp
//
//   Licensed under the Apache License, Version 2.0 (the "License");
//   you may not use this file except in compliance with the License.
//   You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
//   Unless required by applicable law or agreed to in writing, software
//   distributed under the License is distributed on an "AS IS" BASIS,
//   WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//   See the License for the specific language governing permissions and
//   limitations under the License. 
#endregion
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
	public class FuzzyEngine<T> : BaseFuzzyEngine where T : IDefuzzType<T>
	{
		#region Public Methods

		public override Double Defuzzify(Object inputValues)
		{
			if (_rules.Any(r => false == r.IsValid()))
				throw new Exception(ErrorMessages.RulesAreInvalid);

			if (_rules.Any(r => r.Premise.Any(c => false == c.MembershipFunction is T)
				|| false == r.Conclusion.MembershipFunction is T))
				throw new Exception(String.Format(ErrorMessages.MembershipFunctionsDefuzzType, typeof(T)));

			SetVariableInputValues(inputValues);

			double finalValue = 0;
			double premiseValuesSum = 0;

			foreach (FuzzyRule fuzzyRule in _rules)
			{
				var premiseValue = Evaluate(fuzzyRule.Premise);

				var ruleConclusionVar = fuzzyRule.Conclusion.Variable;
				T membershipFunction = (T)ruleConclusionVar.MembershipFunctions.First(mf => mf.Name == fuzzyRule.Conclusion.MembershipFunction.Name);

				var midPoint = membershipFunction.MidPoint();
				finalValue += premiseValue * midPoint;

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
