
using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;

namespace Microblink.Forms.Droid.Overlays
{
    public abstract class OverlaySettings : IOverlaySettings
    {
        private readonly UISettings _nativeUISEttings;

        public virtual UISettings NativeUISettings { 
            get {
                return _nativeUISEttings;
            }
        }

        protected OverlaySettings(UISettings nativeUISettings)
        {
            _nativeUISEttings = nativeUISettings;
        }
    }
}