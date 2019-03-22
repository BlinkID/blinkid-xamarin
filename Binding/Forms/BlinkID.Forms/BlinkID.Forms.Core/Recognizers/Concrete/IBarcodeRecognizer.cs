namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// BarcodeRecognizer is used for scanning most of 1D barcode formats, and 2D format
    /// such as Aztec, DataMatrix and QR code
    /// </summary>
    public interface IBarcodeRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Allow enabling the autodetection of image scale when scanning barcodes.
        /// If set to true, prior reading barcode, image scale will be
        /// corrected. This enabled correct reading of barcodes on high
        /// resolution images but slows down the recognition process.
        /// 
        /// falseTE: This setting is applied only for Code39 and Code128 barcode scanning.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AutoScaleDetection { get; set; }
        
        /// <summary>
        /// Set this to true to scan barcodes which don't have quiet zone (white area) around it
        /// 
        /// Use only if necessary because it slows down the recognition process
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// Enable reading code39 barcode contents as extended data. For more information about code39
        /// extended data (a.k.a. full ASCII mode), see https://en.wikipedia.org/wiki/Code_39#Full_ASCII_Code_39
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReadCode39AsExtendedData { get; set; }
        
        /// <summary>
        /// Set this to true to scan Aztec 2D barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanAztecCode { get; set; }
        
        /// <summary>
        /// Set this to true to scan Code 128 1D barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanCode128 { get; set; }
        
        /// <summary>
        /// Set this to true to scan Code 39 1D barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanCode39 { get; set; }
        
        /// <summary>
        /// Set this to true to scan DataMatrix 2D barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanDataMatrix { get; set; }
        
        /// <summary>
        /// Set this to true to scan EAN 13 barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanEan13 { get; set; }
        
        /// <summary>
        /// Set this to true to scan EAN8 barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanEan8 { get; set; }
        
        /// <summary>
        /// Set this to true to allow scanning barcodes with inverted intensities
        /// (i.e. white barcodes on black background)
        /// 
        /// falseTE: this options doubles the frame processing time
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanInverse { get; set; }
        
        /// <summary>
        /// Set this to true to scan ITF barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanItf { get; set; }
        
        /// <summary>
        /// Set this to true to scan Pdf417 barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanPdf417 { get; set; }
        
        /// <summary>
        /// Set this to true to scan QR barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanQrCode { get; set; }
        
        /// <summary>
        /// Set this to true to scan even barcode not compliant with standards
        /// For example, malformed PDF417 barcodes which were incorrectly encoded
        /// 
        /// Use only if necessary because it slows down the recognition process
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ScanUncertain { get; set; }
        
        /// <summary>
        /// Set this to true to scan UPCA barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanUpca { get; set; }
        
        /// <summary>
        /// Set this to true to scan UPCE barcodes
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanUpce { get; set; }
        
        /// <summary>
        /// Set this to true to allow slower, but better image processing.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool SlowerThoroughScan { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IBarcodeRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBarcodeRecognizer.
    /// </summary>
    public interface IBarcodeRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Type of the barcode scanned
        /// 
        ///  @return Type of the barcode 
        /// </summary>
        BarcodeType BarcodeType { get; }
        
        /// <summary>
        /// Byte array with result of the scan 
        /// </summary>
        byte[] RawData { get; }
        
        /// <summary>
        /// Retrieves string content of scanned data 
        /// </summary>
        string StringData { get; }
        
        /// <summary>
        /// Flag indicating uncertain scanning data
        /// E.g obtained from damaged barcode. 
        /// </summary>
        bool Uncertain { get; }
        
    }
}