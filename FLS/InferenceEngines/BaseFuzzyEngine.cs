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
