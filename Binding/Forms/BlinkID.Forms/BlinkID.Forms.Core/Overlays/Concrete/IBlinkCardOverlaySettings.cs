using System;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// BlinkCard overlay settings. This overlay is best suited for scanning payment cards.
    /// </summary>
    public interface IBlinkCardOverlaySettings : IOverlaySettings {
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
    }

    /// <summary>
    /// BlinkCard overlay settings factory. Use this to create an instance of IBlinkCardOverlaySettings.
    /// </summary>
    public interface IBlinkCardOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the BlinkCard overlay settings using provided recognizer collection.
        /// </summary>
        /// <returns>The document verification overlay settings.</returns>
        /// <param name="recognizerCollection">Recognizer collection that will be used for scanning.</param>
        IBlinkCardOverlaySettings CreateBlinkCardOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
