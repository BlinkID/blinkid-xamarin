using System;
namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Possible types of Machine Readable Travel Documents (MRTDs)
    /// </summary>
    public enum MrtdDocumentType
    {
        /// <summary>
        /// Unknown document type
        /// </summary>
        Unknown,
        /// <summary>
        /// Identity card
        /// </summary>
        IdentityCard,
        /// <summary>
        /// Passport.
        /// </summary>
        Passport,
        /// <summary>
        /// Visa.
        /// </summary>
        Visa,
        /// <summary>
        /// US Green Card .
        /// </summary>
        GreenCard,
        /// <summary>
        /// Malaysian PASS type IMM13P
        /// </summary>
        MalaysianPassIMM13P
    }

    /// <summary>
    /// Represents data extracted from MRZ (Machine Readable Zone) of Machine Readable Travel Document (MRTD).
    /// </summary>
    public interface IMrzResult
    {
        /// <summary>
        /// Gets the type of the document.
        /// </summary>
        /// <value>The type of the document.</value>
        MrtdDocumentType DocumentType { get; }

        /// <summary>
        /// Gets the primary identifier. If there is more than one component, they are separated with space.
        /// </summary>
        /// <value>The primary identifier.</value>
        string PrimaryId { get; }

        /// <summary>
        /// Gets the secondary identifier. If there is more than one component, they are separated with space.
        /// </summary>
        /// <value>The secondary identifier.</value>
        string SecondaryId { get; }

        /// <summary>
        /// Gets the issuer of the document.
        /// The issuer is three-letter or two-letter code which indicate the issuing State. 
        /// Three-letter codes are based on Aplha-3 codes for entities specified in ISO 3166-1, 
        /// with extensions for certain States. Two-letter codes are based on Alpha-2 codes for 
        /// entities specified in ISO 3166-1, with extensions for certain States.
        /// </summary>
        /// <value>The issuer.</value>
        string Issuer { get; }

        /// <summary>
        /// Gets the date of birth of the ID holder.
        /// </summary>
        /// <value>The date of birth.</value>
        IDate DateOfBirth { get; }

        /// <summary>
        /// Gets the document number.
        /// Document number contains up to 9 characters. Element does not exist on US 
        /// Green Card. To see which document was scanned use DocumentType property.
        /// </summary>
        /// <value>The document number.</value>
        string DocumentNumber { get; }

        /// <summary>
        /// Gets the nationality of the ID holder.
        /// The nationality of the holder represented by a three-letter or two-letter code. Three-letter
        /// codes are based on Alpha-3 codes for entities specified in ISO 3166-1, with extensions for certain
        /// States.Two-letter codes are based on Aplha-2 codes for entities specified in ISO 3166-1, with
        /// extensions for certain States.
        /// </summary>
        /// <value>The nationality.</value>
        string Nationality { get; }

        /// <summary>
        /// Gets the gender of the document holder.
        /// Gender is specified by use of the single initial, capital letter F for female,
        /// M for male or <code>&lt;</code> for unspecified.
        /// </summary>
        /// <value>The gender.</value>
        string Gender { get; }

        /// <summary>
        /// Gets the document code.
        /// Document code contains two characters. For MRTD the first character shall 
        /// be A, C or I.The second character shall be discretion of the issuing State or organization except
        /// that V shall not be used, and `C` shall not be used after `A` except in the crew member certificate.
        /// On machine-readable passports (MRP) first character shall be `P` to designate an MRP. One additional
        /// letter may be used, at the discretion of the issuing State or organization, to designate a particular
        /// MRP.If the second character position is not used for this purpose, it shall be filled by the filter
        /// character <code>&lt;</code>.
        /// </summary>
        /// <value>The document code.</value>
        string DocumentCode { get; }

        /// <summary>
        /// Gets the date of expiry of the document.
        /// </summary>
        /// <value>The date of expiry.</value>
        IDate DateOfExpiry { get; }

        /// <summary>
        /// Gets the first optional data.
        /// Contains empty string if not available. 
        /// Element does not exist on US Green Card.
        /// To see which document was scanned use the DocumentType property.
        /// </summary>
        /// <value>The first optional data.</value>
        string Opt1 { get; }

        /// <summary>
        /// Gets the second optional data.
        /// Contains empty string if not available. 
        /// Element does not exist on US Green Card.
        /// To see which document was scanned use the DocumentType property.
        /// </summary>
        /// <value>The second optional data.</value>
        string Opt2 { get; }

        /// <summary>
        /// Gets the alien number.
        /// Contains empty string if not available.
        /// Exists only on US Green Cards.
        /// To see which document was scanned use the DocumentType property.
        /// </summary>
        /// <value>The alien number.</value>
        string AlienNumber { get; }

        /// <summary>
        /// Gets the application receipt number.
        /// Contains empty string if not available.
        /// Exists only on US Green Cards.
        /// To see which document was scanned use the DocumentType property.
        /// </summary>
        /// <value>The application receipt number.</value>
        string ApplicationReceiptNumber { get; }

        /// <summary>
        /// Gets the immigrant case number.
        /// Contains empty string if not available.
        /// Exists only on US Green Cards.
        /// To see which document was scanned use the DocumentType property.
        /// </summary>
        /// <value>The immigrant case number.</value>
        string ImmigrantCaseNumber { get; }

        /// <summary>
        /// Gets entire Machine Readable Zone text from ID. This text is usually 
        /// used for parsing other elements.
        /// NOTE: This string is available only if OCR result was parsed successfully.
        /// </summary>
        /// <value>The MRZ text.</value>
        string MrzText { get; }

        /// <summary>
        /// Gets a value indicating whether Machine Readable Zone has been parsed.
        /// </summary>
        /// <value><c>true</c> if parsed; otherwise, <c>false</c>.</value>
        bool Parsed { get; }

        /// <summary>
        /// Gets a value indicating whether all check digits inside MRZ are correct.
        /// </summary>
        /// <value><c>true</c> if verified; otherwise, <c>false</c>.</value>
        bool Verified { get; }

        /// <summary>
        /// Sanitized field opt1.
        /// </summary>
        /// <value>Sanitized field opt1.</value>
        string SanitizedOpt1 { get; }

        /// <summary>
        /// Sanitized field opt1.
        /// </summary>
        /// <value>Sanitized field opt1.</value>
        string SanitizedOpt2 { get; }

        /// <summary>
        /// Sanitized field nationality
        /// </summary>
        /// <value>Sanitized field nationality.</value>
        string SanitizedNationality { get; }

        /// <summary>
        /// Sanitized field issuer
        /// </summary>
        /// <value>Sanitized field issuer.</value>
        string SanitizedIssuer { get; }

        /// <summary>
        /// Sanitized document code
        /// </summary>
        /// <value>Sanitized document code.</value>
        string SanitizedDocumentCode { get; }

        /// <summary>
        /// Sanitized document number
        /// </summary>
        /// <value>Sanitized document number.</value>
        string SanitizedDocumentNumber { get; }

        /// <summary>
        /// The current age of the document owner in years
        /// </summary>The current age of the document owner in years.</value>
        int Age { get ; }

    }

    /// <summary>
    /// Represents data extracted from the Driver's license.
    /// </summary>
    public interface IDriverLicenseDetailedInfo
    {
        /// <summary>
        /// Gets the restrictions to driving privileges for the driver license owner.
        /// </summary>
        /// <value>The restrictions to driving privileges for the driver license owner.</value>
        string Restrictions { get; }

        /// <summary>
        /// Gets the additional privileges granted to the driver license owner.
        /// </summary>
        /// <value>The additional privileges granted to the driver license owner.</value>
        string Endorsements { get; }

        /// <summary>
        /// Gets the type of vehicle the driver license owner has privilege to drive.
        /// </summary>
        /// <value>The type of vehicle the driver license owner has privilege to drive.</value>
        string VehicleClass { get; }

        /// <summary>
        /// The driver license conditions.
        /// </summary>The driver license conditions.</value>
        string Conditions { get ; }
    }

    /// <summary>
    /// Result of the data matching algorithm for scanned parts/sides of the document.
    /// </summary>
    public enum DataMatchResult
    {
        /// <summary>
        /// Data matching has not been performed.
        /// </summary>
        NotPerformed,
        /// <summary>
        /// Data does not match.
        /// </summary>
        Failed,
        /// <summary>
        /// Data match.
        /// </summary>
        Success
    }

    /// <summary>
    /// Possible supported detectors for documents containing face image.
    /// </summary>
    public enum DocumentFaceDetectorType
    {
        /// <summary>
        /// Uses document detector for TD1 size identity cards.
        /// </summary>
        TD1,
        /// <summary>
        /// Uses document detector for TD2 size identity cards.
        /// </summary>
        TD2,
        /// <summary>
        /// Uses MRTD detector for detecting documents with MRZ
        /// </summary>
        PassportAndVisas
    }

    /// <summary>
    /// Represents the type of scanned document
    /// </summary>
    public enum IdBarcodeDocumentType
    {
        /// <summary>
        /// No document was scanned
        /// </summary>
        None,

        /// <summary>
        /// AAMVACompliant document was scanned
        /// </summary>
        AAMVACompliant,

        /// <summary>
        /// Argentina ID document was scanned
        /// </summary>
        ArgentinaID,

        /// <summary>
        /// Argentina driver license document was scanned
        /// </summary>
        ArgentinaDL,

        /// <summary>
        /// Colombia ID document was scanned
        /// </summary>
        ColombiaID,

        /// <summary>
        /// Colombia driver license document was scanned
        /// </summary>
        ColombiaDL,

        /// <summary>
        /// NigeriaVoter ID document was scanned
        /// </summary>
        NigeriaVoterID,

        /// <summary>
        /// Nigeria driver license document was scanned
        /// </summary>
        NigeriaDL,

        /// <summary>
        /// Panama ID document was scanned
        /// </summary>
        PanamaID,

        /// <summary>
        /// SouthAfrica ID document was scanned
        /// </summary>
        SouthAfricaID,
    }

    public interface IImageExtensionFactors
    {
        /// <summary>
        /// Gets the image extension factor relative to full image height in UP direction.
        /// </summary>
        /// <value>Up factor.</value>
        float UpFactor { get; }

        /// <summary>
        /// Gets the image extension factor relative to full image height in RIGHT direction..
        /// </summary>
        /// <value>The right factor.</value>
        float RightFactor { get; }

        /// <summary>
        /// Gets image extension factor relative to full image height in DOWN direction.
        /// </summary>
        /// <value>Down factor.</value>
        float DownFactor { get; }

        /// <summary>
        /// Gets the image extension factor relative to full image height in LEFT direction.
        /// </summary>
        /// <value>The left factor.</value>
        float LeftFactor { get; }
    }

    /// <summary>
    /// Image extension factors factory. Use this to create an instance of IImageExtensionFactors.
    /// </summary>
    public interface IImageExtensionFactorsFactory
    {
        /// <summary>
        /// Creates the image extension factors.
        /// </summary>
        /// <returns>The image extension factors.</returns>
        /// <param name="upFactor">image extension factor relative to full image height in UP direction</param>
        /// <param name="downFactor">image extension factor relative to full image height in DOWN direction</param>
        /// <param name="leftFactor">image extension factor relative to full image width in LEFT direction</param>
        /// <param name="rightFactor">image extension factor relative to full image width in RIGHT direction</param>
        IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0.0f, float downFactor = 0.0f, float leftFactor = 0.0f, float rightFactor = 0.0f);
    }

    /// <summary>
    /// Represents class information from BlinkID Scanning
    /// </summary>
    public interface IClassInfo
    {
        /// <summary>
        /// The document country.
        /// </summary>
        Country Country { get; }

        /// <summary>
        /// The document region.
        /// </summary>
        Region Region { get; }

        /// <summary>
        /// The type of the scanned document.
        /// </summary>
        Type Type { get; }
    }

    /// <summary>
    /// Possible countries from ClassInfo
    /// </summary>
    public enum Country
    {
        None,
        Albania,
        Algeria,
        Argentina,
        Australia,
        Austria,
        Azerbaijan,
        Bahrain,
        Bangladesh,
        Belgium,
        BosniaAndHerzegovina,
        Brunei,
        Bulgaria,
        Cambodia,
        Canada,
        Chile,
        Colombia,
        CostaRica,
        Croatia,
        Cyprus,
        Czechia,
        Denmark,
        DominicanRepublic,
        Egypt,
        Estonia,
        Finland,
        France,
        Georgia,
        Germany,
        Ghana,
        Greece,
        Guatemala,
        HongKong,
        Hungary,
        India,
        Indonesia,
        Ireland,
        Israel,
        Italy,
        Jordan,
        Kazakhstan,
        Kenya,
        Kosovo,
        Kuwait,
        Latvia,
        Lithuania,
        Malaysia,
        Maldives,
        Malta,
        Mauritius,
        Mexico,
        Morocco,
        Netherlands,
        NewZealand,
        Nigeria,
        Pakistan,
        Panama,
        Paraguay,
        Philippines,
        Poland,
        Portugal,
        PuertoRico,
        Qatar,
        Romania,
        Russia,
        SaudiArabia,
        Serbia,
        Singapore,
        Slovakia,
        Slovenia,
        SouthAfrica,
        Spain,
        Sweden,
        Switzerland,
        Taiwan,
        Thailand,
        Tunisia,
        Turkey,
        UAE,
        Uganda,
        UK,
        Ukraine,
        Usa,
        Vietnam,
        Brazil,
        Norway,
        Oman,
        Ecuador,
        ElSalvador,
        SriLanka,
    }

    /// <summary>
    /// Possible regions from ClassInfo
    /// </summary>
    public enum Region
    {
        None,
        Alabama,
        Alaska,
        Alberta,
        Arizona,
        Arkansas,
        AustralianCapitalTerritory,
        BritishColumbia,
        California,
        Colorado,
        Connecticut,
        Delaware,
        DistrictOfColumbia,
        Florida,
        Georgia,
        Hawaii,
        Idaho,
        Illinois,
        Indiana,
        Iowa,
        Kansas,
        Kentucky,
        Louisiana,
        Maine,
        Manitoba,
        Maryland,
        Massachusetts,
        Michigan,
        Minnesota,
        Mississippi,
        Missouri,
        Montana,
        Nebraska,
        Nevada,
        NewBrunswick,
        NewHampshire,
        NewJersey,
        NewMexico,
        NewSouthWales,
        NewYork,
        NorthernTerritory,
        NorthCarolina,
        NorthDakota,
        NovaScotia,
        Ohio,
        Oklahoma,
        Ontario,
        Oregon,
        Pennsylvania,
        Quebec,
        Queensland,
        RhodeIsland,
        Saskatchewan,
        SouthAustralia,
        SouthCarolina,
        SouthDakota,
        Tasmania,
        Tennessee,
        Texas,
        Utah,
        Vermont,
        Victoria,
        Virginia,
        Washington,
        WesternAustralia,
        WestVirginia,
        Wisconsin,
        Wyoming,
        Yukon,
    }

    /// <summary>
    /// Possible types from ClassInfo
    /// </summary>
    public enum Type
    {
        None,
        ConsularId,
        Dl,
        DlPublicServicesCard,
        FinCard,
        EmploymentPass,
        GreenCard,
        Id,
        MultipurposeId,
        MyKad,
        MyKid,
        MyTentera,
        PanCard,
        ProfessionalId,
        PublicServicesCard,
        ResidencePermit,
        ResidentId,
        TemporaryResidencePermit,
        VoterId,
        WorkPermit,
        iKad,
        MilitaryId,
        MyKas,
        SocialSecurityCard,
        HealthInsuranceCard,
    }

    /// <summary>
    /// Defines possible color and moire statuses determined from scanned image.
    /// </summary>
    public interface IImageAnalysisResult
    {
        /// <summary>
        /// Whether the image is blurred.
        /// </summary>
        bool Blurred { get; }

        /// <summary>
        /// The color status determined from scanned image.
        /// </summary>
        DocumentImageColorStatus DocumentImageColorStatus { get; }

        /// <summary>
        /// The Moire pattern detection status determined from the scanned image.
        /// </summary>
        ImageAnalysisDetectionStatus DocumentImageMoireStatus { get; }

        /// <summary>
        /// Face detection status determined from the scanned image.
        /// </summary>
        ImageAnalysisDetectionStatus FaceDetectionStatus { get; }

        /// <summary>
        /// Mrz detection status determined from the scanned image.
        /// </summary>
        ImageAnalysisDetectionStatus MrzDetectionStatus { get; }

        /// <summary>
        /// Barcode detection status determined from the scanned image.
        /// </summary>
        ImageAnalysisDetectionStatus BarcodeDetectionStatus { get; }
    }

    /// <summary>
    /// DocumentImageColorStatus enum defines possible color statuses determined from scanned image.
    /// </summary>
    public enum DocumentImageColorStatus
    {
        // Determining image color status was not performed
        NotAvailable,

        // Black-and-white image scanned
        BlackAndWhite,

        // Color image scanned
        Color,
    }

    /// <summary>
    /// Defines possible states of detection.
    /// </summary>
    public enum ImageAnalysisDetectionStatus
    {
        // Detection was not performed.
        NotAvailable,

        // Not detected on input image.
        NotDetected,

        // Detected on input image.
        Detected
    }

    /// <summary>
    /// AnonymizationMode is used to define level of anonymization performed on recognizer result.
    /// </summary>
    public enum AnonymizationMode
    {
        // Anonymization will not be performed.
        None,

        // ImageOnly is anonymized with black boxes covering sensitive data.
        ImageOnly,

        // Result fields containing sensitive data are removed from result.
        ResultFieldsOnly,

        // This mode is combination of ImageOnly and ResultFieldsOnly modes.
        FullResult
    }

    /// <summary>
    /// Defines the data extracted from the barcode.
    /// </summary>
    public interface IBarcodeResult
    {
        /// <summary>
        /// Type of the barcode scanned
        /// 
        ///  @return Type of the barcode 
        /// </summary>
        BarcodeType BarcodeType { get; }
        
        /// <summary>
        /// Byte array with result of the scan 
        /// </summary>
        byte[] RawData { get; }
        
        /// <summary>
        /// Retrieves string content of scanned data 
        /// </summary>
        string StringData { get; }
        
        /// <summary>
        /// Flag indicating uncertain scanning data
        /// E.g obtained from damaged barcode. 
        /// </summary>
        bool Uncertain { get; }
        
        /// <summary>
        /// Gets the first name of the document owner.
        /// </summary>
        /// <value>The first name of the document owner.</value>
        string FirstName { get; }

        /// <summary>
        /// Gets the last name of the document owner.
        /// </summary>
        /// <value>The last name of the document owner.</value>
        string LastName { get; }

        /// <summary>
        /// Gets the full name of the document owner.
        /// </summary>
        /// <value>The full name.</value>
        string FullName { get; }

        /// <summary>
        /// Gets the additional name information of the document owner.
        /// </summary>
        /// <value>The additional name information of the document owner..</value>
        string AdditionalNameInformation { get; }

        /// <summary>
        /// Gets the address of the document owner.
        /// </summary>
        /// <value>The document code.</value>
        string Address { get; }

        /// <summary>
        /// Gets the place of birth of the document owner.
        /// </summary>
        /// <value>The place of birth of the document owner.</value>
        string PlaceOfBirth { get; }

        /// <summary>
        /// Gets the nationality of the documet owner.
        /// </summary>
        /// <value>The nationality of the documet owner.</value>
        string Nationality { get; }

        /// <summary>
        /// Gets the race of the document owner.
        /// </summary>
        /// <value>The race of the document owner.</value>
        string Race { get; }

        /// <summary>
        /// Gets the religion of the document owner.
        /// </summary>
        /// <value>The religion of the document owner.</value>
        string Religion { get; }

        /// <summary>
        /// Gets the profession of the document owner.
        /// </summary>
        /// <value>The profession of the document owner.</value>
        string Profession { get; }

        /// <summary>
        /// Gets the marital status of the document owner.
        /// </summary>
        /// <value>The marital status of the document owner.</value>
        string MaritalStatus { get; }

        /// <summary>
        /// Gets the residential stauts of the document owner.
        /// </summary>
        /// <value>The residential stauts of the document owner.</value>
        string ResidentialStatus { get; }

        /// <summary>
        /// Gets the employer of the document owner.
        /// </summary>
        /// <value>The employer of the document owner.</value>
        string Employer { get; }

        /// <summary>
        /// Gets the sex of the document owner.
        /// </summary>
        /// <value>The sex of the document owner.</value>
        string Sex { get; }

        /// <summary>
        /// The date of birth of the document owner.
        /// </summary>
        /// <value>The date of birth of the document owner.</value>
        IDate DateOfBirth { get; }

        /// <summary>
        /// The date of issue of the document.
        /// </summary>
        /// <value>The date of issue of the document.</value>
        IDate DateOfIssue { get; }

        /// <summary>
        /// The date of expiry of the document.
        /// </summary>
        /// <value>The date of expiry of the document.</value>
        IDate DateOfExpiry { get; }

        /// <summary>
        /// The document number.
        /// </summary>
        /// <value>The document number.</value>
        string DocumentNumber { get; }

        /// <summary>
        /// The personal identification number.
        /// </summary>
        /// <value>The personal identification number.</value>
        string PersonalIdNumber { get; }

        /// <summary>
        /// The additional number of the document.
        /// </summary>
        /// <value>The additional number of the document.</value>
        string DocumentAdditionalNumber { get; }

        /// <summary>
        /// The issuing authority of the document.
        /// </summary>The issuing authority of the document.</value>
        string IssuingAuthority { get ; }

        /// <summary>
        /// The street address portion of the document owner.
        /// </summary>The street address portion of the document owner.</value>
        string Street { get ; }

        /// <summary>
        /// The postal code address portion of the document owner.
        /// </summary>The postal code address portion of the document owner.</value>
        string PostalCode { get ; }

        /// <summary>
        /// The city address portion of the document owner.
        /// </summary>The city address portion of the document owner.</value>
        string City { get ; }

        /// <summary>
        /// The jurisdiction code address portion of the document owner.
        /// </summary>The jurisdiction code address portion of the document owner.</value>
        string Jurisdiction { get ; }

        /// <summary>
        /// The driver license detailed info.
        /// </summary>The driver license detailed info.</value>
        IDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get ; }

        /// <summary>
        /// Flag that indicates if barcode result is empty
        /// </summary>Flag that indicates if barcode result is empty</value>
        bool Empty { get ; }
    }

    /// <summary>
    /// Defines the data extracted from the visual inspection zone
    /// </summary>
    public interface IVizResult
    {
        /// <summary>
        /// Gets the first name of the document owner.
        /// </summary>
        /// <value>The first name of the document owner.</value>
        string FirstName { get; }

        /// <summary>
        /// Gets the last name of the document owner.
        /// </summary>
        /// <value>The last name of the document owner.</value>
        string LastName { get; }

        /// <summary>
        /// Gets the full name of the document owner.
        /// </summary>
        /// <value>The full name.</value>
        string FullName { get; }

        /// <summary>
        /// Gets the additional name information of the document owner.
        /// </summary>
        /// <value>The additional name information of the document owner..</value>
        string AdditionalNameInformation { get; }

        /// <summary>
        /// Gets the localized name of the document owner.
        /// </summary>
        /// <value>The localized name of the document owner.</value>
        string LocalizedName { get; }

        /// <summary>
        /// Gets the address of the document owner.
        /// </summary>
        /// <value>The document code.</value>
        string Address { get; }

        /// <summary>
        /// Gets the additional address information of the document owner.
        /// </summary>
        /// <value>The additional address information of the document owner.</value>
        string AdditionalAddressInformation { get; }

        /// <summary>
        /// Gets the place of birth of the document owner.
        /// </summary>
        /// <value>The place of birth of the document owner.</value>
        string PlaceOfBirth { get; }

        /// <summary>
        /// Gets the nationality of the documet owner.
        /// </summary>
        /// <value>The nationality of the documet owner.</value>
        string Nationality { get; }

        /// <summary>
        /// Gets the race of the document owner.
        /// </summary>
        /// <value>The race of the document owner.</value>
        string Race { get; }

        /// <summary>
        /// Gets the religion of the document owner.
        /// </summary>
        /// <value>The religion of the document owner.</value>
        string Religion { get; }

        /// <summary>
        /// Gets the profession of the document owner.
        /// </summary>
        /// <value>The profession of the document owner.</value>
        string Profession { get; }

        /// <summary>
        /// Gets the marital status of the document owner.
        /// </summary>
        /// <value>The marital status of the document owner.</value>
        string MaritalStatus { get; }

        /// <summary>
        /// Gets the residential stauts of the document owner.
        /// </summary>
        /// <value>The residential stauts of the document owner.</value>
        string ResidentialStatus { get; }

        /// <summary>
        /// Gets the employer of the document owner.
        /// </summary>
        /// <value>The employer of the document owner.</value>
        string Employer { get; }

        /// <summary>
        /// Gets the sex of the document owner.
        /// </summary>
        /// <value>The sex of the document owner.</value>
        string Sex { get; }

        /// <summary>
        /// The date of birth of the document owner.
        /// </summary>
        /// <value>The date of birth of the document owner.</value>
        IDate DateOfBirth { get; }

        /// <summary>
        /// The date of issue of the document.
        /// </summary>
        /// <value>The date of issue of the document.</value>
        IDate DateOfIssue { get; }

        /// <summary>
        /// The date of expiry of the document.
        /// </summary>
        /// <value>The date of expiry of the document.</value>
        IDate DateOfExpiry { get; }

        /// <summary>
        /// The document number.
        /// </summary>
        /// <value>The document number.</value>
        string DocumentNumber { get; }

        /// <summary>
        /// The personal identification number.
        /// </summary>
        /// <value>The personal identification number.</value>
        string PersonalIdNumber { get; }

        /// <summary>
        /// The additional number of the document.
        /// </summary>
        /// <value>The additional number of the document.</value>
        string DocumentAdditionalNumber { get; }

        /// <summary>
        /// The additional personal identification number.
        /// </summary>
        /// <value>The additional personal identification number.</value>
        string AdditionalPersonalIdNumber { get; }

        /// <summary>
        /// The issuing authority of the document.
        /// </summary>The issuing authority of the document.</value>
        string IssuingAuthority { get ; }

        /// <summary>
        /// The driver license detailed info.
        /// </summary>The driver license detailed info.</value>
        IDriverLicenseDetailedInfo DriverLicenseDetailedInfo { get ; }

        /// <summary>
        /// Flag that indicates if barcode result is empty
        /// </summary>Flag that indicates if barcode result is empty</value>
        bool Empty { get ; }
    }

    /// <summary>
    /// ProcessingStatus defines status of the last recognition process.
    /// </summary>
    public enum ProcessingStatus
    {
        // Recognition was successful.
        Success,

        // Detection of the document failed.
        DetectionFailed,

        // Preprocessing of the input image has failed. 
        ImagePreprocessingFailed,

        // Recognizer has inconsistent results. 
        StabilityTestFailed,

        // Wrong side of the document has been scanned. 
        ScanningWrongSide,

        // Identification of the fields present on the document has failed. 
        FieldIdentificationFailed,

        // Mandatory field for the specific document is missing. 
        MandatoryFieldMissing,

        // Result contains invalid characters in some of the fields. 
        InvalidCharactersFound,

        // Failed to return a requested image. 
        ImageReturnFailed,

        // Reading or parsing of the barcode has failed. 
        BarcodeRecognitionFailed,

        // Parsing of the MRZ has failed. 
        MrzParsingFailed,

        // Document class has been filtered out. 
        ClassFiltered,

        // Document currently not supported by the recognizer. 
        UnsupportedClass,

        // License for the detected document is missing. 
        UnsupportedByLicense
    }

    /// <summary>
    /// RecognitionMode defines possible recognition modes by BlinkID(Combined)Recognizer.
    /// </summary>
    public enum RecognitionMode
    {
        // No recognition performed. 
        None,

        // Recognition of mrz document (does not include visa and passport) 
        MrzId,

        // Recognition of visa mrz. 
        MrzVisa,

        // Recognition of passport mrz. 
        MrzPassport,

        // Recognition of documents that have face photo on the front. 
        PhotoId,

        // Detailed document recognition. 
        FullRecognition
    }

    /// <summary>
    /// IRecognitionModeFilter is used to enable/disable recognition of specific document groups.
    /// Setting is taken into account only if the right for that document is purchased.
    /// </summary>
    public interface IRecognitionModeFilter
    {
        /// <summary>
        /// Enable scanning of MRZ IDs. Setting is taken into account only if the mrz_id right is purchased.
        /// </summary>
        /// <value>Enable Mrz.</value>
        bool EnableMrzId { get; }

        /// <summary>
        /// Enable scanning of visa MRZ. Setting is taken into account only if the visa right is purchased.
        /// </summary>
        /// <value>Enable Mrz Visa.</value>
        bool EnableMrzVisa { get; }

        /// <summary>
        /// Enable scanning of Passport MRZ. Setting is taken into account only if the passport right is purchased.
        /// </summary>
        /// <value>Enable Mrz Passport.</value>
        bool EnableMrzPassport { get; }

        /// <summary>
        /// Enable scanning of Photo ID. Setting is taken into account only if the photo_id right is purchased.
        /// </summary>
        /// <value>Enable Photo ID.</value>
        bool EnablePhotoId { get; }

        /// <summary>
        /// Enable full document recognition. Setting is taken into account only if the document right to scan that document is purchased.
        /// </summary>
        /// <value>Enable Full Document Recognition.</value>
        bool EnableFullDocumentRecognition { get; }
    }

    /// <summary>
    /// Recognition mode filter factory. Use this to create an instance of IRecognitionModeFilter.
    /// </summary>
    public interface IRecognitionModeFilterFactory
    {
        /// <summary>
        /// Creates the recognition mode filter,
        /// </summary>
        /// <returns>The recognition mode filters.</returns>
        /// <param name="enableMrzId">enable scanning of MRZ IDs. Setting is taken into account only if the mrz_id right is purchased.</param>
        /// <param name="enableMrzVisa">enable scanning of visa MRZ. Setting is taken into account only if the visa right is purchased.</param>
        /// <param name="enableMrzPassport">enable scanning of Passport MRZ. Setting is taken into account only if the passport right is purchased.</param>
        /// <param name="enablePhotoId">enable scanning of Photo ID. Setting is taken into account only if the photo_id right is purchased.</param>
        /// <param name="enableFullDocumentRecognition">enable full document recognition. Setting is taken into account only if the document right to scan that document is purchased.</param>
        IRecognitionModeFilter CreateRecognitionModeFilter(bool enableMrzId = true, bool enableMrzVisa = true, bool enableMrzPassport = true, bool enablePhotoId = true, bool enableFullDocumentRecognition = true);
    }

}
