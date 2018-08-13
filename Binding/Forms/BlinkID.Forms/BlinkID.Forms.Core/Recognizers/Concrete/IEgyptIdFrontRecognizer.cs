namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Egypt ID Front Recognizer.
    /// 
    /// Egypt ID Front recognizer is used for scanning front side of Egypt ID.
    /// </summary>
    public interface IEgyptIdFrontRecognizer : IRecognizer
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
        /// Defines if owner's national number should be extracted from Egypt ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationalNumber { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        IEgyptIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IEgyptIdFrontRecognizer.
    /// </summary>
    public interface IEgyptIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The document number of the Egypt ID. 
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
        /// The National Number of the Egypt ID owner. 
        /// </summary>
        string NationalNumber { get; }
        
    }
}