using BlinkID.Forms.Droid.Recognizers;
using BlinkID.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentFaceRecognizer))]
namespace BlinkID.Forms.Droid.Recognizers
{
    public sealed class DocumentFaceRecognizer : Recognizer, IDocumentFaceRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceRecognizer nativeRecognizer;

        DocumentFaceRecognizerResult result;

        public DocumentFaceRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceRecognizer;
            result = new DocumentFaceRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IDocumentFaceRecognizerResult Result => result;

        
        public DocumentFaceDetectorType DetectorType 
        { 
            get => (DocumentFaceDetectorType)nativeRecognizer.DetectorType.Ordinal(); 
            set => nativeRecognizer.DetectorType = Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceDetectorType.Values()[(int)value];
        }
        
        public int FaceImageDpi 
        { 
            get => nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
        }
        
        public int FullDocumentImageDpi 
        { 
            get => nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        
        public int NumStableDetectionsThreshold 
        { 
            get => nativeRecognizer.NumStableDetectionsThreshold; 
            set => nativeRecognizer.NumStableDetectionsThreshold = (int)value;
        }
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ShouldReturnFaceImage(); 
            set => nativeRecognizer.SetReturnFaceImage(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class DocumentFaceRecognizerResult : RecognizerResult, IDocumentFaceRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceRecognizer.Result nativeResult;

        internal DocumentFaceRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Documentface.DocumentFaceRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IQuadrilateral DocumentLocation => nativeResult.DocumentLocation != null ? new Quadrilateral(nativeResult.DocumentLocation) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public IQuadrilateral FaceLocation => nativeResult.FaceLocation != null ? new Quadrilateral(nativeResult.FaceLocation) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
    }
}