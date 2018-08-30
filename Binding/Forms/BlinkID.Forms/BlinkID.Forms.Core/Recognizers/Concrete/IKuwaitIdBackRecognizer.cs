namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Kuwait national ID cards.
    /// </summary>
    public interface IKuwaitIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if serial number of Kuwait ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSerialNo { get; set; }
        
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
        IKuwaitIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IKuwaitIdBackRecognizer.
    /// </summary>
    public interface IKuwaitIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The serial number of Kuwait ID. 
        /// </summary>
        string SerialNo { get; }
        
    }
}