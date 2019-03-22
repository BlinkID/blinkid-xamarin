namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Colombia drivers licence.
    /// </summary>
    public interface IColombiaDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if the date of birth of the Colombia Dl owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if the driver restrictions of the Colombia Dl owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDriverRestrictions { get; set; }
        
        /// <summary>
        /// Defines if the issuing agency of the Colombia Dl card should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAgency { get; set; }
        
        /// <summary>
        /// Defines if the name of the Colombia Dl owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
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
        IColombiaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IColombiaDlFrontRecognizer.
    /// </summary>
    public interface IColombiaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the Colombia Dl card owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of issue of the Colombia Dl card. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The driver restrictions of the Colombia Dl card owner. 
        /// </summary>
        string DriverRestrictions { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing agency of the Colombia Dl card. 
        /// </summary>
        string IssuingAgency { get; }
        
        /// <summary>
        /// The licence number of the Colombia Dl card. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The name of the Colombia Dl card owner. 
        /// </summary>
        string Name { get; }
        
    }
}