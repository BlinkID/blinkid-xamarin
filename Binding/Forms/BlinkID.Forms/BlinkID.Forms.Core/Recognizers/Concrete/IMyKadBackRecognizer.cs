namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer for reading back side of Malaysian MyKad.
    /// </summary>
    public interface IMyKadBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if old NRIC (National Registration Identity Card Number) of MyKad 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOldNric { get; set; }
        
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
        IMyKadBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMyKadBackRecognizer.
    /// </summary>
    public interface IMyKadBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Date of birth of MyKad owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Extended NRIC (National Registration Identity Card Number) of MyKad. 
        /// </summary>
        string ExtendedNric { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// NRIC (National Registration Identity Card Number) of MyKad. 
        /// </summary>
        string Nric { get; }
        
        /// <summary>
        /// Old NRIC (National Registration Identity Card Number) of MyKad. 
        /// </summary>
        string OldNric { get; }
        
        /// <summary>
        /// Sex of MyKad owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}