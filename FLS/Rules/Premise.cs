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
using System.Linq;
using System.Text;

namespace FLS.Rules
{
	/// <summary>
	/// The if-part of the rule
	/// </summary>
	public class Premise : List<FuzzyRuleCondition>
	{
		public Premise(FuzzyRuleCondition condition)
		{
			this.Add(condition);
		}
		public Premise(IEnumerable<FuzzyRuleCondition> conditions)
		{
			foreach (var condition in conditions)
			{
				Add(condition);
			}
		}


	}
}
