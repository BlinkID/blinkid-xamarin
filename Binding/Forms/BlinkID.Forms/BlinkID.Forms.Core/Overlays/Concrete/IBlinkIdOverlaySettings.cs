using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// BlinkId overlay settings. This overlay is best for scanning various ID documents.
    /// </summary>
    public interface IBlinkIdOverlaySettings : IOverlaySettings
    {
        /// <summary>
        /// Message that is shown while scanning first side of the document.
        /// If null, default value will be used.
        /// </summary>
        string FirstSideInstructionsText { get; set;}
        /// <summary>
        /// Instructions to flip the document, shown when scanning of the first side is done, before scanning the second
        /// side of the document.
        /// If null, default value will be used.
        /// </summary>
        string FlipInstructions { get; set; }
        /// <summary>
        /// Instructions for the user to move the document closer.
        /// If null, default value will be used.
        /// </summary>
        string ErrorMoveCloser { get; set; }
        /// <summary>
        /// Instructions for the user to move the document farther.
        /// If null, default value will be used.
        /// </summary>
        string ErrorMoveFarther { get; set; }
        /// <summary>
        /// Title of the dialog, which is shown when scanned document sides are not from the same document.
        /// If null, default value will be used.
        /// </summary>
        string SidesNotMatchingTitle { get; set; }
        /// <summary>
        /// Message inside dialog, which is shown when scanned document sides are not from the same document.
        /// If null, default value will be used.
        /// </summary>
        string SidesNotMatchingMessage { get; set; }
        /// <summary>
        /// Title of the dialog, which is shown when unsupported document is scanned.
        /// If null, default value will be used.
        /// </summary>
        string UnsupportedDocumentTitle { get; set; }
         /// <summary>
        /// Message inside dialog, which is shown when unsupported document is scanned.
        /// If null, default value will be used.
        /// </summary>
        string UnsupportedDocumentMessage { get; set; }
        /// <summary>
        /// Title of the dialog, which is shown on timeout when scanning is stuck on the back document side.
        /// If null, default value will be used.
        /// </summary>
        string RecognitionTimeoutTitle { get; set; }
        /// <summary>
        /// Message inside dialog, which is shown on timeout when scanning is stuck on the back document side.
        /// If null, default value will be used.
        /// </summary>
        string RecognitionTimeoutMessage { get; set; }
        /// <summary>
        /// Text of the "retry" button inside dialog, which is shown on timeout when scanning is stuck on the back
        /// document side.
        /// If null, default value will be used.
        /// </summary>
        string RetryButtonText { get; set; }
        /// <summary>
        /// If true, BlinkIdCombinedRecognizer will check if sides do match when scanning is finished.
        /// Default true
        /// </summary>
        bool RequireDocumentSidesDataMatch { get; set; }
        /// <summary>
        /// Defines whether Document Not Supported dialog will be displayed in UI.
        /// Default true
        /// </summary>
        bool ShowNotSupportedDialog { get; set; }
        /// <summary>
        /// Option to configure back side scanning timeout.
        /// Default 17000.
        /// </summary>
        long BackSideScanningTimeoutMilliseconds { get; set; }
        /// <summary>
        /// Message that is shown while scanning the barcode.
        /// If null, default value will be used.
        /// </summary>
        string ScanBarcodeText { get; set; }
        /// <summary>
        /// Instructions for the user to move the document from the edge.
        /// If null, default value will be used.
        /// </summary>
        string ErrorDocumentTooCloseToEdge { get; set; }


    }

    /// <summary>
    /// BlinkId overlay settings factory. Use this to create an instance of IBlinkIdOverlaySettings.
    /// </summary>
    public interface IBlinkIdOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the BlinkId overlay settings using the provided recognizer collection.
        /// </summary>
        /// <returns>The BlinkId overlay settings.</returns>
        /// <param name="recognizerCollection">Recognizer collection that will be used for scanning.</param>
        IBlinkIdOverlaySettings CreateBlinkIdOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
