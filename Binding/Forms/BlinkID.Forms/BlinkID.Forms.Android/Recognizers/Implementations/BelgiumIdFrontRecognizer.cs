using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BelgiumIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BelgiumIdFrontRecognizer : Recognizer, IBelgiumIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdFrontRecognizer nativeRecognizer;

        BelgiumIdFrontRecognizerResult result;

        public BelgiumIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdFrontRecognizer;
            result = new BelgiumIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBelgiumIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
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
        
    }

    public sealed class BelgiumIdFrontRecognizerResult : RecognizerResult, IBelgiumIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdFrontRecognizer.Result nativeResult;

        internal BelgiumIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CardNumber => nativeResult.CardNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
    }
}