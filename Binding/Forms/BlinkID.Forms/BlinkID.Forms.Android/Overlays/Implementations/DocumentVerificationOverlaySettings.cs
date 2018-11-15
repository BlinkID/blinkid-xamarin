using System;
using Com.Microblink.Uisettings;
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
                if (FirstSideSplashMessage != null) {
                    concreteUISettings.FirstSideSplashMessage = FirstSideSplashMessage;
                }
                if (SecondSideSplashMessage != null) {
                    concreteUISettings.SecondSideSplashMessage = SecondSideSplashMessage;
                }
                if (FirstSideInstructions != null) {
                    concreteUISettings.FirstSideInstructions = FirstSideInstructions;
                }
                if (SecondSideInstructions != null) {
                    concreteUISettings.SecondSideInstructions = SecondSideInstructions;
                }
                if (GlareMessage != null) {
                    concreteUISettings.GlareMessage = GlareMessage;
                }
                return concreteUISettings;
            }
        }

        public string FirstSideSplashMessage { get; set; }

        public string SecondSideSplashMessage { get; set; }

        public string FirstSideInstructions { get; set; }

        public string SecondSideInstructions { get; set; }

        public string GlareMessage { get; set; }

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
