using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS
{
	public interface IFuzzyEngineFactory
	{
		IFuzzyEngine GetDefault();
		
		IFuzzyEngine GetEngine<T>() where T : IFuzzyEngine, new();

		IFuzzyEngine GetEngine(FuzzyEngineType type);
	}
}
