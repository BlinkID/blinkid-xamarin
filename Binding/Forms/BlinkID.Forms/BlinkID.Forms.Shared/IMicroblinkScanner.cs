using Microblink.Forms.Shared.Overlays;

namespace Microblink.Forms.Shared
{
	public interface IMicroblinkScanner
	{
        void Scan(IOverlaySettings overlaySettings);
	}

    public interface IMicroblinkScannerFactory
    {
        IMicroblinkScanner CreateMicroblinkScanner(string licenseKey);
        IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee);
    }

}

