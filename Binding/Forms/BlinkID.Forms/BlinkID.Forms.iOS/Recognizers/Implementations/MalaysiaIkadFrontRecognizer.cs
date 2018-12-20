using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaIkadFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MalaysiaIkadFrontRecognizer : Recognizer, IMalaysiaIkadFrontRecognizer
    {
        MBMalaysiaIkadFrontRecognizer nativeRecognizer;

        MalaysiaIkadFrontRecognizerResult result;

        public MalaysiaIkadFrontRecognizer() : base(new MBMalaysiaIkadFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMalaysiaIkadFrontRecognizer;
            result = new MalaysiaIkadFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaIkadFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ExtractAddress; 
            set => nativeRecognizer.ExtractAddress = value;
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractEmployer 
        { 
            get => nativeRecognizer.ExtractEmployer; 
            set => nativeRecognizer.ExtractEmployer = value;
        }
        
        public bool ExtractFacultyAddress 
        { 
            get => nativeRecognizer.ExtractFacultyAddress; 
            set => nativeRecognizer.ExtractFacultyAddress = value;
        }
        
        public bool ExtractGender 
        { 
            get => nativeRecognizer.ExtractGender; 
            set => nativeRecognizer.ExtractGender = value;
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
        
        public bool ExtractPassportNumber 
        { 
            get => nativeRecognizer.ExtractPassportNumber; 
            set => nativeRecognizer.ExtractPassportNumber = value;
        }
        
        public bool ExtractSector 
        { 
            get => nativeRecognizer.ExtractSector; 
            set => nativeRecognizer.ExtractSector = value;
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

    public sealed class MalaysiaIkadFrontRecognizerResult : RecognizerResult, IMalaysiaIkadFrontRecognizerResult
    {
        MBMalaysiaIkadFrontRecognizerResult nativeResult;

        internal MalaysiaIkadFrontRecognizerResult(MBMalaysiaIkadFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public string Employer => nativeResult.Employer;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FacultyAddress => nativeResult.FacultyAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Gender => nativeResult.Gender;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string PassportNumber => nativeResult.PassportNumber;
        public string Sector => nativeResult.Sector;
    }
}