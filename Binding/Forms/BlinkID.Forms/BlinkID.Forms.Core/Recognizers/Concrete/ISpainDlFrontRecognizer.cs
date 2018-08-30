namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Spain national DL cards
    /// </summary>
    public interface ISpainDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Spain DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if first name of Spain DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of Spain DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if licence categories of Spain DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceCategories { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Spain DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if surname of Spain DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Spain DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidFrom { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Spain DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
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
        /// the DPI (Dots Per Inch) for signature image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISpainDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISpainDlFrontRecognizer.
    /// </summary>
    public interface ISpainDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of Spain DL owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Spain DL owner 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing authority of the Spain DL 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The licence categories of the Spain DL 
        /// </summary>
        string LicenceCategories { get; }
        
        /// <summary>
        /// The licence number of the Spain DL 
        /// </summary>
        string Number { get; }
        
        /// <summary>
        /// The date of birth of Spain DL owner 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of the Spain DL owner. 
        /// </summary>
        string Surname { get; }
        
        /// <summary>
        /// The date of issue of Spain DL 
        /// </summary>
        IDate ValidFrom { get; }
        
        /// <summary>
        /// The date of expiry of Spain DL 
        /// </summary>
        IDate ValidUntil { get; }
        
    }
}