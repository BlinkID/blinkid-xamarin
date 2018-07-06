using System;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// Barcode overlay settings. This overlay is best for scanning various barcode types.
    /// </summary>
    public interface IBarcodeOverlaySettings : IOverlaySettings
    {}

    /// <summary>
    /// Barcode overlay settings factory. Use this to create an instance of IBarcodeOverlaySettings.
    /// </summary>
    public interface IBarcodeOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the barcode overlay settings using the provided recognizer collection.
        /// </summary>
        /// <returns>The barcode overlay settings.</returns>
        /// <param name="recognizerCollection">Recognizer collection that will be used for scanning.</param>
        IBarcodeOverlaySettings CreateBarcodeOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
