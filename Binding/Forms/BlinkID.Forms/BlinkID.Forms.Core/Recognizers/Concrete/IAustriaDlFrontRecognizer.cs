namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Austrian national DL cards.
    /// </summary>
    public interface IAustriaDlFrontRecognizer : IRecognizer
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
        /// Defines if date of birth of Austrian DL owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Austrian DL should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Austrian DL should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if first name of Austrian DL owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of Austrian DL should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if name of Austrian DL owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Austrian DL owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if vehicle categories of Austrian DL should be extracted.
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
        IAustriaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustriaDlFrontRecognizer.
    /// </summary>
    public interface IAustriaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date Of Birth of the front side of the Austria Dl owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date Of Expiry of the front side of the Austria Dl owner. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date Of Issue of the front side of the Austria Dl owner. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first Name of the front side of the Austria Dl owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing Authority of the front side of the Austria Dl owner. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The licence Number of the front side of the Austria Dl owner. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The name of the front side of the Austria Dl owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The place Of Birth of the front side of the Austria Dl owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The vehicle Categories of the front side of the Austria Dl owner. 
        /// </summary>
        string VehicleCategories { get; }
        
    }
}