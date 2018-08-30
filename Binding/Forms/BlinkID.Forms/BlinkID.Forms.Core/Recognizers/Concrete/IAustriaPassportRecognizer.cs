namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan Austrian passport.
    /// </summary>
    public interface IAustriaPassportRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Austrian passport owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Austrian passport should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Austrian passport should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if given name of Austrian passport owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenName { get; set; }
        
        /// <summary>
        /// Defines if height of Austrian passport owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of Austrian passport should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if nationality of the Austrian passport owner should be extracted 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if passport number of Austrian passport should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Austrian passport owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if sex of Austrian passport owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if surname of Austrian passport owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Defines whether signature image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for signature image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IAustriaPassportRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustriaPassportRecognizer.
    /// </summary>
    public interface IAustriaPassportRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of Austrian passport owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of Austrian passport 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Austrian passport 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The given name of the Austrian passport owner 
        /// </summary>
        string GivenName { get; }
        
        /// <summary>
        /// The height of the passport owner in centimeters 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The issuing authority of the Austrian passport 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The nationality of the Austrian passport owner 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The passport number of the Austrian passport 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// The place of birth of the Austrian passport owner 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The sex of the Austrian passport owner 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of the Austrian passport owner. 
        /// </summary>
        string Surname { get; }
        
    }
}