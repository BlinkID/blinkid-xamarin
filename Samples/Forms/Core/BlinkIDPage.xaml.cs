using System;
using BlinkIDFormsSample.Recognizers;
using BlinkIDFormsSample.Overlays;

using Xamarin.Forms;

namespace BlinkIDApp
{
	public partial class BlinkIDPage : ContentPage
	{
        IBlinkID blinkID;

        IMrtdRecognizer mrtdRecognizer;

		public BlinkIDPage ()
		{
			InitializeComponent ();

            blinkID = DependencyService.Get<IBlinkID>();
            blinkID.AndroidLicenseKey = "sRwAAAAeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lke7qv4oIhH4ywlU8/YH/8cm0jwA///VuPzhD+RzCIvUhrmq8qu2zEep/0tstNdNT74cwhbhHt6StRbB0eDF1A/f3TrMcZ7hQBLeml2T4349qxB2L9wMW1PBBm89B8grHAD66a38WEwXracWLmsdyZ2OQdNJTVlqXAhoE8uiSKQm+0DZTd2xKs3VyA/2QMLj9dUfs6csGHSwZsLFsuaxMgkHuv9z5Rg5oCDuAQ3EZYydnyZbq/9Q==";
            blinkID.IosLicenseKey = "sRwAAAEeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lks3unDF2B9jpa6FeAwxAdkXxaNOMEzJmfZ4hR21AVB8wknhBesyrlSBS0GhBEOmnINIQuUaYt5/35Ed6eOxOyXZeeSVl6eljzTY88HilqzAc4x4L1donsPivtU0wNm1Ew1efXkB4GIEzC4oHzkQDLiFegrSOXhZwxOTya1zIUw537gG/c52NSW67xV7k1ooTfaSK+JgADz3V4Sd4FAHXXNx47WwfV7qMe6cVal/9AtezVn5hocw==";

            // license keys must be set before creating Recognizer, othervise InvalidLicenseKeyException will be thrown
            mrtdRecognizer = DependencyService.Get<IMrtdRecognizer>();
            mrtdRecognizer.ReturnFullDocumentImage = true;

			// Display results in Editor
            MessagingCenter.Subscribe<Messages.ScanningDoneMessage> (this, Messages.ScanningDoneMessageId, (sender) => {
                var result = mrtdRecognizer.Result;

                string asString;

                if (sender.ScanningCancelled)
                {
                    asString = "Scanning cancelled";
                }
                else
                {
                    asString = "PrimaryID: " + result.MrzResult.PrimaryId + "\n" +
                               "SecondaryID: " + result.MrzResult.SecondaryId + "\n" +
                               "Date of birth: " + result.MrzResult.DateOfBirth.Day + "." + result.MrzResult.DateOfBirth.Month + "." + result.MrzResult.DateOfBirth.Year + ".";
                }

				Device.BeginInvokeOnMainThread (() => {
					resultsEditor.Text = asString;
                    fullDocumentImage.Source = result.FullDocumentImage;
				});

			});
		}

		void StartScan (object sender, EventArgs e)
		{
            var recognizerCollection = DependencyService.Get<IRecognizerCollectionFactory>().CreateRecognizerCollection(mrtdRecognizer);
            var documentOverlaySettings = DependencyService.Get<IDocumentOverlaySettingsFactory>().CreateDocumentOverlaySettings(recognizerCollection);


            blinkID.Scan(documentOverlaySettings);
		}
	}
}

