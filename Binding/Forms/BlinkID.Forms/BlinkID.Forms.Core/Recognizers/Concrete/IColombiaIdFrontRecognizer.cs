namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Colombian national ID cards.
    /// </summary>
    public interface IColombiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if first name of ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if last name of ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
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
        IColombiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IColombiaIdFrontRecognizer.
    /// </summary>
    public interface IColombiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The document number of Colombia ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of Colombia ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The last name of Colombia ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}