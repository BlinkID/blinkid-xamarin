namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Nigeria voter ID cards.
    /// </summary>
    public interface INigeriaVoterIdBackRecognizer : IRecognizer
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
        /// full document image if enabled with returnFullDocumentImage property.
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