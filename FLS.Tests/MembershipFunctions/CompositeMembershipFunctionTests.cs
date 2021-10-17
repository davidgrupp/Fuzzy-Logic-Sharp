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
using System;

namespace FLS.Tests.MembershipFunctions
{
	[TestFixture]
	public class CompositeMembershipFunctionTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(0, 0)]
		[TestCase(10, 1)]
		[TestCase(20, 1)]
		[TestCase(15, .5)]
		public void CompositeFuzzify_Success(double inputValue, double expectedResult)
		{
			//Arrange
			var triMF1 = new TriangleMembershipFunction("t1", 0, 10, 20);
			var triMF2 = new TriangleMembershipFunction("t2", 10, 20, 30);
			var membershipFunction = new CompositeMembershipFunction("test", triMF1, triMF2, 15.0);

			//Act
			var result = membershipFunction.Fuzzify(inputValue);

			//Assert
			Assert.That(Math.Round(result, 3), Is.EqualTo(expectedResult));
		}

		[Test]
		public void CompositeMin_Success()
		{
			//Arrange
			var triMF1 = new TriangleMembershipFunction("t1", 0, 10, 20);
			var triMF2 = new TriangleMembershipFunction("t2", 10, 20, 30);
			var membershipFunction = new CompositeMembershipFunction("test", triMF1, triMF2, 15.0);

			//Act
			var result = membershipFunction.Min();

			//Assert
			Assert.That(result, Is.EqualTo(0));
		}

		[Test]
		public void CompositeMax_Success()
		{
			//Arrange
			var triMF1 = new TriangleMembershipFunction("t1", 0, 10, 20);
			var triMF2 = new TriangleMembershipFunction("t2", 10, 20, 30);
			var membershipFunction = new CompositeMembershipFunction("test", triMF1, triMF2, 15.0);

			//Act
			var result = membershipFunction.Max();

			//Assert
			Assert.That(result, Is.EqualTo(30));
		}
	}
}
