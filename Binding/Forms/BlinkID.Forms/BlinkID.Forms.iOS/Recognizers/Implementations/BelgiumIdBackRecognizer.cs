using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BelgiumIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BelgiumIdBackRecognizer : Recognizer, IBelgiumIdBackRecognizer
    {
        MBBelgiumIdBackRecognizer nativeRecognizer;

        BelgiumIdBackRecognizerResult result;

        public BelgiumIdBackRecognizer() : base(new MBBelgiumIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBelgiumIdBackRecognizer;
            result = new BelgiumIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBelgiumIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class BelgiumIdBackRecognizerResult : RecognizerResult, IBelgiumIdBackRecognizerResult
    {
        MBBelgiumIdBackRecognizerResult nativeResult;

        internal BelgiumIdBackRecognizerResult(MBBelgiumIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}