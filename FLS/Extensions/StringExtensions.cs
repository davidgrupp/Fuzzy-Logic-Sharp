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
using System.Linq;
using System.Text;

namespace FLS
{
	public static class StringExtenstions
	{
		public static String[] Split(this String value, String characters)
		{
			return value.Split(characters, StringSplitOptions.None);
		}

		public static String[] Split(this String value, String characters, StringSplitOptions stringSplitOptions)
		{
			return value.Split(new String[1] { characters }, stringSplitOptions);
		}

		public static String Join(this IEnumerable<String> value, String aggregateFormat)
		{
			if (0 >= value.Count())
				return String.Empty;

			return value.Aggregate((x1, x2) => String.Format(aggregateFormat, x1, x2));
		}

		public static String Join<T>(this IEnumerable<T> value, String aggregateFormat)
		{
			if (0 >= value.Count())
				return String.Empty;

			return value.Select(x => x.ToString()).Join(aggregateFormat);
		}
	}
}
