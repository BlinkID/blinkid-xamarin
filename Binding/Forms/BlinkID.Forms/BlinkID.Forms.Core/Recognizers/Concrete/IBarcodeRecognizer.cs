namespace Microblink.Forms.Core.Recognizers
{
    public interface IBarcodeRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Allow enabling the autodetection of image scale when scanning barcodes. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AutoScaleDetection { get; set; }
        
        /// <summary>
        /// The license key for unlocking improved aztec scanning feature, provided by Manatee. 
        ///
        /// By default, this is set to ''
        /// </summary>
        string ManateeLicenseKey { get; set; }
        
        /// <summary>
        /// Allow scanning PDF417 barcodes which don't have quiet zone 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// Enable reading code39 barcode contents as extended data. For more information about code39 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReadCode39AsExtendedData { get; set; }
        
        /// <summary>
        /// Should Aztec 2D barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanAztecCode { get; set; }
        
        /// <summary>
        /// Should Code128 barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanCode128 { get; set; }
        
        /// <summary>
        /// Should Code39 barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanCode39 { get; set; }
        
        /// <summary>
        /// Should DataMatrix 2D barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanDataMatrix { get; set; }
        
        /// <summary>
        /// Should EAN13 barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanEan13 { get; set; }
        
        /// <summary>
        /// Should EAN8 barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanEan8 { get; set; }
        
        /// <summary>
        /// Enables scanning of barcodes with inverse intensity values (e.g. white barcode on black background) 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanInverse { get; set; }
        
        /// <summary>
        /// Should ITF barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanItf { get; set; }
        
        /// <summary>
        /// Should PDF417 2D barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanPdf417 { get; set; }
        
        /// <summary>
        /// Should QR code be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanQrCode { get; set; }
        
        /// <summary>
        /// Enable decoding of non-standard PDF417 barcodes, but without 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ScanUncertain { get; set; }
        
        /// <summary>
        /// Should UPCA barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanUpca { get; set; }
        
        /// <summary>
        /// Should UPCE barcode be scanned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanUpce { get; set; }
        
        /// <summary>
        /// Enable slower, but more thorough scanning, thus giving higher possibility of successful scan. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool SlowerThoroughScan { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IBarcodeRecognizerResult Result { get; }
    }

    public interface IBarcodeRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The format of the scanned barcode. 
        /// </summary>
        BarcodeType BarcodeType { get; }
        
        /// <summary>
        /// The raw bytes contained inside barcode. 
        /// </summary>
        byte[] RawData { get; }
        
        /// <summary>
        /// String representation of data inside barcode. 
        /// </summary>
        string StringData { get; }
        
        /// <summary>
        /// True if returned result is uncertain, i.e. if scanned barcode was incomplete (i.e. 
        /// </summary>
        bool Uncertain { get; }
        
    }
}