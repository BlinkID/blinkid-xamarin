namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan front side of slovak national ID cards.
    /// 
    /// </summary>
    public interface ISlovakiaIdFrontRecognizer : IRecognizer
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
        /// True if sex is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        ISlovakiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISlovakiaIdFrontRecognizer.
    /// </summary>
    public interface ISlovakiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of Slovak ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of Slovak ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Slovak ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
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
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuer of the Slovak ID. 
        /// </summary>
        string IssuedBy { get; }
        
        /// <summary>
        /// The last name of the Slovak ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The nationality of the Slovak ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The personal number of the Slovak ID owner. 
        /// </summary>
        string PersonalNumber { get; }
        
        /// <summary>
        /// Sex of the Slovak ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}