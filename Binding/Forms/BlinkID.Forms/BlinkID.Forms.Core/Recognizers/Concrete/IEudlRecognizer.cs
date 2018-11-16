namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring EU Driver License Recognizer.
    /// 
    /// EU Driver License recognizer is used for scanning EU Driver License.
    /// </summary>
    public interface IEudlRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Country of scanning Eudl. The default value of EudlCountryAny will scan all supported driver's licenses.
        /// 
        ///  
        ///
        /// By default, this is set to 'MBEudlCountryAny'
        /// </summary>
        EudlCountry Country { get; set; }
        
        /// <summary>
        /// Defines if owner's address should be extracted from EU Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if owner's date of expiry should be extracted from EU Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if owner's date of issue should be extracted from EU Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if owner's issuing authority should be extracted from EU Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAuthority { get; set; }
        
        /// <summary>
        /// Defines if owner's personal number should be extracted from EU Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPersonalNumber { get; set; }
        
        /// <summary>
        /// Property for setting DPI for face images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Image extension factors for full document image.
        /// 
        /// @see ImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Sets whether face image from ID card should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
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
        /// The address of the EU Driver License owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The birth Data of the EU Driver License owner. 
        /// </summary>
        string BirthData { get; }
        
        /// <summary>
        /// The country of the EU Driver License owner. 
        /// </summary>
        EudlCountry Country { get; }
        
        /// <summary>
        /// The driver Number of the EU Driver License owner. 
        /// </summary>
        string DriverNumber { get; }
        
        /// <summary>
        /// The expiry Date of the EU Driver License owner. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first Name of the EU Driver License owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issue Date of the EU Driver License owner. 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// The issuing Authority of the EU Driver License owner. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The last Name of the EU Driver License owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The personal Number of the EU Driver License owner. 
        /// </summary>
        string PersonalNumber { get; }
        
    }
}