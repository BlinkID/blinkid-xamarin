using BlinkID;

namespace BlinkID.Forms.iOS.Overlays
{
    public interface IOverlayVCDelegate
    {
        void ScanningFinished(MBOverlayViewController overlayViewController, MBRecognizerResultState state);

        void CloseButtonTapped(MBOverlayViewController overlayViewController);
    }
}