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
using Com.Microblink.Blinkid.Wrapper;

namespace CustomUIApp
{
    [Activity(Label = "BlinkIDCustomUI Xamarin", MainLauncher = true, Icon = "@mipmap/ic_launcher", HardwareAccelerated = true)]
    public class MainActivity : Activity
    {
        const int ACTIVITY_REQUEST_ID = 101;

        // BlinkIdRecognizer is used for automatic classification and data extraction from the supported
        // document
        BlinkIdRecognizer blinkidRecognizer;

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
                    BlinkIDWrapper.StartMyScanActivityForResult(this, ACTIVITY_REQUEST_ID, recognizerBundle);
                };
            }
        }

        private void initBlinkId()
        {
            // set license key for Android with package name com.microblink.xamarin.blinkid
            MicroblinkSDK.SetLicenseKey("sRwAAAAVY29tLm1pY3JvYmxpbmsuc2FtcGxlU9kJdf5ZkGlTu9U3P8tqz/OQlP4WPMiRjJ8ogPx3I/XahwQ+FZH+4q0sbbRGfo1IDXwYR6Cdy7o6IZeOzT2iRIZT7eW+Cqk65y1ngxGxk5caaR7WSyCGCe/yQqSjp1fxerQaVWUL0uK7s0xfv8EtVTqz7hocOKoqeC4c2m0L+WeEc7kAHGuYjoIMVm2BOmEtCOR4grLQUmrz5ojA8fFjuknxBnEGkFWdJNT0evkrH/BgcnM9S+CH2018twWbYYV8ggqaD8DB", this);

            // Since we plan to transfer large data between activities, we need to enable
            // PersistedOptimised intent data transfer mode.
            // for more information about transfer mode, check android documentation: https://github.com/blinkid/blinkid-android#-passing-recognizer-objects-between-activities
            MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;

            // create recognizers and bundle them into RecognizerBundle
            blinkidRecognizer = new BlinkIdRecognizer();
            blinkidRecognizer.SetReturnFullDocumentImage(true);
            blinkidRecognizer.SetReturnFaceImage(true);

            recognizerBundle = new RecognizerBundle(blinkidRecognizer);
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == ACTIVITY_REQUEST_ID && resultCode == Result.Ok)
            {
                // load results from intent
                recognizerBundle.LoadFromIntent(data);
                // obtain image view that will display image of the document
                ImageView documentImageFrontView = this.FindViewById<ImageView>(Resource.Id.documentImageFrontView);

                // unfortunately, C# does not support covariant return types, so binding
                // of AAR loses the return type of the Java's GetResult method. Therefore, a cast is required.
                // This is always a safe cast, since the original object in Java is of correct type - type
                // information was lost during conversion to C# due to https://github.com/xamarin/java.interop/pull/216
                var blinkidResult = (BlinkIdRecognizer.Result)blinkidRecognizer.GetResult();
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
                    if (blinkidResult.FullDocumentImage != null)
                    {
                        documentImageFrontView.SetImageBitmap(blinkidResult.FullDocumentImage.ConvertToBitmap());
                    }
                    else
                    {
                        documentImageFrontView.SetImageResource(0);
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
