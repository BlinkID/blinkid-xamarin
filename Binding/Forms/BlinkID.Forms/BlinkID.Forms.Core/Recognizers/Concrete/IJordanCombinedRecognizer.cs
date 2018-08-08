namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    ///  Recognizer for combined reading of both front and back side of Jordan ID.
    /// 
    /// </summary>
    public interface IJordanCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Defines whether glare detector is enabled. 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool DetectGlare { get; set; }
        
        /// <summary>
        /// true if date of birth of Jordan owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractDateOfBirth { get; set; }
        
        /// <summary>
        /// true if name of Jordan ID owner is being extracted 
        ///
        /// By default, this is set to 'true'
        /// </summary>
        bool ExtractName { get; set; }
        
        /// <summary>
        /// true if sex of Jordan owner is being extracted 
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
        /// Defines whether or not recognition result should be signed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool SignResult { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IJordanCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IJordanCombinedRecognizer.
    /// </summary>
    public interface IJordanCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the date of birth of Jordan ID owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// the document date of expiry of the Jordan ID. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
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
        /// the document number of Jordan ID. 
        /// </summary>
        string DocumentNumber { get; }
        
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
        /// the issuer of Jordan ID. 
        /// </summary>
        string Issuer { get; }
        
        /// <summary>
        /// true if all check digits inside MRZ are correct, false otherwise. 
        /// </summary>
        bool MrzVerified { get; }
        
        /// <summary>
        /// the name of the Jordan ID owner. 
        /// </summary>
        string Name { get; }
        
        /// <summary>
        /// the national number of Jordan ID owner. 
        /// </summary>
        string NationalNumber { get; }
        
        /// <summary>
        /// nationality of the Jordan ID owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        ///  {true} if recognizer has finished scanning first side and is now scanning back side, 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
        /// <summary>
        /// sex of the Jordan ID owner. 
        /// </summary>
        string Sex { get; }
        
    }
}