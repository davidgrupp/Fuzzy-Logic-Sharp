using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests.InferenceEngines
{
	[TestFixture]
	public class FuzzyEngineFactoryTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		[TestCase(FuzzyEngineType.CoG, typeof(CoGDefuzzification))]
		[TestCase(FuzzyEngineType.MoM, typeof(MoMDefuzzification))]
		public void Factory_EngineType_Success(FuzzyEngineType engineType, Type defuzzType)
		{
			//Arrange
			var factory = new FuzzyEngineFactory();

			//Act
			var engine = factory.Create(engineType);

			//Assert
			Assert.That(engine, Is.InstanceOf<FuzzyEngine>());
			Assert.That(engine.Defuzzification, Is.InstanceOf(defuzzType));
		}

		
	}
}
