using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaMyKadFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MalaysiaMyKadFrontRecognizer : Recognizer, IMalaysiaMyKadFrontRecognizer
    {
        MBMalaysiaMyKadFrontRecognizer nativeRecognizer;

        MalaysiaMyKadFrontRecognizerResult result;

        public MalaysiaMyKadFrontRecognizer() : base(new MBMalaysiaMyKadFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMalaysiaMyKadFrontRecognizer;
            result = new MalaysiaMyKadFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaMyKadFrontRecognizerResult Result => result;

        
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

    public sealed class MalaysiaMyKadFrontRecognizerResult : RecognizerResult, IMalaysiaMyKadFrontRecognizerResult
    {
        MBMalaysiaMyKadFrontRecognizerResult nativeResult;

        internal MalaysiaMyKadFrontRecognizerResult(MBMalaysiaMyKadFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate != null ? new Date(nativeResult.BirthDate) : null;
        public string City => nativeResult.City;
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