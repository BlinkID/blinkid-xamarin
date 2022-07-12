using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using Android.Content;

using Com.Microblink.Entities.Recognizers.Blinkid.Generic;
using Com.Microblink.Entities.Recognizers;
using Com.Microblink.Util;
using Com.Microblink;
using Com.Microblink.Intent;
using Com.Microblink.Uisettings;
using Android.Runtime;

namespace Android
{
    [Activity(Label = "BlinkID Xamarin", MainLauncher = true, Icon = "@mipmap/icon", HardwareAccelerated = true)]
    public class MainActivity : Activity
    {
        const int ACTIVITY_REQUEST_ID = 101;

        // BlinkIdCombinedRecognizer is used for automatic classification and data extraction from the supported
        // document
        BlinkIdCombinedRecognizer blinkidRecognizer;

        // there are plenty of recognizers available - see Android documentation
        // for more information: https://github.com/BlinkID/blinkid-android/blob/master/README.md

        // RecognizerBundle is required for transferring recognizers via Intent to another activity
        // and for loading results from them back.
        RecognizerBundle recognizerBundle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            RequestedOrientation = ScreenOrientation.Portrait;

            Button button = FindViewById<Button>(Resource.Id.startScanningButton);

            // Setup BlinkID before usage
            initBlinkId();

            // check if BlinkID is supported on current device. Device needs to have camera with autofocus.
            if (RecognizerCompatibility.GetRecognizerCompatibilityStatus(this) != RecognizerCompatibilityStatus.RecognizerSupported)
            {
                button.Enabled = false;
                Toast.MakeText(this, "BlinkID is not supported!", ToastLength.Long).Show();
            }
            else
            {
                button.Click += delegate {
                    // create a settings object for activity that will be used. For ID it's best to
                    // use DocumentUISettings. There are also other UI settings available - check Android documentation
                    var blinkidUISettings = new BlinkIdUISettings(recognizerBundle);

                    // start activity associated with given UI settings. After scanning completes,
                    // OnActivityResult will be invoked
                    ActivityRunner.StartActivityForResult(this, ACTIVITY_REQUEST_ID, blinkidUISettings);
                };
            }
        }

        private void initBlinkId()
        {
            // set license key for Android with package name com.microblink.sample
            MicroblinkSDK.SetLicenseKey("sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdZhZkGlTu9U3OJtAYGbizcXhV5K1maxiDMJFmnmLT3IzuOot5d+g5HVnoLFduWFtl9egla46EkGtuAdJd1p0a67N0Q2JnbcTqZB5h6ksNpjPsrmcY9OLjmlul2n9rcunJkM1cxu96HES75tdPBQvPz+WBbdx8Tz1y8ZyW7sNjqzemaZ5oqGZEQPj/NrWl2nHjeFxectQG9iOVTmHUNaSPZN4bsYYAeD7v6bGrXG2sv1FrkMjPIQ7Ic50r/drJmq+qhMNPZOJ+M9PfyO5zGuZN+uChv5k4lxcRRZ/sYgxNvuA6plBiFcg3uYugkuIDTD1fVyCYE5BSUzOGQjyacgH", this);

            // Since we plan to transfer large data between activities, we need to enable
            // PersistedOptimised intent data transfer mode.
            // for more information about transfer mode, check android documentation: https://github.com/blinkid/blinkid-android#-passing-recognizer-objects-between-activities
            MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;

            // create recognizers and bundle them into RecognizerBundle
            blinkidRecognizer = new BlinkIdCombinedRecognizer();
            blinkidRecognizer.SetReturnFullDocumentImage(true);
            blinkidRecognizer.SetReturnFaceImage(true);

            recognizerBundle = new RecognizerBundle(blinkidRecognizer);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == ACTIVITY_REQUEST_ID && resultCode == Result.Ok)
            {

                // obtain image view that will display image of the document
                ImageView documentImageFrontView = this.FindViewById<ImageView>(Resource.Id.documentImageFrontView);
                ImageView documentImageBackView = this.FindViewById<ImageView>(Resource.Id.documentImageBackView);

                // unfortunately, C# does not support covariant return types, so binding
                // of AAR loses the return type of the Java's GetResult method. Therefore, a cast is required.
                // This is always a safe cast, since the original object in Java is of correct type - type
                // information was lost during conversion to C# due to https://github.com/xamarin/java.interop/pull/216
                var blinkidResult = (BlinkIdCombinedRecognizer.Result)blinkidRecognizer.GetResult();
                // var mrtdResult = (MrtdRecognizer.Result)mrtdRecognizer.GetResult();


                var message = "";

                // we can check ResultState property of the Result to see if the result contains scanned information
                if (blinkidResult.ResultState == Recognizer.Result.State.Valid)
                {
                    message += "BlinkID recognizer result:\n" +
                        "FirstName: " + blinkidResult.FirstName + "\n" +
                        "LastName: " + blinkidResult.LastName + "\n" +
                        "Address: " + blinkidResult.Address + "\n" +
                        "DocumentNumber: " + blinkidResult.DocumentNumber + "\n" +
                        "Sex: " + blinkidResult.Sex + "\n";
                    var dob = blinkidResult.DateOfBirth.Date;
                    if (dob != null)
                    {
                        message +=
                            "DateOfBirth: " + dob.Day + "." +
                                              dob.Month + "." +
                                              dob.Year + ".\n";
                    }
                    var doi = blinkidResult.DateOfIssue.Date;
                    if (doi != null)
                    {
                        message +=
                            "DateOfIssue: " + doi.Day + "." +
                                              doi.Month + "." +
                                              doi.Year + ".\n";

                    }
                    var doe = blinkidResult.DateOfExpiry.Date;
                    if (doe != null)
                    {
                        message +=
                            "DateOfExpiry: " + doe.Day + "." +
                                               doe.Month + "." +
                                               doe.Year + ".\n";

                    }
                    // there are other fields to extract

                    // show full document images
                    if (blinkidResult.FullDocumentFrontImage != null)
                    {
                        documentImageFrontView.SetImageBitmap(blinkidResult.FullDocumentFrontImage.ConvertToBitmap());
                    }
                    else
                    {
                        documentImageFrontView.SetImageResource(0);
                    }
                    if (blinkidResult.FullDocumentBackImage != null)
                    {
                        documentImageBackView.SetImageBitmap(blinkidResult.FullDocumentBackImage.ConvertToBitmap());
                    }
                    else
                    {
                        documentImageBackView.SetImageResource(0);
                    }

                }

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("BlinkID Results");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                alert.SetMessage(message);
                alert.Show();
            }
        }
    }
}