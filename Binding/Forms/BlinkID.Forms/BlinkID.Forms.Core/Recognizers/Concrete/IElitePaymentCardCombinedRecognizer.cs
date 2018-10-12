namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning both sides of elite payment cards.
    /// </summary>
    public interface IElitePaymentCardCombinedRecognizer : IRecognizer
    {
        
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
        /// Should extract the card owner information 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOwner { get; set; }
        
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
        /// Defines whether or not recognition result should be signed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IElitePaymentCardCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IElitePaymentCardCombinedRecognizer.
    /// </summary>
    public interface IElitePaymentCardCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The payment card number. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// Payment card's security code/value. 
        /// </summary>
        string Cvv { get; }
        
        /// <summary>
        /// Defines digital signature of recognition results. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Defines digital signature version. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Defines {true} if data from scanned parts/sides of the document match, 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        /// Back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// Front side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// Payment card's inventory number. 
        /// </summary>
        string InventoryNumber { get; }
        
        /// <summary>
        /// Information about the payment card owner (name, company, etc.) 
        /// </summary>
        string Owner { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The payment card's last month of validity. 
        /// </summary>
        IDate ValidThru { get; }
        
    }
}