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
using NUnit.Framework;

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
		public void TrapezoidFuzzify_Success(double x0, double x1, double x2, double x3, double inputValue, double expectedResult)
		{
			//Arrange
			var membershipFunction = new TrapezoidMembershipFunction("test", x0, x1, x2, x3);

			//Act
			var result = membershipFunction.Fuzzify(inputValue);

			//Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		[TestCase(0, 0, 20, 40, 0)]
		[TestCase(-50, 0, 20, 40, -50)]
		[TestCase(10, 20, 30, 40, 10)]
		public void TrapezoidMin_Success(double x0, double x1, double x2, double x3, double expectedResult)
		{
			//Arrange
			var membershipFunction = new TrapezoidMembershipFunction("test", x0, x1, x2, x3);

			//Act
			var result = membershipFunction.Min();

			//Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}

		[Test]
		[TestCase(-40, -40, -20, 0, 0)]
		[TestCase(-50, -50, -20, -10, -10)]
		[TestCase(10, 20, 30, 40, 40)]
		public void TrapezoidMax_Success(double x0, double x1, double x2, double x3, double expectedResult)
		{
			//Arrange
			var membershipFunction = new TrapezoidMembershipFunction("test", x0, x1, x2, x3);

			//Act
			var result = membershipFunction.Max();

			//Assert
			Assert.That(result, Is.EqualTo(expectedResult));
		}
	}
}
