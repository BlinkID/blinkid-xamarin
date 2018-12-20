namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Malaysian MyKad cards.
    /// </summary>
    public interface IMalaysiaMyKadFrontRecognizer : IRecognizer
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
        /// Defines if full name and address of Malaysian MyKad owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullNameAndAddress { get; set; }
        
        /// <summary>
        /// Defines if religion of Malaysian MyKad owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReligion { get; set; }
        
        /// <summary>
        /// Defines if sex of Malaysian MyKad owner should be extracted.
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
        IMalaysiaMyKadFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMalaysiaMyKadFrontRecognizer.
    /// </summary>
    public interface IMalaysiaMyKadFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The birth date of Malaysian MyKad owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// The city of Malaysian MyKad owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The address of Malaysian MyKad owner. 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The full name of Malaysian MyKad owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The nric of Malaysian IDMyKad 
        /// </summary>
        string Nric { get; }
        
        /// <summary>
        /// The state of Malaysian MyKad owner. 
        /// </summary>
        string OwnerState { get; }
        
        /// <summary>
        /// The religion of Malaysian MyKad owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The sex of Malaysian MyKad owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The street of Malaysian MyKad owner. 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// The zipcode of Malaysian MyKad owner. 
        /// </summary>
        string Zipcode { get; }
        
    }
}