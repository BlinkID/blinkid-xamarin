using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UnitedArabEmiratesIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class UnitedArabEmiratesIdBackRecognizer : Recognizer, IUnitedArabEmiratesIdBackRecognizer
    {
        MBUnitedArabEmiratesIdBackRecognizer nativeRecognizer;

        UnitedArabEmiratesIdBackRecognizerResult result;

        public UnitedArabEmiratesIdBackRecognizer() : base(new MBUnitedArabEmiratesIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBUnitedArabEmiratesIdBackRecognizer;
            result = new UnitedArabEmiratesIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUnitedArabEmiratesIdBackRecognizerResult Result => result;

        
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

    public sealed class UnitedArabEmiratesIdBackRecognizerResult : RecognizerResult, IUnitedArabEmiratesIdBackRecognizerResult
    {
        MBUnitedArabEmiratesIdBackRecognizerResult nativeResult;

        internal UnitedArabEmiratesIdBackRecognizerResult(MBUnitedArabEmiratesIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}