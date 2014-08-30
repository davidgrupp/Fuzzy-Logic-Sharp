using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FLS
{
	public class FuzzyEngineFactory : IFuzzyEngineFactory
	{
		public IFuzzyEngine GetDefault()
		{
			return new CoGFuzzyEngine();
		}

		public IFuzzyEngine GetEngine<T>() where T : IFuzzyEngine, new()
		{
			return new T();
		}

		public IFuzzyEngine GetEngine(FuzzyEngineType type)
		{
			switch (type)
			{
				case FuzzyEngineType.CoG:
					return new CoGFuzzyEngine();
				case FuzzyEngineType.MoM:
					return new MoMFuzzyEngine();
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
