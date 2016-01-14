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
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FLS;
using FLS.Rules;

namespace FLS.Tests
{
	[TestFixture]
	public class UsageExampleTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void UsageExample_Success()
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var warm = water.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTriangle("Low", 0, 25, 50);
			var high = power.MembershipFunctions.AddTriangle("High", 25, 50, 75);
			
			IFuzzyEngine fuzzyEngine = new FuzzyEngineFactory().Default();

			var rule1 = Rule.If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high));
			var rule2 = Rule.If(water.Is(hot)).Then(power.Is(low));
			fuzzyEngine.Rules.Add(rule1, rule2);

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = 60 });

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(Math.Floor(40.0)));

			//Extra
			System.Diagnostics.Debug.WriteLine(result);
		}




	}
}
