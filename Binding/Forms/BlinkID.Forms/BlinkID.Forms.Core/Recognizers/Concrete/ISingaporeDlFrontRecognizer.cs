namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Singapore Dl Front Recognizer.
    /// 
    /// Singapore Dl Front recognizer is used for scanning front side of the Singapore Driver's license..
    /// </summary>
    public interface ISingaporeDlFrontRecognizer : IRecognizer
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
        /// Defines if owner's birth date should be extracted from front side of the Singapore DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBirthDate { get; set; }
        
        /// <summary>
        /// Defines if the issue date should be extracted from front side of the Singapore DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssueDate { get; set; }
        
        /// <summary>
        /// Defines if owner's name should be extracted from front side of the Singapore DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if valid till should be extracted from front side of the Singapore DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidTill { get; set; }
        
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
        ISingaporeDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeDlFrontRecognizer.
    /// </summary>
    public interface ISingaporeDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The birth Date of the Singapore DL owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The issue date of the Singapore DL. 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// The licence Number of the Singapore DL. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// The name of the Singapore DL owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The valid till of the Singapore DL. 
        /// </summary>
        IDate ValidTill { get; }
        
    }
}