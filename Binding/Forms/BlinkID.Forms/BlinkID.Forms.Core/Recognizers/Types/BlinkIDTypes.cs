using System;
namespace BlinkID.Forms.Core.Recognizers
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

        /// <summary>
        /// Flag that indicates if class info is empty
        /// </summary>
        bool Empty { get; }

        /// <summary>
        /// The name of the country that issued the scanned document.
        /// </summary>
        string CountryName { get; }

        /// <summary>
        /// The ISO numeric code of the country that issued the scanned document.
        /// </summary>
        string IsoNumericCountryCode { get; }

        /// <summary>
        /// The 2 letter ISO code of the country that issued the scanned document.
        /// </summary>
        string IsoAlpha2CountryCode { get; }

         /// <summary>
        /// The 3 letter ISO code of the country that issued the scanned document.
        /// </summary>
        string IsoAlpha3CountryCode { get; }
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
        Peru,
        Uruguay,
        Bahamas,
        Bermuda,
        Bolivia,
        China,
        EuropeanUnion,
        Haiti,
        Honduras,
        Iceland,
        Japan,
        Luxembourg,
        Montenegro,
        Nicaragua,
        SouthKorea,
        Venezuela,
        Afghanistan,
        AlandIslands,
        AmericanSamoa,
        Andorra,
        Angola,
        Anguilla,
        Antarctica,
        AntiguaAndBarbuda,
        Armenia,
        Aruba,
        BailiwickOfGuernsey,
        BailiwickOfJersey,
        Barbados,
        Belarus,
        Belize,
        Benin,
        Bhutan,
        BonaireSaintEustatiusAndSaba,
        Botswana,
        BouvetIsland,
        BritishIndianOceanTerritory,
        BurkinaFaso,
        Burundi,
        Cameroon,
        CapeVerde,
        CaribbeanNetherlands,
        CaymanIslands,
        CentralAfricanRepublic,
        Chad,
        ChristmasIsland,
        CocosIslands,
        Comoros,
        Congo,
        CookIslands,
        Cuba,
        Curacao,
        DemocraticRepublicOfTheCongo,
        Djibouti,
        Dominica,
        EastTimor,
        EquatorialGuinea,
        Eritrea,
        Ethiopia,
        FalklandIslands,
        FaroeIslands,
        FederatedStatesOfMicronesia,
        Fiji,
        FrenchGuiana,
        FrenchPolynesia,
        FrenchSouthernTerritories,
        Gabon,
        Gambia,
        Gibraltar,
        Greenland,
        Grenada,
        Guadeloupe,
        Guam,
        Guinea,
        GuineaBissau,
        Guyana,
        HeardIslandAndMcdonaldIslands,
        Iran,
        Iraq,
        IsleOfMan,
        IvoryCoast,
        Jamaica,
        Kiribati,
        Kyrgyzstan,
        Laos,
        Lebanon,
        Lesotho,
        Liberia,
        Libya,
        Liechtenstein,
        Macau,
        Madagascar,
        Malawi,
        Mali,
        MarshallIslands,
        Martinique,
        Mauritania,
        Mayotte,
        Moldova,
        Monaco,
        Mongolia,
        Montserrat,
        Mozambique,
        Myanmar,
        Namibia,
        Nauru,
        Nepal,
        NewCaledonia,
        Niger,
        Niue,
        NorfolkIsland,
        NorthernCyprus,
        NorthernMarianaIslands,
        NorthKorea,
        NorthMacedonia,
        Palau,
        Palestine,
        PapuaNewGuinea,
        Pitcairn,
        Reunion,
        Rwanda,
        SaintBarthelemy,
        SaintHelenaAscensionAndTristianDaCunha,
        SaintKittsAndNevis,
        SaintLucia,
        SaintMartin,
        SaintPierreAndMiquelon,
        SaintVincentAndTheGrenadines,
        Samoa,
        SanMarino,
        SaoTomeAndPrincipe,
        Senegal,
        Seychelles,
        SierraLeone,
        SintMaarten,
        SolomonIslands,
        Somalia,
        SouthGeorgiaAndTheSouthSandwichIslands,
        SouthSudan,
        Sudan,
        Suriname,
        SvalbardAndJanMayen,
        Swaziland,
        Syria,
        Tajikistan,
        Tanzania,
        Togo,
        Tokelau,
        Tonga,
        TrinidadAndTobago,
        Turkmenistan,
        TurksAndCaicosIslands,
        Tuvalu,
        UnitedStatesMinorOutlyingIslands,
        Uzbekistan,
        Vanuatu,
        VaticanCity,
        VirginIslandsBritish,
        VirginIslandsUs,
        WallisAndFutuna,
        WesternSahara,
        Yemen,
        Yugoslavia,
        Zambia,
        Zimbabwe
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
        CiudadDeMexico,
        Jalisco,
        NewfoundlandAndLabrador,
        NuevoLeon,
        BajaCalifornia,
        Chihuahua,
        Guanajuato,
        Guerrero,
        Mexico,
        Michoacan,
        NewYorkCity,
        Tamaulipas,
        Veracruz,
        Chiapas,
        Coahuila,
        Durango,
        GuerreroCocula,
        GuerreroJuchitan,
        GuerreroTepecoacuilco,
        GuerreroTlacoapa,
        Gujarat,
        Hidalgo,
        Karnataka,
        Kerala,
        KhyberPakhtunkhwa,
        MadhyaPradesh,
        Maharashtra,
        Morelos,
        Nayarit,
        Oaxaca,
        Puebla,
        Punjab,
        Queretaro,
        SanLuisPotosi,
        Sinaloa,
        Sonora,
        Tabasco,
        TamilNadu,
        Yucatan,
        Zacatecas,
        Aguascalientes,
        BajaCaliforniaSur,
        Campeche,
        Colima,
        QuintanaRooBenitoJuarez
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
        EmploymentPass,
        FinCard,
        Id,
        MultipurposeId,
        MyKad,
        MyKid,
        MyPr,
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
        Passport,
        SPass,
        AddressCard,
        AlienId,
        AlienPassport,
        GreenCard,
        MinorsId,
        PostalId,
        ProfessionalDl,
        TaxId,
        WeaponPermit,
        Visa,
        BorderCrossingCard,
        DriverCard,
        GlobalEntryCard,
        Mypolis,
        NexusCard,
        PassportCard,
        ProofOfAgeCard,
        RefugeeId,
        TribalId,
        VeteranId,
        CitizenshipCertificate
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
        /// Gets the middle name of the document owner.
        /// </summary>
        /// <value>The middle name of the document owner.</value>
        string MiddleName { get; }

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

        /// <summary>
        /// Document specific extended elements that contain all barcode fields in their original form.
        ///
        /// Currently this is only filled for AAMVACompliant documents.
        /// </summary>Document specific extended elements that contain all barcode fields in their original form.</value>
        IBarcodeElements ExtendedElements { get ; }
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

        /// <summary>
        /// The one more additional number of the document.
        /// </summary>The one more additional number of the document.</value>
        string DocumentOptionalAdditionalNumber { get; }
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
        UnsupportedByLicense,

        // Front side recognition has completed successfully, and recognizer is waiting for the other side to be scanned.
        AwaitingOtherSide,

        // Side not scanned.
        NotScanned
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
        FullRecognition,

        // Recognition of barcode document.
        BarcodeId
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
        /// Enable scanning of barcode IDs. Setting is taken into account only if the barcode right to scan that barcode is purchased.
        /// </summary>
        /// <value>Enable Barcode ID.</value>
        bool EnableBarcodeId { get; }

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
        /// <param name="enableBarcodeId">enable scanning of barcode IDs. Setting is taken into account only if the barcode right to scan that barcode is purchased.</param>
        /// <param name="enableFullDocumentRecognition">enable full document recognition. Setting is taken into account only if the document right to scan that document is purchased.</param>
        IRecognitionModeFilter CreateRecognitionModeFilter(bool enableMrzId = true, bool enableMrzVisa = true, bool enableMrzPassport = true, bool enablePhotoId = true, bool enableBarcodeId = true, bool enableFullDocumentRecognition = true);
    }

    public enum BarcodeElementKey
    {
        //==============================================================/
        //============== 1. DETERMINING BARCODE VERSION ================/
        //==============================================================/

        /**
        Mandatory on all driver's licenses. All barcodes which are using 3-track magnetic
        stripe encoding used in the interest of smoothing a transition from legacy documents
        shall be designated as "Magnetic". All barcodes which are using compact encoding
        compliant with ISO/IEC 18013-2 shall be designated as "Compact". All barcodes (majority
        compliant with Mandatory PDF417 Bar Code of the American Association of Motor Vehicle
        Administrators (AAMVA Card Design Standard from AAMVA DL/ID-2000 standard to DL/ID-2013
        shall be designated as "AAMVA".
        */
        DocumentType,

        /**
        Mandatory on all driver's licenses.

        AAMVA Version Number: This is a decimal value between 0 and 99 that
        specifies the version level of the PDF417 bar code format. Version "0" and "00"
        is reserved for bar codes printed to the specification of the American Association
        of Motor Vehicle Administrators (AAMVA prior to the adoption of the AAMVA DL/ID-2000
        standard.

        - All barcodes compliant with AAMVA DL/ID-2000 standard shall be designated Version "01."
        - All barcodes compliant with AAMVA Card Design Specification version 1.0, dated 09-2003
        shall be designated Version "02."
        - All barcodes compliant with AAMVA Card Design Specification version 2.0, dated 03-2005
        shall be designated Version "03."
        - All barcodes compliant with AAMVA Card Design Standard version 1.0, dated 07-2009
        shall be designated Version "04."
        - All barcodes compliant with AAMVA Card Design Standard version 1.0, dated 07-2010
        shall be designated Version "05."
        - All barcodes compliant with AAMVA Card Design Standard version 1.0, dated 07-2011
        shall be designated Version "06".
        - All barcodes compliant with AAMVA Card Design Standard version 1.0, dated 06-2012
        shall be designated Version "07".
        - All barcodes compliant with this current AAMVA standard shall be designated "08".

        Should a need arise requiring major revision to the format, this field provides the
        means to accommodate additional revision.

        If the document type is not "AAMVA", this field defines the version number of the
        given document type's standard.
        */
        StandardVersionNumber,

        //==============================================================/
        //==========          2. PERSONAL DATA KEYS          ===========/
        //==============================================================/

        /**
        Mandatory on all AAMVA, Magnetic and Compact barcodes.

        Family name of the cardholder. (Family name is sometimes also called "last name" or "surname."
        Collect full name for record, print as many characters as possible on portrait side of DL/ID.
        */
        CustomerFamilyName,

        /**
        Mandatory on all AAMVA, Magnetic and Compact barcodes.

        First name of the cardholder.
        */
        CustomerFirstName,

        /**
        Mandatory on all AAMVA, Magnetic and Compact barcodes.

        Full name of the individual holding the Driver's License or ID.

        The Name field contains up to four portions, separated with the "," delimiter:
        Last Name (required
        , (required
        First Name (required
        , (required if other name portions follow, otherwise optional
        Middle Name(s (optional
        , (required if other name portions follow, otherwise optional
        Suffix (optional
        , (optional

        If the individual has more than one middle name they are separated with space.
        */
        CustomerFullName,

        /**
        Mandatory on all AAMVA, Magnetic and Compact barcodes.

        Date on which the cardholder was born. (MMDDCCYY format
        */
        DateOfBirth,

        /**
        Mandatory on all AAMVA, Magnetic barcodes.
        Optional on Compact barcodes.

        Gender of the cardholder. 1 = male, 2 = female.
        */
        Sex,

        /**
        Mandatory on AAMVA 02, 03, 04, 05, 06, 07, 08 barcodes.
        Optional on AAMVA 01, Magnetic and Compact barcodes.

        Color of cardholder's eyes. (ANSI D-20 codes

        Code   Description
        BLK    Black
        BLU    Blue
        BRO    Brown
        GRY    Gray
        GRN    Green
        HAZ    Hazel
        MAR    Maroon
        PNK    Pink
        DIC    Dichromatic
        UNK    Unknown
        */
        EyeColor,

        /**
        Mandatory on all AAMVA and Magnetic barcodes.

        On compact barcodes, use kFullAddress.

        Street portion of the cardholder address.
        The place where the registered driver of a vehicle (individual or corporation
        may be contacted such as a house number, street address, etc.
        */
        AddressStreet,

        /**
        Mandatory on all AAMVA and Magnetic barcodes.

        On compact barcodes, use kFullAddress.

        City portion of the cardholder address.
        */
        AddressCity,

        /**
        Mandatory on all AAMVA and Magnetic barcodes.

        On compact barcodes, use kFullAddress.

        State portion of the cardholder address.
        */
        AddressJurisdictionCode,

        /**
        Mandatory on all AAMVA and Magnetic barcodes.

        On compact barcodes, use kFullAddress.

        Postal code portion of the cardholder address in the U.S. and Canada. If the
        trailing portion of the postal code in the U.S. is not known, zeros can be used
        to fill the trailing set of numbers up to nine (9 digits.
        */
        AddressPostalCode,

        /**
        Mandatory on all AAMVA and Magnetic barcodes.
        Optional on Compact barcodes.

        Full address of the individual holding the Driver's License or ID.

        The full address field contains up to four portions, separated with the "," delimiter:
        Street Address (required
        , (required if other address portions follow, otherwise optional
        City (optional
        , (required if other address portions follow, otherwise optional
        Jurisdiction Code (optional
        , (required if other address portions follow, otherwise optional
        ZIP - Postal Code (optional

        */
        FullAddress,

        /**
        Mandatory on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.
        Optional on AAMVA 01 and Magnetic barcodes.

        Height of cardholder, either in Inches or in Centimeters.

        Inches (in: number of inches followed by " in"
        example: 6'1'' = "73 in"

        Centimeters (cm: number of centimeters followed by " cm"
        example: 181 centimeters = "181 cm"
        */
        Height,

        /**
        Mandatory on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.
        Optional on AAMVA 01 and Magnetic barcodes.

        Height of cardholder in Inches.
        Example: 5'9'' = "69".
        */
        HeightIn,

        /**
        Mandatory on AAMVA 02, 03, 04, 05, 06, 07, 08 Compact barcodes.
        Optional on AAMVA 01 and Magnetic barcodes.

        Height of cardholder in Centimeters.
        Example: 180 Centimeters = "180".
        */
        HeightCm,

        /**
        Mandatory on AAMVA 04, 05, 06, 07, 08 barcodes.
        Optional on AAMVA 01, 02, 03, Magnetic and Compcat barcodes.

        Middle name(s of the cardholder. In the case of multiple middle names they
        shall be separated by space " ".
        */
        CustomerMiddleName,

        /**
        Optional on all AAMVA, Magnetic and Compact barcodes.

        Bald, black, blonde, brown, gray, red/auburn, sandy, white, unknown. If the issuing
        jurisdiction wishes to abbreviate colors, the three-character codes provided in ANSI D20 must be
        used.

        Code   Description
        BAL    Bald
        BLK    Black
        BLN    Blond
        BRO    Brown
        GRY    Grey
        RED    Red/Auburn
        SDY    Sandy
        WHI    White
        UNK    Unknown
        */
        HairColor,

        /**
        Mandatory on AAMVA 02 barcodes.
        Optional on AAMVA 01, 03, 04, 05, 06, 07, 08, Magnetic and Compact barcodes.

        Name Suffix (If jurisdiction participates in systems requiring name suffix (PDPS, CDLIS, etc.,
        the suffix must be collected and displayed on the DL/ID and in the MRT.
        - JR (Junior
        - SR (Senior
        - 1ST or I (First
        - 2ND or II (Second
        - 3RD or III (Third
        - 4TH or IV (Fourth
        - 5TH or V (Fifth
        - 6TH or VI (Sixth
        - 7TH or VII (Seventh
        - 8TH or VIII (Eighth
        - 9TH or IX (Ninth
        */
        NameSuffix,

        /**
        Optional on all AAMVA and Compact barcodes.

        Other name by which the cardholder is known. ALTERNATIVE NAME(S of the individual
        holding the Driver License or ID.

        The Name field contains up to four portions, separated with the "," delimiter:
        AKA Last Name (required
        , (required
        AKA First Name (required
        , (required if other name portions follow, otherwise optional
        AKA Middle Name(s (optional
        , (required if other name portions follow, otherwise optional
        AKA Suffix (optional
        , (optional

        If the individual has more than one AKA middle name they are separated with space.
        */
        AKAFullName,

        /**
        Optional on all AAMVA and Compact barcodes.

        Other family name by which the cardholder is known.
        */
        AKAFamilyName,

        /**
        Optional on all AAMVA and Compact barcodes.

        Other given name by which the cardholder is known
        */
        AKAGivenName,

        /**
        Optional on all AAMVA and Compact barcodes.

        Other suffix by which the cardholder is known.

        The Suffix Code Portion, if submitted, can contain only the Suffix Codes shown in the following table (e.g., Andrew Johnson, III = JOHNSON@ANDREW@@3RD:

        Suffix     Meaning or Synonym
        JR         Junior
        SR         Senior or Esquire 1ST First
        2ND        Second
        3RD        Third
        4TH        Fourth
        5TH        Fifth
        6TH        Sixth
        7TH        Seventh
        8TH        Eighth
        9TH        Ninth
        */
        AKASuffixName,

        /**
        Mandatory on AAMVA 02 barcodes.
        Optional on AAMVA 01, 03, 04, 05, 06, 07, 08, Magnetic and Compact barcodes.

        Indicates the approximate weight range of the cardholder:
        0 = up to 31 kg (up to 70 lbs
        1 = 32 – 45 kg (71 – 100 lbs
        2 = 46 - 59 kg (101 – 130 lbs
        3 = 60 - 70 kg (131 – 160 lbs
        4 = 71 - 86 kg (161 – 190 lbs
        5 = 87 - 100 kg (191 – 220 lbs
        6 = 101 - 113 kg (221 – 250 lbs
        7 = 114 - 127 kg (251 – 280 lbs
        8 = 128 – 145 kg (281 – 320 lbs
        9 = 146+ kg (321+ lbs
        */
        WeightRange,

        /**
        Mandatory on AAMVA 02 barcodes.
        Optional on AAMVA 01, 03, 04, 05, 06, 07, 08, Magnetic and Compact barcodes.

        Cardholder weight in pounds Example: 185 lb = "185"
        */
        WeightPounds,

        /**
        Mandatory on AAMVA 02 barcodes.
        Optional on AAMVA 01, 03, 04, 05, 06, 07, 08, Magnetic and Compact barcodes.

        Cardholder weight in kilograms Example: 84 kg = "084"
        */
        WeightKilograms,

        /**
        Mandatory on all AAMVA and Compact barcodes.

        The number assigned or calculated by the issuing authority.
        */
        CustomerIdNumber,

        /**
        Mandatory on AAMVA 04, 05, 06, 07, 08 barcodes.
        Optional on Compact barcodes.

        A code that indicates whether a field has been truncated (T, has not been
        truncated (N, or – unknown whether truncated (U.
        */
        FamilyNameTruncation,

        /**
        Mandatory on AAMVA 04, 05, 06, 07, 08 barcodes.
        Optional on Compact barcodes.

        A code that indicates whether a field has been truncated (T, has not been
        truncated (N, or – unknown whether truncated (U.
        */
        FirstNameTruncation,

        /**
        Mandatory on AAMVA 04, 05, 06, 07, 08 barcodes.

        A code that indicates whether a field has been truncated (T, has not been
        truncated (N, or – unknown whether truncated (U.
        */
        MiddleNameTruncation,

        /**
        Optional on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.

        Country and municipality and/or state/province.
        */
        PlaceOfBirth,

        /**
        Optional on all AAMVA barcodes.

        On Compact barcodes, use kFullAddress.

        Second line of street portion of the cardholder address.
        */
        AddressStreet2,

        /**
        Optional on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.

        Codes for race or ethnicity of the cardholder, as defined in ANSI D20.

        Race:
        Code   Description
        AI     Alaskan or American Indian (Having Origins in Any of The Original Peoples of
                North America, and Maintaining Cultural Identification Through Tribal
                Affiliation of Community Recognition
        AP     Asian or Pacific Islander (Having Origins in Any of the Original Peoples of
                the Far East, Southeast Asia, or Pacific Islands. This Includes China, India,
                Japan, Korea, the Philippines Islands, and Samoa
        BK     Black (Having Origins in Any of the Black Racial Groups of Africa
        W      White (Having Origins in Any of The Original Peoples of Europe, North Africa,
                or the Middle East

        Ethnicity:
        Code   Description
        H      Hispanic Origin (A Person of Mexican, Puerto Rican, Cuban, Central or South
                American or Other Spanish Culture or Origin, Regardless of Race
        O      Not of Hispanic Origin (Any Person Other Than Hispanic
        U      Unknown

        */
        RaceEthnicity,

        /**
        Optional on AAMVA 01 barcodes.

        PREFIX to Driver Name. Freeform as defined by issuing jurisdiction.
        */
        NamePrefix,

        /**
        Mandatory on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.

        Country in which DL/ID is issued. U.S. = USA, Canada = CAN.
        */
        CountryIdentification,

        /**
        Optional on AAMVA version 01.

        Driver Residence Street Address 1.
        */
        ResidenceStreetAddress,

        /**
        Optional on AAMVA version 01.

        Driver Residence Street Address 2.
        */
        ResidenceStreetAddress2,

        /**
        Optional on AAMVA version 01.

        Driver Residence City
        */
        ResidenceCity,

        /**
        Optional on AAMVA version 01.

        Driver Residence Jurisdiction Code.
        */
        ResidenceJurisdictionCode,

        /**
        Optional on AAMVA 01 barcodes.

        Driver Residence Postal Code.
        */
        ResidencePostalCode,

        /**
        Optional on AAMVA 01 barcodes.

        Full residence address of the individual holding the Driver's License or ID.

        The full address field contains up to four portions, separated with the "," delimiter:
        Residence Street Address (required
        , (required if other address portions follow, otherwise optional
        Residence City (optional
        , (required if other address portions follow, otherwise optional
        Residence Jurisdiction Code (optional
        , (required if other address portions follow, otherwise optional
        Residence ZIP - Residence Postal Code (optional
        */
        ResidenceFullAddress,

        /**
        Optional on AAMVA 05, 06, 07, 08 barcodes.

        Date on which the cardholder turns 18 years old. (MMDDCCYY format
        */
        Under18,

        /**
        Optional on AAMVA 05, 06, 07, 08 barcodes.

        Date on which the cardholder turns 19 years old. (MMDDCCYY format
        */
        Under19,

        /**
        Optional on AAMVA 05, 06, 07, 08 barcodes.

        Date on which the cardholder turns 21 years old. (MMDDCCYY format
        */
        Under21,

        /**
        Optional on AAMVA version 01.

        The number assigned to the individual by the Social Security Administration.
        */
        SocialSecurityNumber,

        /**
        Optional on AAMVA version 01.

        Driver "AKA" Social Security Number. FORMAT SAME AS DRIVER SOC SEC NUM. ALTERNATIVE NUMBERS(S used as SS NUM.
        */
        AKASocialSecurityNumber,

        /**
        Optional on AAMVA 01 barcodes.

        ALTERNATIVE MIDDLE NAME(s or INITIALS of the individual holding the Driver License or ID.
        Hyphenated names acceptable, spaces between names acceptable, but no other
        use of special symbols.
        */
        AKAMiddleName,

        /**
        Optional on AAMVA 01 barcodes.

        ALTERNATIVE PREFIX to Driver Name. Freeform as defined by issuing jurisdiction.
        */
        AKAPrefixName,

        /**
        Optional on AAMVA 01, 06, 07, 08 barcodes.

        Field that indicates that the cardholder is an organ donor = "1".
        */
        OrganDonor,

        /**
        Optional on AAMVA 07, 08 barcodes.

        Field that indicates that the cardholder is a veteran = "1"
        */
        Veteran,

        /**
        Optional on AAMVA 01. (MMDDCCYY format

        ALTERNATIVE DATES(S given as date of birth.
        */
        AKADateOfBirth,

        //==============================================================/
        //==========          3. LICENSE DATA KEYS          ============/
        //==============================================================/

        /**
        Mandatory on all AAMVA, Magnetic and Compact barcodes.

        This number uniquely identifies the issuing jurisdiction and can
        be obtained by contacting the ISO Issuing Authority (AAMVA
        */
        IssuerIdentificationNumber,

        /**
        Mandatory on all AAMVA, Magnetic and Compact barcodes.

        If the document is non expiring then "Non expiring" is written in this field.

        Date on which the driving and identification privileges granted by the document are
        no longer valid. (MMDDCCYY format
        */
        DocumentExpirationDate,

        /**
        Mandatory on all AAMVA and Compact barcodes.
        Optional on Magnetic barcodes.

        Jurisdiction Version Number: This is a decimal value between 0 and 99 that
        specifies the jurisdiction version level of the PDF417 barcode format.
        Notwithstanding iterations of this standard, jurisdictions implement incremental
        changes to their barcodes, including new jurisdiction-specific data, compression
        algorithms for digitized images, digital signatures, or new truncation
        conventions used for names and addresses. Each change to the barcode format
        within each AAMVA version (above must be noted, beginning with Jurisdiction
        Version 00.
        */
        JurisdictionVersionNumber,

        /**
        Mandatory on all AAMVA and Magnetic barcodes.

        Jurisdiction-specific vehicle class / group code, designating the type
        of vehicle the cardholder has privilege to drive.
        */
        JurisdictionVehicleClass,

        /**
        Mandatory on all AAMVA barcodes.
        Optional on Magnetic barcodes.

        Jurisdiction-specific codes that represent restrictions to driving
        privileges (such as airbrakes, automatic transmission, daylight only, etc..
        */
        JurisdictionRestrictionCodes,

        /**
        Mandatory on all AAMVA barcodes.
        Optional on Magnetic barcodes.

        Jurisdiction-specific codes that represent additional privileges
        granted to the cardholder beyond the vehicle class (such as transportation of
        passengers, hazardous materials, operation of motorcycles, etc..
        */
        JurisdictionEndorsementCodes,

        /**
        Mandatory on all AAMVA and Compact barcodes.

        Date on which the document was issued. (MMDDCCYY format
        */
        DocumentIssueDate,

        /**
        Mandatory on AAMVA versions 02 and 03.

        Federally established codes for vehicle categories, endorsements, and restrictions
        that are generally applicable to commercial motor vehicles. If the vehicle is not a
        commercial vehicle, "NONE" is to be entered.
        */
        FederalCommercialVehicleCodes,

        /**
        Optional on all AAMVA barcodes.
        Mandatory on Compact barcodes.

        Jurisdictions may define a subfile to contain jurisdiction-specific information.
        These subfiles are designated with the first character of “Z” and the second
        character is the first letter of the jurisdiction's name. For example, "ZC" would
        be the designator for a California or Colorado jurisdiction-defined subfile, "ZQ"
        would be the designator for a Quebec jurisdiction-defined subfile. In the case of
        a jurisdiction-defined subfile that has a first letter that could be more than
        one jurisdiction (e.g. California, Colorado, Connecticut then other data, like
        the IIN or address, must be examined to determine the jurisdiction.
        */
        IssuingJurisdiction,

        /**
        Optional on all AAMVA barcodes.
        Mandatory on Compact barcodes.

        Standard vehicle classification code(s for cardholder. This data element is a
        placeholder for future efforts to standardize vehicle classifications.
        */
        StandardVehicleClassification,

        /**
        Optional on all AAMVA and Magnetic barcodes.

        Name of issuing jurisdiction, for example: Alabama, Alaska ...
        */
        IssuingJurisdictionName,

        /**
        Optional on all AAMVA barcodes.

        Standard endorsement code(s for cardholder. See codes in D20. This data element is a
        placeholder for future efforts to standardize endorsement codes.

        Code   Description
        H      Hazardous Material - This endorsement is required for the operation of any vehicle
                transporting hazardous materials requiring placarding, as defined by U.S.
                Department of Transportation regulations.
        L      Motorcycles – Including Mopeds/Motorized Bicycles.
        N      Tank - This endorsement is required for the operation of any vehicle transporting,
                as its primary cargo, any liquid or gaseous material within a tank attached to the vehicle.
        O      Other Jurisdiction Specific Endorsement(s - This code indicates one or more
                additional jurisdiction assigned endorsements.
        P      Passenger - This endorsement is required for the operation of any vehicle used for
                transportation of sixteen or more occupants, including the driver.
        S      School Bus - This endorsement is required for the operation of a school bus. School bus means a
                CMV used to transport pre-primary, primary, or secondary school students from home to school,
                from school to home, or to and from school sponsored events. School bus does not include a
                bus used as common carrier (49 CRF 383.5.
        T      Doubles/Triples - This endorsement is required for the operation of any vehicle that would be
                referred to as a double or triple.
        X      Combined Tank/HAZ-MAT - This endorsement may be issued to any driver who qualifies for
                both the N and H endorsements.
        */
        StandardEndorsementCode,

        /**
        Optional on all AAMVA barcodes.

        Standard restriction code(s for cardholder. See codes in D20. This data element is a placeholder
        for future efforts to standardize restriction codes.

        Code   Description
        B      Corrective Lenses
        C      Mechanical Devices (Special Brakes, Hand Controls, or Other Adaptive Devices
        D      Prosthetic Aid
        E      Automatic Transmission
        F      Outside Mirror
        G      Limit to Daylight Only
        H      Limit to Employment
        I      Limited Other
        J      Other
        K      CDL Intrastate Only
        L      Vehicles without air brakes
        M      Except Class A bus
        N      Except Class A and Class B bus
        O      Except Tractor-Trailer
        V      Medical Variance Documentation Required
        W      Farm Waiver
        */
        StandardRestrictionCode,

        /**
        Optional on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.

        Text that explains the jurisdiction-specific code(s for classifications
        of vehicles cardholder is authorized to drive.
        */
        JurisdictionVehicleClassificationDescription,

        /**
        Optional on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.

        Text that explains the jurisdiction-specific code(s that indicates additional
        driving privileges granted to the cardholder beyond the vehicle class.
        */
        JurisdictionEndorsmentCodeDescription,

        /**
        Optional on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.

        Text describing the jurisdiction-specific restriction code(s that curtail driving privileges.
        */
        JurisdictionRestrictionCodeDescription,

        /**
        Optional on AAMVA 02, 03, 04, 05, 06, 07, 08 barcodes.

        A string of letters and/or numbers that is affixed to the raw materials (card stock,
        laminate, etc. used in producing driver's licenses and ID cards. (DHS recommended field
        */
        InventoryControlNumber,

        /**
        Optional on AAMVA 04, 05, 06, 07, 08 and Compact barcodes.

        DHS required field that indicates date of the most recent version change or
        modification to the visible format of the DL/ID. (MMDDCCYY format
        */
        CardRevisionDate,

        /**
        Mandatory on AAMVA 02, 03, 04, 05, 06, 07, 08 and Magnetic barcodes.
        Optional and Compact barcodes.

        Number must uniquely identify a particular document issued to that customer
        from others that may have been issued in the past. This number may serve multiple
        purposes of document discrimination, audit information number, and/or inventory control.
        */
        DocumentDiscriminator,

        /**
        Optional on AAMVA 04, 05, 06, 07, 08 and Compact barcodes.

        DHS required field that indicates that the cardholder has temporary lawful status = "1".
        */
        LimitedDurationDocument,

        /**
        Optional on AAMVA 02, 03, 04, 05, 06, 07, 08 and Compact barcodes.

        A string of letters and/or numbers that identifies when, where, and by whom a driver's
        license/ID card was made. If audit information is not used on the card or the MRT, it
        must be included in the driver record.
        */
        AuditInformation,

        /**
        Optional on AAMVA 04, 05, 06, 07, 08 and Compact barcodes.

        DHS required field that indicates compliance: "M" = materially compliant,
        "F" = fully compliant, and, "N" = non-compliant.
        */
        ComplianceType,

        /**
        Optional on AAMVA version 01 barcodes.

        Issue Timestamp. A string used by some jurisdictions to validate the document against their data base.
        */
        IssueTimestamp,

        /**
        Optional on AAMVA version 01 barcodes.

        Driver Permit Expiration Date. MMDDCCYY format. Date permit expires.
        */
        PermitExpirationDate,

        /**
        Optional on AAMVA version 01 barcodes..

        Type of permit.
        */
        PermitIdentifier,

        /**
        Optional on AAMVA version 01 barcodes..

        Driver Permit Issue Date. MMDDCCYY format. Date permit was issued.
        */
        PermitIssueDate,

        /**
        Optional on AAMVA version 01.

        Number of duplicate cards issued for a license or ID if any.
        */
        NumberOfDuplicates,

        /**
        Optional on AAMVA 04, 05, 06, 07, 08 and Compact barcodes.

        Date on which the hazardous material endorsement granted by the document is
        no longer valid. (MMDDCCYY format
        */
        HAZMATExpirationDate,

        /**
        Optional on AAMVA version 01.

        Medical Indicator/Codes.
        STATE SPECIFIC. Freeform, Standard "TBD"
        */
        MedicalIndicator,

        /**
        Optional on AAMVA version 01.

        Non-Resident Indicator. "Y". Used by some jurisdictions to indicate holder of the document is a non-resident.
        */
        NonResident,

        /**
        Optional on AAMVA version 01.

        A number or alphanumeric string used by some jurisdictions to identify a "customer" across multiple data bases.
        */
        UniqueCustomerId,

        /**
        Optional on compact barcodes.

        Document discriminator.
        */
        DataDiscriminator,

        /**
        Optional on Magnetic barcodes.

        Month on which the driving and identification privileges granted by the document are
        no longer valid. (MMYY format
        */
        DocumentExpirationMonth,

        /**
        Optional on Magnetic barcodes.

        Field that indicates that the driving and identification privileges granted by the
        document are nonexpiring = "1".
        */
        DocumentNonexpiring,

        /**
        Optional on Magnetic barcodes.

        Security version beeing used.
        */
        SecurityVersion
    }

    /// <summary>
    /// IBarcodeElements is used to find all data from AAMVA-compliant barcodes.
    /// </summary>
    public interface IBarcodeElements
    {
        /// <summary>
        /// Flag that indicates if barcode elements is empty
        /// </summary>
        bool Empty { get; }

        /// <summary>
        /// String value for BarcodeElementKey enum
        /// </summary>
        string GetValue(BarcodeElementKey key);

    }
}