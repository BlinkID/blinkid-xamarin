﻿namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// A generic recognizer which can scan front and back side of the document.
    /// </summary>
    public interface IBlinkIdCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether blured frames filtering is allowed. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AllowBlurFilter { get; set; }
        
        /// <summary>
        /// Defines whether returning of unparsed MRZ (Machine Readable Zone) results is allowed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnparsedMrzResults { get; set; }
        
        /// <summary>
        /// Defines whether returning unverified MRZ (Machine Readable Zone) results is allowed. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AllowUnverifiedMrzResults { get; set; }
        
        /// <summary>
        /// Whether sensitive data should be anonymized in full document image result. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool AnonymizeImage { get; set; }
        
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
        /// Padding is a minimum distance from the edge of the frame and it is defined 
        ///
        /// By default, this is set to '0.0'
        /// </summary>
        float PaddingEdge { get; set; }
        
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
        /// Defines whether or not recognition result should be signed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        
        /// <summary>
        /// Skip back side capture and processing step when back side of the document is not supported. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SkipUnsupportedBack { get; set; }
        
        /// <summary>
        /// Whether result characters validatation is performed. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ValidateResultCharacters { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IBlinkIdCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IBlinkIdCombinedRecognizer.
    /// </summary>
    public interface IBlinkIdCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The additional name information of the document owner. 
        /// </summary>
        string AdditionalAddressInformation { get; }
        
        /// <summary>
        /// The additional name information of the document owner. 
        /// </summary>
        string AdditionalNameInformation { get; }
        
        /// <summary>
        /// The address of the document owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The current age of the document owner in years. It is calculated difference 
        /// </summary>
        int Age { get; }
        
        /// <summary>
        /// The document class information. 
        /// </summary>
        IClassInfo ClassInfo { get; }
        
        /// <summary>
        /// The driver license conditions. 
        /// </summary>
        string Conditions { get; }
        
        /// <summary>
        /// The date of birth of the document owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the document. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Determines if date of expiry is permanent. 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// The date of issue of the document. 
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
        /// The additional number of the document. 
        /// </summary>
        string DocumentAdditionalNumber { get; }
        
        /// <summary>
        /// The document back side color status determined from scanned image. 
        /// </summary>
        DocumentImageColorStatus DocumentBackImageColorStatus { get; }
        
        /// <summary>
        /// The Moire pattern detection status determined from the back side image. 
        /// </summary>
        DocumentImageMoireStatus DocumentBackImageMoireStatus { get; }
        
        /// <summary>
        /// Defines result of the data matching algorithm for scanned parts/sides of the document. 
        /// </summary>
        DataMatchResult DocumentDataMatch { get; }
        
        /// <summary>
        /// The document front side color status determined from scanned image. 
        /// </summary>
        DocumentImageColorStatus DocumentFrontImageColorStatus { get; }
        
        /// <summary>
        /// The Moire pattern detection status determined from the front side image. 
        /// </summary>
        DocumentImageMoireStatus DocumentFrontImageMoireStatus { get; }
        
        /// <summary>
        /// The document number. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The driver license detailed info. 
        /// </summary>
        IDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get; }
        
        /// <summary>
        /// The employer of the document owner. 
        /// </summary>
        string Employer { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The first name of the document owner. 
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
        /// The full name of the document owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The issuing authority of the document. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The last name of the document owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The localized name of the document owner. 
        /// </summary>
        string LocalizedName { get; }
        
        /// <summary>
        /// The marital status of the document owner. 
        /// </summary>
        string MaritalStatus { get; }
        
        /// <summary>
        /// The data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// The nationality of the documet owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The personal identification number. 
        /// </summary>
        string PersonalIdNumber { get; }
        
        /// <summary>
        /// The place of birth of the document owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The profession of the document owner. 
        /// </summary>
        string Profession { get; }
        
        /// <summary>
        /// The race of the document owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// The religion of the document owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The residential stauts of the document owner. 
        /// </summary>
        string ResidentialStatus { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the document owner. 
        /// </summary>
        string Sex { get; }
        
    }
}