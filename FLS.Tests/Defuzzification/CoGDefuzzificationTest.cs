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
using FLS.MembershipFunctions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests.Defuzzification
{
	[TestFixture]
	public class CoGDefuzzificationTest
	{
		[Test]
		public void CoG_Defuzzify()
		{
			//Arrange
			LinguisticVariable temp = new LinguisticVariable("Tempurature");
			var cold = temp.MembershipFunctions.AddTrapezoid("Cold", 0, 0, 30, 50);
			var warm = temp.MembershipFunctions.AddTriangle("Warm", 30, 50, 70);
			var hot = temp.MembershipFunctions.AddTrapezoid("Hot", 70, 80, 90, 90);
			cold.PremiseModifier = 0.5;
			warm.PremiseModifier = 0.5;
			hot.PremiseModifier = 0.5;
			var defuzz = new CoGDefuzzification();
			var defuzzTrap = new TrapezoidCoGDefuzzification();

			//Act
			var resultIntg = defuzz._Defuzzify(temp.MembershipFunctions.ToList());
			var resultTrap = defuzz.Defuzzify(temp.MembershipFunctions.ToList());

			//Assert
			var expectedResult = 40;
			Assert.That(Math.Floor(resultIntg), Is.EqualTo(expectedResult));
			Assert.That(Math.Floor(resultTrap), Is.EqualTo(expectedResult));
		}

		[Test]
		public void CoG_Defuzzify_Trapezoid()
		{
			var memFunc = new TrapezoidMembershipFunction("mf", 0, 10, 20, 30);
			CoG_Defuzzify(memFunc, 15);
		}
		[Test]
		public void CoG_Defuzzify_Triangle()
		{
			var memFunc = new TriangleMembershipFunction("mf", 30, 50, 70);
			CoG_Defuzzify(memFunc, 50);
		}

		[Test]
		public void CoG_Defuzzify_Rectangle()
		{
			var memFunc = new RectangleMembershipFunction("mf", 30, 50);
			CoG_Defuzzify(memFunc, 40);
		}

		[Test]
		public void CoG_Defuzzify_Gaussian()
		{
			var memFunc = new GaussianMembershipFunction("mf", 50, 20);
			CoG_Defuzzify(memFunc, 50);
		}
		[Test]
		public void CoG_Defuzzify_Bell()
		{
			var memFunc = new BellMembershipFunction("mf", 15, 6, 50);
			CoG_Defuzzify(memFunc, 50);
		}
		[Test]
		public void CoG_Defuzzify_SShaped()
		{
			//manual calculation at
			//http://www.wolframalpha.com/input/?i=%E2%88%AB+%28x*%28%28tanh%28%28x-50%29%2F10%29%29%2B1%29%2F4%29+from+0+to+100+%2F+%E2%88%AB%28%28%28tanh%28%28x-50%29%2F10%29%29%2B1%29%2F4%29+from+0+to+100

			var memFunc = new SShapedMembershipFunction("mf", 50, 10);
			CoG_Defuzzify(memFunc, 74);
		}
		[Test]
		public void CoG_Defuzzify_ZShaped()
		{
			var memFunc = new ZShapedMembershipFunction("mf", 50, 10);
			CoG_Defuzzify(memFunc, 25);
		}
		private void CoG_Defuzzify(IMembershipFunction memFunc, Double expectedResult)
		{
			//Arrange
			LinguisticVariable temp = new LinguisticVariable("v");
			temp.MembershipFunctions.Add(memFunc);
			memFunc.PremiseModifier = 1;

			var defuzz = new CoGDefuzzification();

			//Act
			var result = defuzz._Defuzzify(temp.MembershipFunctions.ToList());

			//Assert
			Assert.That(Math.Floor(result), Is.EqualTo(expectedResult));
		}
	}
}
