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
