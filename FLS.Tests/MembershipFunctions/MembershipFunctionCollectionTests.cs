using FLS.MembershipFunctions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests.MembershipFunctions
{
	[TestFixture]
	public class MembershipFunctionCollectionTests
	{
		[SetUp]
		public void Setup()
		{

		}

		[Test]
		public void MembershipFunctionCollection_Types_Success()
		{
			//Arrange
			var collection = new MembershipFunctionCollection();

			//Act
			var trap = collection.AddTrapezoid("trap", 0, 0, 20, 40);
			var tri = collection.AddTriangle("tri", 20, 40, 60);
			collection.AddGaussian("gaus", 50, 20);
			collection.AddComposite("comp", trap, tri, 20);

			//Assert
			Assert.That(collection.Any(mf => mf is TrapezoidMembershipFunction), Is.True, "Trapezoid");
			Assert.That(collection.Any(mf => mf is TriangleMembershipFunction), Is.True, "Triangle");
			Assert.That(collection.Any(mf => mf is GaussianMembershipFunction), Is.True, "Gaussian");
			Assert.That(collection.Any(mf => mf is CompositeMembershipFunction), Is.True, "Composite");
		}


	}
}
