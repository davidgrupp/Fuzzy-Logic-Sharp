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
	public class TrapezoidMembershipFunctionTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(0, 0, 20, 40, 0, 1)]
		[TestCase(0, 0, 20, 40, 1, 1)]
		[TestCase(0, 0, 20, 40, 100, 0)]
		[TestCase(0, 0, 20, 40, 30, 0.5)]
		[TestCase(10, 20, 30, 40, 0, 0)]
		public void Fuzzify_Success(double x0, double x1, double x2, double x3, double inputValue, double expectedResult)
		{
			//Arrange
			var membershipFunction = new TrapezoidMembershipFunction("test", x0, x1, x2, x3);

			//Act
			var result = membershipFunction.Fuzzify(inputValue);

			//Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}


	}
}
