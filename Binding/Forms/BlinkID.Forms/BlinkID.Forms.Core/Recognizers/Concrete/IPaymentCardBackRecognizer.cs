namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning the back side of credit/debit cards
    /// </summary>
    public interface IPaymentCardBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Should extract the card's inventory number 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractInventoryNumber { get; set; }
        
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
        IPaymentCardBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IPaymentCardBackRecognizer.
    /// </summary>
    public interface IPaymentCardBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Payment card's security code/value. 
        /// </summary>
        string Cvv { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Payment card's inventory number. 
        /// </summary>
        string InventoryNumber { get; }
        
    }
}