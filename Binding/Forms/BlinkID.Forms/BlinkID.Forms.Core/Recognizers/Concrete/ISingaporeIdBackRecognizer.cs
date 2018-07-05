namespace Microblink.Forms.Core.Recognizers
{
    public interface ISingaporeIdBackRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if blood group of Singapore ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodGroup { get; set; }
        
        /// <summary>
        /// true if date of issue is being extracted from Singapore ID 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in result. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISingaporeIdBackRecognizerResult Result { get; }
    }

    public interface ISingaporeIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// address of the Singapore ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// blood group of the Singapore ID owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// the card number of Singapore ID. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// the document date of issue of the Singapore ID 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}