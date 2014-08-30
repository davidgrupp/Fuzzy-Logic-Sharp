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
