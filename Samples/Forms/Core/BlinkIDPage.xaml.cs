using System;
using Microblink.Forms.Core;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;

using Xamarin.Forms;

namespace BlinkIDApp
{
    public partial class BlinkIDPage : ContentPage
    {
        /// <summary>
        /// Microblink scanner is used for scanning the identity documents.
        /// </summary>
        IMicroblinkScanner blinkID;

        /// <summary>
        /// MRTD recognizer will be used for scanning Machine Readable Travel Documents (MRTDs), such as IDs and passports.
        /// </summary>
        IMrtdRecognizer mrtdRecognizer;

        /// <summary>
        /// This success frame grabber recognizer will wrap mrtdRecognizer and will contain camera frame of the moment
        /// when wrapped recognizer finished its recognition.
        /// </summary>
        ISuccessFrameGrabberRecognizer mrtdSuccessFrameGrabberRecognizer;

        /// <summary>
        /// USDL recognizer will be used for scanning barcode from back side of United States' driver's licenses.
        /// </summary>
        IUsdlRecognizer usdlRecognizer;

        /// <summary>
        /// This success frame grabber recognizer will wrap usdlRecognizer and will contain camera frame of the moment
        /// when wrapped recognizer finished its recognition.
        /// </summary>
        ISuccessFrameGrabberRecognizer usdlSuccessFrameGrabberRecognizer;

		public BlinkIDPage ()
		{
			InitializeComponent ();

            // before obtaining any of the recognizer's implementations from DependencyService, it is required
            // to obtain instance of IMicroblinkScanner and set the license key.
            // Failure to do so will crash your app.
            var microblinkFactory = DependencyService.Get<IMicroblinkScannerFactory>();

            // license keys are different for iOS and Android and depend on iOS bundleID/Android application ID
            // in your app, you may obtain the correct license key for your platform via DependencyService from
            // your Droid/iOS projects
            string licenseKey;

            // both these license keys are demo license keys for bundleID/applicationID com.microblink.xamarin.blinkid
            if (Device.RuntimePlatform == Device.iOS)
            {
                licenseKey = "sRwAAAEeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lks3unDF2B9jpa6FeAwxAdkXxaNOMEzJmfZ4hR21AVB8wknhBesyrlSBS0GhBEOmnINIQuUaYt5/35Ed6eOxOyXZeeSVl6eljzTY88HilqzAc4x4L1donsPivtU0wNm1Ew1efXkB4GIEzC4oHzkQDLiFegrSOXhZwxOTya1zIUw537gG/c52NSW67xV7k1ooTfaSK+JgADz3V4Sd4FAHXXNx47WwfV7qMe6cVal/9AtezVn5hocw==";    
            }
            else
            {
                licenseKey = "sRwAAAAeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lke7qv4oIhH4ywlU8/YH/8cm0jwA///VuPzhD+RzCIvUhrmq8qu2zEep/0tstNdNT74cwhbhHt6StRbB0eDF1A/f3TrMcZ7hQBLeml2T4349qxB2L9wMW1PBBm89B8grHAD66a38WEwXracWLmsdyZ2OQdNJTVlqXAhoE8uiSKQm+0DZTd2xKs3VyA/2QMLj9dUfs6csGHSwZsLFsuaxMgkHuv9z5Rg5oCDuAQ3EZYydnyZbq/9Q==";
            }

            // since DependencyService requires implementations to have default constructor, a factory is needed
            // to construct implementation of IMicroblinkScanner with given license key
            blinkID = microblinkFactory.CreateMicroblinkScanner(licenseKey);

            // license keys must be set before creating Recognizer, othervise InvalidLicenseKeyException will be thrown

            // the following code creates and sets up implementation of MrtdRecognizer
            mrtdRecognizer = DependencyService.Get<IMrtdRecognizer>();
            mrtdRecognizer.ReturnFullDocumentImage = true;

            // success frame grabber recognizer must be constructed with reference to its slave recognizer,
            // so we need to use factory to avoid DependencyService's limitations
            mrtdSuccessFrameGrabberRecognizer = DependencyService.Get<ISuccessFrameGrabberRecognizerFactory>().CreateSuccessFrameGrabberRecognizer(mrtdRecognizer);

            // the following code creates and sets up implementation of UsdlRecognizer
            usdlRecognizer = DependencyService.Get<IUsdlRecognizer>();

            // success frame grabber recognizer must be constructed with reference to its slave recognizer,
            // so we need to use factory to avoid DependencyService's limitations
            usdlSuccessFrameGrabberRecognizer = DependencyService.Get<ISuccessFrameGrabberRecognizerFactory>().CreateSuccessFrameGrabberRecognizer(usdlRecognizer);

            // subscribe to scanning done message
            MessagingCenter.Subscribe<Messages.ScanningDoneMessage> (this, Messages.ScanningDoneMessageId, (sender) => {
                ImageSource faceImageSource = null;
                ImageSource fullDocumentImageSource = null;
                ImageSource successFrameImageSource = null;

                string stringResult = "No valid results.";

                // if user cancelled scanning, sender.ScanningCancelled will be true
                if (sender.ScanningCancelled)
                {
                    stringResult = "Scanning cancelled";
                }
                else
                {
                    // otherwise, one or more recognizers used in RecognizerCollection (see StartScan method below)
                    // will contain result

                    // if specific recognizer's result's state is Valid, then it contains data recognized from image
                    if (mrtdRecognizer.Result.ResultState == RecognizerResultState.Valid)
                    {
                        var result = mrtdRecognizer.Result;
                        stringResult = "PrimaryID: " + result.MrzResult.PrimaryId + "\n" +
                                       "SecondaryID: " + result.MrzResult.SecondaryId + "\n" +
                                       "Nationality: " + result.MrzResult.Nationality + "\n" +
                                       "Gender: " + result.MrzResult.Gender + "\n" +
                                       "Date of birth: " + result.MrzResult.DateOfBirth.Day + "." + result.MrzResult.DateOfBirth.Month + "." + result.MrzResult.DateOfBirth.Year + ".";

                        fullDocumentImageSource = result.FullDocumentImage;
                        successFrameImageSource = mrtdSuccessFrameGrabberRecognizer.Result.SuccessFrame;
                    }

                    // similarly, we can check for results of other recognizers
                    if (usdlRecognizer.Result.ResultState == RecognizerResultState.Valid)
                    {
                        var result = usdlRecognizer.Result;
                        stringResult = 
                            "USDL version: " + result.GetField(UsdlKeys.StandardVersionNumber) + "\n" +
                            "Family name: " + result.GetField(UsdlKeys.CustomerFamilyName) + "\n" +
                            "First name: " + result.GetField(UsdlKeys.CustomerFirstName) + "\n" +
                            "Date of birth: " + result.GetField(UsdlKeys.DateOfBirth) + "\n" +
                            "Sex: " + result.GetField(UsdlKeys.Sex) + "\n" +
                            "Eye color: " + result.GetField(UsdlKeys.EyeColor) + "\n" +
                            "Height: " + result.GetField(UsdlKeys.Height) + "\n" +
                            "Street: " + result.GetField(UsdlKeys.AddressStreet) + "\n" +
                            "City: " + result.GetField(UsdlKeys.AddressCity) + "\n" +
                            "Jurisdiction: " + result.GetField(UsdlKeys.AddressJurisdictionCode) + "\n" +
                            "Postal code: " + result.GetField(UsdlKeys.AddressPostalCode) + "\n" +
                              // License information
                              "Issue date: " + result.GetField(UsdlKeys.DocumentIssueDate) + "\n" +
                              "Expiration date: " + result.GetField(UsdlKeys.DocumentExpirationDate) + "\n" +
                              "Issuer ID: " + result.GetField(UsdlKeys.IssuerIdentificationNumber) + "\n" +
                              "Jurisdiction version: " + result.GetField(UsdlKeys.JurisdictionVersionNumber) + "\n" +
                              "Vehicle class: " + result.GetField(UsdlKeys.JurisdictionVehicleClass) + "\n" +
                              "Restrictions: " + result.GetField(UsdlKeys.JurisdictionRestrictionCodes) + "\n" +
                              "Endorsments: " + result.GetField(UsdlKeys.JurisdictionEndorsementCodes) + "\n" +
                              "Customer ID: " + result.GetField(UsdlKeys.CustomerIdNumber);

                        successFrameImageSource = usdlSuccessFrameGrabberRecognizer.Result.SuccessFrame;
                    }
                }

                // updating the UI must be performed on main thread
                Device.BeginInvokeOnMainThread (() => {
                    resultsEditor.Text = stringResult;
                    fullDocumentImage.Source = fullDocumentImageSource;
                    successScanImage.Source = successFrameImageSource;
                    faceImage.Source = faceImageSource;
                });

            });
        }

        /// <summary>
        /// Button click event handler that will start the scanning procedure.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void StartScan (object sender, EventArgs e)
        {
            // first create a recognizer collection from all recognizers that you want to use in recognition
            // if some recognizer is wrapped with SuccessFrameGrabberRecognizer, then you should use only the wrapped one
            var recognizerCollection = DependencyService.Get<IRecognizerCollectionFactory>().CreateRecognizerCollection(mrtdSuccessFrameGrabberRecognizer, usdlSuccessFrameGrabberRecognizer);

            // using recognizerCollection, create overlay settings that will define the UI that will be used
            // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
            // document overlay settings is best for scanning identity documents
            var documentOverlaySettings = DependencyService.Get<IDocumentOverlaySettingsFactory>().CreateDocumentOverlaySettings(recognizerCollection);

            // start scanning
            blinkID.Scan(documentOverlaySettings);
        }
    }
}

