namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Kad Back Recognizer.
    /// 
    /// MyKadBack recognizer is used for scanning back side of MyKad.
    /// </summary>
    public interface IMyKadBackRecognizer : IRecognizer
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
        /// Defines if old NRIC should be extracted from back side of the MyKad
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOldNric { get; set; }
        
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
        /// Sets whether signature image from ID card should be extracted.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        
        /// <summary>
        /// Property for setting DPI for signature images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint SignatureImageDpi { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IMyKadBackRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMyKadBackRecognizer.
    /// </summary>
    public interface IMyKadBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The Date Of Birth of the MyKad owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The Extended NRIC of the MyKad owner. 
        /// </summary>
        string ExtendedNric { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The NRIC of the MyKad owner. 
        /// </summary>
        string Nric { get; }
        
        /// <summary>
        /// The old NRIC of the MyKad owner. 
        /// </summary>
        string OldNric { get; }
        
        /// <summary>
        /// The Sex of the MyKad owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// image of the signature if enabled with returnSignatureImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}