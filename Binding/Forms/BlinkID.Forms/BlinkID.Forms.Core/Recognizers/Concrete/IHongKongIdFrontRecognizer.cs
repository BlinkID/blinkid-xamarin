namespace Microblink.Forms.Core.Recognizers
{
    public interface IHongKongIdFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if commercial code of Hong Kong ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractCommercialCode { get; set; }
        
        /// <summary>
        /// true if date of birth of Hong Kong ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if date of issue of Hong Kong ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// true if full name of Hong Kong ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractFullName { get; set; }
        
        /// <summary>
        /// true if sex of Hong Kong ID owner is being extracted 
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
        IHongKongIdFrontRecognizerResult Result { get; }
    }

    public interface IHongKongIdFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// owner commercial code if written on ID 
        /// </summary>
        string CommercialCode { get; }
        
        /// <summary>
        /// owner's date of birth if it is successfully converted to {Date} from date format: <code>DDMMYYYY</code>. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// ID date of issue it is successfully converted to {Date} from date format: <code>DDMMYYYY</code>. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// the Hong Kong document number. 
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
        /// owner full name. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// owner sex (M for male, F for female). 
        /// </summary>
        string Sex { get; }
        
    }
}