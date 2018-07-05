namespace Microblink.Forms.Core.Recognizers
{
    public interface ISingaporeIdFrontRecognizer : IRecognizer
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
        ///  Defines if country of birth of Singapore ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCountryOfBirth { get; set; }
        
        /// <summary>
        ///  Defines if date of birth of Singapore ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        ///  Defines if race of Singapore ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRace { get; set; }
        
        /// <summary>
        ///  Defines if sex of Singapore ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
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
        ISingaporeIdFrontRecognizerResult Result { get; }
    }

    public interface ISingaporeIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The identity card number of the Singapore ID. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The country of birth of the Singapore ID owner. 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// The date of birth of the Singapore ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The name of the Singapore ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The race of the Singapore ID owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// The sex of the Singapore ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}