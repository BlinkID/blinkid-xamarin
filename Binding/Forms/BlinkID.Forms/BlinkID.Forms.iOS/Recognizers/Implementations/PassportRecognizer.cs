using BlinkID.Forms.iOS.Recognizers;
using BlinkID.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PassportRecognizer))]
namespace BlinkID.Forms.iOS.Recognizers
{
    public sealed class PassportRecognizer : Recognizer, IPassportRecognizer
    {
        MBPassportRecognizer nativeRecognizer;

        PassportRecognizerResult result;

        public PassportRecognizer() : base(new MBPassportRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBPassportRecognizer;
            result = new PassportRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPassportRecognizerResult Result => result;

        
        
        public bool AnonymizeNetherlandsMrz 
        { 
            get => nativeRecognizer.AnonymizeNetherlandsMrz; 
            set => nativeRecognizer.AnonymizeNetherlandsMrz = value;
        }
        
        
        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
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

    public sealed class PassportRecognizerResult : RecognizerResult, IPassportRecognizerResult
    {
        MBPassportRecognizerResult nativeResult;

        internal PassportRecognizerResult(MBPassportRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}