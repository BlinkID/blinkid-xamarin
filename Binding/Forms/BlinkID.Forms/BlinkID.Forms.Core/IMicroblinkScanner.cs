using Microblink.Forms.Core.Overlays;

namespace Microblink.Forms.Core
{
    /// <summary>
    /// A main scanner object that will be used for performing the scan.
    /// </summary>
	public interface IMicroblinkScanner
	{
        /// <summary>
        /// Perform the scanning using overlay specified by given IOverlaySettings.
        /// </summary>
        /// <param name="overlaySettings">Overlay settings that specify the UI overlay that will be used for scanning.</param>
        void Scan(IOverlaySettings overlaySettings);
	}

    /// <summary>
    /// Microblink scanner factory is needed for creating an instance of IMicroblinkScanner.
    /// </summary>
    public interface IMicroblinkScannerFactory
    {
        /// <summary>
        /// Creates the microblink scanner using provided licenseKey. The license key used must be bound to
        /// specific iOS bundleID or Android application ID.
        /// </summary>
        /// <returns>The microblink scanner.</returns>
        /// <param name="licenseKey">License key for unlocking the scanning feature.</param>
        /// <param name="showTimeLimitedLicenseWarning">Flag which indicates whether warning for time limited license key will be shown.</param>
        IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, bool showTimeLimitedLicenseWarning = true);

        /// <summary>
        /// Creates the microblink scanner using provided <paramref name="licenseKey"/>. The license key used must be bound to
        /// given licensee.
        /// </summary>
        /// <returns>The microblink scanner.</returns>
        /// <param name="licenseKey">License key for unlocking the scanning feature</param>
        /// <param name="licensee">Licensee to which provided <paramref name="licenseKey"/> is bound.
        /// <param name="showTimeLimitedLicenseWarning">Flag which indicates whether warning for time limited license key will be shown.</param>
        IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee, bool showTimeLimitedLicenseWarning = true);
    }

}

