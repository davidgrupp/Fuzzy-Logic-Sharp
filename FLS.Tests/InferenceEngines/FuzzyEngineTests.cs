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
using FLS.MembershipFunctions;
using FLS.Rules;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests
{
	[TestFixture]
	public class FuzzyEngineTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = ErrorMessages.RulesAreInvalid)]
		public void FuzzyEngine_InvalidRules_Success()
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var warm = water.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTriangle("Low", 0, 25, 50);
			var high = power.MembershipFunctions.AddTriangle("High", 25, 50, 75);


			IFuzzyEngine fuzzyEngine = new FuzzyEngine(new CoGDefuzzification());

			fuzzyEngine.Rules.If(water.Is(hot));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = 60 });

			//Assert
		}

		[Test]
		[ExpectedException(ExpectedException = typeof(ArgumentException))]
		public void FuzzyEngine_InvalidInputs_Success()
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var warm = water.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTriangle("Low", 0, 25, 50);
			var high = power.MembershipFunctions.AddTriangle("High", 25, 50, 75);


			IFuzzyEngine fuzzyEngine = new FuzzyEngine(new CoGDefuzzification());

			fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(high));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = "invalid input" });

			//Assert
		}
	}
}
