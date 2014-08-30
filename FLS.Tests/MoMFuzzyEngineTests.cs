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

namespace FLS.Tests
{
	[TestFixture]
	public class MoMFuzzyEngineTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(10, 5)]
		[TestCase(35, 35)]
		[TestCase(20, 0)]
		public void MoM_Defuzzify_Success(Int32 waterInputValue, Double expectedValue)
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 10, 20);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 20, 30, 40, 40);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTrapezoid("Low", 0, 0, 10, 20);
			var high = power.MembershipFunctions.AddTrapezoid("High", 20, 30, 40, 40);


			IFuzzyEngine fuzzyEngine = new FuzzyEngine<IMoMDefuzzification>();

			fuzzyEngine.Rules.If(water.Is(cold)).Then(power.Is(low));
			fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(high));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = waterInputValue });

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(expectedValue));
		}

		[Test]
		[TestCase(10, 10)]
		[TestCase(35, 33)]
		public void MoM_Defuzzify2_Success(Int32 waterInputValue, Double expectedValue)
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 30, 40, 50, 50);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTrapezoid("Low", 0, 0, 20, 40);
			var high = power.MembershipFunctions.AddTrapezoid("High", 30, 40, 50, 50);


			IFuzzyEngine fuzzyEngine = new FuzzyEngine<IMoMDefuzzification>();

			fuzzyEngine.Rules.If(water.Is(cold)).Then(power.Is(low));
			fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(high));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = waterInputValue });

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(expectedValue));
		}

	}
}
