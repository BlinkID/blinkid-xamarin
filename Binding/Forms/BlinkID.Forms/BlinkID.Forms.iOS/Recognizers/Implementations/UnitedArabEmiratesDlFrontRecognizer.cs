using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UnitedArabEmiratesDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class UnitedArabEmiratesDlFrontRecognizer : Recognizer, IUnitedArabEmiratesDlFrontRecognizer
    {
        MBUnitedArabEmiratesDlFrontRecognizer nativeRecognizer;

        UnitedArabEmiratesDlFrontRecognizerResult result;

        public UnitedArabEmiratesDlFrontRecognizer() : base(new MBUnitedArabEmiratesDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBUnitedArabEmiratesDlFrontRecognizer;
            result = new UnitedArabEmiratesDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUnitedArabEmiratesDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractIssueDate 
        { 
            get => nativeRecognizer.ExtractIssueDate; 
            set => nativeRecognizer.ExtractIssueDate = value;
        }
        
        public bool ExtractLicenseNumber 
        { 
            get => nativeRecognizer.ExtractLicenseNumber; 
            set => nativeRecognizer.ExtractLicenseNumber = value;
        }
        
        public bool ExtractLicensingAuthority 
        { 
            get => nativeRecognizer.ExtractLicensingAuthority; 
            set => nativeRecognizer.ExtractLicensingAuthority = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ExtractNationality; 
            set => nativeRecognizer.ExtractNationality = value;
        }
        
        public bool ExtractPlaceOfIssue 
        { 
            get => nativeRecognizer.ExtractPlaceOfIssue; 
            set => nativeRecognizer.ExtractPlaceOfIssue = value;
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
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
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ReturnFaceImage; 
            set => nativeRecognizer.ReturnFaceImage = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class UnitedArabEmiratesDlFrontRecognizerResult : RecognizerResult, IUnitedArabEmiratesDlFrontRecognizerResult
    {
        MBUnitedArabEmiratesDlFrontRecognizerResult nativeResult;

        internal UnitedArabEmiratesDlFrontRecognizerResult(MBUnitedArabEmiratesDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IDate IssueDate => nativeResult.IssueDate != null ? new Date(nativeResult.IssueDate) : null;
        public string LicenseNumber => nativeResult.LicenseNumber;
        public string LicensingAuthority => nativeResult.LicensingAuthority;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string PlaceOfIssue => nativeResult.PlaceOfIssue;
    }
}