namespace Microblink.Forms.Core.Recognizers
{
    public interface ISingaporeIdBackRecognizer : IRecognizer
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
        ///  Defines if blood group of Singapore ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBloodGroup { get; set; }
        
        /// <summary>
        ///  Defines if date of issue of Singapore ID owner should be extracted
        /// 
        ///   
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfIssue { get; set; }
        
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
        ISingaporeIdBackRecognizerResult Result { get; }
    }

    public interface ISingaporeIdBackRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The address of the Singapore ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The blood group of the Singapore ID owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The identity card number of the Singapore ID. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The date of issue of the Singapore ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}