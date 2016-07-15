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

			// Display results in Editor
			MessagingCenter.Subscribe<Messages.BlinkIDResults> (this, Messages.BlinkIDResultsMessage, (sender) => {
				Debug.WriteLine (sender.Results);

				string asString = "";

				foreach (var result in sender.Results) {
					asString += string.Join (";", result);
				}

				Device.BeginInvokeOnMainThread (() => {
					resultsEditor.Text = asString;
				});

			});

			// Display metadata image in Image
			MessagingCenter.Subscribe<Messages.BlinkIDImage> (this, Messages.BlinkIDImageMessage, (sender) => {
				Device.BeginInvokeOnMainThread (() => {
					metadataImage.Source = sender.Image;
				});
			});
		}

		void StartScan (object sender, EventArgs e)
		{
			var blinkId = DependencyService.Get<IBlinkID> ();
			blinkId.Scan ();
		}
	}
}

