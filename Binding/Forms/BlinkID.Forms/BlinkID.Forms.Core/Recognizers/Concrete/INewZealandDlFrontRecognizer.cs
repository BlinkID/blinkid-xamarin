namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of New Zealand DL cards.
    /// </summary>
    public interface INewZealandDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of New Zealand DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of birth of New Zealand DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of New Zealand DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of New Zealand DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if donor indicator of New Zealand DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDonorIndicator { get; set; }
        
        /// <summary>
        /// Defines if first names of New Zealand DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstNames { get; set; }
        
        /// <summary>
        /// Defines if surname of New Zealand DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// The extension factors for full document image. 
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
        /// The DPI (Dots Per Inch) for signature image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        INewZealandDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for INewZealandDlFrontRecognizer.
    /// </summary>
    public interface INewZealandDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the New Zealand DL owner 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The card version of the New Zealand DL 
        /// </summary>
        string CardVersion { get; }
        
        /// <summary>
        /// The date of birth of the New Zealand DL owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the New Zealand DL 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of the New Zealand DL 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Donor indicator of the New Zealand DL owner. It's true if "DONOR" is printed on document, otherwise it's false 
        /// </summary>
        bool DonorIndicator { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first names of the New Zealand DL owner 
        /// </summary>
        string FirstNames { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The license number of the New Zealand DL 
        /// </summary>
        string LicenseNumber { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of the New Zealand DL owner 
        /// </summary>
        string Surname { get; }
        
    }
}