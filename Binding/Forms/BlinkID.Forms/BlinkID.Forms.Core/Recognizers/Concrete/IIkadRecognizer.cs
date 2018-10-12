namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for reading Malaysian iKad.
    /// 
    /// </summary>
    public interface IIkadRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// True if address is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// True if employer is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractEmployer { get; set; }
        
        /// <summary>
        /// True if expiry date is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiryDate { get; set; }
        
        /// <summary>
        /// True if faculty address is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFacultyAddress { get; set; }
        
        /// <summary>
        /// True if nationality is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// True if passport number is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// True if sector is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSector { get; set; }
        
        /// <summary>
        /// True if sex is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines the DPI (Dots Per Inch) for full document image that should be returned. 
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
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IIkadRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IIkadRecognizer.
    /// </summary>
    public interface IIkadRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Personal address of the Malaysian iKad owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of Malaysian iKad owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Employer of the Malaysian iKad owner. 
        /// </summary>
        string Employer { get; }
        
        /// <summary>
        /// The expiry date of the Malaysian iKad 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Faculty address of the Malaysian iKad owner. 
        /// </summary>
        string FacultyAddress { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The name of the Malaysian iKad owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of the Malaysian iKad owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The passport number of Malaysian iKad. 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// The sector of Malaysian iKad. 
        /// </summary>
        string Sector { get; }
        
        /// <summary>
        /// Sex of the Malaysian iKad owner. 
        /// </summary>
        string Sex { get; }
        
    }
}