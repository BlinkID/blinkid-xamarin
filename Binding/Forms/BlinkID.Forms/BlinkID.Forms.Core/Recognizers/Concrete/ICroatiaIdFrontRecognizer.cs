namespace Microblink.Forms.Core.Recognizers
{
    public interface ICroatiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if citizenship of Croatian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCitizenship { get; set; }
        
        /// <summary>
        /// true if date of birth of Croatian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if date of expiry is being extracted from Croatian ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// true if sex of Croatian ID owner is being extracted 
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
        ICroatiaIdFrontRecognizerResult Result { get; }
    }

    public interface ICroatiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// citizenship of the Croatian ID owner. 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// the date of birth of Croatian ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the document date of expiry of the Croatian ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// true if date of expiry of the Croatian ID is permanent else false 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// true if scanned document is bilingual 
        /// </summary>
        bool DocumentBilingual { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the Croatian ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the identity card number of Croatian ID. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// the last name of the Croatian ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// sex of the Croatian ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}