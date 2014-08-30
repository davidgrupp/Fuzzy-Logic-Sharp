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
