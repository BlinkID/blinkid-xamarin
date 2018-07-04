using System;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    public interface IDocumentVerificationOverlaySettings : IOverlaySettings
    {
    }

    public interface IDocumentVerificationOverlaySettingsFactory
    {
        IDocumentVerificationOverlaySettings CreateDocumentVerificationOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
