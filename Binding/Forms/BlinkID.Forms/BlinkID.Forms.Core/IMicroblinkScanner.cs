using Microblink.Forms.Core.Overlays;

namespace Microblink.Forms.Core
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

