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
