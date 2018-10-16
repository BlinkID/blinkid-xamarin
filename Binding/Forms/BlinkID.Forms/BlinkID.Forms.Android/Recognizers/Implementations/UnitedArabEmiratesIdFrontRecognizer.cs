using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UnitedArabEmiratesIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class UnitedArabEmiratesIdFrontRecognizer : Recognizer, IUnitedArabEmiratesIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdFrontRecognizer nativeRecognizer;

        UnitedArabEmiratesIdFrontRecognizerResult result;

        public UnitedArabEmiratesIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdFrontRecognizer;
            result = new UnitedArabEmiratesIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUnitedArabEmiratesIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ShouldExtractName(); 
            set => nativeRecognizer.SetExtractName(value);
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ShouldExtractNationality(); 
            set => nativeRecognizer.SetExtractNationality(value);
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

    public sealed class UnitedArabEmiratesIdFrontRecognizerResult : RecognizerResult, IUnitedArabEmiratesIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdFrontRecognizer.Result nativeResult;

        internal UnitedArabEmiratesIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IdNumber => nativeResult.IdNumber;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
    }
}