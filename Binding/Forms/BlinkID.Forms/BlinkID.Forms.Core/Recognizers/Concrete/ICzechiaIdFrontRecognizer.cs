namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan front side of czech national ID cards.
    /// 
    /// </summary>
    public interface ICzechiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// {true} if the date of birth is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// {true} if the date of expiry is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// {true} if the date of issue is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// {true} if the given names is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// {true} if the place of birth is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// {true} if the sex is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// {true} if the surname is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        ICzechiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICzechiaIdFrontRecognizer.
    /// </summary>
    public interface ICzechiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of Czech ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of Czech ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Czech ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Czech ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The identity card number of Czech ID. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// The last name of the Czech ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The place of birth of Czech ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// Sex of the Czech ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}