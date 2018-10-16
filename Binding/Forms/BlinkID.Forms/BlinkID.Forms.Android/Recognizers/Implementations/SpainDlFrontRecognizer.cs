using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SpainDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SpainDlFrontRecognizer : Recognizer, ISpainDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Spain.SpainDlFrontRecognizer nativeRecognizer;

        SpainDlFrontRecognizerResult result;

        public SpainDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Spain.SpainDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Spain.SpainDlFrontRecognizer;
            result = new SpainDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Spain.SpainDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISpainDlFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractFirstName 
        { 
            get => nativeRecognizer.ShouldExtractFirstName(); 
            set => nativeRecognizer.SetExtractFirstName(value);
        }
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ShouldExtractIssuingAuthority(); 
            set => nativeRecognizer.SetExtractIssuingAuthority(value);
        }
        
        public bool ExtractLicenceCategories 
        { 
            get => nativeRecognizer.ShouldExtractLicenceCategories(); 
            set => nativeRecognizer.SetExtractLicenceCategories(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
        }
        
        public bool ExtractValidFrom 
        { 
            get => nativeRecognizer.ShouldExtractValidFrom(); 
            set => nativeRecognizer.SetExtractValidFrom(value);
        }
        
        public bool ExtractValidUntil 
        { 
            get => nativeRecognizer.ShouldExtractValidUntil(); 
            set => nativeRecognizer.SetExtractValidUntil(value);
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
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ShouldReturnSignatureImage(); 
            set => nativeRecognizer.SetReturnSignatureImage(value);
        }
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = (int)value;
        }
        
    }

    public sealed class SpainDlFrontRecognizerResult : RecognizerResult, ISpainDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Spain.SpainDlFrontRecognizer.Result nativeResult;

        internal SpainDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Spain.SpainDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LicenceCategories => nativeResult.LicenceCategories;
        public string Number => nativeResult.Number;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
        public string Surname => nativeResult.Surname;
        public IDate ValidFrom => nativeResult.ValidFrom.Date != null ? new Date(nativeResult.ValidFrom.Date) : null;
        public IDate ValidUntil => nativeResult.ValidUntil.Date != null ? new Date(nativeResult.ValidUntil.Date) : null;
    }
}