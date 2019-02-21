namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer for combined reading of both front and back side of Singapore ID.
    /// </summary>
    public interface ISingaporeCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID owner's address should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID owner's address change date on sticker should be extracted 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractAddressChangeDate { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID owner's blood group should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodGroup { get; set; }
        
        /// <summary>
        /// Defines if country of birth of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCountryOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID's date of issue should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if name of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if race of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRace { get; set; }
        
        /// <summary>
        /// Defines if sex of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        /// Defines whether or not recognition result should be signed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISingaporeCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeCombinedRecognizer.
    /// </summary>
    public interface ISingaporeCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The Singapore ID owner's address 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The Singapore ID owner's address change date, present if the address is on a sticker 
        /// </summary>
        IDate AddressChangeDate { get; }
        
        /// <summary>
        /// The Singapore ID owner's blood group 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The country/place of birth of the Singaporean ID card owner. 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// The date of birth of the Singaporean ID card owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The Singapore ID's date of issue 
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
        /// Back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// Front side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// The identity card number of the Singaporean ID card. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// The name of the Singaporean ID card owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The race of the Singaporean ID card owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the Singaporean ID card owner. 
        /// </summary>
        string Sex { get; }
        
    }
}