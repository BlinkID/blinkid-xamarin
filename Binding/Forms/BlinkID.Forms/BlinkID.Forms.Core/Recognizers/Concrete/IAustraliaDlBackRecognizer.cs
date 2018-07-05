namespace Microblink.Forms.Core.Recognizers
{
    public interface IAustraliaDlBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// true if address of Australian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// true if date of expiry of Australian DL is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// true if last name of Australian DL owner is being extracted 
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
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IAustraliaDlBackRecognizerResult Result { get; }
    }

    public interface IAustraliaDlBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// address of the Australian DL owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// the date of expiry of Australian DL. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// last name of the Australian DL owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// the licence number of Australian DL. 
        /// </summary>
        string LicenceNumber { get; }
        
    }
}