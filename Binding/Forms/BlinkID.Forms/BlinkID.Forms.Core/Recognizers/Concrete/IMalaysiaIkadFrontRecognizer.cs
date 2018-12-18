namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Malaysia iKad card.
    /// </summary>
    public interface IMalaysiaIkadFrontRecognizer : IRecognizer
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
        /// Defines if address of Malaysian iKad owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Malaysian iKad card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if employer of Malaysian iKad owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractEmployer { get; set; }
        
        /// <summary>
        /// Defines if address of faculty, in which Malaysian iKad owner currently studies, should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFacultyAddress { get; set; }
        
        /// <summary>
        /// Defines if gender of Malaysian iKad owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGender { get; set; }
        
        /// <summary>
        /// Defines if (full) name of Malaysian iKad owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of Malaysian iKad owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if passport number of Malaysian iKad owners passport should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// Defines if sector in which  Malaysian iKad owner works should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSector { get; set; }
        
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
        IMalaysiaIkadFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMalaysiaIkadFrontRecognizer.
    /// </summary>
    public interface IMalaysiaIkadFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Address of Malaysian iKad owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of Malaysian iKad owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Date of expiry of Malaysian iKad card. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Employer of Malaysian iKad owner. 
        /// </summary>
        string Employer { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Faculty address in which Malaysian iKad owner currently studies. 
        /// </summary>
        string FacultyAddress { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Gender of Malaysian iKad owner. 
        /// </summary>
        string Gender { get; }
        
        /// <summary>
        /// The name of Malaysian iKad owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Nationality of Malaysian iKad owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The passport number of Malaysian iKad owners passport. 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// Sector in which Malaysian iKad owner works. 
        /// </summary>
        string Sector { get; }
        
    }
}