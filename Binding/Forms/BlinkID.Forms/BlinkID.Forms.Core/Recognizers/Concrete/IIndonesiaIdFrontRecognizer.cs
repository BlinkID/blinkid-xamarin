namespace Microblink.Forms.Core.Recognizers
{
    public interface IIndonesiaIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if address of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractAddress { get; set; }
        
        /// <summary>
        /// true if blood type of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodType { get; set; }
        
        /// <summary>
        /// true if citizenship of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCitizenship { get; set; }
        
        /// <summary>
        /// true if city of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCity { get; set; }
        
        /// <summary>
        /// true if district of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDistrict { get; set; }
        
        /// <summary>
        /// true if Kel/Desa of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractKelDesa { get; set; }
        
        /// <summary>
        /// true if marital status of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractMaritalStatus { get; set; }
        
        /// <summary>
        /// true if name of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// true if occupation of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractOccupation { get; set; }
        
        /// <summary>
        /// true if place of birth of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractPlaceOfBirth { get; set; }
        
        /// <summary>
        /// true if religion of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractReligion { get; set; }
        
        /// <summary>
        /// true if RT of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRt { get; set; }
        
        /// <summary>
        /// true if RW of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractRw { get; set; }
        
        /// <summary>
        /// true if valid until of Indonesian ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidUntil { get; set; }
        
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
        IIndonesiaIdFrontRecognizerResult Result { get; }
    }

    public interface IIndonesiaIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// address of Indonesian ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// blood type of Indonesian ID owner. 
        /// </summary>
        string BloodType { get; }
        
        /// <summary>
        /// citizenship of Indonesian ID owner. 
        /// </summary>
        string Citizenship { get; }
        
        /// <summary>
        /// the city of Indonesian ID. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// date of birth of Indonesian ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// district of Indonesian ID owner. 
        /// </summary>
        string District { get; }
        
        /// <summary>
        /// document classifier of Indonesian ID. 
        /// </summary>
        string DocumentClassifier { get; }
        
        /// <summary>
        /// the document number of Indonesian ID. 
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
        /// Kel/ Desa of Indonesian ID owner. 
        /// </summary>
        string KelDesa { get; }
        
        /// <summary>
        /// marital status of Indonesian ID owner. 
        /// </summary>
        string MaritalStatus { get; }
        
        /// <summary>
        /// the name of Indonesian ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// occupation of Indonesian ID owner. 
        /// </summary>
        string Occupation { get; }
        
        /// <summary>
        /// place of birth of Indonesian ID owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// the province of Indonesian ID. 
        /// </summary>
        string Province { get; }
        
        /// <summary>
        /// religion of Indonesian ID owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// RT of Indonesian ID. 
        /// </summary>
        string Rt { get; }
        
        /// <summary>
        /// RW of Indonesian ID. 
        /// </summary>
        string Rw { get; }
        
        /// <summary>
        /// sex of Indonesian ID owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        ///  signature image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource SignatureImage { get; }
        
        /// <summary>
        /// valid until of Indonesian ID. 
        /// </summary>
        IDate ValidUntil { get; }
        
        /// <summary>
        /// {true} if date of expiry of the Indonesian ID is permanent, {false} otherwise. 
        /// </summary>
        bool ValidUntilPermanent { get; }
        
    }
}