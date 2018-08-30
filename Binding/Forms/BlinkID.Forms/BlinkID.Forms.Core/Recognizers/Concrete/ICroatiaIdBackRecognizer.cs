namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Croatian national ID cards.
    /// </summary>
    public interface ICroatiaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Croatian ID should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if issuer of Croatian ID should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuedBy { get; set; }
        
        /// <summary>
        /// Defines if residence of Croatian ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractResidence { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ICroatiaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICroatiaIdBackRecognizer.
    /// </summary>
    public interface ICroatiaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Determines if date of expiry of Croatian ID is permanent 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// The date of issue of Croatian ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Determines if Croatian ID is issued for non resident 
        /// </summary>
        bool DocumentForNonResident { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuer of Croatian ID 
        /// </summary>
        string IssuedBy { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The residence of Croatian ID owner 
        /// </summary>
        string Residence { get; }
        
    }
}