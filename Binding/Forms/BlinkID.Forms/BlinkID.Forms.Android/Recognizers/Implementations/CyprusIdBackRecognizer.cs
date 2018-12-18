using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CyprusIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CyprusIdBackRecognizer : Recognizer, ICyprusIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Cyprus.CyprusIdBackRecognizer nativeRecognizer;

        CyprusIdBackRecognizerResult result;

        public CyprusIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Cyprus.CyprusIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Cyprus.CyprusIdBackRecognizer;
            result = new CyprusIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Cyprus.CyprusIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICyprusIdBackRecognizerResult Result => result;

        
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

    public sealed class CyprusIdBackRecognizerResult : RecognizerResult, ICyprusIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Cyprus.CyprusIdBackRecognizer.Result nativeResult;

        internal CyprusIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Cyprus.CyprusIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}