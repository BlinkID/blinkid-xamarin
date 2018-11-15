namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which scans German passports.
    /// 
    /// </summary>
    public interface IGermanyPassportRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// {true} if the authority is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// {true} if the date of issue is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// {true} if name is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// {true} if nationality is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// {true} if the place of birth is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// {true} if surname is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// Defines the extension factors for full document image. 
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
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
        IGermanyPassportRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IGermanyPassportRecognizer.
    /// </summary>
    public interface IGermanyPassportRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The authority of German passport. 
        /// </summary>
        string Authority { get; }
        
        /// <summary>
        /// Defines holder's date of birth if it is successfully converted to result from MRZ date format: <code>YYMMDD</code>. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Defines date of expiry if it is successfully converted to result from MRZ date format: <code>YYMMDD</code>. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of German passport. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Defines document code. Document code contains two characters. For MRTD the first character shall 
        /// </summary>
        string DocumentCode { get; }
        
        /// <summary>
        /// Defines document number. Document number contains up to 9 characters. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Defines three-letter or two-letter code which indicate the issuing State. Three-letter codes are based 
        /// </summary>
        string Issuer { get; }
        
        /// <summary>
        /// Defines true if Machine Readable Zone has been parsed, false otherwise. 
        /// </summary>
        bool MrzParsed { get; }
        
        /// <summary>
        /// Defines the entire Machine Readable Zone text from ID. This text is usually used for parsing 
        /// </summary>
        string MrzText { get; }
        
        /// <summary>
        /// Defines true if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// The name of the German passport owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Defines nationality of the holder represented by a three-letter or two-letter code. Three-letter 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// Defines first optional data.<code>null</code> or empty string if not available. 
        /// </summary>
        string Opt1 { get; }
        
        /// <summary>
        /// Defines second optional data.<code>null</code> or empty string if not available. 
        /// </summary>
        string Opt2 { get; }
        
        /// <summary>
        /// The place of birth of the German passport owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// Defines the primary indentifier. If there is more than one component, they are separated with space. 
        /// </summary>
        string PrimaryId { get; }
        
        /// <summary>
        /// Defines the secondary identifier. If there is more than one component, they are separated with space. 
        /// </summary>
        string SecondaryId { get; }
        
        /// <summary>
        /// Defines sex of the card holder. Sex is specified by use of the single initial, 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of the German passport owner. 
        /// </summary>
        string Surname { get; }
        
    }
}