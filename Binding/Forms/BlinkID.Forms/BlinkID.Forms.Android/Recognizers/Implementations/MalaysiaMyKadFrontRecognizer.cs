using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaMyKadFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MalaysiaMyKadFrontRecognizer : Recognizer, IMalaysiaMyKadFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadFrontRecognizer nativeRecognizer;

        MalaysiaMyKadFrontRecognizerResult result;

        public MalaysiaMyKadFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadFrontRecognizer;
            result = new MalaysiaMyKadFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaMyKadFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractFullNameAndAddress 
        { 
            get => nativeRecognizer.ShouldExtractFullNameAndAddress(); 
            set => nativeRecognizer.SetExtractFullNameAndAddress(value);
        }
        
        public bool ExtractReligion 
        { 
            get => nativeRecognizer.ShouldExtractReligion(); 
            set => nativeRecognizer.SetExtractReligion(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
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

    public sealed class MalaysiaMyKadFrontRecognizerResult : RecognizerResult, IMalaysiaMyKadFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadFrontRecognizer.Result nativeResult;

        internal MalaysiaMyKadFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate.Date != null ? new Date(nativeResult.BirthDate.Date) : null;
        public string City => nativeResult.City;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FullAddress => nativeResult.FullAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public string Nric => nativeResult.Nric;
        public string OwnerState => nativeResult.OwnerState;
        public string Religion => nativeResult.Religion;
        public string Sex => nativeResult.Sex;
        public string Street => nativeResult.Street;
        public string Zipcode => nativeResult.Zipcode;
    }
}