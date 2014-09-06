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
using System.Reflection;
using System.Text;

namespace FLS
{
	public static class ObjectExtensions
	{
		public static Dictionary<String, object> PropertyValues(this Object obj)
		{
			Dictionary<String, object> values = new Dictionary<String, object>();
			try
			{
				PropertyInfo[] properties = obj.GetType().GetProperties();

				foreach (var property in properties)
				{
					values.Add(property.Name, property.GetValue(obj, null));
				}
			}
			catch (NullReferenceException e)
			{
				throw new ArgumentNullException("Parameters cannot be a null object", e);
			}

			return values;
		}
	}
}
