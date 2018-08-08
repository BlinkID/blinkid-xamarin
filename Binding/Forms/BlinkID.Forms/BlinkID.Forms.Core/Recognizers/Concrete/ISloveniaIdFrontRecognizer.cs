namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan the front side of Slovenian national ID cards.
    /// 
    /// </summary>
    public interface ISloveniaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if date of birth of Slovenian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if date of expiry is being extracted from Slovenian ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// true if nationality of Slovenian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// true if sex of Slovenian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        ISloveniaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISloveniaIdFrontRecognizer.
    /// </summary>
    public interface ISloveniaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the date of birth of Slovenian ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the date of expiry of Slovenian ID owner 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the Slovenian ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the last name of the Slovenian ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// nationality of the Slovenian ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// sex of the Slovenian ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}