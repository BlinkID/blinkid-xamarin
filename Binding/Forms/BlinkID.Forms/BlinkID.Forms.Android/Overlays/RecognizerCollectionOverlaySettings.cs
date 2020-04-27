
using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;

namespace Microblink.Forms.Droid.Overlays
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