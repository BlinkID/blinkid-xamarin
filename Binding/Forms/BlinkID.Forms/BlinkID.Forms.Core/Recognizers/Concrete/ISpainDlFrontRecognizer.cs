namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Spain Driver's License Front Recognizer.
    /// 
    /// Recognizer which can scan front side of Spain national DL cards
    /// </summary>
    public interface ISpainDlFrontRecognizer : IRecognizer
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
        ///  Defines if date of birth of Spain DL owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        ///  Defines if first name of Spain DL owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of Spain DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if licence categories of Spain DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceCategories { get; set; }
        
        /// <summary>
        ///  Defines if place of birth of Spain DL owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        ///  Defines if surname of Spain DL owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Spain DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidFrom { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Spain DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
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
        ISpainDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISpainDlFrontRecognizer.
    /// </summary>
    public interface ISpainDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of Spain DL owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Spain DL owner 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing authority of the Spain DL 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The licence categories of the Spain DL 
        /// </summary>
        string LicenceCategories { get; }
        
        /// <summary>
        /// The licence number of the Spain DL 
        /// </summary>
        string Number { get; }
        
        /// <summary>
        /// The place of birth of Spain DL owner 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of the Spain DL owner 
        /// </summary>
        string Surname { get; }
        
        /// <summary>
        /// The date of issue of Spain DL 
        /// </summary>
        IDate ValidFrom { get; }
        
        /// <summary>
        /// The date of expiry of Spain DL 
        /// </summary>
        IDate ValidUntil { get; }
        
    }
}