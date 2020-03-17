using System;
using Android.Content;
using Com.Microblink.Uisettings;
using Com.Microblink.Fragment.Overlay.Blinkid.Reticleui;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Droid.Overlays.Implementations;
using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Droid.Overlays;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays
{
    public sealed class BlinkIdOverlaySettings : OverlaySettings, IBlinkIdOverlaySettings
    {
        public override UISettings NativeUISettings {
            get {
                var concreteUISettings = (BlinkIdUISettings)base.NativeUISettings;

                concreteUISettings.SetDocumentDataMatchRequired(RequireDocumentSidesDataMatch);
                concreteUISettings.SetShowNotSupportedDialog(ShowNotSupportedDialog);
                concreteUISettings.SetBackSideScanningTimeoutMs(BackSideScanningTimeoutMilliseconds);

                var overlayStringsBuilder = new ReticleOverlayStrings.Builder(Android.App.Application.Context);
                if (FirstSideInstructionsText != null) {
                    overlayStringsBuilder.SetFirstSideInstructionsText(FirstSideInstructionsText);
                }
                if (FlipInstructions != null) {
                    overlayStringsBuilder.SetFlipInstructions(FlipInstructions);
                }
                if (ErrorMoveCloser != null) {
                    overlayStringsBuilder.SetErrorMoveCloser(ErrorMoveCloser);
                }
                if (ErrorMoveFarther != null) {
                    overlayStringsBuilder.SetErrorMoveFarther(ErrorMoveFarther);
                }
                if (SidesNotMatchingTitle != null) {
                    overlayStringsBuilder.SetSidesNotMatchingTitle(SidesNotMatchingTitle);
                }
                if (SidesNotMatchingMessage != null) {
                    overlayStringsBuilder.SetSidesNotMatchingMessage(SidesNotMatchingMessage);
                }
                if (UnsupportedDocumentTitle != null) {
                    overlayStringsBuilder.SetUnsupportedDocumentTitle(UnsupportedDocumentTitle);
                }
                if (UnsupportedDocumentMessage != null) {
                    overlayStringsBuilder.SetUnsupportedDocumentMessage(UnsupportedDocumentMessage);
                }
                if (RecognitionTimeoutTitle != null) {
                    overlayStringsBuilder.SetRecognitionTimeoutTitle(RecognitionTimeoutTitle);
                }
                if (RecognitionTimeoutMessage != null) {
                    overlayStringsBuilder.SetRecognitionTimeoutMessage(RecognitionTimeoutMessage);
                }
                 if (RetryButtonText != null) {
                    overlayStringsBuilder.SetRetryButtonText(RetryButtonText);
                }
                concreteUISettings.SetStrings(overlayStringsBuilder.Build());
                return concreteUISettings;
            }
        }

        public string FirstSideInstructionsText { get; set; }

        public string FlipInstructions { get; set; }

        public string ErrorMoveCloser { get; set; }

        public string ErrorMoveFarther { get; set; }

        public string SidesNotMatchingTitle { get; set; }

        public string SidesNotMatchingMessage { get; set; }

        public string UnsupportedDocumentTitle { get; set; }

        public string UnsupportedDocumentMessage { get; set; }

        public string RecognitionTimeoutTitle { get; set; }

        public string RecognitionTimeoutMessage { get; set; }

        public string RetryButtonText { get; set; }

        public bool RequireDocumentSidesDataMatch { get; set; } = true;

        public bool ShowNotSupportedDialog { get; set; } = true;

        public long BackSideScanningTimeoutMilliseconds { get; set; } = 17000;

        public BlinkIdOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new BlinkIdUISettings((recognizerCollection as RecognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {}
    }

    public sealed class BlinkIdOverlaySettingsFactory : IBlinkIdOverlaySettingsFactory
    {
        public IBlinkIdOverlaySettings CreateBlinkIdOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BlinkIdOverlaySettings(recognizerCollection);
        }
    }
}
