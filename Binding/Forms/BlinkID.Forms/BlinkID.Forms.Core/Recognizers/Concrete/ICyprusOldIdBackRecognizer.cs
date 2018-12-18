namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of old Cyprus national ID cards.
    /// </summary>
    public interface ICyprusOldIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if the expiry date of old Cryprus ID card should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiresOn { get; set; }
        
        /// <summary>
        /// Defines if the sex of old Cyprus ID card owner should be extracted. 
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
        ICyprusOldIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICyprusOldIdBackRecognizer.
    /// </summary>
    public interface ICyprusOldIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the old Cyprus ID card owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The expiry date of old Cyprus ID card. 
        /// </summary>
        IDate ExpiresOn { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The sex of the old Cyprus ID card owner. 
        /// </summary>
        string Sex { get; }
        
    }
}