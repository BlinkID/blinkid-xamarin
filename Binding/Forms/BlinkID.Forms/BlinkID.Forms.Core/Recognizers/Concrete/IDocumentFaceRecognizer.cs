namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Class for configuring Document Face Recognizer Recognizer.
    /// 
    /// Document Face Recognizer recognizer is used for scanning documents containing face images.
    /// </summary>
    public interface IDocumentFaceRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Type of docment this recognizer will scan.
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
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// Property for setting DPI for full document images
        /// Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception
        /// 
        ///  
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
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
        uint NumStableDetectionsThreshold { get; set; }
        
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
        /// Setting for control over FaceImageCropProcessor's tryBothOrientations option
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool TryBothOrientations { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IDocumentFaceRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IDocumentFaceRecognizer.
    /// </summary>
    public interface IDocumentFaceRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Quadrangle represeting corner points of the document within the input image. 
        /// </summary>
        IQuadrilateral DocumentLocation { get; }
        
        /// <summary>
        /// face image from the document if enabled with returnFaceImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// Quadrangle represeting corner points of the face image within the input image. 
        /// </summary>
        IQuadrilateral FaceLocation { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}