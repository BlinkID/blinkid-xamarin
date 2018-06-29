
using BlinkIDFormsSample.iOS.Overlays;
using BlinkIDFormsSample.Overlays;
using BlinkIDFormsSample.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(OverlaySettings))]
namespace BlinkIDFormsSample.iOS.Overlays
{
	public abstract class OverlaySettings : IOverlaySettings
    {
        public MBOverlaySettings NativeOverlaySettings { get; }
        public IRecognizerCollection RecognizerCollection { get; }

        protected OverlaySettings(MBOverlaySettings nativeOverlaySettings, IRecognizerCollection recognizerCollection)
        {
            NativeOverlaySettings = nativeOverlaySettings;
            RecognizerCollection = recognizerCollection;
        }

        public abstract MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate);
    }
}
