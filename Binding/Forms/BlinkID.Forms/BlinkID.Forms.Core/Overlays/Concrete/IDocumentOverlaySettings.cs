using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// Document overlay settings. This overlay is best for scanning various ID documents.
    /// </summary>
    public interface IDocumentOverlaySettings : IOverlaySettings
    {}

    /// <summary>
    /// Document overlay settings factory. Use this to create an instance of IDocumentOverlaySettings.
    /// </summary>
    public interface IDocumentOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the document overlay settings using the provided recognizer collection.
        /// </summary>
        /// <returns>The document overlay settings.</returns>
        /// <param name="recognizerCollection">Recognizer collection that will be used for scanning.</param>
        IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
