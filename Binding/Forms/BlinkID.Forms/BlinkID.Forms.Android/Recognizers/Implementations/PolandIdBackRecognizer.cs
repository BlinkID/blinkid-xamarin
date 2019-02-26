using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PolandIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class PolandIdBackRecognizer : Recognizer, IPolandIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer nativeRecognizer;

        PolandIdBackRecognizerResult result;

        public PolandIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer;
            result = new PolandIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPolandIdBackRecognizerResult Result => result;

        
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

    public sealed class PolandIdBackRecognizerResult : RecognizerResult, IPolandIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer.Result nativeResult;

        internal PolandIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}