namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for the back side of Jordan ID.
    /// 
    /// </summary>
    public interface IJordanIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IJordanIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IJordanIdBackRecognizer.
    /// </summary>
    public interface IJordanIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Defines holder's date of birth if it is successfully converted to result from MRZ date format: <code>YYMMDD</code>. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Defines date of expiry if it is successfully converted to result from MRZ date format: <code>YYMMDD</code>. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Defines document code. Document code contains two characters. For MRTD the first character shall 
        /// </summary>
        string DocumentCode { get; }
        
        /// <summary>
        /// Defines document number. Document number contains up to 9 characters. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Defines three-letter or two-letter code which indicate the issuing State. Three-letter codes are based 
        /// </summary>
        string Issuer { get; }
        
        /// <summary>
        /// Defines true if Machine Readable Zone has been parsed, false otherwise. 
        /// </summary>
        bool MrzParsed { get; }
        
        /// <summary>
        /// Defines the entire Machine Readable Zone text from ID. This text is usually used for parsing 
        /// </summary>
        string MrzText { get; }
        
        /// <summary>
        /// Defines true if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// Defines nationality of the holder represented by a three-letter or two-letter code. Three-letter 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// Defines first optional data.<code>null</code> or empty string if not available. 
        /// </summary>
        string Opt1 { get; }
        
        /// <summary>
        /// Defines second optional data.<code>null</code> or empty string if not available. 
        /// </summary>
        string Opt2 { get; }
        
        /// <summary>
        /// Defines the primary indentifier. If there is more than one component, they are separated with space. 
        /// </summary>
        string PrimaryId { get; }
        
        /// <summary>
        /// Defines the secondary identifier. If there is more than one component, they are separated with space. 
        /// </summary>
        string SecondaryId { get; }
        
        /// <summary>
        /// Defines sex of the card holder. Sex is specified by use of the single initial, 
        /// </summary>
        string Sex { get; }
        
    }
}