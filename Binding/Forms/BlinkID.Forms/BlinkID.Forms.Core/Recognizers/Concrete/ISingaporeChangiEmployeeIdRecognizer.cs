namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Singapore Changi Employee Id Recognizer.
    /// 
    /// Singapore Changi Employee Id recognizer is used for scanning front side of the Singapore Driver's license..
    /// </summary>
    public interface ISingaporeChangiEmployeeIdRecognizer : IRecognizer
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
        /// Defines if company name should be extracted from the Singapore Changi Employee Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCompanyName { get; set; }
        
        /// <summary>
        /// Defines if birth of expiry should be extracted from the Singapore Changi Employee Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if owner's name should be extracted from the Singapore Changi Employee Id
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
        ISingaporeChangiEmployeeIdRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeChangiEmployeeIdRecognizer.
    /// </summary>
    public interface ISingaporeChangiEmployeeIdRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// TThe company name of the Singapore Changi employee ID owner. 
        /// </summary>
        string CompanyName { get; }
        
        /// <summary>
        /// The date of expiry of Singapore Changi employee ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The document number of the Singapore Changi employee ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The name of the Singapore Changi employee ID owner. 
        /// </summary>
        string Name { get; }
        
    }
}