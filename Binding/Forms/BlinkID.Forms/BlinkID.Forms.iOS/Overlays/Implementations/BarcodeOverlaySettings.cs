using System;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.iOS.Overlays.Implementations;
using Microblink.Forms.iOS.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BarcodeOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays.Implementations
{
    public sealed class BarcodeOverlaySettings : OverlaySettings, IBarcodeOverlaySettings
    {
        MBBarcodeOverlaySettings nativeBarcodeOverlaySettings;

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        BarcodeOverlayVCDelegate barcodeOverlayVCDelegate;

        public BarcodeOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new MBBarcodeOverlaySettings(), recognizerCollection)
        {
            nativeBarcodeOverlaySettings = NativeOverlaySettings as MBBarcodeOverlaySettings;
        }

        public override MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            barcodeOverlayVCDelegate = new BarcodeOverlayVCDelegate(overlayVCDelegate);
            return new MBBarcodeOverlayViewController(nativeBarcodeOverlaySettings, (RecognizerCollection as RecognizerCollection).NativeRecognizerCollection, barcodeOverlayVCDelegate);
        }
    }

    public sealed class BarcodeOverlaySettingsFactory : IBarcodeOverlaySettingsFactory
    {
        public IBarcodeOverlaySettings CreateBarcodeOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new BarcodeOverlaySettings(recognizerCollection);
        }
    }

    public sealed class BarcodeOverlayVCDelegate : MBBarcodeOverlayViewControllerDelegate
    {
        readonly IOverlayVCDelegate overlayVCDelegate;

        public BarcodeOverlayVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            this.overlayVCDelegate = overlayVCDelegate;
        }

        public override void BarcodeOverlayViewControllerDidFinishScanning(MBBarcodeOverlayViewController barcodeOverlayViewController, MBRecognizerResultState state)
        {
            overlayVCDelegate.ScanningFinished(barcodeOverlayViewController, state);
        }

        public override void BarcodeOverlayViewControllerDidTapClose(MBBarcodeOverlayViewController barcodeOverlayViewController)
        {
            overlayVCDelegate.CloseButtonTapped(barcodeOverlayViewController);
        }

    }
}
