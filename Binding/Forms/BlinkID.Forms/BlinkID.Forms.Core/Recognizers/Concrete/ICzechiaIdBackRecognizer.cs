namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan the back side of Czech IDs.
    /// </summary>
    public interface ICzechiaIdBackRecognizer : IRecognizer
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
        /// Defines if Czech ID's issuing authority should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// Defines if Czech ID owner's permanent address should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPermanentStay { get; set; }
        
        /// <summary>
        /// Defines if Czech ID owner's personal number should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPersonalNumber { get; set; }
        
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
        ICzechiaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICzechiaIdBackRecognizer.
    /// </summary>
    public interface ICzechiaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The Czech ID's issuing authority. 
        /// </summary>
        string Authority { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The data extracted from Czech ID's machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The Czech ID owner's permanent address. 
        /// </summary>
        string PermanentStay { get; }
        
        /// <summary>
        /// The Czech ID owner's personal number. 
        /// </summary>
        string PersonalNumber { get; }
        
    }
}