namespace Microblink.Forms.Core.Recognizers
{
    public interface IColombiaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// true if null quiet zone is allowed 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// true if should scan uncertain results 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ScanUncertain { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IColombiaIdBackRecognizerResult Result { get; }
    }

    public interface IColombiaIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// owner blood type 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// owner date of birth 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the Colombian ID document number number. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// owner fingerprint 
        /// </summary>
        byte[] Fingerprint { get; }
        
        /// <summary>
        /// owner first name 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// owner first name 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// owner sex 
        /// </summary>
        string Sex { get; }
        
    }
}