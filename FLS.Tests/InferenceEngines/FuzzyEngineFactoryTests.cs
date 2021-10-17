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
using NUnit.Framework;
using System;

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
