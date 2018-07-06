namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Colombia ID Back Recognizer.
    /// 
    /// Colombia ID Back recognizer is used for scanning back side of Colombia ID.
    /// </summary>
    public interface IColombiaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Set this to true to scan barcodes which don't have quiet zone (white area) around it
        /// 
        /// Use only if necessary because it slows down the recognition process
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// Set this to true to scan even barcode not compliant with standards
        /// For example, malformed PDF417 barcodes which were incorrectly encoded
        /// 
        /// Use only if necessary because it slows down the recognition process
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ScanUncertain { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IColombiaIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IColombiaIdBackRecognizer.
    /// </summary>
    public interface IColombiaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The blood group of the Colombian ID owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The date of birth of the Colombian ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The document number of the Colombian ID card. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The fingerprint of the Colombian ID owner. 
        /// </summary>
        byte[] Fingerprint { get; }
        
        /// <summary>
        /// The first name of the Colombian ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// The last name of the Colombian ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The sex of the Colombian ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}