namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Romania ID.
    /// </summary>
    public interface IRomaniaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Romania ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Romania ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Romania ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if first name of Romania ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of Romania ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuedBy { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Romania ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if sex of Romania ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if surname of Romania ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        IRomaniaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IRomaniaIdFrontRecognizer.
    /// </summary>
    public interface IRomaniaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of Romania ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The CNP number of Romania ID owner. 
        /// </summary>
        string CnpNumber { get; }
        
        /// <summary>
        /// The date of expiry of Romania ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Romania ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of Romania ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing authority of Romania ID. 
        /// </summary>
        string IssuedBy { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The nationality of Romania ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The parent name of Romania ID owner. 
        /// </summary>
        string ParentName { get; }
        
        /// <summary>
        /// The place of birth of Romania ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The sex of Romania ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The surname of Romania ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}