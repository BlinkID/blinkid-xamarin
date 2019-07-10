using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkCardOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays
{
    public sealed class BlinkCardOverlaySettings : OverlaySettings, IBlinkCardOverlaySettings
    {
        readonly MBBlinkCardOverlaySettings nativeBlinkCardOverlaySettings;

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        BlinkCardOverlayVCDelegate blinkCardOverlayVCDelegate;

        public BlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new MBBlinkCardOverlaySettings(), recognizerCollection)
        {
            nativeBlinkCardOverlaySettings = NativeOverlaySettings as MBBlinkCardOverlaySettings;
        }

        public override MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            blinkCardOverlayVCDelegate = new BlinkCardOverlayVCDelegate(overlayVCDelegate);
            return new MBBlinkCardOverlayViewController(nativeBlinkCardOverlaySettings, (RecognizerCollection as RecognizerCollection).NativeRecognizerCollection, blinkCardOverlayVCDelegate);
        }

        public string FirstSideInstructions { get; set; }
        public string SecondSideInstructions { get; set; }
    }

    public sealed class BlinkCardOverlaySettingsFactory : IBlinkCardOverlaySettingsFactory
    {
        public IBlinkCardOverlaySettings CreateBlinkCardOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BlinkCardOverlaySettings(recognizerCollection);
        }
    }

    public sealed class BlinkCardOverlayVCDelegate : MBBlinkCardOverlayViewControllerDelegate
    {
        readonly IOverlayVCDelegate overlayVCDelegate;

        public BlinkCardOverlayVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            this.overlayVCDelegate = overlayVCDelegate;
        }

        public override void BlinkCardOverlayViewControllerDidFinishScanning(MBBlinkCardOverlayViewController blinkCardOverlayViewController, MBRecognizerResultState state)
        {
            overlayVCDelegate.ScanningFinished(blinkCardOverlayViewController, state);
        }

        public override void BlinkCardOverlayViewControllerDidTapClose(MBBlinkCardOverlayViewController blinkCardOverlayViewController)
        {
            overlayVCDelegate.CloseButtonTapped(blinkCardOverlayViewController);
        }
    }
}
