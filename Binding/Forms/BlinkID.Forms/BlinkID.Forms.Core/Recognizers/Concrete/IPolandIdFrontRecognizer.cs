namespace Microblink.Forms.Core.Recognizers
{
    public interface IPolandIdFrontRecognizer : IRecognizer
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
        /// Defines if date of expiry should be extracted from Polish ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Polish ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFamilyName { get; set; }
        
        /// <summary>
        /// Defines if date of birth of Polish ID owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractGivenNames { get; set; }
        
        /// <summary>
        /// Defines if date of expiry should be extracted from Polish ID
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractParentsGivenNames { get; set; }
        
        /// <summary>
        ///  Defines if sex of Polish ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSex { get; set; }
        
        /// <summary>
        /// Defines if citizenship of Polish ID owner should be extracted
        /// 
        ///  
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractSurname { get; set; }
        
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
        IPolandIdFrontRecognizerResult Result { get; }
    }

    public interface IPolandIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The date of birth of Polish ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// The family name of Polish ID owner. 
        /// </summary>
        string FamilyName { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// The first name of the Polish ID owner. 
        /// </summary>
        string GivenNames { get; }
        
        /// <summary>
        /// The parents name of Polish ID owner. 
        /// </summary>
        string ParentsGivenNames { get; }
        
        /// <summary>
        /// The sex of the Polish ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The last name of the Polish ID owner. 
        /// </summary>
        string Surname { get; }
        
    }
}