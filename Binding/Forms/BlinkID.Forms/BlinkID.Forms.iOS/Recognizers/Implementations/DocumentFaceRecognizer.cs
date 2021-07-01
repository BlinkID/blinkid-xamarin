using BlinkID.Forms.iOS.Recognizers;
using BlinkID.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentFaceRecognizer))]
namespace BlinkID.Forms.iOS.Recognizers
{
    public sealed class DocumentFaceRecognizer : Recognizer, IDocumentFaceRecognizer
    {
        MBDocumentFaceRecognizer nativeRecognizer;

        DocumentFaceRecognizerResult result;

        public DocumentFaceRecognizer() : base(new MBDocumentFaceRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBDocumentFaceRecognizer;
            result = new DocumentFaceRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IDocumentFaceRecognizerResult Result => result;

        
        
        public DocumentFaceDetectorType DetectorType 
        { 
            get => (DocumentFaceDetectorType)nativeRecognizer.DetectorType; 
            set => nativeRecognizer.DetectorType = (MBDocumentFaceDetectorType)value;
        }
        
        
        
        public int FaceImageDpi 
        { 
            get => (int)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
        }
        
        
        
        public int FullDocumentImageDpi 
        { 
            get => (int)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
        
        
        
        public int NumStableDetectionsThreshold 
        { 
            get => (int)nativeRecognizer.NumStableDetectionsThreshold; 
            set => nativeRecognizer.NumStableDetectionsThreshold = value;
        }
        
        
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ReturnFaceImage; 
            set => nativeRecognizer.ReturnFaceImage = value;
        }
        
        
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        
    }

    public sealed class DocumentFaceRecognizerResult : RecognizerResult, IDocumentFaceRecognizerResult
    {
        MBDocumentFaceRecognizerResult nativeResult;

        internal DocumentFaceRecognizerResult(MBDocumentFaceRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IQuadrilateral DocumentLocation => nativeResult.DocumentLocation != null ? new Quadrilateral(nativeResult.DocumentLocation) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public IQuadrilateral FaceLocation => nativeResult.FaceLocation != null ? new Quadrilateral(nativeResult.FaceLocation) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
    }
}