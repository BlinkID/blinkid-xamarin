using Com.Microblink.Uisettings;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Droid.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BarcodeOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays
{
    public sealed class BarcodeOverlaySettings : OverlaySettings, IBarcodeOverlaySettings
    {
        public BarcodeOverlaySettings(IRecognizerCollection recognizerCollection) 
            : base(new BarcodeUISettings((recognizerCollection as RecognizerCollection).NativeRecognizerBundle), recognizerCollection)
        {}
    }

    public sealed class BarcodeOverlaySettingsFactory : IBarcodeOverlaySettingsFactory
    {
        public IBarcodeOverlaySettings CreateBarcodeOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BarcodeOverlaySettings(recognizerCollection);
        }
    }
}
