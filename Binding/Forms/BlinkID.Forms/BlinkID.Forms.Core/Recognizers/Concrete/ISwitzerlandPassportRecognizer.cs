namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Swiss Passport Recognizer.
    /// 
    /// Swiss Passport recognizer is used for scanning Swiss Passport.
    /// </summary>
    public interface ISwitzerlandPassportRecognizer : IRecognizer
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
        /// Defines if authority should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAuthority { get; set; }
        
        /// <summary>
        /// Defines if date of birth should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if date of issue should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if owner's name should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenName { get; set; }
        
        /// <summary>
        /// Defines if height should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractHeight { get; set; }
        
        /// <summary>
        /// Defines if passport number should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPassportNumber { get; set; }
        
        /// <summary>
        /// Defines if owner's place of birth should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// Defines if sex should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if owner's surname should be extracted from Swiss Passport
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        /// Gets the result.
        /// </summary>
        ISwitzerlandPassportRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISwitzerlandPassportRecognizer.
    /// </summary>
    public interface ISwitzerlandPassportRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Issuing authority of the Passport 
        /// </summary>
        string Authority { get; }
        
        /// <summary>
        /// Holder's date of birth. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Date of expiry of the document. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Date of issue in NSDate object 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The document code. Document code contains two characters. For MRTD the first character
        /// shall be A, C or I. The second character shall be discretion of the issuing State or organization
        /// except that V shall not be used, and C shall not be used after A except in the crew member
        /// certificate. On machine-readable passports (MRP) first character shall be P to designate an MRP.
        /// One additional letter may be used, at the discretion of the issuing State or organization,
        /// to designate a particular MRP. If the second character position is not used for this purpose, it
        /// shall be filled by the filter character <. 
        /// </summary>
        string DocumentCode { get; }
        
        /// <summary>
        /// Unique number of the document. Document number contains up to 9 characters.
        /// Element does not exist on US Green Card. To see which document was scanned use documentType property. 
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
        /// The name of the Swiss Passport owner. 
        /// </summary>
        string GivenName { get; }
        
        /// <summary>
        /// The height of the Swiss Passport owner 
        /// </summary>
        string Height { get; }
        
        /// <summary>
        /// Three-letter code which indicate the issuing State.
        /// Three-letter codes are based on Alpha-3 codes for entities specified in
        /// ISO 3166-1, with extensions for certain States. 
        /// </summary>
        string Issuer { get; }
        
        /// <summary>
        /// Boolean value which denotes that MRTD result is successfully parsed. When the result is parsed, all
        /// properties below are present.
        /// 
        /// If in the PPMrtdRecognizerSettings you specified allowUnparsedResults = true, then it can happen that
        /// MRTDRecognizerResult is not parsed. When this happens, this property will be equal to true.
        /// 
        /// In that case, you can use rawOcrResult property to obtain the raw result of the OCR process, so you can
        /// implement MRTD parsing in your application.
        /// 
        ///  @return true if MRTD Recognizer result was successfully parsed and all the fields are extracted. false otherwise. 
        /// </summary>
        bool MrzParsed { get; }
        
        /// <summary>
        /// The entire Machine Readable Zone text from ID. This text is usually used for parsing
        /// other elements. 
        /// </summary>
        string MrzText { get; }
        
        /// <summary>
        /// true if all check digits inside MRZ are correct, false otherwise.
        /// More specifically, true if MRZ complies with ICAO Document 9303 standard, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// Nationality of the holder represented by a three-letter code. Three-letter codes are based
        /// on Alpha-3 codes for entities specified in ISO 3166-1, with extensions for certain States. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// Date of birth, as written on the passport 
        /// </summary>
        IDate NonMrzDateOfBirth { get; }
        
        /// <summary>
        /// Date of expiry, as written on the passport 
        /// </summary>
        IDate NonMrzDateOfExpiry { get; }
        
        /// <summary>
        /// The sex of the Swiss Passport owner 
        /// </summary>
        string NonMrzSex { get; }
        
        /// <summary>
        /// First optional data. Returns nil or empty string if not available.
        /// Element does not exist on US Green Card. To see which document was scanned use documentType property. 
        /// </summary>
        string Opt1 { get; }
        
        /// <summary>
        /// Second optional data. Returns nil or empty string if not available.
        /// Element does not exist on Passports and Visas. To see which document was scanned use documentType property. 
        /// </summary>
        string Opt2 { get; }
        
        /// <summary>
        /// Number of the Passport 
        /// </summary>
        string PassportNumber { get; }
        
        /// <summary>
        /// The place of birth of the Swiss Passport owner 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// Returns the primary indentifier. If there is more than one component, they are separated with space.
        /// 
        ///  @return primary id of a card holder. 
        /// </summary>
        string PrimaryId { get; }
        
        /// <summary>
        /// Returns the secondary identifier. If there is more than one component, they are separated with space.
        /// 
        ///  @return secondary id of a card holder 
        /// </summary>
        string SecondaryId { get; }
        
        /// <summary>
        /// Sex of the card holder. Sex is specified by use of the single initial, capital
        /// letter F for female, M for male or < for unspecified. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The surname of the Swiss Passport owner. 
        /// </summary>
        string Surname { get; }
        
    }
}