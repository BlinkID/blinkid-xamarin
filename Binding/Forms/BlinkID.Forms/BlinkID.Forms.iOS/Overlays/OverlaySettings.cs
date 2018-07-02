
using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.Shared.Overlays;
using Microblink.Forms.Shared.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(OverlaySettings))]
namespace Microblink.Forms.iOS.Overlays
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
