namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Colombian national ID cards.
    /// </summary>
    public interface IColombiaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// The extension factors for full document image. 
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Allow scanning PDF417 barcodes which don't have quiet zone 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Enable decoding of non-standard PDF417 barcodes, but without 
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
        /// The birth date of Colombia ID owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// The blood group of Colombia ID owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The document number of Colombia ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The encoded fingerprint of Colombia ID owner. 
        /// </summary>
        byte[] Fingerprint { get; }
        
        /// <summary>
        /// The first name of Colombia ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The last name of Colombia ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The sex of Colombia ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}