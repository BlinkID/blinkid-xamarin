namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Singapore Id Back Recognizer.
    /// 
    /// Singapore Id Back recognizer is used for scanning back side of the Singapore Id.
    /// </summary>
    public interface ISingaporeIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines if glare detection should be turned on/off.
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if owner's address should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if owner's address change date should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractAddressChangeDate { get; set; }
        
        /// <summary>
        /// Defines if owner's blood type should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodGroup { get; set; }
        
        /// <summary>
        /// Defines if owner's date of issue should be extracted from back side of the Singapore Id
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
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
        /// Image extension factors for full document image.
        /// 
        /// @see ImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
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
        ISingaporeIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeIdBackRecognizer.
    /// </summary>
    public interface ISingaporeIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the back side of the Singapore Id owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The address Change Date of the back side of the Singapore Id owner. 
        /// </summary>
        IDate AddressChangeDate { get; }
        
        /// <summary>
        /// The blood Type of the back side of the Singapore Id owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The card Number of the back side of the Singapore Id owner. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The date Of Issue of the back side of the Singapore Id owner. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}