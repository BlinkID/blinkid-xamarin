namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front and back side of the United States driver license.
    /// </summary>
    public interface IBlinkIdCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether blured frames filtering is allowed
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AllowBlurFilter { get; set; }
        
        /// <summary>
        /// Defines whether returning of unparsed MRZ (Machine Readable Zone) results is allowed
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnparsedMrzResults { get; set; }
        
        /// <summary>
        /// Defines whether returning unverified MRZ (Machine Readable Zone) results is allowed
        /// Unverified MRZ is parsed, but check digits are incorrect
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AllowUnverifiedMrzResults { get; set; }
        
        /// <summary>
        /// Defines whether sensitive data should be anonymized in full document image result.
        /// The setting only applies to certain documents
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AnonymizeImage { get; set; }
        
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
        /// Pading is a minimum distance from the edge of the frame and is defined as a percentage of the frame width. Default value is 0.0f and in that case
        /// padding edge and image edge are the same.
        /// Recommended value is 0.02f.
        /// 
        ///  
        ///
        /// By default, this is set to '0.0f'
        /// </summary>
        float PaddingEdge { get; set; }
        
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
        /// Whether or not recognition result should be signed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        
        /// <summary>
        /// Skip back side capture and processing step when back side of the document is not supported
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SkipUnsupportedBack { get; set; }
        
        /// <summary>
        /// Defines whether result characters validatation is performed.
        /// If a result member contains invalid character, the result state cannot be valid
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ValidateResultCharacters { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IBlinkIdCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBlinkIdCombinedRecognizer.
    /// </summary>
    public interface IBlinkIdCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The additional address information of the document owner. 
        /// </summary>
        string AdditionalAddressInformation { get; }
        
        /// <summary>
        /// The additional name information of the document owner. 
        /// </summary>
        string AdditionalNameInformation { get; }
        
        /// <summary>
        /// The address of the document owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The current age of the document owner in years. It is calculated difference
        /// between now and date of birth. Now is current time on the device.
        /// @return current age of the document owner in years or -1 if date of birth is unknown. 
        /// </summary>
        int Age { get; }
        
        /// <summary>
        /// The classification information. 
        /// </summary>
        IClassInfo ClassInfo { get; }
        
        /// <summary>
        /// The driver license conditions. 
        /// </summary>
        string Conditions { get; }
        
        /// <summary>
        /// The date of birth of the document owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the document. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Determines if date of expiry is permanent. 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// The date of issue of the document. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Digital signature of the recognition result. Available only if enabled with signResult property. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Version of the digital signature. Available only if enabled with signResult property. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
        /// <summary>
        /// The additional number of the document. 
        /// </summary>
        string DocumentAdditionalNumber { get; }
        
        /// <summary>
        /// Defines possible color statuses determined from scanned image. 
        /// </summary>
        DocumentImageColorStatus DocumentBackImageColorStatus { get; }
        
        /// <summary>
        /// Defines possible moire statuses determined from scanned image. 
        /// </summary>
        DocumentImageMoireStatus DocumentBackImageMoireStatus { get; }
        
        /// <summary>
        /// Returns DataMatchResultSuccess if data from scanned parts/sides of the document match,
        /// DataMatchResultFailed otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return DataMatchResultFailed. Result will
        /// be DataMatchResultSuccess only if scanned values for all fields that are compared are the same. 
        /// </summary>
        DataMatchResult DocumentDataMatch { get; }
        
        /// <summary>
        /// Defines possible color statuses determined from scanned image. 
        /// </summary>
        DocumentImageColorStatus DocumentFrontImageColorStatus { get; }
        
        /// <summary>
        /// Defines possible moire statuses determined from scanned image. 
        /// </summary>
        DocumentImageMoireStatus DocumentFrontImageMoireStatus { get; }
        
        /// <summary>
        /// The document number. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The driver license detailed info. 
        /// </summary>
        IDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }
        
        /// <summary>
        /// The employer of the document owner. 
        /// </summary>
        string Employer { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the document owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// back side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// front side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// The full name of the document owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The issuing authority of the document. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The last name of the document owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The localized name of the document owner. 
        /// </summary>
        string LocalizedName { get; }
        
        /// <summary>
        /// The marital status of the document owner. 
        /// </summary>
        string MaritalStatus { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The nationality of the documet owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The personal identification number. 
        /// </summary>
        string PersonalIdNumber { get; }
        
        /// <summary>
        /// The place of birth of the document owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The profession of the document owner. 
        /// </summary>
        string Profession { get; }
        
        /// <summary>
        /// The race of the document owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// The religion of the document owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The residential stauts of the document owner. 
        /// </summary>
        string ResidentialStatus { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the document owner. 
        /// </summary>
        string Sex { get; }
        
    }
}