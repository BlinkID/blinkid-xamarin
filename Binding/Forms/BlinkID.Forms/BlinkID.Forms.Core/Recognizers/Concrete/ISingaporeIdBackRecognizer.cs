namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Singapore national ID cards.
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
        /// Defines if address of Singapore ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if adress change date, present on sticker, of Singapore ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddressChangeDate { get; set; }
        
        /// <summary>
        /// Defines if blood group of Singapore ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodGroup { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Singapore ID should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// The extension factors for full document image. 
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
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
        /// The address of Singapore ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The address change date, present if the address is on a sticker, of Singapore ID owner. 
        /// </summary>
        IDate AddressChangeDate { get; }
        
        /// <summary>
        /// The blood group of Singapore ID owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The card number of Singapore ID. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The date of issue of Singapore ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}