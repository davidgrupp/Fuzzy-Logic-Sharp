using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Linq;

namespace FLS.MembershipFunctions
{
	/// <summary>
	/// A collection of membership functions.
	/// </summary>
	public class MembershipFunctionCollection : Collection<IMembershipFunction>
	{
		#region Public Methods

		public IMembershipFunction AddTrapezoid(String name, Double x0, Double x1, Double x2, Double x3)
		{
			var memFunc = new TrapezoidMembershipFunction(name, x0, x1, x2, x3);
			this.Add(memFunc);
			return memFunc;
		}

		public IMembershipFunction AddTriangle(String name, Double x0, Double x1, Double x2)
		{
			var memFunc = new TriangleMembershipFunction(name, x0, x1, x2);
			this.Add(memFunc);
			return memFunc;
		}

		public IMembershipFunction AddGaussian(String name, Double c, Double tou)
		{
			var memFunc = new GaussianMembershipFunction(name, c, tou);
			this.Add(memFunc);
			return memFunc;
		}

		public IMembershipFunction AddComposite(String name, IMembershipFunction left, IMembershipFunction right, double midPoint)
		{
			var memFunc = new CompositeMembershipFunction(name, left, right, midPoint);
			this.Add(memFunc);
			return memFunc;
		}

		#endregion
	}
}
