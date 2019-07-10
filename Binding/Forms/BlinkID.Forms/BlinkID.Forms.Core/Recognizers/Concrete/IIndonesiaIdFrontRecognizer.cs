namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Indonesian national ID cards.
    /// </summary>
    public interface IIndonesiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if blood type of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodType { get; set; }
        
        /// <summary>
        /// Defines if citizenship of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCitizenship { get; set; }
        
        /// <summary>
        /// Defines if city of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCity { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of Indonesian ID card should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if district of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDistrict { get; set; }
        
        /// <summary>
        /// Defines if Kel/Desa of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractKelDesa { get; set; }
        
        /// <summary>
        /// Defines if marital status of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractMaritalStatus { get; set; }
        
        /// <summary>
        /// Defines if name of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if occupation of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOccupation { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if religion of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReligion { get; set; }
        
        /// <summary>
        /// Defines if RT number of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRt { get; set; }
        
        /// <summary>
        /// Defines if RW number of Indonesian ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRw { get; set; }
        
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
        /// The DPI (Dots Per Inch) for signature image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IIndonesiaIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IIndonesiaIdFrontRecognizer.
    /// </summary>
    public interface IIndonesiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Indonesian ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The blood type of the Indonesian ID owner. 
        /// </summary>
        string BloodType { get; }
        
        /// <summary>
        /// The citizenship of the Indonesian ID owner. 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// The city of the Indonesian ID owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The date of birth of the Indonesian ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the Indonesian ID card. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of expiry of the Indonesian ID card is permanent. 
        /// </summary>
        bool DateOfExpiryPermanent { get; }
        
        /// <summary>
        /// The district of the Indonesian ID owner. 
        /// </summary>
        string District { get; }
        
        /// <summary>
        /// The document number of Indonesian ID card. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The Kel/Desa of the Indonesian ID owner. 
        /// </summary>
        string KelDesa { get; }
        
        /// <summary>
        /// The marital status of the Indonesian ID owner. 
        /// </summary>
        string MaritalStatus { get; }
        
        /// <summary>
        /// The name of the Indonesian ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The occupation of the Indonesian ID owner. 
        /// </summary>
        string Occupation { get; }
        
        /// <summary>
        /// The place of birth of the Indonesian ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The province of the Indonesian ID owner. 
        /// </summary>
        string Province { get; }
        
        /// <summary>
        /// The religion of the Indonesian ID owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The RT number of the Indonesian ID owner. 
        /// </summary>
        string Rt { get; }
        
        /// <summary>
        /// The RW number of the Indonesian ID owner. 
        /// </summary>
        string Rw { get; }
        
        /// <summary>
        /// The sex of the Indonesian ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// Signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}