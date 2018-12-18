using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CyprusIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class CyprusIdBackRecognizer : Recognizer, ICyprusIdBackRecognizer
    {
        MBCyprusIdBackRecognizer nativeRecognizer;

        CyprusIdBackRecognizerResult result;

        public CyprusIdBackRecognizer() : base(new MBCyprusIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCyprusIdBackRecognizer;
            result = new CyprusIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICyprusIdBackRecognizerResult Result => result;

        
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

    public sealed class CyprusIdBackRecognizerResult : RecognizerResult, ICyprusIdBackRecognizerResult
    {
        MBCyprusIdBackRecognizerResult nativeResult;

        internal CyprusIdBackRecognizerResult(MBCyprusIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}