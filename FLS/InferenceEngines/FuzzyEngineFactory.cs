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

namespace FLS
{
	public class FuzzyEngineFactory : IFuzzyEngineFactory
	{
		public FuzzyEngineFactory()
			: this(new FuzzyRuleEvaluator())
		{

		}

		public FuzzyEngineFactory(IFuzzyRuleEvaluator fuzzyRuleEvaluator)
		{
			_fuzzyRuleEvaluator = fuzzyRuleEvaluator;
		}

		#region Private Properties

		protected IFuzzyRuleEvaluator _fuzzyRuleEvaluator;

		#endregion

		public IFuzzyEngine Default()
		{
			return Create(new CoGDefuzzification());
		}

		public IFuzzyEngine Create(IDefuzzification defuzzification)
		{
			return new FuzzyEngine(defuzzification, _fuzzyRuleEvaluator);
		}

		public IFuzzyEngine Create(FuzzyEngineType type)
		{
			switch (type)
			{
				case FuzzyEngineType.CoG:
					return Create(new CoGDefuzzification());
				case FuzzyEngineType.MoM:
					return Create(new MoMDefuzzification());
				default:
					throw new ArgumentException("Cannot create engine with type.");
			}
		}
	}

	public enum FuzzyEngineType
	{
		CoG,
		MoM
	}
}
