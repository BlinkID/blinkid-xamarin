namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan the front side of Australian driver's licences.
    /// </summary>
    public interface IAustraliaDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Australian DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Australian DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if full name of Australian DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullName { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Australian DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenseExpiry { get; set; }
        
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
        IAustraliaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustraliaDlFrontRecognizer.
    /// </summary>
    public interface IAustraliaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Australian DL owner 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of the Australian DL owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The full name of the Australian DL owner 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The date of expiry of the Australian DL 
        /// </summary>
        IDate LicenceExpiry { get; }
        
        /// <summary>
        /// The licence number of the Australian DL 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The licence type of the Australian DL 
        /// </summary>
        string LicenceType { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}