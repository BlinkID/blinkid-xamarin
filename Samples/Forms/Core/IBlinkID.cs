using BlinkIDFormsSample.Overlays;
using BlinkIDFormsSample.Recognizers;

namespace BlinkIDApp
{
	public interface IBlinkID
	{
        string AndroidLicenseKey { get; set; }
        string IosLicenseKey { get; set; }

        void Scan(IOverlaySettings overlaySettings, IRecognizerCollection recognizerCollection);
	}
}

