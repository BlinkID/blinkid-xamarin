namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Kuwait national ID cards.
    /// </summary>
    public interface IKuwaitIdFrontRecognizer : IRecognizer
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
        /// Defines if date of birth of Kuwait ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBirthDate { get; set; }
        
        /// <summary>
        /// Defines if name of Kuwait ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if nationality of Kuwait ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if sex of Kuwait ID owner should be extracted.
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
        IKuwaitIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IKuwaitIdFrontRecognizer.
    /// </summary>
    public interface IKuwaitIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The birth Date of the front side of the Kuroom wait Id owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// The civil Id Number of the front side of the Kuwait Id owner. 
        /// </summary>
        string CivilIdNumber { get; }
        
        /// <summary>
        /// The expiry Date of the front side of the Kuwait Id owner. 
        /// </summary>
        IDate ExpiryDate { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The name of the front side of the Kuwait Id owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The nationality of the front side of the Kuwait Id owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The sex of the front side of the Kuwait Id owner. 
        /// </summary>
        string Sex { get; }
        
    }
}