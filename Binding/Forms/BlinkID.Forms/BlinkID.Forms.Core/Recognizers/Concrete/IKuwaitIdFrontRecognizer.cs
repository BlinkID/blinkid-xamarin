namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Kuwait national ID cards.
    /// </summary>
    public interface IKuwaitIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Kuwait ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBirthDate { get; set; }
        
        /// <summary>
        /// Defines if name of Kuwait ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of Kuwait ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if sex of Kuwait ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        IKuwaitIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IKuwaitIdFrontRecognizer.
    /// </summary>
    public interface IKuwaitIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The birth date of the Kuwait ID owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// The civil ID number of the Kuwait ID owner. 
        /// </summary>
        string CivilIdNumber { get; }
        
        /// <summary>
        /// The expiry date of the Kuwait ID. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The name of the Kuwait ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of the Kuwait ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The sex of the Kuwait ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}