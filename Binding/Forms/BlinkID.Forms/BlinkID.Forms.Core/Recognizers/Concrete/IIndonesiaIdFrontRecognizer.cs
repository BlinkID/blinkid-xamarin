namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Indonesian national ID cards.
    /// </summary>
    public interface IIndonesiaIdFrontRecognizer : IRecognizer
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
        /// Defines if address of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if blood type of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodType { get; set; }
        
        /// <summary>
        /// Defines if citizenship of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCitizenship { get; set; }
        
        /// <summary>
        /// Defines if city of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCity { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Indonesian ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if district of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDistrict { get; set; }
        
        /// <summary>
        /// Defines if Kel/Desa of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractKelDesa { get; set; }
        
        /// <summary>
        /// Defines if marital status of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractMaritalStatus { get; set; }
        
        /// <summary>
        /// Defines if name of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if occupation of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOccupation { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if religion of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReligion { get; set; }
        
        /// <summary>
        /// Defines if RT number of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRt { get; set; }
        
        /// <summary>
        /// Defines if RW number of Indonesian ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRw { get; set; }
        
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
        IIndonesiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IIndonesiaIdFrontRecognizer.
    /// </summary>
    public interface IIndonesiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the front side of the Indonesia Id owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The blood Type of the front side of the Indonesia Id owner. 
        /// </summary>
        string BloodType { get; }
        
        /// <summary>
        /// The citizenship of the front side of the Indonesia Id owner. 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// The city of the front side of the Indonesia Id owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The date Of Birth of the front side of the Indonesia Id owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date Of Expiry of the front side of the Indonesia Id owner. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date Of Expiry Permanent of the front side of the Indonesia Id owner. 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// The district of the front side of the Indonesia Id owner. 
        /// </summary>
        string District { get; }
        
        /// <summary>
        /// The document Number of the front side of the Indonesia Id owner. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The kel Desa of the front side of the Indonesia Id owner. 
        /// </summary>
        string KelDesa { get; }
        
        /// <summary>
        /// The marital Status of the front side of the Indonesia Id owner. 
        /// </summary>
        string MaritalStatus { get; }
        
        /// <summary>
        /// The name of the front side of the Indonesia Id owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The occupation of the front side of the Indonesia Id owner. 
        /// </summary>
        string Occupation { get; }
        
        /// <summary>
        /// The place Of Birth of the front side of the Indonesia Id owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The province of the front side of the Indonesia Id owner. 
        /// </summary>
        string Province { get; }
        
        /// <summary>
        /// The religion of the front side of the Indonesia Id owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The rt of the front side of the Indonesia Id owner. 
        /// </summary>
        string Rt { get; }
        
        /// <summary>
        /// The rw of the front side of the Indonesia Id owner. 
        /// </summary>
        string Rw { get; }
        
        /// <summary>
        /// The sex of the front side of the Indonesia Id owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}