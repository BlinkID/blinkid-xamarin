namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of old Cyprus national ID cards.
    /// </summary>
    public interface ICyprusOldIdBackRecognizer : IRecognizer
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
        /// Defines if the expiry date of old Cryprus ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiresOn { get; set; }
        
        /// <summary>
        /// Defines if the sex of old Cyprus ID card owner should be extracted.
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
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The sex of the old Cyprus ID card owner. 
        /// </summary>
        string Sex { get; }
        
    }
}