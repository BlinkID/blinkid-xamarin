namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Brunei temporary residence permit cards.
    /// </summary>
    public interface IBruneiTemporaryResidencePermitBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Brunei temporary residence permit owner's employer should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Brunei temporary residence permit should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if the passport number of Brunei temporary residence permit owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
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
        IBruneiTemporaryResidencePermitBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBruneiTemporaryResidencePermitBackRecognizer.
    /// </summary>
    public interface IBruneiTemporaryResidencePermitBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of Brunei temporary residence permit owner's employer. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of issue of Brunei temporary residence permit. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The passport number of Brunei temporary residence permit owner. 
        /// </summary>
        string PassportNumber { get; }
        
    }
}