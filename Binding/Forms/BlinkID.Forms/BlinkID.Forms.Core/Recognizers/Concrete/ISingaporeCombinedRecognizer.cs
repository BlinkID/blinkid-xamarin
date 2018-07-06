namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Singapore ID Combined Recognizer.
    /// 
    /// Singapore ID Combined recognizer is used for scanning both front and back side of Singapore ID.
    /// </summary>
    public interface ISingaporeCombinedRecognizer : IRecognizer
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
        /// Whether or not recognition result should be signed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISingaporeCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISingaporeCombinedRecognizer.
    /// </summary>
    public interface ISingaporeCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The name of the Singapore ID owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The blood group of the Singapore ID owner. 
        /// </summary>
        string BloodGroup { get; }
        
        /// <summary>
        /// The identity card number of Singapore ID. 
        /// </summary>
        string CardNumber { get; }
        
        /// <summary>
        /// The country of birth of the Singapore ID owner. 
        /// </summary>
        string CountryOfBirth { get; }
        
        /// <summary>
        /// The date of birth of Singapore ID owner 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of issue of Singapore ID owner 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// Digital signature of the recognition result. Available only if enabled with signResult property. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Version of the digital signature. Available only if enabled with signResult property. 
        /// </summary>
        uint DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Returns true if data from scanned parts/sides of the document match,
        /// false otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return false. Result will
        /// be true only if scanned values for all fields that are compared are the same. 
        /// </summary>
        bool DocumentDataMatch { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// back side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentBackImage { get; }
        
        /// <summary>
        /// front side image of the document if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentFrontImage { get; }
        
        /// <summary>
        /// The first name of the Singapore ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// The race of the Singapore ID owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// The sex of the Singapore ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}