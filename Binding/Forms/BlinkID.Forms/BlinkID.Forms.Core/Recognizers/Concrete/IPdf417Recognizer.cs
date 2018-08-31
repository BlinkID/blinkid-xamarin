namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// A recognizer that can scan PDF417 2D barcodes.
    /// </summary>
    public interface IPdf417Recognizer : IRecognizer
    {
        
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
        /// Gets the result.
        /// </summary>
        IPdf417RecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IPdf417Recognizer.
    /// </summary>
    public interface IPdf417RecognizerResult : IRecognizerResult {
        
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