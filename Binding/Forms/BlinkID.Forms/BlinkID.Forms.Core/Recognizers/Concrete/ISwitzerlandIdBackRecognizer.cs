namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Switzerland ID.
    /// </summary>
    public interface ISwitzerlandIdBackRecognizer : IRecognizer
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
        /// Defines if issuing authority of Switzerland ID should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Switzerland ID should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Switzerland ID should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if height of Switzerland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if place of origin of Switzerland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfOrigin { get; set; }
        
        /// <summary>
        /// Defines if sex of Switzerland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        ISwitzerlandIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISwitzerlandIdBackRecognizer.
    /// </summary>
    public interface ISwitzerlandIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The issuing authority of Switzerland ID. 
        /// </summary>
        string Authority { get; }
        
        /// <summary>
        /// The date of expiry of Switzerland ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Switzerland ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The height of Switzerland ID owner. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The place of origin of Switzerland ID owner. 
        /// </summary>
        string PlaceOfOrigin { get; }
        
        /// <summary>
        /// The sex of Switzerland ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}