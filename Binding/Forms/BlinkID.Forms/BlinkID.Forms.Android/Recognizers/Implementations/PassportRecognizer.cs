using BlinkID.Forms.Droid.Recognizers;
using BlinkID.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PassportRecognizer))]
namespace BlinkID.Forms.Droid.Recognizers
{
    public sealed class PassportRecognizer : Recognizer, IPassportRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Passport.PassportRecognizer nativeRecognizer;

        PassportRecognizerResult result;

        public PassportRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Passport.PassportRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Passport.PassportRecognizer;
            result = new PassportRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Passport.PassportRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPassportRecognizerResult Result => result;

        
        public bool AnonymizeNetherlandsMrz 
        { 
            get => nativeRecognizer.ShouldAnonymizeNetherlandsMrz(); 
            set => nativeRecognizer.SetAnonymizeNetherlandsMrz(value);
        }
        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class PassportRecognizerResult : RecognizerResult, IPassportRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Passport.PassportRecognizer.Result nativeResult;

        internal PassportRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Passport.PassportRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public int DigitalSignatureVersion => (int)nativeResult.DigitalSignatureVersion;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}