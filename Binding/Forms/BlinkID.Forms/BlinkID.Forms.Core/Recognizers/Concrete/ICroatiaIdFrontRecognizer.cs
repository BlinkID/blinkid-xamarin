namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Croatian ID Front Recognizer.
    /// 
    /// Croatian ID Front recognizer is used for scanning front side of Croatian ID. It always extracts
    /// identity card number, first and last name of ID holder while extracting other elements is optional.
    /// </summary>
    public interface ICroatiaIdFrontRecognizer : IRecognizer
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
        /// Defines if citizenship of Croatian ID owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCitizenship { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Croatian ID owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Croatian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        ///  Defines if first name of Croatian ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFirstName { get; set; }
        
        /// <summary>
        ///  Defines if last name of Croatian ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
        /// <summary>
        ///  Defines if sex of Croatian ID owner should be extracted
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
        /// Sets whether signature image from ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        
        /// <summary>
        /// Property for setting DPI for signature images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ICroatiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICroatiaIdFrontRecognizer.
    /// </summary>
    public interface ICroatiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The citizenship of the Croatian ID owner. 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// The date of birth of Croatian ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The document date of expiry of the Croatian ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Check if date of expiry is permanent on the Croatian ID. 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// true if the document is bilingual 
        /// </summary>
        bool DocumentBilingual { get; }
        
        /// <summary>
        /// The document number of the Croatian ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the Croatian ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The last name of the Croatian ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The sex of the Croatian ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}