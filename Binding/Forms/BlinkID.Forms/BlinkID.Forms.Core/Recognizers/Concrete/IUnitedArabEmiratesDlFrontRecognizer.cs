namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of UAE drivers license.
    /// </summary>
    public interface IUnitedArabEmiratesDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if date of birth of UAE DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if issue date of UAE DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssueDate { get; set; }
        
        /// <summary>
        /// Defines if license number of UAE DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenseNumber { get; set; }
        
        /// <summary>
        /// Defines if licensing authority code of UAE DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicensingAuthority { get; set; }
        
        /// <summary>
        /// Defines if name of UAE DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of UAE DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if place of issue of UAE DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfIssue { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        IUnitedArabEmiratesDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IUnitedArabEmiratesDlFrontRecognizer.
    /// </summary>
    public interface IUnitedArabEmiratesDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of UAE DL owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The expiry date of UAE DL 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issue date of UAE DL 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// The license number of UAE DL 
        /// </summary>
        string LicenseNumber { get; }
        
        /// <summary>
        /// The licensing authority code of UAE DL 
        /// </summary>
        string LicensingAuthority { get; }
        
        /// <summary>
        /// The name of UAE DL owner 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of UAE DL owner 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The place of issue of UAE DL 
        /// </summary>
        string PlaceOfIssue { get; }
        
    }
}