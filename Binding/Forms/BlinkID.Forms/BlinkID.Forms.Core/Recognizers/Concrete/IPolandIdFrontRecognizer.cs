namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Poland ID cards.
    /// </summary>
    public interface IPolandIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Poland ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if family name of Poland ID owner should be extracted. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractFamilyName { get; set; }
        
        /// <summary>
        /// Defines if given names of Poland ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// Defines if parents given names of Poland ID owner should be extracted. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ExtractParentsGivenNames { get; set; }
        
        /// <summary>
        /// Defines if sex of Poland ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if surname of Poland ID owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// The DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
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
        /// Defines whether face image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFaceImage { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IPolandIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IPolandIdFrontRecognizer.
    /// </summary>
    public interface IPolandIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of the Poland ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The family name of the Poland ID owner. 
        /// </summary>
        string FamilyName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The given names of the Poland ID owner. 
        /// </summary>
        string GivenNames { get; }
        
        /// <summary>
        /// The parents given names of the Poland ID owner. 
        /// </summary>
        string ParentsGivenNames { get; }
        
        /// <summary>
        /// The sex of the Poland ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The surname of the Poland ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}