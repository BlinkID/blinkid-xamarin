namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan front side of austrian driver's license.
    /// 
    /// </summary>
    public interface IAustraliaDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// true if address of Australian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// true if date of birth of Australian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if date of expiry of Australian DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// true if licence number of Australian DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceNumber { get; set; }
        
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
        /// Defines whether signature image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IAustraliaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustraliaDlFrontRecognizer.
    /// </summary>
    public interface IAustraliaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// address of the Australian DL owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// the date of birth of Australian DL owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the date of expiry of Australian DL. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the licence number of Australian DL. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// the licence type of the Australian DL. 
        /// </summary>
        string LicenceType { get; }
        
        /// <summary>
        /// the full name of the Australian ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}