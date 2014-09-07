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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.MembershipFunctions
{
	public class RectangleMembershipFunction : TrapezoidMembershipFunction
	{
		/// <param name="name">The name for the membership function.</param>
		/// <param name="a">The left most x value at 0 and 1.</param>
		/// <param name="b">The right most x value at 0 and 1.</param>
		public RectangleMembershipFunction(String name, Double a, Double b)
			: base(name, a, a, b, b)
		{

		}
	}
}
