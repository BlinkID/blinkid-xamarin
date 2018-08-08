namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for reading front side of Jordan ID.
    /// 
    /// </summary>
    public interface IJordanIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if date of birth of Jordan owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if name of Jordan ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// true if sex of Jordan owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        IJordanIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IJordanIdFrontRecognizer.
    /// </summary>
    public interface IJordanIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// date of birth of Jordan ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// name of Jordan ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// the national number of Jordan ID card owner. 
        /// </summary>
        string NationalNumber { get; }
        
        /// <summary>
        /// sex of Jordan ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}