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
using FLS.MembershipFunctions;
using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS
{
	public static class FuzzyRuleExtensions
	{
		public static FuzzyRule If(this FuzzyRuleCollection value, List<FuzzyRuleCondition> conditions)
		{
			var rule = Rule.If(conditions);
			value.Add(rule);
			return rule;
		}

		public static FuzzyRule If(this FuzzyRuleCollection value, FuzzyRuleCondition condition)
		{
			var rule = Rule.If(condition);
			value.Add(rule);
			return rule;
		}

		public static FuzzyRule If(this FuzzyRule value, List<FuzzyRuleCondition> conditions)
		{
			if (null == value.Premise)
				value.Premise = new Premise(conditions);

			return value;
		}

		public static FuzzyRule If(this FuzzyRule value, FuzzyRuleCondition condition)
		{
			if (null == value.Premise)
				value.Premise = new Premise(condition);

			return value;
		}

		public static void Add(this FuzzyRuleCollection value, params FuzzyRule[] rules)
		{
			foreach (var rule in rules)
			{
				value.Add(rule);
			}
		}

		public static FuzzyRuleCondition Is(this LinguisticVariable value, IMembershipFunction function)
		{
			if (null == function)
				throw new ArgumentNullException("function");

			var @operator = new FuzzyRuleToken("IS", FuzzyRuleTokenType.Is);
			var clause = new FuzzyRuleCondition(value, @operator, function);
			return clause;
		}

		public static FuzzyRuleCondition IsNot(this LinguisticVariable value, IMembershipFunction function)
		{
			if (null == function)
				throw new ArgumentNullException("function");

			var @operator = new FuzzyRuleToken("NOT", FuzzyRuleTokenType.Not);
			var clause = new FuzzyRuleCondition(value, @operator, function);
			return clause;
		}

		public static List<FuzzyRuleCondition> Or(this FuzzyRuleCondition value, FuzzyRuleCondition condition)
		{
			if (null == condition)
				throw new ArgumentNullException("condition");

			var conditions = new List<FuzzyRuleCondition>();

			var conjunction = new FuzzyRuleConditionConjunction() { Conjunction = new FuzzyRuleToken("OR", FuzzyRuleTokenType.Or), FirstCondition = value, SecondCondition = condition };

			condition.Conjunction = conjunction;
			conditions.Add(value);
			conditions.Add(condition);

			return conditions;
		}
		public static List<FuzzyRuleCondition> Or(this List<FuzzyRuleCondition> value, FuzzyRuleCondition condition)
		{
			var firstCondition = value.Last();
			var conjunction = new FuzzyRuleConditionConjunction() { Conjunction = new FuzzyRuleToken("OR", FuzzyRuleTokenType.Or), FirstCondition = firstCondition, SecondCondition = condition };
			condition.Conjunction = conjunction;

			value.Add(condition);

			return value;
		}

		public static List<FuzzyRuleCondition> And(this FuzzyRuleCondition value, FuzzyRuleCondition condition)
		{
			var conditions = new List<FuzzyRuleCondition>();
			var conjunction = new FuzzyRuleConditionConjunction() { Conjunction = new FuzzyRuleToken("AND", FuzzyRuleTokenType.And), FirstCondition = value, SecondCondition = condition };
			condition.Conjunction = conjunction;
			conditions.Add(value);
			conditions.Add(condition);

			return conditions;
		}
		public static List<FuzzyRuleCondition> And(this List<FuzzyRuleCondition> value, FuzzyRuleCondition condition)
		{
			var firstCondition = value.Last();
			var conjunction = new FuzzyRuleConditionConjunction() { Conjunction = new FuzzyRuleToken("AND", FuzzyRuleTokenType.And), FirstCondition = firstCondition, SecondCondition = condition };
			condition.Conjunction = conjunction;

			value.Add(condition);

			return value;
		}

		public static FuzzyRule Then(this FuzzyRule value, FuzzyRuleClause clause)
		{
			if (null == clause)
				throw new ArgumentNullException("clause");

			var conclusion = new Conclusion(clause.Variable, clause.Operator, clause.MembershipFunction);

			value.Conclusion = conclusion;

			return value;
		}

	}
}
