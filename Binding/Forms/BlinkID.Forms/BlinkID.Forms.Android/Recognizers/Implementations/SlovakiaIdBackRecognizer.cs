using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SlovakiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SlovakiaIdBackRecognizer : Recognizer, ISlovakiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer nativeRecognizer;

        SlovakiaIdBackRecognizerResult result;

        public SlovakiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer;
            result = new SlovakiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISlovakiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractSpecialRemarks 
        { 
            get => nativeRecognizer.ShouldExtractSpecialRemarks(); 
            set => nativeRecognizer.SetExtractSpecialRemarks(value);
        }
        
        public bool ExtractSurnameAtBirth 
        { 
            get => nativeRecognizer.ShouldExtractSurnameAtBirth(); 
            set => nativeRecognizer.SetExtractSurnameAtBirth(value);
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

    public sealed class SlovakiaIdBackRecognizerResult : RecognizerResult, ISlovakiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer.Result nativeResult;

        internal SlovakiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string SpecialRemarks => nativeResult.SpecialRemarks;
        public string SurnameAtBirth => nativeResult.SurnameAtBirth;
    }
}