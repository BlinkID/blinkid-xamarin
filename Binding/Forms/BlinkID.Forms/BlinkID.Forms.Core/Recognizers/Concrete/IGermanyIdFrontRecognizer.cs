namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan the front side of German national ID cards.
    /// 
    /// </summary>
    public interface IGermanyIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// {true} if the can number is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCanNumber { get; set; }
        
        /// <summary>
        /// {true} if the date of expiry is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfExpiry { get; set; }
        
        /// <summary>
        /// {true} if the document number is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDocumentNumber { get; set; }
        
        /// <summary>
        /// {true} if the given names is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// {true} if the nationality is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractNationality { get; set; }
        
        /// <summary>
        /// {true} if the place of birth is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// {true} if the surname is being extracted, {false} otherwise. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
        /// <summary>
        /// Defines the extension factors for full document image. 
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
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        
        /// <summary>
        /// Defines whether signature image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnSignatureImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IGermanyIdFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IGermanyIdFrontRecognizer.
    /// </summary>
    public interface IGermanyIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the CAN number of German ID. 
        /// </summary>
        string CanNumber { get; }
        
        /// <summary>
        /// the date of birth of German ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the date of expiry of German ID 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// the document number of German ID. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the first name of the German ID owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the last name of the German ID owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// nationality of the German ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// the place of birth of German ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
    }
}