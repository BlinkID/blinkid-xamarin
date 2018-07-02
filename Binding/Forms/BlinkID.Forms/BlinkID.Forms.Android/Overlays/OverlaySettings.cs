
using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Shared.Overlays;
using Microblink.Forms.Shared.Recognizers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(OverlaySettings))]
namespace Microblink.Forms.Droid.Overlays
{
    public abstract class OverlaySettings : IOverlaySettings
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
