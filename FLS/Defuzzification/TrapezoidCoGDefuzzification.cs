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
using FLS.MembershipFunctions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS
{
	/// <summary>
	/// Uses the Center of Gravity method to calculate the defuzzification of membership functions.
	/// This is faster alternative method to the other CoGDefuzzification class specifically for 
	/// trapezoid and triangle membership functions
	/// </summary>
	public class TrapezoidCoGDefuzzification : IDefuzzification
	{
		public Double Defuzzify(List<IMembershipFunction> functions)
		{
			if (functions.Any(f => false == f is TrapezoidMembershipFunction))
				throw new ArgumentException(ErrorMessages.AllMembershipFunctionsMustBeTrapezoid);

			Double numerator = 0;
			Double denominator = 0;

			foreach (var function in functions.Select(f => f as TrapezoidMembershipFunction))
			{
				var trapCent = TrapezoidCentroid(function);
				var trapArea = TrapezoidArea(function, trapCent);
				numerator += trapCent * trapArea;
				denominator += trapArea;
			}

			return (0 != denominator) ? numerator / denominator : 0;
		}

		private Double TrapezoidArea(TrapezoidMembershipFunction f, Double centroid)
		{
			return ((f.C - f.B) + (f.D - f.A)) * f.PremiseModifier;
		}

		private Double TrapezoidCentroid(TrapezoidMembershipFunction f)
		{
			var top = f.C - f.B;
			var bot = f.D - f.A;

			var tm = f.B + (top / 2.0); //top midpoint
			var bm = f.A + (bot / 2.0); //bottom midpoint
			if (tm == bm)
				return tm;

			//y value for the centroid
			var y = ((2.0 * top) + bot) / (top + bot);
			y = y / 3.0;

			var mRecip = (tm - bm); // mRecip =  (1 / m)
			var b = (bm / mRecip);

			return (y + b) * mRecip;
		}
	}
}
