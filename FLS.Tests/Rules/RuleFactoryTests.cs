#region License
//   FLS - Fuzzy Logic Sharp for .NET
//   Copyright 2015 David Grupp
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
using FLS.Rules;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests.Rules
{
	[TestFixture]
	public class RuleFactoryTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void RuleFactory_Condition_Success()
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var warm = water.MembershipFunctions.AddTrapezoid("Warm", 30, 50, 50, 70);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTrapezoid("Low", 0, 25, 25, 50);
			var high = power.MembershipFunctions.AddTrapezoid("High", 25, 50, 50, 75);

			//Act
			var rule1 = Rule.If(water.Is(cold)).Then(power.Is(high)); //valid
			var rule2 = Rule.If(water.IsNot(cold)).Then(power.Is(high)); //valid
			var rule3 = Rule.If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high)); //valid
			var rule4 = Rule.If(water.Is(cold).Or(water.Is(warm)).And(water.Is(hot))).Then(power.Is(high)); //valid
			var rule5 = Rule.If(water.Is(cold).And(water.Is(warm)).And(water.Is(hot))).Then(power.Is(high)); //valid
			var rule6 = Rule.If(water.Is(cold).Or(water.Is(warm)).Or(water.Is(hot))).Then(power.Is(high)); //valid

			var result1 = rule1.IsValid();
			var result2 = rule2.IsValid();
			var result3 = rule3.IsValid();
			var result4 = rule4.IsValid();
			var result5 = rule3.IsValid();
			var result6 = rule4.IsValid();

			//Assert
			Assert.That(result1, Is.True, "result1");
			Assert.That(result2, Is.True, "result2");
			Assert.That(result3, Is.True, "result3");
			Assert.That(result4, Is.True, "result4");
			Assert.That(result5, Is.True, "result5");
			Assert.That(result6, Is.True, "result6");
		}
	}
}
