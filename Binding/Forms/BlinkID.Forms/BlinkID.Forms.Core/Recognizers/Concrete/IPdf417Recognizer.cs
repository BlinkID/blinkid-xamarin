namespace Microblink.Forms.Core.Recognizers
{
    public interface IPdf417Recognizer : IRecognizer
    {
        
        /// <summary>
        /// Allow scanning PDF417 barcodes which don't have quiet zone 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// Enables scanning of barcodes with inverse intensity values (e.g. white barcode on black background) 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ScanInverse { get; set; }
        
        /// <summary>
        /// Enable decoding of non-standard PDF417 barcodes, but without 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ScanUncertain { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IPdf417RecognizerResult Result { get; }
    }

    public interface IPdf417RecognizerResult : IRecognizerResult {
        
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