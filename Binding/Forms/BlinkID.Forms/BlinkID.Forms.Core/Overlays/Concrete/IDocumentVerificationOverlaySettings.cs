using System;
using BlinkID.Forms.Core.Recognizers;

namespace BlinkID.Forms.Core.Overlays
{
    /// <summary>
    /// Document verification overlay settings. This overlay is best for scanning with combined recognizers 
    /// that perform scanning of both front and back side of the document.
    /// </summary>
    public interface IDocumentVerificationOverlaySettings : IOverlaySettings, IScanSoundOverlaySettings
    {
        /// <summary>
        /// Splash message that is shown before scanning the first side of the document, while starting camera.
        /// If null, default value will be used.
        /// </summary>
        string FirstSideSplashMessage { get; set;}
        /// <summary>
        /// Splash message that is shown before scanning the second side of the document, while starting camera.
        /// If null, default value will be used.
        /// </summary>
        string SecondSideSplashMessage { get; set; }
        /// <summary>
        /// Splash message that is shown after scanning the document.
        /// If null, default value will be used.
        /// </summary>
        string ScanningDoneSplashMessage { get; set; }
        /// <summary>
        /// User instructions that are shown above camera preview while the first side of the document is being scanned.
        /// If null, default value will be used.
        /// </summary>
        string FirstSideInstructions { get; set; }
        /// <summary>
        /// User instructions that are shown above camera preview while the second side of the document is being scanned.
        /// If null, default value will be used.
        /// </summary>
        string SecondSideInstructions { get; set; }
        /// <summary>
        /// Glare message that is shown if glare was detected while scanning document.
        /// If null, default value will be used.
        /// </summary>
        string GlareMessage { get; set; }
    }

    /// <summary>
    /// Document verification overlay settings factory. Use this to create an instance of IDocumentVerificationOverlaySettings.
    /// </summary>
    public interface IDocumentVerificationOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the document verification overlay settings using provided recognizer collection.
        /// </summary>
        /// <returns>The document verification overlay settings.</returns>
        /// <param name="recognizerCollection">Recognizer collection that will be used for scanning.</param>
        IDocumentVerificationOverlaySettings CreateDocumentVerificationOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}