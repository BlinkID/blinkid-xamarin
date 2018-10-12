namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Ireland drivers license.
    /// </summary>
    public interface IIrelandDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Ireland DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Ireland DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Ireland DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Ireland DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if first name of Ireland DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of Ireland DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuedBy { get; set; }
        
        /// <summary>
        /// Defines if licence categories of Ireland DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceCategories { get; set; }
        
        /// <summary>
        /// Defines if licence number of Ireland DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceNumber { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Ireland DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if surname of Ireland DL owner should be extracted 
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
        /// Defines whether signature image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for signature image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IIrelandDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IIrelandDlFrontRecognizer.
    /// </summary>
    public interface IIrelandDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of Ireland DL owner 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of Ireland DL owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of Ireland DL 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of Ireland DL 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The driver number of Ireland DL owner 
        /// </summary>
        string DriverNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of Ireland DL owner 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing authority of Ireland DL 
        /// </summary>
        string IssuedBy { get; }
        
        /// <summary>
        /// The licence categories of Ireland DL 
        /// </summary>
        string LicenceCategories { get; }
        
        /// <summary>
        /// The licence number of Ireland DL 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The place of birth of Ireland DL owner 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of Ireland DL owner 
        /// </summary>
        string Surname { get; }
        
    }
}