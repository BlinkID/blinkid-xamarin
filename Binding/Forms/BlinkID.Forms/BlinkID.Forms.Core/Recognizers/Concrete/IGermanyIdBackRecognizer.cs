namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of German ID.
    /// </summary>
    public interface IGermanyIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of German ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of German ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// Defines if colour of eyes of German ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractColourOfEyes { get; set; }
        
        /// <summary>
        /// Defines if date of issue of German ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if height of German ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
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
        IGermanyIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IGermanyIdBackRecognizer.
    /// </summary>
    public interface IGermanyIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The city of German ID owner. 
        /// </summary>
        string AddressCity { get; }
        
        /// <summary>
        /// The house number of German ID owner. 
        /// </summary>
        string AddressHouseNumber { get; }
        
        /// <summary>
        /// The street of German ID owner. 
        /// </summary>
        string AddressStreet { get; }
        
        /// <summary>
        /// The zip code of German ID owner. 
        /// </summary>
        string AddressZipCode { get; }
        
        /// <summary>
        /// The issuing authority of German ID. 
        /// </summary>
        string Authority { get; }
        
        /// <summary>
        /// The colour of eyes of German ID owner. 
        /// </summary>
        string ColourOfEyes { get; }
        
        /// <summary>
        /// The date of issue of German ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The full address of German ID owner. 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The height of German ID owner. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
    }
}