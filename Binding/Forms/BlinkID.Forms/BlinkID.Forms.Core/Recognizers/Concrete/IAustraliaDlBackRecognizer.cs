namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan back side of austrian driver's license.
    /// 
    /// </summary>
    public interface IAustraliaDlBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// True if address of Australian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// True if date of expiry of Australian DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// True if last name of Australian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
        /// <summary>
        /// Defines the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IAustraliaDlBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IAustraliaDlBackRecognizer.
    /// </summary>
    public interface IAustraliaDlBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Address of the Australian DL owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The date of expiry of Australian DL. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// Last name of the Australian DL owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The licence number of Australian DL. 
        /// </summary>
        string LicenceNumber { get; }
        
    }
}