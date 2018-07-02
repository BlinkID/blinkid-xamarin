using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettings))]
[assembly: Xamarin.Forms.Dependency(typeof(DocumentOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays
{
    public class DocumentOverlaySettings : OverlaySettings, IDocumentOverlaySettings
    {
        readonly MBDocumentOverlaySettings nativeDocumentOverlaySettings;

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        DocumentOverlayVCDelegate documentOverlayVCDelegate;

        public DocumentOverlaySettings(IRecognizerCollection recognizerCollection) : base(new MBDocumentOverlaySettings(), recognizerCollection)
        {
            nativeDocumentOverlaySettings = (MBDocumentOverlaySettings)NativeOverlaySettings;
        }

        public override MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            documentOverlayVCDelegate = new DocumentOverlayVCDelegate(overlayVCDelegate);
            return new MBDocumentOverlayViewController(nativeDocumentOverlaySettings, ((RecognizerCollection)RecognizerCollection).NativeRecognizerCollection, documentOverlayVCDelegate);
        }
    }

    public class DocumentOverlaySettingsFactory : IDocumentOverlaySettingsFactory
    {
        public IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection)
        {
            return new DocumentOverlaySettings(recognizerCollection);
        }
    }

    public class DocumentOverlayVCDelegate : MBDocumentOverlayViewControllerDelegate
    {
        readonly IOverlayVCDelegate overlayVCDelegate;

        public DocumentOverlayVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            this.overlayVCDelegate = overlayVCDelegate;
        }

        public override void DocumentOverlayViewControllerDidFinishScanning(MBDocumentOverlayViewController documentOverlayViewController, MBRecognizerResultState state)
        {
            overlayVCDelegate.ScanningFinished(documentOverlayViewController, state);
        }

        public override void DocumentOverlayViewControllerDidTapClose(MBDocumentOverlayViewController documentOverlayViewController)
        {
            overlayVCDelegate.CloseButtonTapped(documentOverlayViewController);
        }
    }
}
