namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Colombia Id Back Recognizer.
    /// 
    /// Colombia Id Back recognizer is used for scanning back side of the Colombia Id.
    /// </summary>
    public interface IColombiaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines if glare detection should be turned on/off.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Image extension factors for full document image.
        /// 
        /// @see ImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Set this to true to scan barcodes which don't have quiet zone (white area) around it
        /// 
        /// Use only if necessary because it slows down the recognition process
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
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
        IColombiaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IColombiaIdBackRecognizer.
    /// </summary>
    public interface IColombiaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The birth Date of the Colombia Id owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// The blood Group of the Colombia Id owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The document Number Colombia Id owner. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The fingerprint of the Colombian ID owner. 
        /// </summary>
        byte[] Fingerprint { get; }
        
        /// <summary>
        /// The first Name of the Colombia Id owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The last Name of the Colombia Id owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The sex of the Colombia Id owner. 
        /// </summary>
        string Sex { get; }
        
    }
}