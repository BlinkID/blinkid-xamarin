namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Sweden Dl Front Recognizer.
    /// 
    /// Sweden Dl Front recognizer is used for scanning front side of Sweden Dl.
    /// </summary>
    public interface ISwedenDlFrontRecognizer : IRecognizer
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
        /// Defines if owner's date of birth should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if issuing agency should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAgency { get; set; }
        
        /// <summary>
        /// Defines iflicence categories should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractLicenceCategories { get; set; }
        
        /// <summary>
        /// Defines if owner's name should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if reference number should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReferenceNumber { get; set; }
        
        /// <summary>
        /// Defines if owner's surname should be extracted from Sweden DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        ISwedenDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISwedenDlFrontRecognizer.
    /// </summary>
    public interface ISwedenDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The Date Of Birth of the Sweden DL owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The Date Of Expiry of the Sweden DL. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The Date Of Issue of the Sweden DL. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The Issuing Agency of the Sweden DL. 
        /// </summary>
        string IssuingAgency { get; }
        
        /// <summary>
        /// The Licence Categories of the Sweden DL. 
        /// </summary>
        string LicenceCategories { get; }
        
        /// <summary>
        /// The Licence Numer of the Sweden DL. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The Name of the Sweden DL owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The Reference Number of the Sweden DL. 
        /// </summary>
        string ReferenceNumber { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The Surname of the Sweden DL owner. 
        /// </summary>
        string Surname { get; }
        
    }
}