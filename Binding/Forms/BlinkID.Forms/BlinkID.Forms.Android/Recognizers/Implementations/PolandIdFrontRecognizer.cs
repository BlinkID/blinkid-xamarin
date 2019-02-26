using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PolandIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class PolandIdFrontRecognizer : Recognizer, IPolandIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdFrontRecognizer nativeRecognizer;

        PolandIdFrontRecognizerResult result;

        public PolandIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdFrontRecognizer;
            result = new PolandIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPolandIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractFamilyName 
        { 
            get => nativeRecognizer.ShouldExtractFamilyName(); 
            set => nativeRecognizer.SetExtractFamilyName(value);
        }
        
        public bool ExtractGivenNames 
        { 
            get => nativeRecognizer.ShouldExtractGivenNames(); 
            set => nativeRecognizer.SetExtractGivenNames(value);
        }
        
        public bool ExtractParentsGivenNames 
        { 
            get => nativeRecognizer.ShouldExtractParentsGivenNames(); 
            set => nativeRecognizer.SetExtractParentsGivenNames(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
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

    public sealed class PolandIdFrontRecognizerResult : RecognizerResult, IPolandIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdFrontRecognizer.Result nativeResult;

        internal PolandIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FamilyName => nativeResult.FamilyName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string GivenNames => nativeResult.GivenNames;
        public string ParentsGivenNames => nativeResult.ParentsGivenNames;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}