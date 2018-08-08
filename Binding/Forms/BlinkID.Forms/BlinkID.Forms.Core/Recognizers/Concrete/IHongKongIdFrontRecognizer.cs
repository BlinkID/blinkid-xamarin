namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Hong Kong national ID cards.
    /// </summary>
    public interface IHongKongIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if commercial code of Hong Kong ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCommercialCode { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Hong Kong ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of issue of Hong Kong ID should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines if full name of Hong Kong ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullName { get; set; }
        
        /// <summary>
        /// Defines if residential status of Hong Kong ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractResidentialStatus { get; set; }
        
        /// <summary>
        /// Defines if sex of Hong Kong ID owner should be extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
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
        IHongKongIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IHongKongIdFrontRecognizer.
    /// </summary>
    public interface IHongKongIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The commercial code of Hong Kong ID owner 
        /// </summary>
        string CommercialCode { get; }
        
        /// <summary>
        /// The date of birth of Hong Kong ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of issue of Hong Kong ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The document number of Hong Kong ID 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The full name of Hong Kong ID owner 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The residential status of Hong Kong ID owner 
        /// </summary>
        string ResidentialStatus { get; }
        
        /// <summary>
        /// The sex of Hong Kong ID owner 
        /// </summary>
        string Sex { get; }
        
    }
}