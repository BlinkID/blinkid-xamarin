namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for combined reading of both front and back side of Serbian ID.
    /// 
    /// </summary>
    public interface ISerbiaCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
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
        ISerbiaCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISerbiaCombinedRecognizer.
    /// </summary>
    public interface ISerbiaCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the Serbian ID holder. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The document date of expiry of the Serbian ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The document date of issue of the Serbian ID. 
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
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// First name of the Serbian ID holder. 
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
        /// The identity card number of Serbian ID. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// Issuer of the Serbian ID holder. 
        /// </summary>
        string Issuer { get; }
        
        /// <summary>
        /// Personal identification number of the Serbian ID holder. 
        /// </summary>
        string Jmbg { get; }
        
        /// <summary>
        /// Last name of the Serbian ID holder. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// True if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// Nationality of the Serbian ID holder. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// Sex of the Serbian ID holder. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}