using FLS.Constants;
using FLS.Rules;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests
{
	[TestFixture]
	public class CoGFuzzyEngineTests
	{
		[SetUp]
		public void Setup()
		{
			_testFilesPath = Path.Combine(TestUtilities.GetTestAssemblyDirectory(), @"..\..\TestFiles");
		}

		private String _testFilesPath;

		[Test]
		[ExpectedException(ExpectedException = typeof(Exception), ExpectedMessage = ErrorMessages.RulesAreInvalid)]
		public void Defuzzify_InvalidRules_Success()
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var warm = water.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTriangle("Low", 0, 25, 50);
			var high = power.MembershipFunctions.AddTriangle("High", 25, 50, 75);


			IFuzzyEngine fuzzyEngine = new CoGFuzzyEngine();

			fuzzyEngine.Rules.If(water.Is(hot));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = 60 });

			//Assert
		}

		[Test]
		[TestCase(60, 40)]
		public void Defuzzify_Success(Int32 waterInputValue, Double expectedValue)
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var warm = water.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTriangle("Low", 0, 25, 50);
			var high = power.MembershipFunctions.AddTriangle("High", 25, 50, 75);


			IFuzzyEngine fuzzyEngine = new CoGFuzzyEngine();

			fuzzyEngine.Rules.If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high));
			fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(low));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = waterInputValue });

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(Math.Floor(expectedValue)));
		}

		[Test]
		[TestCase(60, 66)]
		public void Defuzzify2_Success(Int32 waterInputValue, Double expectedValue)
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 40, 70);
			var warm = water.MembershipFunctions.AddTriangle("Warm", 40, 70, 100);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 70, 100, 120, 120);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTriangle("Low", -50, 20, 50);
			var med = power.MembershipFunctions.AddTriangle("Medium", 20, 50, 100);
			var high = power.MembershipFunctions.AddTriangle("High", 50, 100, 150);


			IFuzzyEngine fuzzyEngine = new CoGFuzzyEngine();

			fuzzyEngine.Rules.If(water.Is(cold)).Then(power.Is(high));
			fuzzyEngine.Rules.If(water.Is(warm)).Then(power.Is(med));
			fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(low));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = waterInputValue });

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(Math.Floor(expectedValue)));
		}
	}
}
