#region License
//   FLS - Fuzzy Logic Sharp for .NET
//   Copyright 2015 David Grupp
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
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests.Defuzzification
{
	[TestFixture]
	public class TrapezoidCoGDefuzzificationTests
	{
		[Test]
		public void CoG_Trapezoid_Defuzzify()
		{
			//Arrange
			LinguisticVariable temp = new LinguisticVariable("Tempurature");
			var cold = temp.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 20, 40);
			var warm = temp.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
			var hot = temp.MembershipFunctions.AddTrapezoid("Hot", 50, 80, 100, 100);
			cold.PremiseModifier = 0.5;
			warm.PremiseModifier = 0.5;
			hot.PremiseModifier = 0.5;

			var defuzz = new TrapezoidCoGDefuzzification();

			//Act
			var result = defuzz.Defuzzify(temp.MembershipFunctions.ToList());

			//Assert
			Assert.That(result, Is.EqualTo(1));
		}
	}
}
