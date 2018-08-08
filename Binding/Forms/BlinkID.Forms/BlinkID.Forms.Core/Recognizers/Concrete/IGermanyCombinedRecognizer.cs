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
        /// true if address is being extracted from ID 
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
        /// Defines whether full document image will be available in result. 
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
        /// the address of the German ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// the CAN number of German ID. 
        /// </summary>
        string CanNumber { get; }
        
        /// <summary>
        /// the date of birth of German ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the document date of expiry of the German ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// the document date of issue of the German ID. 
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
        /// the issuing authority of German ID. 
        /// </summary>
        string EyeColor { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the German ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        ///  front side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// the issuing authority of German ID. 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// the identity card number of German ID. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// the issuing authority of German ID. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// the last name of the German ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// true if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// nationality of the German ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// the issuing authority of German ID. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        ///  {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// sex of the German ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}