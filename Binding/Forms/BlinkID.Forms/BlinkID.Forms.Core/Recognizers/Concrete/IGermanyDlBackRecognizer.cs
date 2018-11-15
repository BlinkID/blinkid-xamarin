namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of German DL cards.
    /// </summary>
    public interface IGermanyDlBackRecognizer : IRecognizer
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
        IGermanyDlBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IGermanyDlBackRecognizer.
    /// </summary>
    public interface IGermanyDlBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of issue for B category of German DL card. 
        /// </summary>
        IDate DateOfIssueB10 { get; }
        
        /// <summary>
        /// The date of issue for B category of German DL card is not specified. 
        /// </summary>
        bool DateOfIssueB10NotSpecified { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}