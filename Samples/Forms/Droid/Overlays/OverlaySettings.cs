
using BlinkIDFormsSample.Droid.Overlays;
using BlinkIDFormsSample.Overlays;
using BlinkIDFormsSample.Recognizers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(OverlaySettings))]
namespace BlinkIDFormsSample.Droid.Overlays
{
	public class OverlaySettings : IOverlaySettings
    {
        public UISettings NativeUISettings { get; }

        public IRecognizerCollection RecognizerCollection { get; }

        protected OverlaySettings(UISettings nativeUISettings, IRecognizerCollection recognizerCollection)
        {
            NativeUISettings = nativeUISettings;
            RecognizerCollection = recognizerCollection;
        }
    }
}
