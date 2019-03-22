namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan the back side of Australian driver's licences
    /// </summary>
    public interface IAustraliaDlBackRecognizer : IRecognizer
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
        /// Defines if address of the Australia DL owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if last name of the Australia DL owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
        /// <summary>
        /// Defines if the licence number of the Australia DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceNumber { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of the Australia DL should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenseExpiry { get; set; }
        
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
        IAustraliaDlBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustraliaDlBackRecognizer.
    /// </summary>
    public interface IAustraliaDlBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Australia DL owner 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The last name of the Australia DL owner 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The date of expiry of the Australia DL 
        /// </summary>
        IDate LicenceExpiry { get; }
        
        /// <summary>
        /// The licence number of the Australia DL 
        /// </summary>
        string LicenceNumber { get; }
        
    }
}