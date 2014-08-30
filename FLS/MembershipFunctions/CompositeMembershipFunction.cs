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
	public class CompositeMembershipFunction : FuzzyRuleToken, IMembershipFunction, ICoGMembershipFunction, IMoMMembershipFunction
	{
		public CompositeMembershipFunction(String name, IMembershipFunction leftFunction, IMembershipFunction rightFunction, double midPoint)
			: base(name, FuzzyRuleTokenType.Function)
		{
			_leftFunction = leftFunction;
			_rightFunction = rightFunction;
			_midPoint = midPoint;
		}

		private IMembershipFunction _leftFunction;
		private IMembershipFunction _rightFunction;
		private double _midPoint;

		public double Fuzzify(double inputValue)
		{
			if (inputValue <= _midPoint)
			{
				return _leftFunction.Fuzzify(inputValue);
			}
			else
			{
				return _leftFunction.Fuzzify(inputValue);
			}
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


		public Double MiddleMaximum()
		{
			var vals = 200;

			var max = 0.0;
			var startMax = 0.0;
			var len = 0.0;

			for (var i = 0.0; i < vals; i += 1)
			{
				var fuzVal = Fuzzify(i);
				if (max < fuzVal)
				{
					max = fuzVal;
					startMax = i;
					len = 0.0;
				}
				else if (max == fuzVal)
				{
					len++;
				}
			}

			var mid = startMax + ((startMax - len) / 2.0);

			return mid;
		}
	}
}
