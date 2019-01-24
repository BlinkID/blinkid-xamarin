namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Slovak ID Combined Recognizer.
    /// 
    /// Slovak ID Combined recognizer is used for scanning both front and back side of Slovak ID.
    /// </summary>
    public interface ISlovakiaCombinedRecognizer : IRecognizer
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
        /// Defines if owner's date of birth should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if ID's date of expiry should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if ID's date of issue should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if issuing document number should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDocumentNumber { get; set; }
        
        /// <summary>
        /// Defines if issuing authority should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuedBy { get; set; }
        
        /// <summary>
        /// Defines if owner's nationality should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if owner's place of birth should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if owner's sex should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if owner's special remarks should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSpecialRemarks { get; set; }
        
        /// <summary>
        /// Defines if owner's surname at birth should be extracted from Slovakian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurnameAtBirth { get; set; }
        
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
        ISlovakiaCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISlovakiaCombinedRecognizer.
    /// </summary>
    public interface ISlovakiaCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Slovak ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of Slovak ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of Slovak ID owner 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Slovak ID owner 
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
        /// The identity card number of Slovak ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Slovak ID owner. 
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
        /// The issuing authority of Slovak ID. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The last name of the Slovak ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// true if all check digits inside MRZ are correct, false otherwise.
        /// More specifically, true if MRZ complies with ICAO Document 9303 standard, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// The nationality of the Slovak ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The PIN of the Slovak ID owner. 
        /// </summary>
        string PersonalIdentificationNumber { get; }
        
        /// <summary>
        /// The place of birth of the Slovak ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the Slovak ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The special remarks of Slovak ID. 
        /// </summary>
        string SpecialRemarks { get; }
        
        /// <summary>
        /// The surname at birth of Slovak ID. 
        /// </summary>
        string SurnameAtBirth { get; }
        
    }
}