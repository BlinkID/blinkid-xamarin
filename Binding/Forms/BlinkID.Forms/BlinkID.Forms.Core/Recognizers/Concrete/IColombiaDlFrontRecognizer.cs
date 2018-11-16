namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Colombia drivers licence.
    /// </summary>
    public interface IColombiaDlFrontRecognizer : IRecognizer
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
        /// Defines if the date of birth of the Colombia Dl owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if the driver restrictions of the Colombia Dl owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDriverRestrictions { get; set; }
        
        /// <summary>
        /// Defines if the issuing agency of the Colombia Dl card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssuingAgency { get; set; }
        
        /// <summary>
        /// Defines if the name of the Colombia Dl owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
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
        IColombiaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IColombiaDlFrontRecognizer.
    /// </summary>
    public interface IColombiaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date Of Birth of the front side of the Colombia Dl owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date Of Issue of the front side of the Colombia Dl owner. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The driver Restrictions of the front side of the Colombia Dl owner. 
        /// </summary>
        string DriverRestrictions { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issuing Agency of the front side of the Colombia Dl owner. 
        /// </summary>
        string IssuingAgency { get; }
        
        /// <summary>
        /// The licence Number of the front side of the Colombia Dl owner. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The name of the front side of the Colombia Dl owner. 
        /// </summary>
        string Name { get; }
        
    }
}