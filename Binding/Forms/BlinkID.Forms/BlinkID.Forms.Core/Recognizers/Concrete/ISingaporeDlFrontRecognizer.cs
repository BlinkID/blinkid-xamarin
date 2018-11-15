namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// The Singapore Dl Front Recognizer is used for scanning front side of the Singapore Dl.
    /// </summary>
    public interface ISingaporeDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if birth date of Singapore driver's license owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBirthDate { get; set; }
        
        /// <summary>
        /// Defines if issue date of Singapore driver's license should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssueDate { get; set; }
        
        /// <summary>
        /// Defines if name of Singapore driver's license owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if valid till date of Singapore driver's license should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidTill { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
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
        ISingaporeDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeDlFrontRecognizer.
    /// </summary>
    public interface ISingaporeDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The birth date of Singapore driver's owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issue date of Singapore driver's licence. 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// The licence number of Singapore driver's licence. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The (full) name of Singapore driver's licence owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The valid till date of Singapore driver's licence. 
        /// </summary>
        IDate ValidTill { get; }
        
    }
}