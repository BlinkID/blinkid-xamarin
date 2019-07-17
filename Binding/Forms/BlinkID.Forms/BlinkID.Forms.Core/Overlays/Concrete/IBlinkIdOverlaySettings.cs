using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// BlinkId overlay settings. This overlay is best for scanning various ID documents.
    /// </summary>
    public interface IBlinkIdOverlaySettings : IOverlaySettings
    {}

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
