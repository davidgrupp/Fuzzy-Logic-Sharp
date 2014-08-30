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
		public void Defuzzify_Success(Int32 waterInputValue, Double expectedValue)
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 10, 20);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 20, 30, 40, 40);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTrapezoid("Low", 0, 0, 10, 20);
			var high = power.MembershipFunctions.AddTrapezoid("High", 20, 30, 40, 40);


			IFuzzyEngine fuzzyEngine = new MoMFuzzyEngine();

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
		public void Defuzzify2_Success(Int32 waterInputValue, Double expectedValue)
		{
			//Arrange
			LinguisticVariable water = new LinguisticVariable("Water");
			var cold = water.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var hot = water.MembershipFunctions.AddTrapezoid("Hot", 30, 40, 50, 50);

			LinguisticVariable power = new LinguisticVariable("Power");
			var low = power.MembershipFunctions.AddTrapezoid("Low", 0, 0, 20, 40);
			var high = power.MembershipFunctions.AddTrapezoid("High", 30, 40, 50, 50);


			IFuzzyEngine fuzzyEngine = new MoMFuzzyEngine();

			fuzzyEngine.Rules.If(water.Is(cold)).Then(power.Is(low));
			fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(high));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = waterInputValue });

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(expectedValue));
		}

	}
}
