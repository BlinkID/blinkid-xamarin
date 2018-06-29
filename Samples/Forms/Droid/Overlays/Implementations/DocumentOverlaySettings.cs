using BlinkIDFormsSample.Droid.Overlays;
using BlinkIDFormsSample.Droid.Recognizers;
using BlinkIDFormsSample.Overlays;
using BlinkIDFormsSample.Recognizers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettings))]
[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettingsFactory))]
namespace BlinkIDFormsSample.Droid.Overlays
{
    public class DocumentOverlaySettings : OverlaySettings, IDocumentOverlaySettings
    {
        DocumentUISettings nativeDocumentUISettings;

        public DocumentOverlaySettings(IRecognizerCollection recognizerCollection) : base(new DocumentUISettings(((RecognizerCollection)recognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {
            nativeDocumentUISettings = (DocumentUISettings)NativeUISettings;
        }
    }

    public class DocumentOverlaySettingsFactory : IDocumentOverlaySettingsFactory
    {
        public IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new DocumentOverlaySettings(recognizerCollection);
        }
    }
}
