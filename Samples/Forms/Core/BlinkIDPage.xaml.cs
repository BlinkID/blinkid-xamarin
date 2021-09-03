using System;
using BlinkCard.Forms.Core.Recognizers;
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
        /// Microblink scanner is used for scanning the credit cards
        /// </summary>
        BlinkCard.Forms.Core.IMicroblinkScanner blinkCard;

        /// <summary>
        /// BlinkCard recognizer will be used for automatic detection and data extraction from the supported document.
        /// </summary>
        IBlinkCardRecognizer blinkCardRecognizer;

        public BlinkIDPage ()
        {
            InitializeComponent ();
            initializeBlinkCard();
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
                licenseKey = "sRwAAAEVY29tLm1pY3JvYmxpbmsuc2FtcGxl1BIcP4FpSuS/38JVOjalnIUAO6GSoXBJSnE8F0QDNJHKEMH7o9ipBUa6gs9JVUn1xhlm+gU+CE8M5dfpDJ5dThQAwhdat7lEBlhqCWhhVnaFAwhRPzmGoBT5DPJH+/j0bMsP52KFNDIQyjJ56+N/rtC1NQc0A/5weRzGQ0mJCESXhL1iCYi/ewtO8VmzBIMsPHcbtNKVqSabeqBOvjKVdwCDodUHYD4gxp+Z5QGjWEUTqqubZcRckHLEq+55y3IRpBev7y2ZfrwTPTBvkg6icvXZzpYl9G7UQnJfsx90JCFnGbFwkzgtCyG0D4EgWxpW2TRBZU9REHXXGZqh9BdHGCmv";
            }
            else
            {
                licenseKey = "sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdZhZkGlTu9U3Oitiw6TT2FGkiyJFlAhM8pExgH/ZF5IuOoC/DbKHoiR382JaMb+r7NDBTzi88CBCEGTbXlCknk+hJObhf+9SOOJyV9scpqUqGgudxZCbR7Ao8QVhwb7XavkyHr+6j1COdVVFlV105JVZF2y7TTB/c6qKl1YLlEPsHcgQJIR15cWeLaSrM9SDq3cW66fdVqjrmXTlZOpo3r6Kzc5LWa+B/kFt7oEJGC3+E8RVD0L/BM6W0vQvCFrgz2XMss7AmHyHugG2t7xId3TBcx9Jct+EcEjICkuJ3KnzdNj8OlVIHcVAlEcLcqx90wxL";
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
                    if (blinkidRecognizer.Result.ResultState == BlinkID.Forms.Core.Recognizers.RecognizerResultState.Valid)
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
                            BuildResult(blinkidResult.ResidentialStatus, "Residential Status");

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

        private void initializeBlinkCard()
        {
            // before obtaining any of the recognizer's implementations from DependencyService, it is required
            // to obtain instance of IMicroblinkScanner and set the license key.
            // Failure to do so will crash your app.
            var microblinkFactory = DependencyService.Get<BlinkCard.Forms.Core.IMicroblinkScannerFactory>();

            // license keys are different for iOS and Android and depend on iOS bundleID/Android application ID
            // in your app, you may obtain the correct license key for your platform via DependencyService from
            // your Droid/iOS projects
            string licenseKey;

            // both these license keys are demo license keys for bundleID/applicationID com.microblink.sample
            if (Device.RuntimePlatform == Device.iOS)
            {
                licenseKey = "sRwAAAEVY29tLm1pY3JvYmxpbmsuc2FtcGxl1BIcP6dpSuS/37rVPvGgnEXtW6n0WYNXlN/0i1f88yoVpcC6wVI7C9/PwW96iHudfFxZtXdYuU3G3FGWKgCcqkSdZwRtiHrFeYz8beVEwPAGbLMPGidJ8qm5ZtgfLYHJ5NqR0qfIfqKTIDlsGzUY2D2qp3KUfYcscbf9JftuQdMpQ8VfQ8eu0+x1aUckcowsgAfq8/CTF3cpaSF1mBKMCO+idtTRWI8B52aZZDeybQ==";
            }
            else
            {
                licenseKey = "sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdb5ZkGlTu623Pixsw037mGhBUOlKf9FyC46r0aJfr+2FJclONWXQv/Xlj27pDDhp07b66EWvmCZeP9oUM7zUHo17x8A4DC8nIZhxCsRgz5FLeMD7opEa+XVTb3/kxNOc8zNZ2XSG0Pw9VTxYf/74hEC7mVhYMIK+4Nf94HM5hujNJInjb5BRLBqrje6tcOlqgSDdQGBkCIre9FOLJDgVtyq41HIwC4cxSS/ryg==";
            }

            // since DependencyService requires implementations to have default constructor, a factory is needed
            // to construct implementation of IMicroblinkScanner with given license key
            blinkCard = microblinkFactory.CreateMicroblinkScanner(licenseKey, true);

            // subscribe to scanning done message
            MessagingCenter.Subscribe<BlinkCard.Forms.Core.Messages.ScanningDoneMessage>(this, BlinkCard.Forms.Core.Messages.ScanningDoneMessageId, (sender) => {
                ImageSource fullDocumentFirstImageSource = null;
                ImageSource fullDocumentSecondImageSource = null;

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
                    if (blinkCardRecognizer.Result.ResultState == BlinkCard.Forms.Core.Recognizers.RecognizerResultState.Valid)
                    {
                        var blinkCard = blinkCardRecognizer.Result;
                        stringResult =
                            "BlinkCard recognizer result:\n" +
                            BuildResult(blinkCard.CardNumber, "Card number") +
                            BuildResult(blinkCard.CardNumberValid, "Card number valid") +
                            BuildResult(blinkCard.CardNumberPrefix, "Card number prefix") +
                            BuildResult(blinkCard.Iban, "IBAN") +
                            BuildResult(blinkCard.Owner, "Owner") +
                            BuildResult(blinkCard.ExpiryDate, "Expiry date") +
                            BuildResult(blinkCard.Cvv, "CVV");

                        fullDocumentFirstImageSource = blinkCard.FirstSideFullDocumentImage;
                        fullDocumentSecondImageSource = blinkCard.SecondSideFullDocumentImage;
                    }

                }

                // updating the UI must be performed on main thread
                Device.BeginInvokeOnMainThread(() => {
                    resultsEditor.Text = stringResult;
                    fullDocumentFrontImage.Source = fullDocumentFirstImageSource;
                    fullDocumentBackImage.Source = fullDocumentSecondImageSource;
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

        private string BuildResult(BlinkID.Forms.Core.Recognizers.IDate result, string propertyName)
        {
            if (result == null || result.Year == 0)
            {
                return "";
            }

            DateTime date = new DateTime(result.Year, result.Month, result.Day);
            return propertyName + ": " + date.ToShortDateString() + "\n";
        }

        private string BuildResult(BlinkCard.Forms.Core.Recognizers.IDate result, string propertyName)
        {
            if (result == null || result.Year == 0)
            {
                return "";
            }

            return propertyName + ": "+ result.Month + "/"+ result.Year + "\n";
        }

        /// <summary>
        /// Button click event handler that will start the scanning procedure.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void StartBlinkCard(object sender, EventArgs e)
        {
            blinkCardRecognizer = DependencyService.Get<IBlinkCardRecognizer>(DependencyFetchTarget.NewInstance);
            blinkCardRecognizer.ReturnFullDocumentImage = true;

            // first create a recognizer collection from all recognizers that you want to use in recognition
            // if some recognizer is wrapped with SuccessFrameGrabberRecognizer, then you should use only the wrapped one
            var recognizerCollection = DependencyService.Get<BlinkCard.Forms.Core.Recognizers.IRecognizerCollectionFactory>().CreateRecognizerCollection(blinkCardRecognizer);

            // using recognizerCollection, create overlay settings that will define the UI that will be used
            // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
            // document overlay settings is best for scanning identity documents
            var blinkCardOverlaySettings = DependencyService.Get<BlinkCard.Forms.Core.Overlays.IBlinkCardOverlaySettingsFactory>().CreateBlinkCardOverlaySettings(recognizerCollection);

            // start scanning
            blinkCard.Scan(blinkCardOverlaySettings);
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
            var recognizerCollection = DependencyService.Get<BlinkID.Forms.Core.Recognizers.IRecognizerCollectionFactory>().CreateRecognizerCollection(blinkidRecognizer/*, usdlSuccessFrameGrabberRecognizer*/);

            // using recognizerCollection, create overlay settings that will define the UI that will be used
            // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
            // document overlay settings is best for scanning identity documents
            var blinkidOverlaySettings = DependencyService.Get<IBlinkIdOverlaySettingsFactory>().CreateBlinkIdOverlaySettings(recognizerCollection);

            // start scanning
            blinkID.Scan(blinkidOverlaySettings);
        }
    }
}