namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Cyprus national ID cards.
    /// </summary>
    public interface ICyprusIdBackRecognizer : IRecognizer
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
        /// Defines if the expiry date of Cryprus ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiresOn { get; set; }
        
        /// <summary>
        /// Defines if sex of Cyprus ID card owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        ICyprusIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICyprusIdBackRecognizer.
    /// </summary>
    public interface ICyprusIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date Of Birth of the back side of the Cyprus Id owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The expiry date of Cyprus ID card. 
        /// </summary>
        IDate ExpiresOn { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The sex of the back side of the Cyprus Id owner. 
        /// </summary>
        string Sex { get; }
        
    }
}