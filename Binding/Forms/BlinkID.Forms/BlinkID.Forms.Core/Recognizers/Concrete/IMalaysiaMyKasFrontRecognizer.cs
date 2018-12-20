namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Malaysian MyKAS cards.
    /// </summary>
    public interface IMalaysiaMyKasFrontRecognizer : IRecognizer
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
        /// Defines if full name and address of Malaysian MyKAS owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullNameAndAddress { get; set; }
        
        /// <summary>
        /// Defines if religion of Malaysian MyKAS owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReligion { get; set; }
        
        /// <summary>
        /// Defines if sex of Malaysian MyKAS owner should be extracted.
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
        IMalaysiaMyKasFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMalaysiaMyKasFrontRecognizer.
    /// </summary>
    public interface IMalaysiaMyKasFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The birth date of Malaysian MyKAS owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// The city of Malaysian MyKAS owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The date of expiry of Malaysian MyKAS. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The address of Malaysian MyKAS owner. 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The full name of Malaysian MyKAS owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The nric of Malaysian MyKAS. 
        /// </summary>
        string Nric { get; }
        
        /// <summary>
        /// The state of Malaysian MyKAS owner. 
        /// </summary>
        string OwnerState { get; }
        
        /// <summary>
        /// The religion of Malaysian MyKAS owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The sex of Malaysian MyKAS owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The street of Malaysian MyKAS owner. 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// The zipcode of Malaysian MyKAS owner. 
        /// </summary>
        string Zipcode { get; }
        
    }
}