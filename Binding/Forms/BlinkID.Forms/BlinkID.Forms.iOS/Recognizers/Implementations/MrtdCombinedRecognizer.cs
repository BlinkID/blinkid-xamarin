using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdCombinedRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MrtdCombinedRecognizer : Recognizer, IMrtdCombinedRecognizer
    {
        MBMrtdCombinedRecognizer nativeRecognizer;

        MrtdCombinedRecognizerResult result;

        public MrtdCombinedRecognizer() : base(new MBMrtdCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMrtdCombinedRecognizer;
            result = new MrtdCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMrtdCombinedRecognizerResult Result => result;

        
        public bool AllowSpecialCharacters 
        { 
            get => nativeRecognizer.AllowSpecialCharacters; 
            set => nativeRecognizer.AllowSpecialCharacters = value;
        }
        
        public bool AllowUnparsedResults 
        { 
            get => nativeRecognizer.AllowUnparsedResults; 
            set => nativeRecognizer.AllowUnparsedResults = value;
        }
        
        public bool AllowUnverifiedResults 
        { 
            get => nativeRecognizer.AllowUnverifiedResults; 
            set => nativeRecognizer.AllowUnverifiedResults = value;
        }
        
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
    }

    public sealed class MrtdCombinedRecognizerResult : RecognizerResult, IMrtdCombinedRecognizerResult
    {
        MBMrtdCombinedRecognizerResult nativeResult;

        internal MrtdCombinedRecognizerResult(MBMrtdCombinedRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentBackImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentFrontImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
    }
}