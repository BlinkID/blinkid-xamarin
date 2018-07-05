namespace Microblink.Forms.Core.Recognizers
{
    public interface IAustraliaDlBackRecognizer : IRecognizer
    {
        
        /// <summary>
        ///  Defines if sex of Australian DL owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Australian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        ///  Defines if last name of Australian DL owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractLastName { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
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
        /// The address of the Australian DL owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The document date of expiry of the Australian DL 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The last name of the Australian DL owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The licence number of the Australian DL owner. 
        /// </summary>
        string LicenceNumber { get; }
        
    }
}