namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for reading Egypt ID Front document.
    /// 
    /// </summary>
    public interface IEgyptIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// True if national number of Egypt ID Front owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationalNumber { get; set; }
        
        /// <summary>
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
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
        /// The Egypt ID document number. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The Egypt ID card owner national number. 
        /// </summary>
        string NationalNumber { get; }
        
    }
}