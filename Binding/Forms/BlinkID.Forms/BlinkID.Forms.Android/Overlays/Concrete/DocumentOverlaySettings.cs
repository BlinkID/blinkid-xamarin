using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays
{
    public sealed class DocumentOverlaySettings : OverlaySettings, IDocumentOverlaySettings
    {
        public DocumentOverlaySettings(IRecognizerCollection recognizerCollection) 
            : base(new DocumentUISettings((recognizerCollection as RecognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {}
    }

    public sealed class DocumentOverlaySettingsFactory : IDocumentOverlaySettingsFactory
    {
        public IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new DocumentOverlaySettings(recognizerCollection);
        }
    }
}
