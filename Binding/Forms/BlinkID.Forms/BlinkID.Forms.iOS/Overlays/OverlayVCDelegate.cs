using Microblink;

namespace Microblink.Forms.iOS.Overlays
{
    public interface IOverlayVCDelegate
    {
        void ScanningFinished(MBOverlayViewController overlayViewController, MBRecognizerResultState state);

        void CloseButtonTapped(MBOverlayViewController overlayViewController);

        void ScanningFinishedWithHighResolutionImage(MBOverlayViewController overlayViewController, MBImage highResImage, MBRecognizerResultState state);
    }
}
