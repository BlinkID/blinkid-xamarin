namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Cyprus national ID cards.
    /// </summary>
    public interface ICyprusIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if expires on date should be extractred. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiresOn { get; set; }
        
        /// <summary>
        /// Defines if sex of Cyprus ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        ICyprusIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICyprusIdBackRecognizer.
    /// </summary>
    public interface ICyprusIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the Cyprus ID card owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The expiry date of Cyprus ID card. 
        /// </summary>
        IDate ExpiresOn { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The sex of the Cyprus ID card owner. 
        /// </summary>
        string Sex { get; }
        
    }
}