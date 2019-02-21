namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Austrian national ID cards.
    /// </summary>
    public interface IAustriaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if date of issuance should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssuance { get; set; }
        
        /// <summary>
        /// Defines if height of Austrian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if issuing authority should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Austrian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if principal residence of Austrian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPrincipalResidence { get; set; }
        
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
        IAustriaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustriaIdBackRecognizer.
    /// </summary>
    public interface IAustriaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of issuance of the ID 
        /// </summary>
        IDate DateOfIssuance { get; }
        
        /// <summary>
        /// The document number of Austrian ID 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The eye colour of the card holder. 
        /// </summary>
        string EyeColour { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The height of the cardholder in centimeters 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The issuing authority of Austrian ID 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The place of birth of the card holder 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The principal residence at issuance of the card holder. 
        /// </summary>
        string PrincipalResidence { get; }
        
    }
}