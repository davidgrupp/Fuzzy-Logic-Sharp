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

namespace FLS.MembershipFunctions
{
	public class GaussianMembershipFunction : BaseMembershipFunction
	{
		public GaussianMembershipFunction(String name, Double c, Double tou, Double min, Double max)
			: base(name)
		{
			if (0 == tou)
				throw new ArgumentException(ErrorMessages.TouArgumentIsInvalid);

			_c = c;
			_tou = tou;
			_min = min;
			_max = max;
		}

		public GaussianMembershipFunction(String name, Double c, Double tou)
			: this(name, c, tou, 0, 200)
		{
		}

		private Double _c;
		private Double _tou;
		private Double _min;
		private Double _max;

		#region Public Methods

		public override Double Fuzzify(Double inputValue)
		{
			//http://www.wolframalpha.com/input/?i=e%5E%28%28-1%2F2%29%28%28x-50%29%2F20%29%5E2%29+for+x+%3D+50+

			var power = -0.5 * Math.Pow((inputValue - _c) / _tou, 2.0);
			return Math.Min(1.0, Math.Exp(power));
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
