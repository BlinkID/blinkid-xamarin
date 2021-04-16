using System;
using System.Collections.Generic;

namespace BlinkID.Forms.Core
{
    /// <summary>
    /// Contains messages that can be exchanged between Xamarin Forms app and 
    /// Microblink scanner.
    /// </summary>
	public class Messages
	{
        /// <summary>
        /// The scanning done message identifier.
        /// </summary>
        public static string ScanningDoneMessageId = "ScanningDone";
        /// <summary>
        /// Scanning done message.
        /// </summary>
        public class ScanningDoneMessage {
            /// <summary>
            /// Gets a value indicating whether scanning was cancelled.
            /// </summary>
            /// <value><c>true</c> if scanning cancelled; otherwise, <c>false</c>.</value>
            public bool ScanningCancelled { get; set; }
        }
	}
}