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
    }
}
