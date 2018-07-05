namespace Microblink.Forms.Core.Recognizers
{
    public interface ISingaporeCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
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
        /// Defines whether or not recognition result should be signed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISingaporeCombinedRecognizerResult Result { get; }
    }

    public interface ISingaporeCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the address of the Singapore ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// blood group of the Singapore ID holder. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// the card number of Singapore ID. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// the country of birth of Singapore ID. 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// the date of birth of Singapore ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the document date of issue of the Singapore ID. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Defines digital signature of recognition results. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Defines digital signature version. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Defines {true} if data from scanned parts/sides of the document match, 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        ///  back side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        ///  front side image of the document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// the name of the Singapore ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// race of the Singapore ID owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        ///  {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// sex of the Singapore ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}