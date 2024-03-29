﻿using System;
using BlinkID.Forms.Core;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.Core.Recognizers;

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
        /// BlinkID Combined recognizer will be used for automatic detection and data extraction from the supported document.
        /// </summary>
        IBlinkIdCombinedRecognizer blinkidRecognizer;

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

            // both these license keys are demo license keys for bundleID/applicationID com.microblink.sample
            if (Device.RuntimePlatform == Device.iOS)
            {
                licenseKey = "sRwAAAEVY29tLm1pY3JvYmxpbmsuc2FtcGxl1BIcP4FpSuS/38KlOWaNNOdhCR8jZQy8ZovXZ5Aq0bmGObJNpZvi2Gbw7+2OComAtSRhlWEr/OMOOdEKmceqWXZ+qX/TfMON1D6n0f4OApDQcXQW+7nhK9W/NdfSgXxrkhqTL5boSwopLixLNHLDaw47WmQ+7UVWRb4xZovVFmKtX+pwBW/YoFC5U3eWdtnL/6sPEaBRii0f8k7f4nyzHILHmlU9YTuhIuZz8CwOhgoeeJ1RyBelPvN3kRxHuQxXUhSxA8dqABW8fCS1Ddp8JKoaocEQqJS3pABSqakIf3NuK2kIsF6OGyTfhDbyQfpD8amqNJshSFaNNxYjbtNYJtQHQA==";
            }
            else
            {
                licenseKey = "sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdZhZkGlTu9XHOXtHZ5sEIxfrd8QRtGUpBIN4H59/oIIoDep7g5k2bvWM6ectjLQNLLa+8uVtpNekwbLYvD+HFqTXNY78QiDkaZovM6KnsU9ChZhZOoM1du4CJwbGrzRq/+xBNsI6hPWP0PCJyWPADScdvMzlS7hJd4l4IsuPJ2wuUprFFdE9woA68ojyCeu0jj9/5mBfZMqLZ7tZPGzji5q+ZTjqL9ZHHI7ZNHj/SFoOOdH29/fGqW0efquPs+QLtF75pbJ0+rUpTVQH5apFVM9BOvMprs0gE975dNfpgjfBSBtahqqW9XTMlp79Th1/Ht6+w+rYKZUi7O24WBHqUA==";
            }

            // since DependencyService requires implementations to have default constructor, a factory is needed
            // to construct implementation of IMicroblinkScanner with given license key
            blinkID = microblinkFactory.CreateMicroblinkScanner(licenseKey);

            // subscribe to scanning done message
            MessagingCenter.Subscribe<Messages.ScanningDoneMessage> (this, Messages.ScanningDoneMessageId, (sender) => {
                ImageSource faceImageSource = null;
                ImageSource fullDocumentFrontImageSource = null;
                ImageSource fullDocumentBackImageSource = null;
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
                            BuildResult(blinkidResult.FirstName, "First name") +
                            BuildResult(blinkidResult.LastName, "Last name") +
                            BuildResult(blinkidResult.FullName, "Full name") +
                            BuildResult(blinkidResult.LocalizedName, "Localized name") +
                            BuildResult(blinkidResult.AdditionalNameInformation, "Additional name info") +
                            BuildResult(blinkidResult.Address, "Address") +
                            BuildResult(blinkidResult.AdditionalAddressInformation, "Additional address info") +
                            BuildResult(blinkidResult.AdditionalOptionalAddressInformation, "Additional optional address info") +
                            BuildResult(blinkidResult.DocumentNumber, "Document number") +
                            BuildResult(blinkidResult.DocumentAdditionalNumber, "Additional document number") +
                            BuildResult(blinkidResult.Sex, "Sex") +
                            BuildResult(blinkidResult.IssuingAuthority, "Issuing authority") +
                            BuildResult(blinkidResult.Nationality, "Nationality") +
                            BuildResult(blinkidResult.DateOfBirth, "DateOfBirth") +
                            BuildResult(blinkidResult.Age, "Age") +
                            BuildResult(blinkidResult.DateOfIssue, "Date of issue") +
                            BuildResult(blinkidResult.DateOfExpiry, "Date of expiry") +
                            BuildResult(blinkidResult.DateOfExpiryPermanent, "Date of expiry permanent") +
                            BuildResult(blinkidResult.MaritalStatus, "Martial status") +
                            BuildResult(blinkidResult.PersonalIdNumber, "Personal Id Number") +
                            BuildResult(blinkidResult.Profession, "Profession") +
                            BuildResult(blinkidResult.Race, "Race") +
                            BuildResult(blinkidResult.Religion, "Religion") +
                            BuildResult(blinkidResult.ResidentialStatus, "Residential Status") +
                            BuildResult(" ", "Data Match Detailed Info") +
                            BuildResult(blinkidResult.DataMatchDetailedInfo.DataMatchResult.ToString(), "> Data Match Result") +
                            BuildResult(blinkidResult.DataMatchDetailedInfo.DateOfBirth.ToString(), "> Date Of Birth") +
                            BuildResult(blinkidResult.DataMatchDetailedInfo.DateOfExpiry.ToString(), "> Date Of Expiry") +
                            BuildResult(blinkidResult.DataMatchDetailedInfo.DocumentNumber.ToString(), "> Document Number");

                        IDriverLicenseDetailedInfo licenceInfo = blinkidResult.DriverLicenseDetailedInfo;
                        if (licenceInfo != null)
                        {
                            stringResult +=
                                BuildResult(licenceInfo.Restrictions, "Restrictions") +
                                BuildResult(licenceInfo.Endorsements, "Endorsements") +
                                BuildResult(licenceInfo.VehicleClass, "Vehicle class") +
                                BuildResult(licenceInfo.Conditions, "Conditions");

                        }

                        fullDocumentFrontImageSource = blinkidResult.FullDocumentFrontImage;
                        fullDocumentBackImageSource = blinkidResult.FullDocumentBackImage;
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
                    fullDocumentFrontImage.Source = fullDocumentFrontImageSource;
                    fullDocumentBackImage.Source = fullDocumentBackImageSource;
                    successScanImage.Source = successFrameImageSource;
                    faceImage.Source = faceImageSource;
                });

            });

        }

        private string BuildResult(string result, string propertyName)
        {
            if (result == null || result.Length == 0)
            {
                return "";
            }

            return propertyName + ": " + result + "\n";
        }

        private string BuildResult(Boolean result, string propertyName)
        {
            if (result)
            {
                return propertyName + ": YES" + "\n";
            }

            return propertyName + ": NO" + "\n";
        }

        private string BuildResult(int result, string propertyName)
        {
            if (result < 0)
            {
                return "";
            }

            return propertyName + ": " + result + "\n";
        }

        private string BuildResult(IDate result, string propertyName)
        {
            if (result == null || result.Year == 0)
            {
                return "";
            }

            DateTime date = new DateTime(result.Year, result.Month, result.Day);
            return propertyName + ": " + date.ToShortDateString() + "\n";
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
            blinkidRecognizer = DependencyService.Get<IBlinkIdCombinedRecognizer>(DependencyFetchTarget.NewInstance);
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