using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(IkadRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class IkadRecognizer : Recognizer, IIkadRecognizer
    {
        MBIkadRecognizer nativeRecognizer;

        IkadRecognizerResult result;

        public IkadRecognizer() : base(new MBIkadRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBIkadRecognizer;
            result = new IkadRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IIkadRecognizerResult Result => result;

        
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
        
        public bool ExtractEmployer 
        { 
            get => nativeRecognizer.ExtractEmployer; 
            set => nativeRecognizer.ExtractEmployer = value;
        }
        
        public bool ExtractExpiryDate 
        { 
            get => nativeRecognizer.ExtractExpiryDate; 
            set => nativeRecognizer.ExtractExpiryDate = value;
        }
        
        public bool ExtractFacultyAddress 
        { 
            get => nativeRecognizer.ExtractFacultyAddress; 
            set => nativeRecognizer.ExtractFacultyAddress = value;
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
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
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

    public sealed class IkadRecognizerResult : RecognizerResult, IIkadRecognizerResult
    {
        MBIkadRecognizerResult nativeResult;

        internal IkadRecognizerResult(MBIkadRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public string Employer => nativeResult.Employer;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FacultyAddress => nativeResult.FacultyAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string PassportNumber => nativeResult.PassportNumber;
        public string Sector => nativeResult.Sector;
        public string Sex => nativeResult.Sex;
    }
}