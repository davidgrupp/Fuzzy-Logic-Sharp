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
using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FLS.Tests.Rules
{
	[TestFixture]
	public class FuzzyRuleEvaluatorTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(0, 0, 10, 20, true, 15, .5)] // v IS f
		[TestCase(0, 0, 10, 20, false, 15, .5)] // v NOT f
		[TestCase(0, 0, 10, 20, true, 12.5, .75)] // v IS f
		[TestCase(0, 0, 10, 20, false, 12.5, .25)] // v NOT f
		[TestCase(0, 0, 10, 20, true, 5, 1)]  // v IS f
		[TestCase(0, 0, 10, 20, false, 5, 0)]  // v NOT f
		public void RuleEvaluation_Single_Success(Double a, Double b, Double c, Double d, Boolean IsOp, Double v, Double expectedResult)
		{
			//Arrange
			var conditions = new List<FuzzyRuleCondition>();

			var variable = new LinguisticVariable("v");
			variable.InputValue = v;
			var operatr = new FuzzyRuleToken("is", IsOp ? FuzzyRuleTokenType.Is : FuzzyRuleTokenType.Not);
			var function = new TrapezoidMembershipFunction("f", a, b, c, d);
			conditions.Add(new FuzzyRuleCondition(variable, operatr, function));

			//Act
			var srv = new FuzzyRuleEvaluator();
			var result = srv.Evaluate(conditions);

			//Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		[TestCase(0, 10, 20, true, true, 0, 10, 30, true, 15, .5)] // v1 IS f1 AND v2 IS f2
		[TestCase(0, 10, 20, true, true, 0, 10, 30, false, 15, .25)] // v1 IS f1 AND v2 NOT f2
		[TestCase(0, 10, 20, true, false, 0, 10, 30, true, 15, .75)] // v1 IS f1 OR v2 IS f2
		[TestCase(0, 10, 20, true, false, 0, 10, 30, false, 15, .5)] // v1 IS f1 OR v2 NOT f2
		public void RuleEvaluation_Double_Success(Double a1, Double b1, Double c1, Boolean IsOp1,
												Boolean And,
												Double a2, Double b2, Double c2, Boolean IsOp2,
												Double v, Double expectedResult)
		{
			//Arrange
			var conditions = new List<FuzzyRuleCondition>();

			var variable1 = new LinguisticVariable("v1");
			variable1.InputValue = v;
			var operatr1 = new FuzzyRuleToken("is", IsOp1 ? FuzzyRuleTokenType.Is : FuzzyRuleTokenType.Not);
			var function1 = new TriangleMembershipFunction("f1", a1, b1, c1);
			var con1 = new FuzzyRuleCondition(variable1, operatr1, function1);
			conditions.Add(con1);

			var variable2 = new LinguisticVariable("v2");
			variable2.InputValue = v;
			var operatr2 = new FuzzyRuleToken("is", IsOp2 ? FuzzyRuleTokenType.Is : FuzzyRuleTokenType.Not);
			var function2 = new TriangleMembershipFunction("f2", a2, b2, c2);
			var con2 = new FuzzyRuleCondition(variable2, operatr2, function2);
			conditions.Add(con2);

			var conjToken = new FuzzyRuleToken("and", And ? FuzzyRuleTokenType.And : FuzzyRuleTokenType.Or);
			var conj = new FuzzyRuleConditionConjunction() { FirstCondition = con1, SecondCondition = con2, Conjunction = conjToken };
			con2.Conjunction = conj;


			//Act
			var srv = new FuzzyRuleEvaluator();
			var result = srv.Evaluate(conditions);

			//Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}
	}
}
