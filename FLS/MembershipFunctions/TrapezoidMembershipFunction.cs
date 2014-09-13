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
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using FLS.Rules;
using FLS.MembershipFunctions;

namespace FLS.MembershipFunctions
{
	/// <summary>
	/// A membership function.
	/// </summary>
	public class TrapezoidMembershipFunction : BaseMembershipFunction
	{
		#region Private Properties

		private Double _a = 0;
		private Double _b = 0;
		private Double _c = 0;
		private Double _d = 0;

		#endregion

		#region Constructors

		/// <param name="name">The name for the membership function.</param>
		/// <param name="a">The left most x value at 0.</param>
		/// <param name="b">The mid left x value at 1.</param>
		/// <param name="c">The mid right x value at 1.</param>
		/// <param name="d">The right most x value at 1.</param>
		public TrapezoidMembershipFunction(String name, Double a, Double b, Double c, Double d)
			: base(name)
		{
			_a = a;
			_b = b;
			_c = c;
			_d = d;
		}

		#endregion

		#region public Properties

		public Double A { get { return _a; } }

		public Double B { get { return _b; } }

		public Double C { get { return _c; } }

		public Double D { get { return _d; } }

		#endregion

		#region Public Methods

		/// <summary>
		/// Calculates a crisp value's degree of membership.
		/// </summary>
		/// <param name="inputValue">The crisp value to fuzzify.</param>
		/// <returns>The degree of membership.</returns>
		public override Double Fuzzify(Double inputValue)
		{
			if (_a <= inputValue && inputValue < _b)
				return (inputValue - _a) / (_b - _a);
			else if (_b <= inputValue && inputValue <= _c)
				return 1;
			else if (_c < inputValue && inputValue <= _d)
				return (_d - inputValue) / (_d - _c);
			else
				return 0;
		}

		public override Double Min()
		{
			return _a;
		}

		public override Double Max()
		{
			return _d;
		}

		#endregion

		
	}
}
