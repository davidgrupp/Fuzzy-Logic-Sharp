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
	public class BellMembershipFunction : FuzzyRuleToken, IMembershipFunction
	{
		public BellMembershipFunction(String name, double a, double b, double c)
			: base(name, FuzzyRuleTokenType.Function)
		{
			if (0 == a)
				throw new ArgumentException(ErrorMessages.AArgumentIsInvalid);
			_a = a;
			_b = b;
			_c = c;
		}

		private double _a;
		private double _b;
		private double _c;


		#region Public Methods

		public virtual double Fuzzify(double inputValue)
		{
			//http://www.wolframalpha.com/input/?i=1%2F%281%2B%28Abs%28%28x-50%29%2F15%29%29%5E%282*3%29%29+from+-20+to+100

			var power = 1 + Math.Abs(Math.Pow((inputValue - _c) / _a, 2.0 * _b));
			return Math.Max(0, Math.Min(1.0, 1.0 / power));
		}

		public virtual Double Min()
		{
			return 0;
		}

		public virtual Double Max()
		{
			return 200;
		}

		#endregion

		#region public Properties

		public Double Modification { get; set; }

		#endregion


	}
}
