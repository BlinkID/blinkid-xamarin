namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning the back side of elite payment cards.
    /// </summary>
    public interface IElitePaymentCardBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines if glare detection should be turned on/off.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Should extract the card's security code/value
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCvv { get; set; }
        
        /// <summary>
        /// Should extract the card's inventory number
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractInventoryNumber { get; set; }
        
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
        IElitePaymentCardBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IElitePaymentCardBackRecognizer.
    /// </summary>
    public interface IElitePaymentCardBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The card Number of the back side of the Elite Payment Card owner. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The cvv of the back side of the Elite Payment Card owner. 
        /// </summary>
        string Cvv { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The inventory Number of the back side of the Elite Payment Card owner. 
        /// </summary>
        string InventoryNumber { get; }
        
        /// <summary>
        /// The valid Thru of the back side of the Elite Payment Card owner. 
        /// </summary>
        IDate ValidThru { get; }
        
    }
}