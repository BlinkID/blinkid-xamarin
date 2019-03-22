namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer for scanning driver's licence of several european countries
    /// </summary>
    public interface IEudlRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Currently used country. 
        ///
        /// By default, this is set to 'EUDL_COUNTRY_AUTO'
        /// </summary>
        EudlCountry Country { get; set; }
        
        /// <summary>
        /// Defines if address should be extracted from EU driver's license 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if expiry date should be extracted from EU driver's license 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if issue date should be extracted from EU driver's license 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if issuing authority should be extracted from EU driver's license 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if personal number should be extracted from EU driver's license 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPersonalNumber { get; set; }
        
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
        IEudlRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IEudlRecognizer.
    /// </summary>
    public interface IEudlRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Driver's Licence owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// Birth date and birth place of Driver's Licence owner 
        /// </summary>
        string BirthData { get; }
        
        /// <summary>
        /// The country where the driver's license has been issued. 
        /// </summary>
        EudlCountry Country { get; }
        
        /// <summary>
        /// The driver number. 
        /// </summary>
        string DriverNumber { get; }
        
        /// <summary>
        /// The expiry date of the Driver's Licence 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Driver's Licence owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issue date of the Driver's Licence 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// Document issuing authority. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The last name of the Driver's Licence owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The personal number of the Driver's Licence owner. 
        /// </summary>
        string PersonalNumber { get; }
        
    }
}