namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan Switzerland passport.
    /// </summary>
    public interface ISwitzerlandPassportRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of Switzerland passport should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Switzerland passport owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Switzerland passport should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Switzerland passport should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if given name of Switzerland passport owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenName { get; set; }
        
        /// <summary>
        /// Defines if height of Switzerland passport owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if passport number of Switzerland passport should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// Defines if place of origin of Switzerland passport owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfOrigin { get; set; }
        
        /// <summary>
        /// Defines if sex of Switzerland passport owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if surname of Switzerland passport owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
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
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISwitzerlandPassportRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISwitzerlandPassportRecognizer.
    /// </summary>
    public interface ISwitzerlandPassportRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The issuing authority of Switzerland passport. 
        /// </summary>
        string Authority { get; }
        
        /// <summary>
        /// The date of birth of Switzerland passport owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of Switzerland passport. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Switzerland passport. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The given name of Switzerland passport owner. 
        /// </summary>
        string GivenName { get; }
        
        /// <summary>
        /// The height of Switzerland passport owner. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The passport number of Switzerland passport. 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// The place of origin of Switzerland passport owner. 
        /// </summary>
        string PlaceOfOrigin { get; }
        
        /// <summary>
        /// The sex of Switzerland passport owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The surname of Switzerland passport owner. 
        /// </summary>
        string Surname { get; }
        
    }
}