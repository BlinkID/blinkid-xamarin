namespace Microblink.Forms.Core.Recognizers
{
    public interface IIndonesiaIdFrontRecognizer : IRecognizer
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
        /// Defines if address should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if blood type should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodType { get; set; }
        
        /// <summary>
        /// Defines if citizenship should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCitizenship { get; set; }
        
        /// <summary>
        ///  Defines if city of Indonesian ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCity { get; set; }
        
        /// <summary>
        /// Defines if district should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDistrict { get; set; }
        
        /// <summary>
        /// Defines if keldesa should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractKelDesa { get; set; }
        
        /// <summary>
        /// Defines if marital status should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractMaritalStatus { get; set; }
        
        /// <summary>
        /// Defines if name of Indonesian ID owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if occupation should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOccupation { get; set; }
        
        /// <summary>
        /// Defines if place of birth of Indonesian ID owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if religion should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReligion { get; set; }
        
        /// <summary>
        /// Defines if rt should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRt { get; set; }
        
        /// <summary>
        /// Defines if rw should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRw { get; set; }
        
        /// <summary>
        /// Defines if valid until should be extracted from Indonesian ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        IIndonesiaIdFrontRecognizerResult Result { get; }
    }

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
        /// The occupation of the Indonesian ID owner. 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// The city of the Indonesian ID owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The date of birth of Indonesian ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The district of the Indonesian ID owner. 
        /// </summary>
        string District { get; }
        
        /// <summary>
        /// The document classifier of Indonesian ID 
        /// </summary>
        string DocumentClassifier { get; }
        
        /// <summary>
        /// The document number of the Indonesian ID owner. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The kel desa of the Indonesian ID owner. 
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
        /// The rt of the Indonesian ID owner. 
        /// </summary>
        string Rt { get; }
        
        /// <summary>
        /// The rw of the Indonesian ID owner. 
        /// </summary>
        string Rw { get; }
        
        /// <summary>
        /// The sex of the Indonesian ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// The document date of expiry of the Indonesian ID 
        /// </summary>
        IDate ValidUntil { get; }
        
        /// <summary>
        /// Check if date of expiry is permanent on the Indonesian ID. 
        /// </summary>
        bool ValidUntilPermanent { get; }
        
    }
}