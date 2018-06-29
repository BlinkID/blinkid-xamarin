
using BlinkIDFormsSample.Droid.Overlays;
using BlinkIDFormsSample.Overlays;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(OverlaySettings))]
namespace BlinkIDFormsSample.Droid.Overlays
{
	public class OverlaySettings : IOverlaySettings
    {
        public UISettings NativeUISettings { get; }

        protected OverlaySettings(UISettings nativeUISettings)
        {
            NativeUISettings = nativeUISettings;
        }
    }
}
