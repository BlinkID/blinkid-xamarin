namespace Microblink.Forms.Core.Recognizers
{
    public interface ISingaporeIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if country of birth of Singapore ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCountryOfBirth { get; set; }
        
        /// <summary>
        /// true if date of birth of Singapore ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if race of Singapore ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRace { get; set; }
        
        /// <summary>
        /// true if sex of Singapore ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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

    public interface ISingaporeIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the card number of Singapore ID. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// country of birth of the Singapore ID owner 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// the date of birth of Singapore ID owner 
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
        /// name of the Singapore ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// race of the Singapore ID owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// sex of the Singapore ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}