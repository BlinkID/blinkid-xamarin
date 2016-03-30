using System;
using System.Collections.Generic;

namespace BlinkIDApp
{
	public class Messages
	{
		public static string BlinkIDResultsMessage = "BlinkIDResultsMessage";

		public class BlinkIDResults
		{
			public List<Dictionary<string, string>> Results { get; set; }
		}
	}
}

