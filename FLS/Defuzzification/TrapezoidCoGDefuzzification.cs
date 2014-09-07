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
				numerator += TrapezoidCentroid(function) * TrapezoidArea(function);
				denominator += TrapezoidArea(function);
			}

			return (0 != denominator) ? numerator / denominator : 0;
		}

		private Double TrapezoidArea(TrapezoidMembershipFunction function)
		{
			Double a = TrapezoidCentroid(function) - function.A;
			Double b = function.C - function.A;

			return (function.Modification * (b + (b - (a * function.Modification)))) / 2;
		}

		private Double TrapezoidCentroid(TrapezoidMembershipFunction function)
		{
			Double a = function.C - function.B;
			Double b = function.D - function.A;
			Double c = function.B - function.A;

			return ((2 * a * c) + (a * a) + (c * b) + (a * b) + (b * b)) / (3 * (a + b)) + function.A;
		}
	}
}
