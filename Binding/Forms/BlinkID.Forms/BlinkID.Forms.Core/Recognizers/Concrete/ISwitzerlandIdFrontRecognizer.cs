namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Swiss ID Front Recognizer.
    /// 
    /// Swiss ID Front recognizer is used for scanning front side of Swiss ID.
    /// </summary>
    public interface ISwitzerlandIdFrontRecognizer : IRecognizer
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
        /// Defines if owner's first name should be extracted from Swiss ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenName { get; set; }
        
        /// <summary>
        /// Defines if owner's last name should be extracted from Swiss ID
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
        ISwitzerlandIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISwitzerlandIdFrontRecognizer.
    /// </summary>
    public interface ISwitzerlandIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the Swiss ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The first name of the Swiss ID owner. 
        /// </summary>
        string GivenName { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The last name of the Swiss ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}