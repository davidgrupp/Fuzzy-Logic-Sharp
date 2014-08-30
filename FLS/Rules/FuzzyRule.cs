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

namespace FLS.Rules
{
	/// <summary>
	/// A Fuzzy Rule.
	/// </summary>
	public class FuzzyRule
	{
		#region Public Properties

		public Premise Premise { get; set; }

		public Conclusion Conclusion { get; set; }

		#endregion

		#region Public Methods

		/// <summary>
		/// Determines if the current list of tokens is a valid rule.
		/// </summary>
		/// <returns>true if valid, false if invalid</returns>
		public virtual Boolean IsValid()
		{
			var premiseIsNotNull = null != Premise;
			var conclusionIsNotNull = null != Conclusion;
			if (premiseIsNotNull && conclusionIsNotNull)
			{
				var premiseHasAtLeastOneCondition = 0 < Premise.Count;
				var premiseIsValid = Premise.All(c => null != c && null != c.Variable && null != c.Operator && null != c.MembershipFunction);
				var conclusionIsValid = null != Conclusion.Variable && null != Conclusion.Operator && null != Conclusion.MembershipFunction;
				return premiseHasAtLeastOneCondition && premiseIsValid && conclusionIsValid;
			}
			else
			{
				return false;
			}
		}

		#endregion

	}
}
