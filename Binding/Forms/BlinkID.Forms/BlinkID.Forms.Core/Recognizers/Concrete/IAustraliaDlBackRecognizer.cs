namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan the back side of Australian driver's licences
    /// </summary>
    public interface IAustraliaDlBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of the Australia DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if last name of the Australia DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
        /// <summary>
        /// Defines if the licence number of the Australia DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceNumber { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of the Australia DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenseExpiry { get; set; }
        
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
        /// Image of the full document 
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