using BlinkID.Forms.Droid.Overlays;
using BlinkID.Forms.Droid.Recognizers;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettingsFactory))]
namespace BlinkID.Forms.Droid.Overlays
{
    public sealed class DocumentOverlaySettings : RecognizerCollectionOverlaySettings, IDocumentOverlaySettings
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