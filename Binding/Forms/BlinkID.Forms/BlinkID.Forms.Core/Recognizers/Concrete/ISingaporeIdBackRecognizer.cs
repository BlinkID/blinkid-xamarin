namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer used for scanning the back side of Singapore IDs
    /// </summary>
    public interface ISingaporeIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID owner's address should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID owner's address change date on sticker should be extracted 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractAddressChangeDate { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID owner's blood type should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodType { get; set; }
        
        /// <summary>
        /// Defines if Singapore ID's date of issue should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISingaporeIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeIdBackRecognizer.
    /// </summary>
    public interface ISingaporeIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The Singapore ID owner's address 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The Singapore ID owner's address change date, present if the address is on a sticker 
        /// </summary>
        IDate AddressChangeDate { get; }
        
        /// <summary>
        /// The Singapore ID owner's blood type 
        /// </summary>
        string BloodType { get; }
        
        /// <summary>
        /// The Singapore ID card number 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The Singapore ID's date of issue 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}