namespace Microblink.Forms.Core.Recognizers
{
    public interface IPolandIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if date of birth is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if family name is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFamilyName { get; set; }
        
        /// <summary>
        /// true if given names is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// true if parents' given names is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractParentsGivenNames { get; set; }
        
        /// <summary>
        /// true if sex is being extracted from ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// true if surname is being extracted from ID 
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
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IPolandIdFrontRecognizerResult Result { get; }
    }

    public interface IPolandIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the date of birth of Polish ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the family name of Polish ID owner. 
        /// </summary>
        string FamilyName { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the given names of the Polish ID owner. 
        /// </summary>
        string GivenNames { get; }
        
        /// <summary>
        /// the parents' given names of the Polish ID owner. 
        /// </summary>
        string ParentsGivenNames { get; }
        
        /// <summary>
        /// sex of the Polish ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// the surname of the Polish ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}