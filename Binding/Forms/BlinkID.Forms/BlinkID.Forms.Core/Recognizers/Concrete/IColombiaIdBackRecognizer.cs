namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Colombian national ID cards.
    /// </summary>
    public interface IColombiaIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Allow scanning PDF417 barcodes which don't have quiet zone 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool NullQuietZoneAllowed { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Enable decoding of non-standard PDF417 barcodes, but without 
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
        /// owner’s date of birth 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        /// owner’s blood group 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// the Colombian ID document number number. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// owner’s encoded fingerprint 
        /// </summary>
        byte[] Fingerprint { get; }
        
        /// <summary>
        /// owner’s first name 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// owner’s last name 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// owner’s sex 
        /// </summary>
        string Sex { get; }
        
    }
}