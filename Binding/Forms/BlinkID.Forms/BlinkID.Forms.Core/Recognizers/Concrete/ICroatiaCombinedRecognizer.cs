namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for combined reading of both front and back side of Croatian ID.
    /// 
    /// </summary>
    public interface ICroatiaCombinedRecognizer : IRecognizer
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
        ICroatiaCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ICroatiaCombinedRecognizer.
    /// </summary>
    public interface ICroatiaCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the address of the Croatian ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// citizenship of the Croatian ID owner. 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// the date of birth of Croatian ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the document date of expiry of the Croatian ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// true if document expiry is permanent 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// the document date of issue of the Croatian ID. 
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
        /// true if scanned document is bilingual 
        /// </summary>
        bool DocumentBilingual { get; }
        
        /// <summary>
        /// Defines {true} if data from scanned parts/sides of the document match, 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the Croatian ID owner. 
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
        /// the identity card number of Croatian ID. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// the issuing authority of Croatian ID. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// the last name of the Croatian ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// true if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// true if document owner is non resident. 
        /// </summary>
        bool NonResident { get; }
        
        /// <summary>
        /// personal identification number of the Croatian ID holder. 
        /// </summary>
        string PersonalIdentificationNumber { get; }
        
        /// <summary>
        ///  {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// sex of the Croatian ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}