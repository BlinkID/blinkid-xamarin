using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(IkadRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class IkadRecognizer : Recognizer, IIkadRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.IkadRecognizer nativeRecognizer;

        IkadRecognizerResult result;

        public IkadRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.IkadRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.IkadRecognizer;
            result = new IkadRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.IkadRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IIkadRecognizerResult Result => result;

        
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
        
        public bool ExtractEmployer 
        { 
            get => nativeRecognizer.ShouldExtractEmployer(); 
            set => nativeRecognizer.SetExtractEmployer(value);
        }
        
        public bool ExtractExpiryDate 
        { 
            get => nativeRecognizer.ShouldExtractExpiryDate(); 
            set => nativeRecognizer.SetExtractExpiryDate(value);
        }
        
        public bool ExtractFacultyAddress 
        { 
            get => nativeRecognizer.ShouldExtractFacultyAddress(); 
            set => nativeRecognizer.SetExtractFacultyAddress(value);
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
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
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

    public sealed class IkadRecognizerResult : RecognizerResult, IIkadRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.IkadRecognizer.Result nativeResult;

        internal IkadRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.IkadRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public string Employer => nativeResult.Employer;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FacultyAddress => nativeResult.FacultyAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string PassportNumber => nativeResult.PassportNumber;
        public string Sector => nativeResult.Sector;
        public string Sex => nativeResult.Sex;
    }
}