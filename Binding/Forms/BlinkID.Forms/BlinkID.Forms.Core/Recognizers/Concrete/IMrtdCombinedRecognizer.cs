﻿namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// MRTD Combined recognizer
    /// 
    /// MRTD Combined recognizer is used for scanning both front and back side of generic IDs.
    /// </summary>
    public interface IMrtdCombinedRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Whether special characters are allowed
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowSpecialCharacters { get; set; }
        
        /// <summary>
        /// Whether returning of unparsed results is allowed
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnparsedResults { get; set; }
        
        /// <summary>
        /// Whether returning of unverified results is allowed
        /// Unverified result is result that is parsed, but check digits are incorrect.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowUnverifiedResults { get; set; }
        
        /// <summary>
        /// Type of document this recognizer will scan.
        /// 
        ///  
        ///
        /// By default, this is set to 'MBDocumentFaceDetectorTypeTD1'
        /// </summary>
        DocumentFaceDetectorType DetectorType { get; set; }
        
        /// <summary>
        /// Property for setting DPI for face images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        int FaceImageDpi { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        int FullDocumentImageDpi { get; set; }
        
        /// <summary>
        /// Image extension factors for full document image.
        /// 
        /// @see ImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Defines how many times the same document should be detected before the detector
        /// returns this document as a result of the deteciton
        /// 
        /// Higher number means more reliable detection, but slower processing
        /// 
        ///  
        ///
        /// By default, this is set to '6'
        /// </summary>
        int NumStableDetectionsThreshold { get; set; }
        
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
        IMrtdCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IMrtdCombinedRecognizer.
    /// </summary>
    public interface IMrtdCombinedRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Digital signature of the recognition result. Available only if enabled with signResult property. 
        /// </summary>
        byte[] DigitalSignature { get; }
        
        /// <summary>
        /// Version of the digital signature. Available only if enabled with signResult property. 
        /// </summary>
        int DigitalSignatureVersion { get; }
        
        /// <summary>
        /// Returns DataMatchResultSuccess if data from scanned parts/sides of the document match,
        /// DataMatchResultFailed otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return DataMatchResultFailed. Result will
        /// be DataMatchResultSuccess only if scanned values for all fields that are compared are the same. 
        /// </summary>
        DataMatchResult DocumentDataMatch { get; }
        
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
        /// Returns the Data extracted from the machine readable zone. 
        /// </summary>
        IMrzResult MrzResult { get; }
        
        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        bool ScanningFirstSideDone { get; }
        
    }
}