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
	public class FuzzyEngine : IFuzzyEngine
	{
		public FuzzyEngine(IDefuzzification defuzzification)
			: this(defuzzification, new FuzzyRuleEvaluator())
		{

		}

		public FuzzyEngine(IDefuzzification defuzzification, IFuzzyRuleEvaluator fuzzyRuleEvaluator)
		{
			_fuzzyRuleEvaluator = fuzzyRuleEvaluator;
			_defuzzification = defuzzification;
		}

		#region Private Properties

		protected FuzzyRuleCollection _rules;
		protected IFuzzyRuleEvaluator _fuzzyRuleEvaluator;
		protected IDefuzzification _defuzzification;

		#endregion

		#region Private Methods

		protected virtual void SetVariableInputValues(Object inputValues)
		{
			var conditionVariables = _rules.SelectMany(r => r.Premise.Select(p => p.Variable));

			var inputVals = inputValues.PropertyValues();

			foreach (var variable in conditionVariables)
			{
				if (false == inputVals.Any(kv => kv.Key.ToLower() == variable.Name.ToLower() && (kv.Value is Int32 || kv.Value is Double || kv.Value is Decimal)))
				{
					throw new ArgumentException(String.Format(ErrorMessages.InputValusMustBeValid, variable.Name));
				}
				else
				{
					var inputValue = Convert.ToDouble(inputVals.First(kv => kv.Key.ToLower() == variable.Name.ToLower()).Value);
					variable.InputValue = inputValue;
				}
			}
		}

		#endregion


		#region Public Methods

		public Double Defuzzify(Object inputValues)
		{
			if (_rules.Any(r => false == r.IsValid()))
				throw new Exception(ErrorMessages.RulesAreInvalid);

			//reset membership functions
			_rules.ForEach(r => r.Conclusion.MembershipFunction.PremiseModifier = 0);

			SetVariableInputValues(inputValues);

			var conclustionMembershipFunctions = _rules.Select(r => r.Conclusion.MembershipFunction).ToList();

			foreach (FuzzyRule fuzzyRule in _rules)
			{
				var premiseValue = _fuzzyRuleEvaluator.Evaluate(fuzzyRule.Premise);

				var ruleConclusionVar = fuzzyRule.Conclusion.Variable;
				var membershipFunction = ruleConclusionVar.MembershipFunctions.First(mf => mf.Name == fuzzyRule.Conclusion.MembershipFunction.Name);

				membershipFunction.PremiseModifier = premiseValue;
			}

			return _defuzzification.Defuzzify(conclustionMembershipFunctions);
		}


		#endregion

		#region Public Properties

		public FuzzyRuleCollection Rules
		{
			get
			{
				_rules = _rules ?? new FuzzyRuleCollection();
				return _rules;
			}
		}

		public IDefuzzification Defuzzification
		{
			get { return _defuzzification; }
		}

		#endregion

	}
}
