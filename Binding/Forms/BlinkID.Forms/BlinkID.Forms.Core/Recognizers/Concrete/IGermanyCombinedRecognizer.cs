namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front and back side of German national ID cards,
    ///  * front side of German old ID card and front side of German Passport.
    /// </summary>
    public interface IGermanyCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of German ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if issuing authority of German ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// Defines if CAN number of Germany ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCanNumber { get; set; }
        
        /// <summary>
        /// Defines if colour of eyes of German ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractColourOfEyes { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Germany ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue of German ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if document number of Germany ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDocumentNumber { get; set; }
        
        /// <summary>
        /// Defines if given name of German passport owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenName { get; set; }
        
        /// <summary>
        /// Defines if given names of Germany ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// Defines if height of German ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if nationality  of Germany ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Germany ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if surname of Germany ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        /// Defines whether signature image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        
        /// <summary>
        /// Defines whether or not recognition result should be signed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for signature image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IGermanyCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IGermanyCombinedRecognizer.
    /// </summary>
    public interface IGermanyCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Germany ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The issuing authority of the Germany ID card. 
        /// </summary>
        string Authority { get; }
        
        /// <summary>
        /// The CAN number of the Germany ID card. 
        /// </summary>
        string CanNumber { get; }
        
        /// <summary>
        /// The colour of eyes of the Germany ID owner. 
        /// </summary>
        string ColourOfEyes { get; }
        
        /// <summary>
        /// The date of birth of the Germany ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the Germany ID card. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of the Germany ID card. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Defines digital signature of recognition results. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Defines digital signature version. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Defines {true} if data from scanned parts/sides of the document match, 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        /// The document number of the Germany ID card. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// Front side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// The given names of the Germany ID owner. 
        /// </summary>
        string GivenNames { get; }
        
        /// <summary>
        /// The height of the Germany ID owner. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// Determines if all check digits inside MRZ are correct 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// The nationality of the Germany ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The place of birth of the Germany ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The full mrz string result. 
        /// </summary>
        string RawMrzString { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the Germany ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The surname of the Germany ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}