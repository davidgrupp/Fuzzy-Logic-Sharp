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
using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.MembershipFunctions
{
	public class GaussianMembershipFunction : FuzzyRuleToken, IMembershipFunction, ICoGDefuzzification, IMoMDefuzzification
	{
		public GaussianMembershipFunction(String name, double c, double tou)
			: base(name, FuzzyRuleTokenType.Function)
		{
			_c = c;
			_tou = tou;
		}

		private double _c;
		private double _tou;

		public double Fuzzify(double inputValue)
		{
			var power = -0.5 * Math.Pow((inputValue - _c) / _tou, 2.0);
			return Math.Min(1.0, Math.Exp(power));
		}

		public Double Centroid()
		{
			var max = 200;
			var mid = 0.0;
			var sum = 0.0;
			var sumx = 0.0;

			for (var i = 0.0; i < max; i += 1)
			{
				sum += Fuzzify(i);
				sumx += i * Fuzzify(i);
			}

			mid = sumx / sum;

			return mid;
		}

		private Double MiddleMaximum()
		{
			return _c;
		}

		double IDefuzzType<ICoGDefuzzification>.MidPoint()
		{
			return Centroid();
		}

		double IDefuzzType<IMoMDefuzzification>.MidPoint()
		{
			return MiddleMaximum();
		}
	}
}
