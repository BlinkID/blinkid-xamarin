namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// MRTD Combined recognizer
    /// 
    /// MRTD Combined recognizer is used for scanning both front and back side of generic IDs.
    /// </summary>
    public interface IMrtdCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Whether returning of unparsed results is allowed
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnparsedResults { get; set; }
        
        /// <summary>
        /// Whether returning of unverified results is allowed
        /// Unverified result is result that is parsed, but check digits are incorrect.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnverifiedResults { get; set; }
        
        /// <summary>
        /// Defines how many times the same document should be detected before the detector
        /// returns this document as a result of the deteciton
        /// 
        /// Higher number means more reliable detection, but slower processing
        /// 
        ///  
        ///
        /// By default, this is set to '6'
        /// </summary>
        uint NumStableDetectionsThreshold { get; set; }
        
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
        /// Sets whether MRZ image from ID card should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnMrzImage { get; set; }
        
        /// <summary>
        /// Whether or not recognition result should be signed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IMrtdCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMrtdCombinedRecognizer.
    /// </summary>
    public interface IMrtdCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Alien number. Returns nil or empty string if not available.
        /// Exists only on US Green Cards. To see which document was scanned use documentType property. 
        /// </summary>
        string AlienNumber { get; }
        
        /// <summary>
        /// Application receipt number. Returns nil or empty string if not available.
        /// Exists only on US Green Cards. To see which document was scanned use documentType property. 
        /// </summary>
        string ApplicationReceiptNumber { get; }
        
        /// <summary>
        /// Holder's date of birth. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Date of expiry of the document. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Digital signature of the recognition result. Available only if enabled with signResult property. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Version of the digital signature. Available only if enabled with signResult property. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
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
        /// Returns true if data from scanned parts/sides of the document match,
        /// false otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return false. Result will
        /// be true only if scanned values for all fields that are compared are the same. 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        /// Unique number of the document. Document number contains up to 9 characters.
        /// Element does not exist on US Green Card. To see which document was scanned use documentType property. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// Returns the MRTD document type of recognized document. 
        /// </summary>
        MrtdDocumentType DocumentType { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// back side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// front side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// Immigrant case number. Returns nil or empty string if not available.
        /// Exists only on US Green Cards. To see which document was scanned use documentType property. 
        /// </summary>
        string ImmigrantCaseNumber { get; }
        
        /// <summary>
        /// Three-letter code which indicate the issuing State.
        /// Three-letter codes are based on Alpha-3 codes for entities specified in
        /// ISO 3166-1, with extensions for certain States. 
        /// </summary>
        string Issuer { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnMrzImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource MrzImage { get; }
        
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
        /// Returns the primary indentifier. If there is more than one component, they are separated with space.
        /// 
        ///  @return primary id of a card holder. 
        /// </summary>
        string PrimaryId { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
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
        
    }
}