using System;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    public interface IBarcodeOverlaySettings : IOverlaySettings
    {
    }

    public interface IBarcodeOverlaySettingsFactory
    {
        IBarcodeOverlaySettings CreateBarcodeOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
