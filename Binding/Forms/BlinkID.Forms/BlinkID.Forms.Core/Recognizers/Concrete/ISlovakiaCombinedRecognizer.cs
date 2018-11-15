namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for combined reading of both front and back side of Slovak ID.
    /// 
    /// </summary>
    public interface ISlovakiaCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// True if date of birth is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// True if date of expiry is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// True if date of issue is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// True if document number is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDocumentNumber { get; set; }
        
        /// <summary>
        /// True if issuer is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuedBy { get; set; }
        
        /// <summary>
        /// True if nationality is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// True if place of birth is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// True if sex is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// True if special remarks are being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSpecialRemarks { get; set; }
        
        /// <summary>
        /// True if surname at birth is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurnameAtBirth { get; set; }
        
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
        /// Defines whether signature image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        
        /// <summary>
        /// Defines whether or not recognition result should be signed. 
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
        /// The date of birth of Slovak ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The document date of expiry of the Slovak ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The document date of issue of the Slovak ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Defines digital signature of recognition results. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Defines digital signature version. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Defines {true} if data from scanned parts/sides of the document match, 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        /// The identity card number of Slovak ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Slovak ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// Front side image of the document 
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
        /// True if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// Nationality of the Slovak ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// Personal identification number of the Slovak ID holder. 
        /// </summary>
        string PersonalIdentificationNumber { get; }
        
        /// <summary>
        /// Place of birth of the Slovak ID holder. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// Sex of the Slovak ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// Special remarks of the Slovak ID holder. 
        /// </summary>
        string SpecialRemarks { get; }
        
        /// <summary>
        /// Surname at birth of the Slovak ID holder. 
        /// </summary>
        string SurnameAtBirth { get; }
        
    }
}