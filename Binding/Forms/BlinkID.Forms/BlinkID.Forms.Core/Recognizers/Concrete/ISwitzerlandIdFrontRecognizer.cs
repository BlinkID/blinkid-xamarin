namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan the front side of Swiss national ID cards.
    /// 
    /// </summary>
    public interface ISwitzerlandIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if given name of Swiss ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenName { get; set; }
        
        /// <summary>
        /// true if surname of Swiss ID owner is being extracted 
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
        ISwitzerlandIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISwitzerlandIdFrontRecognizer.
    /// </summary>
    public interface ISwitzerlandIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the date of birth of Swiss ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the given name of the Swiss ID owner. 
        /// </summary>
        string GivenName { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// the surname of the Swiss ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}