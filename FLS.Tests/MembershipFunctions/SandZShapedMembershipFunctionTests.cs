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
using NUnit.Framework;
using System;

namespace FLS.Tests.MembershipFunctions
{
	[TestFixture]
	public class SandZShapedMembershipFunctionTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(50, 10, 50, 0.5)]
		[TestCase(50, 10, 40, 0.1192)]
		[TestCase(50, 10, 0, 0)]
		[TestCase(50, 10, 100, 1)]
		public void SandZ_Fuzzify_Success(Double a, Double b, Double inputValue, Double expectedResult)
		{
			//Arrange
			var SmembershipFunction = new SShapedMembershipFunction("test", a, b);
			var ZmembershipFunction = new ZShapedMembershipFunction("test", a, b);

			//Act
			var resultS = SmembershipFunction.Fuzzify(inputValue);
			var resultZ = ZmembershipFunction.Fuzzify(inputValue);

			//Assert
			Assert.That(Math.Round(resultS, 4), Is.EqualTo(expectedResult));
			Assert.That(Math.Round(resultZ, 4), Is.EqualTo(1 - expectedResult));
		}

		[Test]
		public void SandZ_Min_Success()
		{
			//Arrange
			var SmembershipFunction = new SShapedMembershipFunction("test", 50, 20);
			var ZmembershipFunction = new ZShapedMembershipFunction("test", 50, 20);

			//Act
			var resultS = SmembershipFunction.Min();
			var resultZ = ZmembershipFunction.Min();

			//Assert
			Assert.That(resultS, Is.EqualTo(0));
			Assert.That(resultZ, Is.EqualTo(0));
		}

		[Test]
		public void SandZ_Max_Success()
		{
			//Arrange
			var SmembershipFunction = new SShapedMembershipFunction("test", 50, 20);
			var ZmembershipFunction = new ZShapedMembershipFunction("test", 50, 20);

			//Act
			var resultS = SmembershipFunction.Max();
			var resultZ = ZmembershipFunction.Max();

			//Assert
			Assert.That(resultS, Is.EqualTo(100));
			Assert.That(resultZ, Is.EqualTo(100));
		}

		[Test]
		public void S_InvalidInput()
		{
			//Arrange

			//Act
			var membershipFunction = new TestDelegate(() => new SShapedMembershipFunction("test", 50, 0));

			//Assert
			Assert.Throws(Is.InstanceOf(typeof(ArgumentException)), membershipFunction, ErrorMessages.BArgumentIsInvalid);
		}
	}
}
