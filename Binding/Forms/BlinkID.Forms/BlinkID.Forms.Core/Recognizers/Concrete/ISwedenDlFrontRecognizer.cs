namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer settings for reading front side of Sweden DL
    /// 
    /// </summary>
    public interface ISwedenDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// True if date of birth of Sweden DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// True if date of expiry of Sweden DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// True if date of issue of Sweden DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// True if issuing agency of Sweden DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAgency { get; set; }
        
        /// <summary>
        /// True if licence categories of Sweden DL is being extracted 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractLicenceCategories { get; set; }
        
        /// <summary>
        /// True if name of Sweden DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// True if reference number of Sweden DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReferenceNumber { get; set; }
        
        /// <summary>
        /// True if surname of Sweden DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        /// Defines whether signature image will be available in result. 
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
        /// Date of birth of Sweden DL owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Date of expiry of Sweden DL. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Date of issue of Sweden DL. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Issuing agency of Sweden DL card. 
        /// </summary>
        string IssuingAgency { get; }
        
        /// <summary>
        /// Licence categories of Sweden DL. 
        /// </summary>
        string LicenceCategories { get; }
        
        /// <summary>
        /// The licence number of Sweden DL card owner. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// Name of Sweden DL owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// Reference number of Sweden DL card. 
        /// </summary>
        string ReferenceNumber { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// Surname of Sweden DL owner. 
        /// </summary>
        string Surname { get; }
        
    }
}