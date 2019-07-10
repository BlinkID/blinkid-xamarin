namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of UAE drivers license.
    /// </summary>
    public interface IUnitedArabEmiratesDlFrontRecognizer : IRecognizer
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
        /// Defines if date of birth of UAE DL owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if issue date of UAE DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssueDate { get; set; }
        
        /// <summary>
        /// Defines if license number of UAE DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenseNumber { get; set; }
        
        /// <summary>
        /// Defines if licensing authority code of UAE DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicensingAuthority { get; set; }
        
        /// <summary>
        /// Defines if name of UAE DL owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of UAE DL owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if place of issue of UAE DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfIssue { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        IUnitedArabEmiratesDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IUnitedArabEmiratesDlFrontRecognizer.
    /// </summary>
    public interface IUnitedArabEmiratesDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date Of Birth of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The expiry Date of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issue Date of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// The license Number of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        string LicenseNumber { get; }
        
        /// <summary>
        /// The licensing Authority of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        string LicensingAuthority { get; }
        
        /// <summary>
        /// The name of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The place Of Issue of the front side of the United Arab Emirates Dl owner. 
        /// </summary>
        string PlaceOfIssue { get; }
        
    }
}