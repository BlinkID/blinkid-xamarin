using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays
{
    public sealed class BlinkIdOverlaySettings : OverlaySettings, IBlinkIdOverlaySettings
    {
        readonly MBBlinkIdOverlaySettings nativeBlinkIdOverlaySettings;

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        BlinkIdOverlayVCDelegate blinkIdOverlayVCDelegate;

        public BlinkIdOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new MBBlinkIdOverlaySettings(), recognizerCollection)
        {
            nativeBlinkIdOverlaySettings = NativeOverlaySettings as MBBlinkIdOverlaySettings;
        }

        public override MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            blinkIdOverlayVCDelegate = new BlinkIdOverlayVCDelegate(overlayVCDelegate);
            return new MBBlinkIdOverlayViewController(nativeBlinkIdOverlaySettings, (RecognizerCollection as RecognizerCollection).NativeRecognizerCollection, blinkIdOverlayVCDelegate);
        }
    }

    public sealed class BlinkIdOverlaySettingsFactory : IBlinkIdOverlaySettingsFactory
    {
        public IBlinkIdOverlaySettings CreateBlinkIdOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BlinkIdOverlaySettings(recognizerCollection);
        }
    }

    public sealed class BlinkIdOverlayVCDelegate : MBBlinkIdOverlayViewControllerDelegate
    {
        readonly IOverlayVCDelegate overlayVCDelegate;

        public BlinkIdOverlayVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            this.overlayVCDelegate = overlayVCDelegate;
        }

        public override void BlinkIdOverlayViewControllerDidFinishScanning(MBBlinkIdOverlayViewController BlinkIdOverlayViewController, MBRecognizerResultState state)
        {
            overlayVCDelegate.ScanningFinished(BlinkIdOverlayViewController, state);
        }

        public override void BlinkIdOverlayViewControllerDidTapClose(MBBlinkIdOverlayViewController BlinkIdOverlayViewController)
        {
            overlayVCDelegate.CloseButtonTapped(BlinkIdOverlayViewController);
        }
    }
}
