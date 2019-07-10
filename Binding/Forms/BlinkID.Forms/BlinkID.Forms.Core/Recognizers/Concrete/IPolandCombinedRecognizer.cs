namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front and back side of Poland national ID cards.
    /// </summary>
    public interface IPolandCombinedRecognizer : IRecognizer
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
        /// Defines if date of birth of Poland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if family name of Poland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractFamilyName { get; set; }
        
        /// <summary>
        /// Defines if given names of Poland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// Defines if parents given names of Poland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractParentsGivenNames { get; set; }
        
        /// <summary>
        /// Defines if sex of Poland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if surname of Poland ID owner should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        /// Whether or not recognition result should be signed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IPolandCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IPolandCombinedRecognizer.
    /// </summary>
    public interface IPolandCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the Poland ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the Poland ID card. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Digital signature of the recognition result. Available only if enabled with signResult property. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Version of the digital signature. Available only if enabled with signResult property. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Returns true if data from scanned parts/sides of the document match,
        /// false otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return false. Result will
        /// be true only if scanned values for all fields that are compared are the same. 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        /// The document number of the Poland ID card. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The family name of the Poland ID owner. 
        /// </summary>
        string FamilyName { get; }
        
        /// <summary>
        /// back side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// front side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// The given names of the Poland ID owner. 
        /// </summary>
        string GivenNames { get; }
        
        /// <summary>
        /// The issuing authority of the Poland ID card. 
        /// </summary>
        string IssuedBy { get; }
        
        /// <summary>
        /// Determines if all check digits inside MRZ are correct 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// The nationality of the Poland ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The parents given names of the Poland ID owner. 
        /// </summary>
        string ParentsGivenNames { get; }
        
        /// <summary>
        /// The personal number of the Poland ID owner. 
        /// </summary>
        string PersonalNumber { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the Poland ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The surname of the Poland ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}