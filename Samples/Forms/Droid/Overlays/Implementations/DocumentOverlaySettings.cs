using BlinkIDFormsSample.Droid.Overlays;
using BlinkIDFormsSample.Droid.Recognizers;
using BlinkIDFormsSample.Overlays;
using BlinkIDFormsSample.Recognizers;
using Com.Microblink.Entities.Recognizers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettings))]
[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettingsFactory))]
namespace BlinkIDFormsSample.Droid.Overlays
{
    public class DocumentOverlaySettings : OverlaySettings, IDocumentOverlaySettings
    {
        DocumentUISettings nativeDocumentUISettings;

        public DocumentOverlaySettings(RecognizerBundle recognizerBundle) : base(new DocumentUISettings(recognizerBundle))
        {
            nativeDocumentUISettings = (DocumentUISettings)NativeUISettings;
        }
    }

    public class DocumentOverlaySettingsFactory : IDocumentOverlaySettingsFactory
    {
        public IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new DocumentOverlaySettings(((RecognizerCollection)recognizerCollection).NativeRecognizerBundle);
        }
    }
}
