namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer which can scan front side of Singapore driver's license card.
    /// </summary>
    public interface ISingaporeDlFrontRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// Defines if birth date of Singapore driver's license owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractBirthDate { get; set; }
        
        /// <summary>
        /// Defines if issue date of Singapore driver's license should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractIssueDate { get; set; }
        
        /// <summary>
        /// Defines if name of Singapore driver's license owner should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// Defines if valid till date of Singapore driver's license should be extracted. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractValidTill { get; set; }
        
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
        ISingaporeDlFrontRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeDlFrontRecognizer.
    /// </summary>
    public interface ISingaporeDlFrontRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the birth date of Singapore driver's owner. 
        /// </summary>
        IDate BirthDate { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
        /// <summary>
        /// the issue date of Singapore driver's licence. 
        /// </summary>
        IDate IssueDate { get; }
        
        /// <summary>
        /// the licence number of Singapore driver's licence. 
        /// </summary>
        string LicenceNumber { get; }
        
        /// <summary>
        /// the (full) name of Singapore driver's licence owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// the valid till date of Singapore driver's licence. 
        /// </summary>
        IDate ValidTill { get; }
        
    }
}