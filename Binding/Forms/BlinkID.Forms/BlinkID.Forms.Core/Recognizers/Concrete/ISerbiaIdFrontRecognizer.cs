namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Serbian ID Front Recognizer.
    /// 
    /// Serbian ID Front recognizer is used for scanning front side of Serbian ID.
    /// </summary>
    public interface ISerbiaIdFrontRecognizer : IRecognizer
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
        ///  Defines if issuing date of Serbian ID should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingDate { get; set; }
        
        /// <summary>
        ///  Defines if valid until date of Serbian ID should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
        /// <summary>
        /// Sets whether face image from ID card should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Sets whether signature image from ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISerbiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISerbiaIdFrontRecognizer.
    /// </summary>
    public interface ISerbiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The document number of Serbian ID owner 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing date of the Serbian ID. 
        /// </summary>
        IDate IssuingDate { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The valid until date of the Serbian ID. 
        /// </summary>
        IDate ValidUntil { get; }
        
    }
}