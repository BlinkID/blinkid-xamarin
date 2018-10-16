using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UnitedArabEmiratesDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class UnitedArabEmiratesDlFrontRecognizer : Recognizer, IUnitedArabEmiratesDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesDlFrontRecognizer nativeRecognizer;

        UnitedArabEmiratesDlFrontRecognizerResult result;

        public UnitedArabEmiratesDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesDlFrontRecognizer;
            result = new UnitedArabEmiratesDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUnitedArabEmiratesDlFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractIssueDate 
        { 
            get => nativeRecognizer.ShouldExtractIssueDate(); 
            set => nativeRecognizer.SetExtractIssueDate(value);
        }
        
        public bool ExtractLicenseNumber 
        { 
            get => nativeRecognizer.ShouldExtractLicenseNumber(); 
            set => nativeRecognizer.SetExtractLicenseNumber(value);
        }
        
        public bool ExtractLicensingAuthority 
        { 
            get => nativeRecognizer.ShouldExtractLicensingAuthority(); 
            set => nativeRecognizer.SetExtractLicensingAuthority(value);
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
        
        public bool ExtractPlaceOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfIssue(); 
            set => nativeRecognizer.SetExtractPlaceOfIssue(value);
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

    public sealed class UnitedArabEmiratesDlFrontRecognizerResult : RecognizerResult, IUnitedArabEmiratesDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesDlFrontRecognizer.Result nativeResult;

        internal UnitedArabEmiratesDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.UnitedArabEmirates.UnitedArabEmiratesDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate ExpiryDate => nativeResult.ExpiryDate.Date != null ? new Date(nativeResult.ExpiryDate.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IDate IssueDate => nativeResult.IssueDate.Date != null ? new Date(nativeResult.IssueDate.Date) : null;
        public string LicenseNumber => nativeResult.LicenseNumber;
        public string LicensingAuthority => nativeResult.LicensingAuthority;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string PlaceOfIssue => nativeResult.PlaceOfIssue;
    }
}