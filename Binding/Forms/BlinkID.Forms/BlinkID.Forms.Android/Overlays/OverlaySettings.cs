
using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;

namespace Microblink.Forms.Droid.Overlays
{
    public abstract class OverlaySettings : IOverlaySettings
    {
        public UISettings NativeUISettings { get; }

        public IRecognizerCollection RecognizerCollection { get; }

        protected OverlaySettings(UISettings nativeUISettings, IRecognizerCollection recognizerCollection)
        {
            NativeUISettings = nativeUISettings;
            RecognizerCollection = recognizerCollection;
        }
    }
}
