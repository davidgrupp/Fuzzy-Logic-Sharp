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
	public class GaussianMembershipFunction : FuzzyRuleToken, IMembershipFunction
	{
		public GaussianMembershipFunction(String name, double c, double tou)
			: base(name, FuzzyRuleTokenType.Function)
		{
			_c = c;
			_tou = tou;
		}

		private double _c;
		private double _tou;

		#region Public Methods

		public virtual double Fuzzify(double inputValue)
		{
			var power = -0.5 * Math.Pow((inputValue - _c) / _tou, 2.0);
			return Math.Min(1.0, Math.Exp(power));
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
