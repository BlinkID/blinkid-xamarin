namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Brunei national Residence Permit cards.
    /// </summary>
    public interface IBruneiResidencePermitBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Brunei Residence Permit card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Brunei Residence Permit card should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if the race of Brunei Residence Permit card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRace { get; set; }
        
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
        IBruneiResidencePermitBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBruneiResidencePermitBackRecognizer.
    /// </summary>
    public interface IBruneiResidencePermitBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of Brunei Residence Permit card owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of issue of Brunei Residence Permit card. 
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
        
        /// <summary>
        /// The race of Brunei Residence Permit card owner. 
        /// </summary>
        string Race { get; }
        
    }
}