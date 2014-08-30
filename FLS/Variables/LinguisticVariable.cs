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

namespace FLS
{
	/// <summary>
	/// A linguistic variable.
	/// </summary>
	public class LinguisticVariable : FuzzyRuleToken
	{
		#region Constructors

		public LinguisticVariable(string name)
			: base(name, FuzzyRuleTokenType.Variable)
		{
			_membershipFunctions = new MembershipFunctionCollection();
		}

		#endregion

		#region Private Properties

		private MembershipFunctionCollection _membershipFunctions;
		private Double _inputValue = 0;

		#endregion

		#region Public Properties

		/// <summary>
		/// A collection of the variable's membership functions.
		/// </summary>
		public MembershipFunctionCollection MembershipFunctions
		{
			get { return _membershipFunctions; }
			set { _membershipFunctions = value; }
		}

		public double InputValue
		{
			get { return _inputValue; }
			set { _inputValue = value; }
		}

		#endregion

	}
}
