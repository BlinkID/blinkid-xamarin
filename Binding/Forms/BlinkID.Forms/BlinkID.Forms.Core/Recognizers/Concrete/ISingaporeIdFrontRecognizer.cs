namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Singaporean national ID card.
    /// </summary>
    public interface ISingaporeIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if country/place of birth of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCountryOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if name of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if race of Singaporean ID card owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRace { get; set; }
        
        /// <summary>
        /// Defines if sex of Singaporean ID card owner should be extracted. 
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
        ISingaporeIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeIdFrontRecognizer.
    /// </summary>
    public interface ISingaporeIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The country/place of birth of the Singaporean ID card owner. 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// The date of birth of the Singaporean ID card owner. 
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
        /// The identity card number of the Singaporean ID card. 
        /// </summary>
        string IdentityCardNumber { get; }
        
        /// <summary>
        /// The name of the Singaporean ID card owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The race of the Singaporean ID card owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// The sex of the Singaporean ID card owner. 
        /// </summary>
        string Sex { get; }
        
    }
}