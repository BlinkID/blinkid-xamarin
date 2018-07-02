using System;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    public interface IDocumentOverlaySettings : IOverlaySettings
    {
    }

    public interface IDocumentOverlaySettingsFactory
    {
        IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
