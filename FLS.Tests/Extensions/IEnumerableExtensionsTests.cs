#region License and Terms
// MoreLINQ - Extensions to LINQ to Objects
// Copyright (c) 2008 Jonathan Skeet. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
#endregion

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using FLS;

namespace MoreLinq.Test
{
	[TestFixture]
	public class DistinctByTest
	{
		[Test]
		public void DistinctBy()
		{
			string[] source = { "first", "second", "third", "fourth", "fifth" };
			var distinct = source.DistinctBy(word => word.Length);
			distinct.AssertSequenceEqual("first", "second");
		}

		[Test]
		public void DistinctByNullSequence()
		{
			string[] source = null;
			var result = new TestDelegate(() => source.DistinctBy(x => x.Length));
			Assert.Throws(Is.InstanceOf(typeof(ArgumentNullException)), result);
		}

		[Test]
		public void DistinctByNullKeySelector()
		{
			string[] source = Array.Empty<string>();
			var result = new TestDelegate(() => source.DistinctBy((Func<string, string>)null));
			Assert.Throws(Is.InstanceOf(typeof(ArgumentNullException)), result);
		}

		[Test]
		public void DistinctByWithComparer()
		{
			string[] source = { "first", "FIRST", "second", "second", "third" };
			var distinct = source.DistinctBy(word => word, StringComparer.OrdinalIgnoreCase);
			distinct.AssertSequenceEqual("first", "second", "third");
		}

		[Test]
		public void DistinctByNullSequenceWithComparer()
		{
			string[] source = null;
			var result = new TestDelegate(() => source.DistinctBy(x => x, StringComparer.Ordinal));
			Assert.Throws(Is.InstanceOf(typeof(ArgumentNullException)), result);
		}

		[Test]
		public void DistinctByNullKeySelectorWithComparer()
		{
			string[] source = Array.Empty<string>();
			var result = new TestDelegate(() => source.DistinctBy(null, StringComparer.Ordinal));
			Assert.Throws(Is.InstanceOf(typeof(ArgumentNullException)), result);
		}

		[Test]
		public void DistinctByNullComparer()
		{
			string[] source = { "first", "second", "third", "fourth", "fifth" };
			var distinct = source.DistinctBy(word => word.Length, null);
			distinct.AssertSequenceEqual("first", "second");
		}

		[Test]
		public void ForEach_Success()
		{
			var sum = String.Empty;
			string[] source = { "first", "second", "third", "fourth", "fifth" };
			source.ForEach(word => sum += word);
			Assert.That(sum, Is.EqualTo("first" + "second" + "third" + "fourth" + "fifth"));
		}

		[Test]
		public void ForEach_NullAction_Success()
		{
			string[] source = Array.Empty<string>();
			var result = new TestDelegate(() => source.ForEach(null));
			Assert.Throws(Is.InstanceOf(typeof(ArgumentNullException)), result);
		}

		[Test]
		public void ForEach_NullSource_Success()
		{
			string[] source = null;
			var result = new TestDelegate(() => source.ForEach(word => word.ToLower()));
			Assert.Throws(Is.InstanceOf(typeof(ArgumentNullException)), result);
		}
	}

	internal static class TestExtensions
	{
		/// <summary>
		/// Make testing even easier - a params array makes for readable tests :)
		/// The sequence is evaluated exactly once.
		/// </summary>
		internal static void AssertSequenceEqual<T>(this IEnumerable<T> actual, params T[] expected)
		{
			// Working with a copy means we can look over it more than once.
			// We're safe to do that with the array anyway.
			List<T> copy = actual.ToList();
			bool result = copy.SequenceEqual(expected);
			// Looks nicer than Assert.IsTrue or Assert.That, unfortunately.
			if (!result)
			{
				Assert.Fail("Expected: " +
					",".InsertBetween(expected.Select(x => Convert.ToString(x))) + "; was: " +
					",".InsertBetween(copy.Select(x => Convert.ToString(x))));
			}
		}

		internal static string InsertBetween(this string delimiter, IEnumerable<string> items)
		{
			StringBuilder builder = new StringBuilder();
			foreach (string item in items)
			{
				if (builder.Length != 0)
				{
					builder.Append(delimiter);
				}
				builder.Append(item);
			}
			return builder.ToString();
		}



	}
}