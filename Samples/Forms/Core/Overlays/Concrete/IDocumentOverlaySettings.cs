using System;
using BlinkIDFormsSample.Recognizers;

namespace BlinkIDFormsSample.Overlays
{
    public interface IDocumentOverlaySettings : IOverlaySettings
    {
    }

    public interface IDocumentOverlaySettingsFactory
    {
        IDocumentOverlaySettings CreateDocumentOverlaySettings(IRecognizerCollection recognizerCollection);
    }
}
