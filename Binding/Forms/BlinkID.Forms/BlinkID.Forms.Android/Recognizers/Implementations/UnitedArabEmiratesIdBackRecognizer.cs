using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UnitedArabEmiratesIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class UnitedArabEmiratesIdBackRecognizer : Recognizer, IUnitedArabEmiratesIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdBackRecognizer nativeRecognizer;

        UnitedArabEmiratesIdBackRecognizerResult result;

        public UnitedArabEmiratesIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdBackRecognizer;
            result = new UnitedArabEmiratesIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUnitedArabEmiratesIdBackRecognizerResult Result => result;

        
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

    public sealed class UnitedArabEmiratesIdBackRecognizerResult : RecognizerResult, IUnitedArabEmiratesIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdBackRecognizer.Result nativeResult;

        internal UnitedArabEmiratesIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}