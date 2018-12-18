namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Malaysia iKad card.
    /// </summary>
    public interface IMalaysiaIkadFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Malaysian iKad owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Malaysian iKad card should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if employer of Malaysian iKad owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractEmployer { get; set; }
        
        /// <summary>
        /// Defines if address of faculty, in which Malaysian iKad owner currently studies, should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFacultyAddress { get; set; }
        
        /// <summary>
        /// Defines if gender of Malaysian iKad owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGender { get; set; }
        
        /// <summary>
        /// Defines if (full) name of Malaysian iKad owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of Malaysian iKad owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if passport number of Malaysian iKad owners passport should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// Defines if sector in which  Malaysian iKad owner works should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSector { get; set; }
        
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
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Faculty address in which Malaysian iKad owner currently studies. 
        /// </summary>
        string FacultyAddress { get; }
        
        /// <summary>
        /// Image of the full document 
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