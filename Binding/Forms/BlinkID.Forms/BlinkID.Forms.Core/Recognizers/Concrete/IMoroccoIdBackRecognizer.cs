namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan back side of Moroccan national ID cards.
    /// </summary>
    public interface IMoroccoIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if address of the Moroccan ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// Defines if civil status number of the Moroccan ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCivilStatusNumber { get; set; }
        
        /// <summary>
        /// Defines if date of expiry of the Moroccan ID should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// Defines if father's name of the Moroccan ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFathersName { get; set; }
        
        /// <summary>
        /// Defines if mother's name of the Moroccan ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractMothersName { get; set; }
        
        /// <summary>
        /// Defines if sex of the Moroccan ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        IMoroccoIdBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMoroccoIdBackRecognizer.
    /// </summary>
    public interface IMoroccoIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Moroccan ID owner 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The civil status number of the Moroccan ID owner 
        /// </summary>
        string CivilStatusNumber { get; }
        
        /// <summary>
        /// The date of expiry of the Moroccan ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The document number of the Moroccan ID 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The father's name of the Moroccan ID owner 
        /// </summary>
        string FathersName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The mother's name of the Moroccan ID owner 
        /// </summary>
        string MothersName { get; }
        
        /// <summary>
        /// The sex of the Moroccan ID owner 
        /// </summary>
        string Sex { get; }
        
    }
}