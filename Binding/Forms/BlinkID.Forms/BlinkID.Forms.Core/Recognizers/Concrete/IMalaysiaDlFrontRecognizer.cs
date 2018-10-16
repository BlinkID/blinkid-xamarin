namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Malaysian DL cards.
    /// </summary>
    public interface IMalaysiaDlFrontRecognizer : IRecognizer
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
        /// Defines if address of Malaysian DL owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if vehicle classes of Malaysian DL should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractClass { get; set; }
        
        /// <summary>
        /// Defines if name of Malaysian DL owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of Malaysian DL owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Malaysian DL should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidFrom { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Malaysian DL should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
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
        IMalaysiaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMalaysiaDlFrontRecognizer.
    /// </summary>
    public interface IMalaysiaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The city of the front side of the Malaysia Dl owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The dl Class of the front side of the Malaysia Dl owner. 
        /// </summary>
        string DlClass { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The full Address of the front side of the Malaysia Dl owner. 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The identity Number of the front side of the Malaysia Dl owner. 
        /// </summary>
        string IdentityNumber { get; }
        
        /// <summary>
        /// The name of the front side of the Malaysia Dl owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of the front side of the Malaysia Dl owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The owner State of the front side of the Malaysia Dl owner. 
        /// </summary>
        string OwnerState { get; }
        
        /// <summary>
        /// The street of the front side of the Malaysia Dl owner. 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// The valid From of the front side of the Malaysia Dl owner. 
        /// </summary>
        IDate ValidFrom { get; }
        
        /// <summary>
        /// The valid Until of the front side of the Malaysia Dl owner. 
        /// </summary>
        IDate ValidUntil { get; }
        
        /// <summary>
        /// The zipcode of the front side of the Malaysia Dl owner. 
        /// </summary>
        string Zipcode { get; }
        
    }
}