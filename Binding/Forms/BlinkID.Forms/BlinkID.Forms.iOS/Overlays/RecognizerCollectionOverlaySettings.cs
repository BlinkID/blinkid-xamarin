
using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink;

namespace Microblink.Forms.iOS.Overlays
{
	public abstract class RecognizerCollectionOverlaySettings : OverlaySettings
    {
        public IRecognizerCollection RecognizerCollection { get; }

        protected RecognizerCollectionOverlaySettings(MBOverlaySettings nativeOverlaySettings, IRecognizerCollection recognizerCollection) : base(nativeOverlaySettings)
        {
            RecognizerCollection = recognizerCollection;
        }
    }
}
