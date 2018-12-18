using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaMyKasFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MalaysiaMyKasFrontRecognizer : Recognizer, IMalaysiaMyKasFrontRecognizer
    {
        MBMalaysiaMyKasFrontRecognizer nativeRecognizer;

        MalaysiaMyKasFrontRecognizerResult result;

        public MalaysiaMyKasFrontRecognizer() : base(new MBMalaysiaMyKasFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMalaysiaMyKasFrontRecognizer;
            result = new MalaysiaMyKasFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaMyKasFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractFullNameAndAddress 
        { 
            get => nativeRecognizer.ExtractFullNameAndAddress; 
            set => nativeRecognizer.ExtractFullNameAndAddress = value;
        }
        
        public bool ExtractReligion 
        { 
            get => nativeRecognizer.ExtractReligion; 
            set => nativeRecognizer.ExtractReligion = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
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

    public sealed class MalaysiaMyKasFrontRecognizerResult : RecognizerResult, IMalaysiaMyKasFrontRecognizerResult
    {
        MBMalaysiaMyKasFrontRecognizerResult nativeResult;

        internal MalaysiaMyKasFrontRecognizerResult(MBMalaysiaMyKasFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate != null ? new Date(nativeResult.BirthDate) : null;
        public string City => nativeResult.City;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FullAddress => nativeResult.FullAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string FullName => nativeResult.FullName;
        public string Nric => nativeResult.Nric;
        public string OwnerState => nativeResult.OwnerState;
        public string Religion => nativeResult.Religion;
        public string Sex => nativeResult.Sex;
        public string Street => nativeResult.Street;
        public string Zipcode => nativeResult.Zipcode;
    }
}