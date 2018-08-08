namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for reading Malaysian driving license document.
    /// 
    /// </summary>
    public interface IMalaysiaDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if DL class is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDlClass { get; set; }
        
        /// <summary>
        /// true if full address of Malaysian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullAddress { get; set; }
        
        /// <summary>
        /// true if name of Malaysian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// true if nationality of Malaysian DL owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// true if valid from is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidFrom { get; set; }
        
        /// <summary>
        /// true if valid until is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
        /// <summary>
        /// Defines the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
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
        /// extracted city from the owner address. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// Malaysian DL class. 
        /// </summary>
        string DlClass { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full owner address. 
        /// </summary>
        string FullAddress { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the Malaysian DL identity number. 
        /// </summary>
        string IdentityNumber { get; }
        
        /// <summary>
        /// name of Malaysian DL owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// nationality of Malaysian DL owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// extracted state from the owner address. 
        /// </summary>
        string State { get; }
        
        /// <summary>
        /// extracted street from the owner address. 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// Malaysian DL valid from. 
        /// </summary>
        IDate ValidFrom { get; }
        
        /// <summary>
        /// Malaysian DL valid until. 
        /// </summary>
        IDate ValidUntil { get; }
        
        /// <summary>
        /// extracted ZIP code from the owner address. 
        /// </summary>
        string ZipCode { get; }
        
    }
}