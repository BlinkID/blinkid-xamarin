namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring iKad Recognizer.
    /// 
    /// iKad recognizer is used for scanning iKad.
    /// </summary>
    public interface IIkadRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines if glare detection should be turned on/off.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if owner's address should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if owner's employer should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractEmployer { get; set; }
        
        /// <summary>
        /// Defines if expiry date should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiryDate { get; set; }
        
        /// <summary>
        /// Defines if owner's faculty address should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFacultyAddress { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if owner's passport number should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// Defines if owner's sector should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSector { get; set; }
        
        /// <summary>
        /// Defines if owner's sex should be extracted from iKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        IIkadRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IIkadRecognizer.
    /// </summary>
    public interface IIkadRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the iKad owner 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of iKad owner, parsed in NSDate object 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The employer of the iKad owner 
        /// </summary>
        string Employer { get; }
        
        /// <summary>
        /// The expiry date of the iKad, parsed in NSDate object 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The faculty address of the iKad owner 
        /// </summary>
        string FacultyAddress { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The name of the iKad owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of the iKad owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The passport number of the iKad owner. 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// The sector of the iKad owner 
        /// </summary>
        string Sector { get; }
        
        /// <summary>
        /// The sex of the iKad owner 
        /// </summary>
        string Sex { get; }
        
    }
}