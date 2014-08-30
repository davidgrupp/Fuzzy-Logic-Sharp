using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS.MembershipFunctions
{
	public class TriangleMembershipFunction : TrapezoidMembershipFunction
	{
		/// <param name="name">The name for the membership function.</param>
		/// <param name="a">The left most x value at 0.</param>
		/// <param name="b">The middle x value at 1.</param>
		/// <param name="c">The right most x value at 0.</param>
		public TriangleMembershipFunction(String name, Double a, Double b, Double c)
			: base(name, a, b, b, c)
		{

		}
	}
}
