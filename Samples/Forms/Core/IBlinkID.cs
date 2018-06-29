using BlinkIDFormsSample.Overlays;

namespace BlinkIDApp
{
	public interface IBlinkID
	{
        string AndroidLicenseKey { get; set; }
        string IosLicenseKey { get; set; }

        void Scan(IOverlaySettings overlaySettings);
	}
}

