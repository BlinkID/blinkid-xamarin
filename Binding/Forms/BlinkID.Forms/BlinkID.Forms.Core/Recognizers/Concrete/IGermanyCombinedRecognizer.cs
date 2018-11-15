namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for combined reading of both front and back side of German ID.
    /// 
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
        /// True if address is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines the extension factors for full document image. 
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
        /// Gets the result.
        /// </summary>
        IGermanyCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IGermanyCombinedRecognizer.
    /// </summary>
    public interface IGermanyCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the German ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The CAN number of German ID. 
        /// </summary>
        string CanNumber { get; }
        
        /// <summary>
        /// The date of birth of German ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The document date of expiry of the German ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The document date of issue of the German ID. 
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
        /// The issuing authority of German ID. 
        /// </summary>
        string EyeColor { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the German ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// Back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// Front side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// The issuing authority of German ID. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// The identity card number of German ID. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// The issuing authority of German ID. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The last name of the German ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// True if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// Nationality of the German ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The issuing authority of German ID. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// Sex of the German ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}