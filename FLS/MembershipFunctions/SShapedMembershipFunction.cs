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
using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.MembershipFunctions
{
	public class SShapedMembershipFunction : BaseMembershipFunction
	{
		public SShapedMembershipFunction(String name, Double a, Double b, Double min, Double max)
			: base(name)
		{
			if (0 == b)
				throw new ArgumentException(ErrorMessages.BArgumentIsInvalid);

			_a = a;
			_b = b;
			_min = min;
			_max = max;
		}

		public SShapedMembershipFunction(String name, Double a, Double b)
			: this(name, a, b, 0, 100)
		{
		}

		private Double _a;
		private Double _b;
		private Double _min;
		private Double _max;

		#region Public Methods

		public override Double Fuzzify(Double inputValue)
		{
			//http://www.wolframalpha.com/input/?i=%28%28tanh%28%28x-50%29%2F10%29%29%2B1%29%2F2+from+-10+to+100
			var degreeOfMembership = (Math.Tanh((inputValue - _a) / _b) + 1.0) / 2.0;

			return degreeOfMembership;
		}

		public override Double Min()
		{
			return _min;
		}

		public override Double Max()
		{
			return _max;
		}

		#endregion


	}
}
