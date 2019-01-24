namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan the back side of Czech IDs.
    /// </summary>
    public interface ICzechiaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if Czech ID's issuing authority should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// Defines if Czech ID owner's permanent address should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPermanentStay { get; set; }
        
        /// <summary>
        /// Defines if Czech ID owner's personal number should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPersonalNumber { get; set; }
        
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
        /// Defines whether full document image will be available in 
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
        /// Image of the full document 
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