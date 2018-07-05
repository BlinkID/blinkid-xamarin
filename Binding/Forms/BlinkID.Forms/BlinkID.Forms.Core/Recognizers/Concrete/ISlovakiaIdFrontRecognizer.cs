namespace Microblink.Forms.Core.Recognizers
{
    public interface ISlovakiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if date of birth is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if date of expiry is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// true if date of issue is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// true if document number is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDocumentNumber { get; set; }
        
        /// <summary>
        /// true if issuer is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuedBy { get; set; }
        
        /// <summary>
        /// true if nationality is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// true if sex is being extracted from ID 
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
        /// Defines whether full document image will be available in result. 
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

    public interface ISlovakiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the date of birth of Slovak ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the date of expiry of Slovak ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// the date of issue of Slovak ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// the identity card number of Slovak ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the Slovak ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the issuer of the Slovak ID. 
        /// </summary>
        string IssuedBy { get; }
        
        /// <summary>
        /// the last name of the Slovak ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// the nationality of the Slovak ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// the personal number of the Slovak ID owner. 
        /// </summary>
        string PersonalNumber { get; }
        
        /// <summary>
        /// sex of the Slovak ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}