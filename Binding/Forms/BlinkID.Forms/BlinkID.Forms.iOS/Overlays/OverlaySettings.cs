
using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink;

namespace Microblink.Forms.iOS.Overlays
{
	public abstract class OverlaySettings : IOverlaySettings
    {
        public MBOverlaySettings NativeOverlaySettings { get; }

        protected OverlaySettings(MBOverlaySettings nativeOverlaySettings)
        {
            NativeOverlaySettings = nativeOverlaySettings;
        }

        public abstract MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate);
    }
}
