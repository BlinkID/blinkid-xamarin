using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink;
using System;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays
{
    public sealed class BlinkIdOverlaySettings : RecognizerCollectionOverlaySettings, IBlinkIdOverlaySettings
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

        public string FirstSideInstructionsText { 
            get {
                return nativeBlinkIdOverlaySettings.FirstSideInstructionsText;
            }
            set {
                nativeBlinkIdOverlaySettings.FirstSideInstructionsText = value;
            } 
        }

        public string FlipInstructions { 
            get {
                return nativeBlinkIdOverlaySettings.FlipInstructions;
            }
            set {
                nativeBlinkIdOverlaySettings.FlipInstructions = value;
            }  
        }

        public string ErrorMoveCloser { 
            get {
                return nativeBlinkIdOverlaySettings.ErrorMoveCloser;
            }
            set {
                nativeBlinkIdOverlaySettings.ErrorMoveCloser = value;
            }  
        }

        public string ErrorMoveFarther { 
            get {
                return nativeBlinkIdOverlaySettings.ErrorMoveFarther;
            }
            set {
                nativeBlinkIdOverlaySettings.ErrorMoveFarther = value;
            }  
        }

        public string SidesNotMatchingTitle { 
            get {
                return nativeBlinkIdOverlaySettings.SidesNotMatchingTitle;
            }
            set {
                nativeBlinkIdOverlaySettings.SidesNotMatchingTitle = value;
            }  
        }

        public string SidesNotMatchingMessage { 
            get {
                return nativeBlinkIdOverlaySettings.SidesNotMatchingMessage;
            }
            set {
                nativeBlinkIdOverlaySettings.SidesNotMatchingMessage = value;
            }  
        }

        public string UnsupportedDocumentTitle { 
            get {
                return nativeBlinkIdOverlaySettings.UnsupportedDocumentTitle;
            }
            set {
                nativeBlinkIdOverlaySettings.UnsupportedDocumentTitle = value;
            }  
        }

        public string UnsupportedDocumentMessage { 
            get {
                return nativeBlinkIdOverlaySettings.UnsupportedDocumentMessage;
            }
            set {
                nativeBlinkIdOverlaySettings.UnsupportedDocumentMessage = value;
            }  
        }

        public string RecognitionTimeoutTitle { 
            get {
                return nativeBlinkIdOverlaySettings.RecognitionTimeoutTitle;
            }
            set {
                nativeBlinkIdOverlaySettings.RecognitionTimeoutTitle = value;
            }  
        }

        public string RecognitionTimeoutMessage { 
            get {
                return nativeBlinkIdOverlaySettings.RecognitionTimeoutMessage;
            }
            set {
                nativeBlinkIdOverlaySettings.RecognitionTimeoutMessage = value;
            }  
        }

        public string RetryButtonText { 
            get {
                return nativeBlinkIdOverlaySettings.RetryButtonText;
            }
            set {
                nativeBlinkIdOverlaySettings.RetryButtonText = value;
            }  
        }

        public bool RequireDocumentSidesDataMatch { 
            get {
                return nativeBlinkIdOverlaySettings.RequireDocumentSidesDataMatch;
            }
            set {
                nativeBlinkIdOverlaySettings.RequireDocumentSidesDataMatch = value;
            }  
        }

        public bool ShowNotSupportedDialog { 
            get {
                return nativeBlinkIdOverlaySettings.ShowNotSupportedDialog;
            }
            set {
                nativeBlinkIdOverlaySettings.ShowNotSupportedDialog = value;
            }  
        }

        public long BackSideScanningTimeoutMilliseconds { 
            get {
                return Convert.ToInt64(nativeBlinkIdOverlaySettings.BackSideScanningTimeout * 1000);
            }
            set {
                nativeBlinkIdOverlaySettings.BackSideScanningTimeout = Convert.ToDouble(value / 1000.0);
            }  
        }

        public string ScanBarcodeText { 
            get {
                return nativeBlinkIdOverlaySettings.ScanBarcodeText;
            }
            set {
                nativeBlinkIdOverlaySettings.ScanBarcodeText = value;
            }  
        }

        public string ErrorDocumentTooCloseToEdge { 
            get {
                return nativeBlinkIdOverlaySettings.ErrorDocumentTooCloseToEdge;
            }
            set {
                nativeBlinkIdOverlaySettings.ErrorDocumentTooCloseToEdge = value;
            }  
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
