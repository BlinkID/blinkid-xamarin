namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Austrian ID Back Recognizer.
    /// 
    /// Austrian ID Back recognizer is used for scanning back side of Austrian ID.
    /// </summary>
    public interface IAustriaIdBackRecognizer : IRecognizer
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
        /// Defines if date of issuance should be extracted from back side of Austrian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssuance { get; set; }
        
        /// <summary>
        /// Defines if owner's height should be extracted from back side of Austrian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if issuing authority should be extracted from back side of Austrian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if owner's place of birth should be extracted from back side of Austrian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if owner's principal residence should be extracted from back side of Austrian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPrincipalResidence { get; set; }
        
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
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IAustriaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustriaIdBackRecognizer.
    /// </summary>
    public interface IAustriaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The Date Of Issuance of Austrian ID. 
        /// </summary>
        IDate DateOfIssuance { get; }
        
        /// <summary>
        /// The Document Number of Austrian ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The Eye Colour of Austrian ID owner. 
        /// </summary>
        string EyeColour { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The Height of Austrian ID owner. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The Issuing Authority of Austrian ID. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The mrz on the back side of Austrian ID. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The Place Of Birth of Austrian ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The Principal Residence of Austrian ID owner. 
        /// </summary>
        string PrincipalResidence { get; }
        
    }
}