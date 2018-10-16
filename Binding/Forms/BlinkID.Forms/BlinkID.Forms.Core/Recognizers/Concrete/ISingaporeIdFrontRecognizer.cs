namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Singapore ID Front Recognizer.
    /// 
    /// Singapore ID Front recognizer is used for scanning front side of Singapore ID.
    /// </summary>
    public interface ISingaporeIdFrontRecognizer : IRecognizer
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
        ///  Defines if country/place of birth of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCountryOfBirth { get; set; }
        
        /// <summary>
        ///  Defines if date of birth of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        ///  Defines if name of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        ///  Defines if race of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRace { get; set; }
        
        /// <summary>
        ///  Defines if sex of Singaporean ID card owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Property for setting DPI for face images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
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
        /// Image extension factors for full document image.
        /// 
        /// @see ImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        ISingaporeIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeIdFrontRecognizer.
    /// </summary>
    public interface ISingaporeIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The country/place of birth of the Singaporean ID card owner. 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// The date of birth of the Singaporean ID card owner. 
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
        /// The identity card number of the Singaporean ID card. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// The name of the Singaporean ID card owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The race of the Singaporean ID card owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// The sex of the Singaporean ID card owner. 
        /// </summary>
        string Sex { get; }
        
    }
}