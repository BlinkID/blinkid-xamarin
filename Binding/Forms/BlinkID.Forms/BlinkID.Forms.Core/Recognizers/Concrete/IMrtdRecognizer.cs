namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer that can recognizer Machine Readable Zone (MRZ) of the Machine Readable Travel Document (MRTD)
    /// </summary>
    public interface IMrtdRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Whether returning of unparsed results is allowed
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnparsedResults { get; set; }
        
        /// <summary>
        /// Whether returning of unverified results is allowed
        /// Unverified result is result that is parsed, but check digits are incorrect.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnverifiedResults { get; set; }
        
        /// <summary>
        /// Defines if glare detection should be turned on/off.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Whether cropped image of the Machine Readable Zone should be available in result.
        /// Note - enabling this feature will degrade performance
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnMrzImage { get; set; }
        
        /// <summary>
        /// Desired DPI for MRZ and full document images (if saving of those is enabled)
        /// 
        ///  
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
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Image of the Machine Readable Zone or nil if not available. 
        /// </summary>
        Xamarin.Forms.ImageSource MrzImage { get; }
        
        /// <summary>
        /// Returns the Data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
    }
}