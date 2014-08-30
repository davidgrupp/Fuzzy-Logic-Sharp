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
using FLS.Constants;
using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS
{
	public abstract class BaseFuzzyEngine : IFuzzyEngine
	{
	
		#region Private Properties

		protected FuzzyRuleCollection _rules;

		#endregion

		#region Private Methods

		protected double Evaluate(List<FuzzyRuleCondition> ruleConditions)
		{
			Double value = 0;
			Boolean isFirstCondition = true;

			foreach (var condition in ruleConditions)
			{
				var conditionValue = condition.MembershipFunction.Fuzzify(condition.Variable.InputValue);

				if (condition.Operator.Type == FuzzyRuleTokenType.Not)
				{
					conditionValue = 1 - conditionValue;
				}

				if (isFirstCondition)
				{
					value = conditionValue;
				}
				else
				{
					switch (condition.Conjunction.Conjunction.Type)
					{
						case FuzzyRuleTokenType.And:
							if (conditionValue < value)
								value = conditionValue;
							break;
						case FuzzyRuleTokenType.Or:
							if (conditionValue > value)
								value = conditionValue;
							break;
					}
				}
			}

			return value;
		}

		protected void SetVariableInputValues(Object inputValues)
		{
			var conditionVariables = _rules.SelectMany(r => r.Premise.Select(p => p.Variable));

			var inputVals = inputValues.PropertyValues();

			foreach (var variable in conditionVariables)
			{
				if (false == inputVals.Any(kv => kv.Key.ToLower() == variable.Name.ToLower() && kv.Value is Int32))
				{
					throw new ArgumentException(String.Format(ErrorMessages.InputValusMustBeIntegers, variable.Name));
				}
				else
				{
					var inputValue = (Int32)inputVals.First(kv => kv.Key.ToLower() == variable.Name.ToLower()).Value;
					variable.InputValue = inputValue;
				}
			}
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
			private set { _rules = value; }
		}

		#endregion

		#region Public Methods

		public abstract Double Defuzzify(Object inputValues);

		#endregion
	}
}
