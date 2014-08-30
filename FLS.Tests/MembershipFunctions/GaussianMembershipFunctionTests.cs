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

	}
}
