namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Slovenia ID.
    /// </summary>
    public interface ISloveniaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Slovenian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if issuing administrative unit of Slovenian ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAdministrativeUnit { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Slovenian ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
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
        ISloveniaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISloveniaIdBackRecognizer.
    /// </summary>
    public interface ISloveniaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of Slovenian ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The issuing administrative unit of Slovenian ID. 
        /// </summary>
        string AdministrativeUnit { get; }
        
        /// <summary>
        /// The date of issue of Slovenian ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
    }
}