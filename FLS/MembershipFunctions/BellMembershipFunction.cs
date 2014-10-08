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
	public class BellMembershipFunction : BaseMembershipFunction
	{
		public BellMembershipFunction(String name, Double a, Double b, Double c, Double min, Double max)
			: base(name)
		{
			if (0 == a)
				throw new ArgumentException(ErrorMessages.AArgumentIsInvalid);
			_a = a;
			_b = b;
			_c = c;
			_min = min;
			_max = max;
		}

		public BellMembershipFunction(String name, Double a, Double b, Double c)
			: this(name, a, b, c, 0, 200)
		{
		}

		private Double _min;
		private Double _max;
		private Double _a;
		private Double _b;
		private Double _c;


		#region Public Methods

		public override Double Fuzzify(Double inputValue)
		{
			//http://www.wolframalpha.com/input/?i=1%2F%281%2B%28Abs%28%28x-50%29%2F15%29%29%5E%282*3%29%29+from+-20+to+100

			var power = 1 + Math.Abs(Math.Pow((inputValue - _c) / _a, 2.0 * _b));
			return Math.Max(0, Math.Min(1.0, 1.0 / power));
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
