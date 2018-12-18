using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaIkadFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MalaysiaIkadFrontRecognizer : Recognizer, IMalaysiaIkadFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaIkadFrontRecognizer nativeRecognizer;

        MalaysiaIkadFrontRecognizerResult result;

        public MalaysiaIkadFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaIkadFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaIkadFrontRecognizer;
            result = new MalaysiaIkadFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaIkadFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaIkadFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractEmployer 
        { 
            get => nativeRecognizer.ShouldExtractEmployer(); 
            set => nativeRecognizer.SetExtractEmployer(value);
        }
        
        public bool ExtractFacultyAddress 
        { 
            get => nativeRecognizer.ShouldExtractFacultyAddress(); 
            set => nativeRecognizer.SetExtractFacultyAddress(value);
        }
        
        public bool ExtractGender 
        { 
            get => nativeRecognizer.ShouldExtractGender(); 
            set => nativeRecognizer.SetExtractGender(value);
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
        
        public bool ExtractPassportNumber 
        { 
            get => nativeRecognizer.ShouldExtractPassportNumber(); 
            set => nativeRecognizer.SetExtractPassportNumber(value);
        }
        
        public bool ExtractSector 
        { 
            get => nativeRecognizer.ShouldExtractSector(); 
            set => nativeRecognizer.SetExtractSector(value);
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

    public sealed class MalaysiaIkadFrontRecognizerResult : RecognizerResult, IMalaysiaIkadFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaIkadFrontRecognizer.Result nativeResult;

        internal MalaysiaIkadFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaIkadFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public string Employer => nativeResult.Employer;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FacultyAddress => nativeResult.FacultyAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Gender => nativeResult.Gender;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string PassportNumber => nativeResult.PassportNumber;
        public string Sector => nativeResult.Sector;
    }
}