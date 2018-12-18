namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Malaysia DL cards.
    /// </summary>
    public interface IMalaysiaDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Malaysia DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if vehicle classes of Malaysia DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractClass { get; set; }
        
        /// <summary>
        /// Defines if name of Malaysia DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of Malaysia DL owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Malaysia DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidFrom { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Malaysia DL should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// The extension factors for full document image. 
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
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
        /// The city of Malaysia DL owner 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The vehicle classes of Malaysia DL 
        /// </summary>
        string DlClass { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The address of Malaysia DL owner 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The identity number of Malaysia DL owner 
        /// </summary>
        string IdentityNumber { get; }
        
        /// <summary>
        /// The name of Malaysia DL owner 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of Malaysia DL owner 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The state of Malaysia DL owner 
        /// </summary>
        string OwnerState { get; }
        
        /// <summary>
        /// The street of Malaysia DL owner 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// The date of issue of Malaysia DL 
        /// </summary>
        IDate ValidFrom { get; }
        
        /// <summary>
        /// The date of expiry of Malaysia DL 
        /// </summary>
        IDate ValidUntil { get; }
        
        /// <summary>
        /// The zipocde of Malaysia DL owner 
        /// </summary>
        string Zipcode { get; }
        
    }
}