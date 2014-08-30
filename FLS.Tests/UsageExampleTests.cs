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


			IFuzzyEngine fuzzyEngine = new FuzzyEngineFactory().GetDefault();

			fuzzyEngine.Rules.If(water.Is(cold).Or(water.Is(warm))).Then(power.Is(high));
			fuzzyEngine.Rules.If(water.Is(hot)).Then(power.Is(low));

			//Act
			var result = fuzzyEngine.Defuzzify(new { water = 60 });

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(Math.Floor(40M)));

			//Extra
			System.Diagnostics.Debug.WriteLine(result);
		}




	}
}
