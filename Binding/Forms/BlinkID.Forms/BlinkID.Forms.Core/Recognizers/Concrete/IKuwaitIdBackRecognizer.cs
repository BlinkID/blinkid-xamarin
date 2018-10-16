namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Kuwait national ID cards.
    /// </summary>
    public interface IKuwaitIdBackRecognizer : IRecognizer
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
        /// Defines if serial number of Kuwait ID should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSerialNo { get; set; }
        
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
        IKuwaitIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IKuwaitIdBackRecognizer.
    /// </summary>
    public interface IKuwaitIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The serial number of Kuwait ID 
        /// </summary>
        string SerialNo { get; }
        
    }
}