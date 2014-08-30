using FLS.MembershipFunctions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests
{
	[TestFixture]
	public class GaussianMembershipFunctionTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(50, 20, 50, 1)]
		[TestCase(50, 20, 10, .135)]
		[TestCase(50, 20, 90, .135)]
		public void GaussianFuzzify_Success(double c, double tou, double inputValue, double expectedResult)
		{
			//Arrange
			var membershipFunction = new GaussianMembershipFunction("test", c, tou);

			//Act
			var result = membershipFunction.Fuzzify(inputValue);

			//Assert
			Assert.That(Math.Round(result, 3), Is.EqualTo(expectedResult));
		}

		[Test]
		[TestCase(50, 20, 50)]
		[TestCase(40, 20, 41)]
		[TestCase(10, 20, 19)]
		[TestCase(50, 10, 50)]
		public void GaussianCentroid_Success(double c, double tou, double expectedResult)
		{
			//Arrange
			var membershipFunction = new GaussianMembershipFunction("test", c, tou);

			//Act
			var result = membershipFunction.Centroid();

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(expectedResult));
		}
	}
}
