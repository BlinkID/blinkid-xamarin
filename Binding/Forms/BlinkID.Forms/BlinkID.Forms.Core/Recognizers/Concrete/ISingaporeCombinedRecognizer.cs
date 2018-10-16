namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Singapore ID Combined Recognizer.
    /// 
    /// Singapore ID Combined recognizer is used for scanning both front and back side of Singapore ID.
    /// </summary>
    public interface ISingaporeCombinedRecognizer : IRecognizer
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
        /// Defines if owner's address should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if owner's address change date should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractAddressChangeDate { get; set; }
        
        /// <summary>
        /// Defines if owner's blood type should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodGroup { get; set; }
        
        /// <summary>
        ///  Defines if country/place of birth of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCountryOfBirth { get; set; }
        
        /// <summary>
        ///  Defines if date of birth of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if owner's date of issue should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        ///  Defines if name of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        ///  Defines if race of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRace { get; set; }
        
        /// <summary>
        ///  Defines if sex of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        /// Whether or not recognition result should be signed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISingaporeCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeCombinedRecognizer.
    /// </summary>
    public interface ISingaporeCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the back side of the Singapore Id owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The address Change Date of the back side of the Singapore Id owner. 
        /// </summary>
        IDate AddressChangeDate { get; }
        
        /// <summary>
        /// The blood Type of the back side of the Singapore Id owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The country/place of birth of the Singaporean ID card owner. 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// The date of birth of the Singaporean ID card owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date Of Issue of the back side of the Singapore Id owner. 
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
        /// Returns true if data from scanned parts/sides of the document match,
        /// false otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return false. Result will
        /// be true only if scanned values for all fields that are compared are the same. 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// back side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// front side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// The identity card number of the Singaporean ID card. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// The name of the Singaporean ID card owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The race of the Singaporean ID card owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the Singaporean ID card owner. 
        /// </summary>
        string Sex { get; }
        
    }
}