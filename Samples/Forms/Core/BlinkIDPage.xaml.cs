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

        /// <summary>
        /// EUDL recognizer will be used for scanning front side of EU driver's licenses.
        /// </summary>
        IEudlRecognizer eudlRecognizer;

        /// <summary>
        /// This success frame grabber recognizer will wrap eudlRecognizer and will contain camera frame of the moment
        /// when wrapped recognizer finished its recognition.
        /// </summary>
        ISuccessFrameGrabberRecognizer eudlSuccessFrameGrabberRecognizer;

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
                licenseKey = "sRwAAAEeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lks3unDF2B9jpa6FeAx5h89osjSFXqQRtWjes0WSEXe3rubgFApHsFdSF2oJZL0MhSL18AgbaLmPiOT3RFu+lqtKtpsjqRfxEVmc9cU98GnjciEeAOC331OUeT5R1p7zKqsenX/3IytQJuMG4ruEaRXc5746y/Kv8ch0XDgv/nRu4siNlvpkjsUjkeyokbUUwi+uzL6t2G4V/sX0SXTMWPjG7zjtW4ovwpGs6fct/dpBJQfzRQNCn9kg==";    
            }
            else
            {
                licenseKey = "sRwAAAAeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lke7qv4oIhH4ywlU8/Ykcxtro0niv3z3MEx6zurAEm+re10In/l3kLnW/R/vf1JI3weawIMA/ZrsUteLBNgoxST1uM6/g0UBZk5LNiIUHsl1Vgk15fZHJ42o+VAq40Iv6NKOw0yc71eMucbppuSgkH4hTNiR/hOUO/yZsc+GGN1q7Sh+7yCaDfnAMY8yx4z9plZEeQdQSnhXzb9x9ofYabsp2sN4qz/BedEi9+X3C+TTw4HrMoyZ4pCg==";
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

            // the following code creates and sets up implementation of EudlRecognizer
            eudlRecognizer = DependencyService.Get<IEudlRecognizer>();
            eudlRecognizer.ReturnFaceImage = true;
            eudlRecognizer.ReturnFullDocumentImage = true;

            // success frame grabber recognizer must be constructed with reference to its slave recognizer,
            // so we need to use factory to avoid DependencyService's limitations
            eudlSuccessFrameGrabberRecognizer = DependencyService.Get<ISuccessFrameGrabberRecognizerFactory>().CreateSuccessFrameGrabberRecognizer(eudlRecognizer);

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

                    if (eudlRecognizer.Result.ResultState == RecognizerResultState.Valid)
                    {
                        var result = eudlRecognizer.Result;
                        stringResult =
                            "First name: " + result.FirstName + "\n" +
                            "Last name: " + result.LastName + "\n" +
                            "Address: " + result.Address + "\n" +
                            "Personal number: " + result.PersonalNumber + "\n" +
                            "Driver number: " + result.DriverNumber;
                        successFrameImageSource = eudlSuccessFrameGrabberRecognizer.Result.SuccessFrame;
                        faceImageSource = result.FaceImage;
                        fullDocumentImageSource = result.FullDocumentImage;
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
            var recognizerCollection = DependencyService.Get<IRecognizerCollectionFactory>().CreateRecognizerCollection(mrtdSuccessFrameGrabberRecognizer, usdlSuccessFrameGrabberRecognizer, eudlSuccessFrameGrabberRecognizer);

            // using recognizerCollection, create overlay settings that will define the UI that will be used
            // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
            // document overlay settings is best for scanning identity documents
            var documentOverlaySettings = DependencyService.Get<IDocumentOverlaySettingsFactory>().CreateDocumentOverlaySettings(recognizerCollection);

            // start scanning
            blinkID.Scan(documentOverlaySettings);
        }
    }
}

