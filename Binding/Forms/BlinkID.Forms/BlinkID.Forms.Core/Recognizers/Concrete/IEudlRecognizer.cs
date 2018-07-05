namespace Microblink.Forms.Core.Recognizers
{
    public interface IEudlRecognizer : IRecognizer
    {
        
        /// <summary>
        /// currently used country. 
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
        IEudlRecognizerResult Result { get; }
    }

    public interface IEudlRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the address of the Driver's Licence owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// birth date and birth place of Driver's Licence owner 
        /// </summary>
        string BirthData { get; }
        
        /// <summary>
        /// the country where the driver's license has been issued. 
        /// </summary>
        EudlCountry Country { get; }
        
        /// <summary>
        /// the driver number. 
        /// </summary>
        string DriverNumber { get; }
        
        /// <summary>
        /// the expiry date of the Driver's Licence 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the Driver's Licence owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the issue date of the Driver's Licence 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// document issuing authority. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// the last name of the Driver's Licence owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// the personal number of the Driver's Licence owner. 
        /// </summary>
        string PersonalNumber { get; }
        
    }
}