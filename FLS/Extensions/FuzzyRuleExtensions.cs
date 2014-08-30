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
			var rule = new FuzzyRule();

			value.Add(rule);

			return rule.If(conditions);
		}

		public static FuzzyRule If(this FuzzyRuleCollection value, FuzzyRuleCondition condition)
		{
			var rule = new FuzzyRule();

			value.Add(rule);

			return rule.If(condition);
		}

		public static FuzzyRule If(this FuzzyRule value, List<FuzzyRuleCondition> conditions)
		{
			value.Premise = new Premise(conditions);

			return value;
		}

		public static FuzzyRule If(this FuzzyRule value, FuzzyRuleCondition condition)
		{
			value.Premise = new Premise(condition);

			return value;
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
