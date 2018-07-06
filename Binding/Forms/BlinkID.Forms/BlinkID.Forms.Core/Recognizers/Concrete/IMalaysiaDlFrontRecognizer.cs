namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Malaysian DL Front Recognizer.
    /// 
    /// Malaysian DL Front recognizer is used for scanning front side of Malaysian DL.
    /// </summary>
    public interface IMalaysiaDlFrontRecognizer : IRecognizer
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
        /// Defines if owner's license class should be extracted from Malaysian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDlClass { get; set; }
        
        /// <summary>
        /// Defines if owner's full address should be extracted from Malaysian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullAddress { get; set; }
        
        /// <summary>
        /// Defines if owner's name should be extracted from Malaysian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if owner's nationality should be extracted from Malaysian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// Defines if owner's valid from should be extracted from Malaysian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidFrom { get; set; }
        
        /// <summary>
        /// Defines if owner's valid until should be extracted from Malaysian DL
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
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
        /// Sets whether face image from ID card should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
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
        IMalaysiaDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMalaysiaDlFrontRecognizer.
    /// </summary>
    public interface IMalaysiaDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The City of the Malaysian DL owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The Class of the Malaysian DL. 
        /// </summary>
        string DlClass { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The Full Address of the Malaysian DL owner. 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The Identity Number of the Malaysian DL owner. 
        /// </summary>
        string IdentityNumber { get; }
        
        /// <summary>
        /// The Name of the Malaysian DL owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The Nationality of the Malaysian DL owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The State of the Malaysian DL owner. 
        /// </summary>
        string State { get; }
        
        /// <summary>
        /// The Street of the Malaysian DL owner. 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// The Valid From date of the Malaysian DL owner. 
        /// </summary>
        IDate ValidFrom { get; }
        
        /// <summary>
        /// The Valid Until date of the Malaysian DL owner. 
        /// </summary>
        IDate ValidUntil { get; }
        
        /// <summary>
        /// The Zip Code of the Malaysian DL owner. 
        /// </summary>
        string ZipCode { get; }
        
    }
}