using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FLS.Tests
{
	public static class TestUtilities
	{
		public static String GetTestAssemblyDirectory()
		{
			String codeBase = System.Reflection.Assembly.GetExecutingAssembly().CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			String path = Uri.UnescapeDataString(uri.Path);
			return System.IO.Path.GetDirectoryName(path);
		}
	}
}
