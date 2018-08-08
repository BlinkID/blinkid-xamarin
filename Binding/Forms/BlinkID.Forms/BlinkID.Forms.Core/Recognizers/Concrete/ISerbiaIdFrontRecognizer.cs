namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for front side of Serbian ID.
    /// 
    /// </summary>
    public interface ISerbiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if issuing date of Serbian ID is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingDate { get; set; }
        
        /// <summary>
        /// true if valid until is being extracted from Serbian ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
        /// <summary>
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Defines whether signature image will be available in result. 
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
        /// the document number of Serbian ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the issuing date of the Serbian ID. 
        /// </summary>
        IDate IssuingDate { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// the valid until of the Serbian ID. 
        /// </summary>
        IDate ValidUntil { get; }
        
    }
}