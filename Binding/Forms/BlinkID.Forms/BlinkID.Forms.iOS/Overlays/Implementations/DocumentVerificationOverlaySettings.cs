using System;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.Core.Recognizers;
using BlinkID.Forms.iOS.Overlays.Implementations;
using BlinkID.Forms.iOS.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentVerificationOverlaySettingsFactory))]
namespace BlinkID.Forms.iOS.Overlays.Implementations
{
    public sealed class DocumentVerificationOverlaySettings : RecognizerCollectionOverlaySettings, IDocumentVerificationOverlaySettings
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

        public string FirstSideSplashMessage { 
            get {
                return nativeOverlaySettings.FirstSideSplashMessage;
            }
            set {
                nativeOverlaySettings.FirstSideSplashMessage = value;
            } 
        }

        public string SecondSideSplashMessage { 
            get {
                return nativeOverlaySettings.SecondSideSplashMessage;
            }
            set {
                nativeOverlaySettings.SecondSideSplashMessage = value;
            }  
        }

        public string ScanningDoneSplashMessage { 
            get {
                return nativeOverlaySettings.ScanningDoneSplashMessage;
            }
            set {
                nativeOverlaySettings.ScanningDoneSplashMessage = value;
            }  
        }

        public string FirstSideInstructions { 
            get {
                return nativeOverlaySettings.FirstSideInstructions;
            }
            set {
                nativeOverlaySettings.FirstSideInstructions = value;
            }  
        }

        public string SecondSideInstructions { 
            get {
                return nativeOverlaySettings.SecondSideInstructions;
            }
            set {
                nativeOverlaySettings.SecondSideInstructions = value;
            }  
        }

        public string GlareMessage { 
            get {
                return nativeOverlaySettings.GlareMessage;
            }
            set {
                nativeOverlaySettings.GlareMessage = value;
            }  
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