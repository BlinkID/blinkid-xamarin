namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Switzerland DL Front Recognizer.
    /// 
    /// Switzerland DL Front recognizer is used for scanning front side of the Switzerland DL.
    /// </summary>
    public interface ISwitzerlandDlFrontRecognizer : IRecognizer
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
        /// Defines if owner's date of birth should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if owner's first name should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if issuing authority should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if owner's last name should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
        /// <summary>
        /// Defines if owner's place of birth should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if vehicle categories should be extracted from front side of the Switzerland DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractVehicleCategories { get; set; }
        
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
        ISwitzerlandDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISwitzerlandDlFrontRecognizer.
    /// </summary>
    public interface ISwitzerlandDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the Switzerland DL owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of rxpiry of the Switzerland DL. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of the Switzerland DL. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// If true, then this Switzerland DL will never expire. 
        /// </summary>
        bool ExpiryDatePermanent { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Switzerland DL owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing authority of the Switzerland DL. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The last name of the Switzerland DL owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The license number of the Switzerland DL. 
        /// </summary>
        string LicenseNumber { get; }
        
        /// <summary>
        /// The place of birth of the Switzerland DL owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The vehicle categories of the Switzerland DL. 
        /// </summary>
        string VehicleCategories { get; }
        
    }
}