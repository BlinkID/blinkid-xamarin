namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning the back side of elite payment cards.
    /// </summary>
    public interface IElitePaymentCardBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Should anonymize the card number area (redact image pixels) on the document image result 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeCardNumber { get; set; }
        
        /// <summary>
        /// Should anonymize the CVV area (redact image pixels) on the document image result 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeCvv { get; set; }
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Should extract the card's security code/value 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCvv { get; set; }
        
        /// <summary>
        /// Should extract the card's inventory number 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractInventoryNumber { get; set; }
        
        /// <summary>
        /// Should extract the payment card's month of expiry 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidThru { get; set; }
        
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
        IElitePaymentCardBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IElitePaymentCardBackRecognizer.
    /// </summary>
    public interface IElitePaymentCardBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The payment card number. 
        /// </summary>
        string CardNumber { get; }
        
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
        
        /// <summary>
        /// The payment card's last month of validity. 
        /// </summary>
        IDate ValidThru { get; }
        
    }
}