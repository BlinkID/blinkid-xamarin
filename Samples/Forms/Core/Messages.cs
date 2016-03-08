using System;
using System.Collections.Generic;

namespace BlinkIDApp
{
	public class Messages
	{
		public static string BlinkIDResultsMessage = "BlinkIDResultsMessage";

		public class BlinkIDResults
		{
			public IList<IDictionary<string, string>> Results { get; set; }
		}
	}
}

