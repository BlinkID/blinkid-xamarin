namespace Microblink.Forms.Core.Recognizers
{
    public interface INewZealandDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if address of New Zealand DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// true if date of birth on New Zealand DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if donor indicator of New Zealand DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDonorIndicator { get; set; }
        
        /// <summary>
        /// true if expiry date on New Zealand DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiryDate { get; set; }
        
        /// <summary>
        /// true if first names of New Zealand DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstNames { get; set; }
        
        /// <summary>
        /// true if issue date on New Zealand DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssueDate { get; set; }
        
        /// <summary>
        /// true if surname of New Zealand DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        /// Defines whether signature image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        INewZealandDlFrontRecognizerResult Result { get; }
    }

    public interface INewZealandDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// address on New Zealand drivers license. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// card version on New Zealand drivers license. 
        /// </summary>
        string CardVersion { get; }
        
        /// <summary>
        /// date of birth on New Zealand drivers license. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// true if DONOR is on New Zealand drivers license else returns false. 
        /// </summary>
        bool DonorIndicator { get; }
        
        /// <summary>
        /// expiry date on New Zealand drivers license. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// first names on New Zealand drivers license. 
        /// </summary>
        string FirstNames { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// issue date on New Zealand drivers license. 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// license number on New Zealand drivers license. 
        /// </summary>
        string LicenseNumber { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// surname on New Zealand drivers license. 
        /// </summary>
        string Surname { get; }
        
    }
}