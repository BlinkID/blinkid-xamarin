using System;
using System.Collections.Generic;

namespace Microblink.Forms.Shared
{
	public class Messages
	{
        public static string ScanningDoneMessageId = "ScanningDone";
        public class ScanningDoneMessage {
            public bool ScanningCancelled { get; set; }
        }
	}
}

