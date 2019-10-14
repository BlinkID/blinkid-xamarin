namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Nigeria voter ID cards.
    /// </summary>
    public interface INigeriaVoterIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        INigeriaVoterIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for INigeriaVoterIdBackRecognizer.
    /// </summary>
    public interface INigeriaVoterIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of Nigeria Voter ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of Nigeria Voter ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The first name of Nigeria Voter ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The raw barcode data of Nigeria Voter ID card. 
        /// </summary>
        string RawBarcodeData { get; }
        
        /// <summary>
        /// The sex of Nigeria Voter ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The surname of Nigeria Voter ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}