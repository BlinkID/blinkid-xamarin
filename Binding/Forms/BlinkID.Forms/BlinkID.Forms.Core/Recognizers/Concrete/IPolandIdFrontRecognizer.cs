namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer which can scan front side of Polish national ID cards.
    /// 
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
        /// True if date of birth is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// True if family name is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFamilyName { get; set; }
        
        /// <summary>
        /// True if given names is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// True if parents' given names is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractParentsGivenNames { get; set; }
        
        /// <summary>
        /// True if sex is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// True if surname is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        /// The date of birth of Polish ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// Face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The family name of Polish ID owner. 
        /// </summary>
        string FamilyName { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The given names of the Polish ID owner. 
        /// </summary>
        string GivenNames { get; }
        
        /// <summary>
        /// The parents' given names of the Polish ID owner. 
        /// </summary>
        string ParentsGivenNames { get; }
        
        /// <summary>
        /// Sex of the Polish ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The surname of the Polish ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}