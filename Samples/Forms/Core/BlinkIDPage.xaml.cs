using System;
using System.Collections.Generic;

using Xamarin.Forms;
using System.Diagnostics;

namespace BlinkIDApp
{
	public partial class BlinkIDPage : ContentPage
	{
		public BlinkIDPage ()
		{
			InitializeComponent ();

			MessagingCenter.Subscribe<Messages.BlinkIDResults> (this, Messages.BlinkIDResultsMessage, (sender) => {
				Debug.WriteLine (sender.Results);

				string asString = "";

				foreach (var result in sender.Results) {
					asString += string.Join(";", result);
				}

				resultsEditor.Text = asString;
			});
		}

		void StartScan(object sender, EventArgs e) {
			var blinkId = DependencyService.Get<IBlinkID> ();
			blinkId.Scan ();
		}
	}
}

