namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning the front side of credit/debit cards.
    /// </summary>
    public interface IPaymentCardFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Should anonymize the card number area (redact image pixels) on the document image result
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeCardNumber { get; set; }
        
        /// <summary>
        /// Should anonymize the owner area (redact image pixels) on the document image result
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AnonymizeOwner { get; set; }
        
        /// <summary>
        /// Defines if glare detection should be turned on/off.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Should extract the card owner information
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractOwner { get; set; }
        
        /// <summary>
        /// Should extract the payment card's month of expiry
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidThru { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Image extension factors for full document image.
        /// 
        /// @see ImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IPaymentCardFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IPaymentCardFrontRecognizer.
    /// </summary>
    public interface IPaymentCardFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The payment card number. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Information about the payment card owner (name, company, etc.). 
        /// </summary>
        string Owner { get; }
        
        /// <summary>
        /// The payment card's last month of validity. 
        /// </summary>
        IDate ValidThru { get; }
        
    }
}