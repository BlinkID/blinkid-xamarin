namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Australia DL Front Recognizer.
    /// 
    /// Australia DL Front recognizer is used for scanning front side of Australia DL.
    /// </summary>
    public interface IAustraliaDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        ///  Defines if sex of Australian DL owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Australian DL owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Australian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if citizenship of Australian DL owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLicenceNumber { get; set; }
        
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
        IAustraliaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustraliaDlFrontRecognizer.
    /// </summary>
    public interface IAustraliaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Australian DL owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of birth of Australian DL owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The document date of expiry of the Australian DL 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The licence number of the Australian DL owner. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The licence type of Australian DL. 
        /// </summary>
        string LicenceType { get; }
        
        /// <summary>
        /// The first name of the Australian DL owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}