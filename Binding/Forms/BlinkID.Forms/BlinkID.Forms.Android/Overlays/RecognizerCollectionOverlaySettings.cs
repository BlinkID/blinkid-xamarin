
using BlinkID.Forms.Droid.Overlays;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;

namespace BlinkID.Forms.Droid.Overlays
{
    public abstract class RecognizerCollectionOverlaySettings : OverlaySettings
    {
        public IRecognizerCollection RecognizerCollection { get; }

        protected RecognizerCollectionOverlaySettings(UISettings nativeUISettings, IRecognizerCollection recognizerCollection)
            : base(nativeUISettings)
        {
            RecognizerCollection = recognizerCollection;
        }
    }
}