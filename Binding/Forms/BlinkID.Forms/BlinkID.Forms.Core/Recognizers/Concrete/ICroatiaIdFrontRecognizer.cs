namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Croatia national ID cards.
    /// </summary>
    public interface ICroatiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if citizenship of Croatian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCitizenship { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Croatian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Croatian ID document should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if first name of Croatian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if last name of Croatian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
        /// <summary>
        /// Defines if sex of Croatian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
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
        /// the DPI (Dots Per Inch) for signature image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ICroatiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICroatiaIdFrontRecognizer.
    /// </summary>
    public interface ICroatiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The citizenship of the Croatian ID owner 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// The date of birth of the Croatian ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the Croatian ID document 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of expiry of the Croatian ID document is permanent 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// The Croatian ID document is bilingual 
        /// </summary>
        bool DocumentBilingual { get; }
        
        /// <summary>
        /// The document number of the Croatian ID 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The last name of the Croatian ID owner 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The first name of the Croatian ID owner 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The sex of the Croatian ID owner 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}