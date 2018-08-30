namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer for detecting holder's photo on documents containing image.
    /// </summary>
    public interface IDocumentFaceRecognizer : IRecognizer
    {
        
        /// <summary>
        /// currently used detector type. 
        ///
        /// By default, this is set to 'IDENTITY_CARD_TD1'
        /// </summary>
        DocumentFaceDetectorType DetectorType { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for face image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FaceImageDpi { get; set; }
        
        /// <summary>
        /// the DPI (Dots Per Inch) for full document image that should be returned. 
        ///
        /// By default, this is set to '250'
        /// </summary>
        uint FullDocumentImageDpi { get; set; }
        
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
        IDocumentFaceRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IDocumentFaceRecognizer.
    /// </summary>
    public interface IDocumentFaceRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// the location of document detection in coordinate system of full input frame. 
        /// </summary>
        IQuadrilateral DocumentLocation { get; }
        
        /// <summary>
        ///  face image from the document 
        /// </summary>
        Xamarin.Forms.ImageSource FaceImage { get; }
        
        /// <summary>
        /// the location of face detection in coordinate system of cropped full document image. 
        /// </summary>
        IQuadrilateral FaceLocation { get; }
        
        /// <summary>
        ///  image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}