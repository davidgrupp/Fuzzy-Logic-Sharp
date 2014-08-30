using FLS.Rules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.MembershipFunctions
{
	public class GaussianMembershipFunction : FuzzyRuleToken, IMembershipFunction, ICoGMembershipFunction, IMoMMembershipFunction
	{
		public GaussianMembershipFunction(String name, double c, double tou)
			: base(name, FuzzyRuleTokenType.Function)
		{
			_c = c;
			_tou = tou;
		}

		private double _c;
		private double _tou;

		public double Fuzzify(double inputValue)
		{
			var power = -0.5 * Math.Pow((inputValue - _c) / _tou, 2.0);
			return Math.Min(1.0, Math.Exp(power));
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
			return _c;
		}
	}
}
