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
				throw new ArgumentNullException("Paramters cannot be a null object", e);
			}

			return values;
		}
	}
}
