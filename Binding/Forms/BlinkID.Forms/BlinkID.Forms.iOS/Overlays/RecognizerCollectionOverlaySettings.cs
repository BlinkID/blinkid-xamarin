
using BlinkID.Forms.iOS.Overlays;
using BlinkID.Forms.Core.Overlays;
using BlinkID.Forms.Core.Recognizers;
using BlinkID;

namespace BlinkID.Forms.iOS.Overlays
{
	public abstract class RecognizerCollectionOverlaySettings : BaseOverlaySettings
    {
        public IRecognizerCollection RecognizerCollection { get; }

        protected RecognizerCollectionOverlaySettings(MBBaseOverlaySettings nativeOverlaySettings, IRecognizerCollection recognizerCollection) : base(nativeOverlaySettings)
        {
            RecognizerCollection = recognizerCollection;
        }
    }
}