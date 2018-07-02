using System;
using Microblink.Forms.Shared.Recognizers;

namespace Microblink.Forms.Shared.Overlays
{
    public interface IDocumentOverlaySettings : IOverlaySettings
    {
    }

    public interface IDocumentOverlaySettingsFactory
    {
        IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
