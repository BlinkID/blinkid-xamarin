namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Morocco ID Back Recognizer.
    /// 
    /// Morocco ID Back recognizer is used for scanning Back side of the Morocco ID.
    /// </summary>
    public interface IMoroccoIdBackRecognizer : IRecognizer
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
        /// Defines if owner's address should be extracted from Back side of the Morocco ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if owner's civil status number should be extracted from Back side of the Morocco ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCivilStatusNumber { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Back side of the Morocco ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if father's name should be extracted from Back side of the Morocco ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFathersName { get; set; }
        
        /// <summary>
        /// Defines if mother's name should be extracted from Back side of the Morocco ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractMothersName { get; set; }
        
        /// <summary>
        /// Defines if owner's sex should be extracted from Back side of the Morocco ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        IMoroccoIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMoroccoIdBackRecognizer.
    /// </summary>
    public interface IMoroccoIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Morocco ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The civil status number of the Morocco ID owner. 
        /// </summary>
        string CivilStatusNumber { get; }
        
        /// <summary>
        /// The date of expiry of the Morocco ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The document number of the Morocco ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The father's name of the Morocco ID owner. 
        /// </summary>
        string FathersName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The mother's name of the Morocco ID owner. 
        /// </summary>
        string MothersName { get; }
        
        /// <summary>
        /// The sex of the Morocco ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}