namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Croatian ID Back Recognizer.
    /// 
    /// Croatian ID Back recognizer is used for scanning back side of Croatian ID. It always extracts
    /// MRZ zone and address of ID holder while extracting other elements is optional.
    /// </summary>
    public interface ICroatiaIdBackRecognizer : IRecognizer
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
        /// Defines if date of issue of Croatian ID should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if issuer of Croatian ID should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuedBy { get; set; }
        
        /// <summary>
        /// Defines if residence of Croatian ID owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractResidence { get; set; }
        
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
        ICroatiaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICroatiaIdBackRecognizer.
    /// </summary>
    public interface ICroatiaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Determines if date of expiry of Croatian ID is permanent 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// The date of issue of Croatian ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Determines if Croatian ID is issued for non resident 
        /// </summary>
        bool DocumentForNonResident { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuer of Croatian ID 
        /// </summary>
        string IssuedBy { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The residence of Croatian ID owner 
        /// </summary>
        string Residence { get; }
        
    }
}