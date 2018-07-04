using System;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.iOS.Overlays.Implementations;
using Microblink.Forms.iOS.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentVerificationOverlaySettings))]
[assembly: Xamarin.Forms.Dependency(typeof(DocumentVerificationOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays.Implementations
{
    public sealed class DocumentVerificationOverlaySettings : OverlaySettings, IDocumentVerificationOverlaySettings
    {
        readonly MBDocumentVerificationOverlaySettings nativeOverlaySettings;

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        DocumentVerificationVCDelegate vcDelegate;
        
        public DocumentVerificationOverlaySettings(IRecognizerCollection recognizerCollection)
            : base(new MBDocumentVerificationOverlaySettings(), recognizerCollection)
        {
            nativeOverlaySettings = NativeOverlaySettings as MBDocumentVerificationOverlaySettings;
        }

        public override MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            vcDelegate = new DocumentVerificationVCDelegate(overlayVCDelegate);
            return new MBDocumentVerificationOverlayViewController(nativeOverlaySettings, (RecognizerCollection as RecognizerCollection).NativeRecognizerCollection, vcDelegate);
        }
    }

    public sealed class DocumentVerificationVCDelegate : MBDocumentVerificationOverlayViewControllerDelegate
    {
        IOverlayVCDelegate vcDelegate;

        public DocumentVerificationVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            vcDelegate = overlayVCDelegate;
        }

        public override void DocumentVerificationOverlayViewControllerDidFinishScanning(MBDocumentVerificationOverlayViewController documentVerificationOverlayViewController, MBRecognizerResultState state)
        {
            vcDelegate.ScanningFinished(documentVerificationOverlayViewController, state);
        }

        public override void DocumentVerificationOverlayViewControllerDidTapClose(MBDocumentVerificationOverlayViewController documentVerificationOverlayViewController)
        {
            vcDelegate.CloseButtonTapped(documentVerificationOverlayViewController);
        }
    }

    public sealed class DocumentVerificationOverlaySettingsFactory : IDocumentVerificationOverlaySettingsFactory
    {
        public IDocumentVerificationOverlaySettings CreateDocumentVerificationOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new DocumentVerificationOverlaySettings(recognizerCollection);
        }
    }
}
