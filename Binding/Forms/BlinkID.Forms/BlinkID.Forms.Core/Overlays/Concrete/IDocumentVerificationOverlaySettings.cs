using System;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// Document verification overlay settings. This overlay is best for scanning with combined recognizers 
    /// that perform scanning of both front and back side of the document.
    /// </summary>
    public interface IDocumentVerificationOverlaySettings : IOverlaySettings {}

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
