namespace Microblink.Forms.Core.Recognizers
{
    public interface IIkadRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if address is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// true if employer is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractEmployer { get; set; }
        
        /// <summary>
        /// true if expiry date is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiryDate { get; set; }
        
        /// <summary>
        /// true if faculty address is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFacultyAddress { get; set; }
        
        /// <summary>
        /// true if nationality is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// true if passport number is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// true if sector is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSector { get; set; }
        
        /// <summary>
        /// true if sex is being extracted 
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
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IIkadRecognizerResult Result { get; }
    }

    public interface IIkadRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// personal address of the Malaysian iKad owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// the date of birth of Malaysian iKad owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// employer of the Malaysian iKad owner. 
        /// </summary>
        string Employer { get; }
        
        /// <summary>
        /// the expiry date of the Malaysian iKad 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// faculty address of the Malaysian iKad owner. 
        /// </summary>
        string FacultyAddress { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the name of the Malaysian iKad owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// the nationality of the Malaysian iKad owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// the passport number of Malaysian iKad. 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// the sector of Malaysian iKad. 
        /// </summary>
        string Sector { get; }
        
        /// <summary>
        /// sex of the Malaysian iKad owner. 
        /// </summary>
        string Sex { get; }
        
    }
}