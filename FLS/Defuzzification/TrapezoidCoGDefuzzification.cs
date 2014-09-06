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
			double a = TrapezoidCentroid(function) - function.A;
			double b = function.C - function.A;

			return (function.Modification * (b + (b - (a * function.Modification)))) / 2;
		}

		private Double TrapezoidCentroid(TrapezoidMembershipFunction function)
		{
			double a = function.C - function.B;
			double b = function.D - function.A;
			double c = function.B - function.A;

			return ((2 * a * c) + (a * a) + (c * b) + (a * b) + (b * b)) / (3 * (a + b)) + function.A;
		}
	}
}
