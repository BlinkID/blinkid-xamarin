namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Austrian Passport Recognizer.
    /// 
    /// Austrian Passport recognizer is used for scanning Austrian Passport.
    /// </summary>
    public interface IAustriaPassportRecognizer : IRecognizer
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
        /// Defines if owner's date of birth should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if owner's given name should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenName { get; set; }
        
        /// <summary>
        /// Defines if owner's height should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if issuing authority should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if owner's nationality should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if passport number should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// Defines if owner's place of birth should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if owner's sex should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if owner's surname should be extracted from Austrian Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// Property for setting DPI for face images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
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
        /// Sets whether face image from ID card should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Sets whether signature image from ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        
        /// <summary>
        /// Property for setting DPI for signature images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
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
        /// The date Of Birth of the Austrian Passport owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date Of Expiry of the Austrian Passport. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date Of Issue of the Austrian Passport. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The given Name of the Austrian Passport owner. 
        /// </summary>
        string GivenName { get; }
        
        /// <summary>
        /// The height of the Austrian Passport owner. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The issuing Authority of the Austrian Passport. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The mrz of the back side of Austria Passport. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The nationality of the Austrian Passport owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The passport Number of the Austrian Passport. 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// The place Of Birth of the Austrian Passport owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The sex of the Austrian Passport owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of the Austrian Passport owner. 
        /// </summary>
        string Surname { get; }
        
    }
}