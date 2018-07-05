namespace Microblink.Forms.Core.Recognizers
{
    public interface INewZealandDlFrontRecognizer : IRecognizer
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
        /// Defines if owner's address should be extracted from New Zealand Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if owner's date of birth should be extracted from New Zealand Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if owner's donor indicator should be extracted from New Zealand Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDonorIndicator { get; set; }
        
        /// <summary>
        /// Defines if card's expiry date should be extracted from New Zealand Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractExpiryDate { get; set; }
        
        /// <summary>
        /// Defines if owner's first name should be extracted from New Zealand Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstNames { get; set; }
        
        /// <summary>
        /// Defines if card's issue date should be extracted from New Zealand Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssueDate { get; set; }
        
        /// <summary>
        /// Defines if owner's last name should be extracted from New Zealand Driver License
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        /// Sets whether signature image from ID card should be extracted.
        /// 
        ///  
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
        /// The last name of the New Zealand Driver License owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The card version of the New Zealand Driver License. 
        /// </summary>
        string CardVersion { get; }
        
        /// <summary>
        /// The last name of the New Zealand Driver License owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The last name of the New Zealand Driver License owner. 
        /// </summary>
        bool DonorIndicator { get; }
        
        /// <summary>
        /// The last name of the New Zealand Driver License owner. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the New Zealand Driver License owner. 
        /// </summary>
        string FirstNames { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The last name of the New Zealand Driver License owner. 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// The license number of the New Zealand Driver License. 
        /// </summary>
        string LicenseNumber { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The last name of the New Zealand Driver License owner. 
        /// </summary>
        string Surname { get; }
        
    }
}