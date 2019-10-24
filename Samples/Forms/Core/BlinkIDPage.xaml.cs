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
        /// BlinkID recognizer will be used for automatic detection and data extraction from the supported document.
        /// </summary>
        IBlinkIdRecognizer blinkidRecognizer;

        /// <summary>
        /// USDL recognizer will be used for scanning barcode from back side of United States' driver's licenses.
        /// </summary>
        //IUsdlRecognizer usdlRecognizer;

        /// <summary>
        /// This success frame grabber recognizer will wrap usdlRecognizer and will contain camera frame of the moment
        /// when wrapped recognizer finished its recognition.
        /// </summary>
        //ISuccessFrameGrabberRecognizer usdlSuccessFrameGrabberRecognizer;

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
                licenseKey = "sRwAAAEeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lks3unDL+B9jpa6FeAwwR59En984J4Ii3FbxJsLnbDNmxYX1B6I2Wziz/GdpHQk8xYx/+WyaLzil0hiI2oRujoEfQawqvM/FGqhb154jOM8Azuj3p/P54XONjcVB8TjcEDdskWFBuH22Bw6iKCpUrj47CkWGFJb5vv+wQQW9DpF5wH04AnFETMVTsQdqDD2Mio7F3L+eu0xnKtPjyaT73NOHhNEsQDf17F5B+Q7Pd0spOPzGxvVvP73xrsam69NmbmQanB3n+ggL0=";
            }
            else
            {
                licenseKey = "sRwAAAAeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lke7qv4mAhH4ywlU8/YOseEDpc37NgwX0A5o+Tylp/16TUJXSBrGxWr7uFg4F2MWT0+nFMV7Yxf2i9FuRMy13dXgBOhfll1M8RoclQikWapjwiX0jBDOZm2xUlNII3g9nisGbyhkhszCb2/UdhNdQSi7JgLxWRUdx6rMBgHdjsP+P32uNh6fcgopSaOAkpdsoHBMD5rFWJBXlbqa1Ij04EuRHIFZGKJobTmt5dxgA6zyowaXw8zvR6WA33JEKkE7c4nw2MyaBtxWw=";
            }

            // since DependencyService requires implementations to have default constructor, a factory is needed
            // to construct implementation of IMicroblinkScanner with given license key
            blinkID = microblinkFactory.CreateMicroblinkScanner(licenseKey);

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
                    if (blinkidRecognizer.Result.ResultState == RecognizerResultState.Valid)
                    {
                        var blinkidResult = blinkidRecognizer.Result;
                        stringResult =
                            "BlinkID recognizer result:\n" +
                            "FirstName: " + blinkidResult.FirstName + "\n" +
                            "LastName: " + blinkidResult.LastName + "\n" +
                            "Address: " + blinkidResult.Address + "\n" +
                            "DocumentNumber: " + blinkidResult.DocumentNumber + "\n" +
                            "Sex: " + blinkidResult.Sex + "\n";
                        var dob = blinkidResult.DateOfBirth;
                        if (dob != null)
                        {
                            stringResult +=
                                "DateOfBirth: " + dob.Day + "." +
                                                  dob.Month + "." +
                                                  dob.Year + ".\n";
                        }
                        var doi = blinkidResult.DateOfIssue;
                        {
                            stringResult +=
                                "DateOfIssue: " + doi.Day + "." +
                                                  doi.Month + "." +
                                                  doi.Year + ".\n";

                        }
                        var doe = blinkidResult.DateOfExpiry;
                        if (doe != null)
                        {
                            stringResult +=
                                "DateOfExpiry: " + doe.Day + "." +
                                                   doe.Month + "." +
                                                   doe.Year + ".\n";

                        }
                        // there are other fields to extract

                        fullDocumentImageSource = blinkidResult.FullDocumentImage;
                    }

                    // similarly, we can check for results of other recognizers
                    //if (usdlRecognizer.Result.ResultState == RecognizerResultState.Valid)
                    //{
                    //    var result = usdlRecognizer.Result;
                    //    stringResult = 
                    //        "USDL version: " + result.GetField(UsdlKeys.StandardVersionNumber) + "\n" +
                    //        "Family name: " + result.GetField(UsdlKeys.CustomerFamilyName) + "\n" +
                    //        "First name: " + result.GetField(UsdlKeys.CustomerFirstName) + "\n" +
                    //        "Date of birth: " + result.GetField(UsdlKeys.DateOfBirth) + "\n" +
                    //        "Sex: " + result.GetField(UsdlKeys.Sex) + "\n" +
                    //        "Eye color: " + result.GetField(UsdlKeys.EyeColor) + "\n" +
                    //        "Height: " + result.GetField(UsdlKeys.Height) + "\n" +
                    //        "Street: " + result.GetField(UsdlKeys.AddressStreet) + "\n" +
                    //        "City: " + result.GetField(UsdlKeys.AddressCity) + "\n" +
                    //        "Jurisdiction: " + result.GetField(UsdlKeys.AddressJurisdictionCode) + "\n" +
                    //        "Postal code: " + result.GetField(UsdlKeys.AddressPostalCode) + "\n" +
                    //          // License information
                    //          "Issue date: " + result.GetField(UsdlKeys.DocumentIssueDate) + "\n" +
                    //          "Expiration date: " + result.GetField(UsdlKeys.DocumentExpirationDate) + "\n" +
                    //          "Issuer ID: " + result.GetField(UsdlKeys.IssuerIdentificationNumber) + "\n" +
                    //          "Jurisdiction version: " + result.GetField(UsdlKeys.JurisdictionVersionNumber) + "\n" +
                    //          "Vehicle class: " + result.GetField(UsdlKeys.JurisdictionVehicleClass) + "\n" +
                    //          "Restrictions: " + result.GetField(UsdlKeys.JurisdictionRestrictionCodes) + "\n" +
                    //          "Endorsments: " + result.GetField(UsdlKeys.JurisdictionEndorsementCodes) + "\n" +
                    //          "Customer ID: " + result.GetField(UsdlKeys.CustomerIdNumber);

                    //    successFrameImageSource = usdlSuccessFrameGrabberRecognizer.Result.SuccessFrame;
                    //}
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
            // license keys must be set before creating Recognizer, othervise InvalidLicenseKeyException will be thrown
            // the following code creates and sets up implementation of MrtdRecognizer
            blinkidRecognizer = DependencyService.Get<IBlinkIdRecognizer>(DependencyFetchTarget.NewInstance);
            blinkidRecognizer.ReturnFullDocumentImage = true;

            // the following code creates and sets up implementation of UsdlRecognizer
            //usdlRecognizer = DependencyService.Get<IUsdlRecognizer>(DependencyFetchTarget.NewInstance);

            // success frame grabber recognizer must be constructed with reference to its slave recognizer,
            // so we need to use factory to avoid DependencyService's limitations
            //usdlSuccessFrameGrabberRecognizer = DependencyService.Get<ISuccessFrameGrabberRecognizerFactory>(DependencyFetchTarget.NewInstance).CreateSuccessFrameGrabberRecognizer(usdlRecognizer);

            // first create a recognizer collection from all recognizers that you want to use in recognition
            // if some recognizer is wrapped with SuccessFrameGrabberRecognizer, then you should use only the wrapped one
            var recognizerCollection = DependencyService.Get<IRecognizerCollectionFactory>().CreateRecognizerCollection(blinkidRecognizer/*, usdlSuccessFrameGrabberRecognizer*/);

            // using recognizerCollection, create overlay settings that will define the UI that will be used
            // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
            // document overlay settings is best for scanning identity documents
            var blinkidOverlaySettings = DependencyService.Get<IBlinkIdOverlaySettingsFactory>().CreateBlinkIdOverlaySettings(recognizerCollection);

            // start scanning
            blinkID.Scan(blinkidOverlaySettings);
        }
    }
}

