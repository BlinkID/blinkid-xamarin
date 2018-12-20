using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwitzerlandPassportRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SwitzerlandPassportRecognizer : Recognizer, ISwitzerlandPassportRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandPassportRecognizer nativeRecognizer;

        SwitzerlandPassportRecognizerResult result;

        public SwitzerlandPassportRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandPassportRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandPassportRecognizer;
            result = new SwitzerlandPassportRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandPassportRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwitzerlandPassportRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ShouldExtractAuthority(); 
            set => nativeRecognizer.SetExtractAuthority(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractGivenName 
        { 
            get => nativeRecognizer.ShouldExtractGivenName(); 
            set => nativeRecognizer.SetExtractGivenName(value);
        }
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ShouldExtractHeight(); 
            set => nativeRecognizer.SetExtractHeight(value);
        }
        
        public bool ExtractPassportNumber 
        { 
            get => nativeRecognizer.ShouldExtractPassportNumber(); 
            set => nativeRecognizer.SetExtractPassportNumber(value);
        }
        
        public bool ExtractPlaceOfOrigin 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfOrigin(); 
            set => nativeRecognizer.SetExtractPlaceOfOrigin(value);
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

    public sealed class SwitzerlandPassportRecognizerResult : RecognizerResult, ISwitzerlandPassportRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandPassportRecognizer.Result nativeResult;

        internal SwitzerlandPassportRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandPassportRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string GivenName => nativeResult.GivenName;
        public string Height => nativeResult.Height;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PassportNumber => nativeResult.PassportNumber;
        public string PlaceOfOrigin => nativeResult.PlaceOfOrigin;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}