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
using System.Threading.Tasks;

namespace FLS.MembershipFunctions
{
	public abstract class BaseMembershipFunction : FuzzyRuleToken, IMembershipFunction
	{
		#region ctors

		public BaseMembershipFunction(String name)
			: base(name, FuzzyRuleTokenType.Function)
		{

		}

		#endregion


		#region Private Properties

		private Double _premiseModifier = 0;

		#endregion

		#region public Properties

		public Double PremiseModifier
		{
			get
			{
				return _premiseModifier;
			}
			set
			{
				if (value > _premiseModifier)
					_premiseModifier = value;
			}
		}

		[Obsolete("Use PremiseModifier instead. Modification passes through to PremiseModifier.")]
		public Double Modification
		{
			get
			{
				return PremiseModifier;
			}
			set
			{
				PremiseModifier = value;
			}
		}

		#endregion

		#region Abstract Methods

		public abstract Double Fuzzify(Double inputValue);

		public abstract Double Min();

		public abstract Double Max();

		#endregion
	}
}
