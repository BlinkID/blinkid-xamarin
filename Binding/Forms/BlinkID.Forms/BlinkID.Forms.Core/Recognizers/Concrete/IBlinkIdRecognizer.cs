namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Generic BlinkID recognizer.
    /// </summary>
    public interface IBlinkIdRecognizer : IRecognizer
    {
        
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
        IBlinkIdRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBlinkIdRecognizer.
    /// </summary>
    public interface IBlinkIdRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The full address of the United States driver license owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of the United States driver license owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the United States driver license. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of the United States driver license. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The document number of the United States driver license. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The driver license detailed info. 
        /// </summary>
        IDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the United States driver license owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The full name of the United States driver license owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The last name of the United States driver license owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The sex of the United States driver license owner. 
        /// </summary>
        string Sex { get; }
        
    }
}