using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BelgiumIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BelgiumIdBackRecognizer : Recognizer, IBelgiumIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdBackRecognizer nativeRecognizer;

        BelgiumIdBackRecognizerResult result;

        public BelgiumIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdBackRecognizer;
            result = new BelgiumIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBelgiumIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class BelgiumIdBackRecognizerResult : RecognizerResult, IBelgiumIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdBackRecognizer.Result nativeResult;

        internal BelgiumIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Belgium.BelgiumIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}