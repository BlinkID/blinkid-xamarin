using System;
using Android.Content;
using Com.Microblink.Uisettings;
using Com.Microblink.Fragment.Overlay.Blinkid.Documentverification;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Droid.Overlays.Implementations;
using Microblink.Forms.Droid.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentVerificationOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays.Implementations
{
    public sealed class DocumentVerificationOverlaySettings : OverlaySettings, IDocumentVerificationOverlaySettings
    {
        public override UISettings NativeUISettings { 
            get {
                var concreteUISettings = (DocumentVerificationUISettings)base.NativeUISettings;
                var overlayStringsBuilder = new DocumentVerificationOverlayStrings.Builder(Android.App.Application.Context);
                if (FirstSideSplashMessage != null) {
                    overlayStringsBuilder.SetFrontSideSplashText(FirstSideSplashMessage);
                }
                if (SecondSideSplashMessage != null) {
                    overlayStringsBuilder.SetBackSideSplashText(SecondSideSplashMessage);
                }
                if (FirstSideInstructions != null) {
                    overlayStringsBuilder.SetFrontSideInstructions(FirstSideInstructions);
                }
                if (SecondSideInstructions != null) {
                    overlayStringsBuilder.SetBackSideInstructions(SecondSideInstructions);
                }
                if (GlareMessage != null) {
                    overlayStringsBuilder.SetGlareMessage(GlareMessage);
                }
                concreteUISettings.SetStrings(overlayStringsBuilder.Build());
                return concreteUISettings;
            }
        }

        public string FirstSideSplashMessage { get; set; }

        public string SecondSideSplashMessage { get; set; }

        public string FirstSideInstructions { get; set; }

        public string SecondSideInstructions { get; set; }

        public string GlareMessage { get; set; }

        public string ScanningDoneSplashMessage { get; set; }

        public DocumentVerificationOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new DocumentVerificationUISettings((recognizerCollection as RecognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {}
    }

    public sealed class DocumentVerificationOverlaySettingsFactory : IDocumentVerificationOverlaySettingsFactory
    {
        public IDocumentVerificationOverlaySettings CreateDocumentVerificationOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new DocumentVerificationOverlaySettings(recognizerCollection);
        }
    }
}
