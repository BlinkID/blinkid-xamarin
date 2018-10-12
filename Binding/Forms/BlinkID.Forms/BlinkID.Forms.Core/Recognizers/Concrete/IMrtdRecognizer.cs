namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer that can recognize Machine Readable Zone (MRZ) of the Machine Readable Travel Document (MRTD)
    /// </summary>
    public interface IMrtdRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Whether returning of unparsed results is allowed 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnparsedResults { get; set; }
        
        /// <summary>
        /// Whether returning of unverified results is allowed 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnverifiedResults { get; set; }
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Defines whether MRZ image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnMrzImage { get; set; }
        
        /// <summary>
        /// Desired DPI for MRZ and full document images (if saving of those is enabled) 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SaveImageDPI { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IMrtdRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMrtdRecognizer.
    /// </summary>
    public interface IMrtdRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// MRZ image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource MrzImage { get; }
        
        /// <summary>
        /// The Data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
    }
}