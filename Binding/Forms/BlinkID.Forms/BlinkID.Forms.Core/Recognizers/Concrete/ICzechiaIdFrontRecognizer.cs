namespace Microblink.Forms.Core.Recognizers
{
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
        ICzechiaIdFrontRecognizerResult Result { get; }
    }

    public interface ICzechiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the date of birth of Czech ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the date of expiry of Czech ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// the date of issue of Czech ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the Czech ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the identity card number of Czech ID. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// the last name of the Czech ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// the place of birth of Czech ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// sex of the Czech ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}