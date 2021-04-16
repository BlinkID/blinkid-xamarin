
using BlinkID.Forms.iOS.Overlays;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.Core.Recognizers;
using BlinkID;

namespace BlinkID.Forms.iOS.Overlays
{
	public abstract class OverlaySettings : IOverlaySettings
    {
        public MBOverlaySettings NativeOverlaySettings { get; }

        protected OverlaySettings(MBOverlaySettings nativeOverlaySettings)
        {
            NativeOverlaySettings = nativeOverlaySettings;
        }

        public bool UseFrontCamera
        {
            get
            {
                return NativeOverlaySettings.CameraSettings.CameraType == MBCameraType.Front;
            }
            set
            {
                if (value) {
                    NativeOverlaySettings.CameraSettings.CameraType = MBCameraType.Front;
                }
                else
                {
                    NativeOverlaySettings.CameraSettings.CameraType = MBCameraType.Back;
                }
                
            }
        }

        public abstract MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate);
    }
}