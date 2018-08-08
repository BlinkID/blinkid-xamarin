using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MyTenteraRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MyTenteraRecognizer : Recognizer, IMyTenteraRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyTenteraRecognizer nativeRecognizer;

        MyTenteraRecognizerResult result;

        public MyTenteraRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyTenteraRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyTenteraRecognizer;
            result = new MyTenteraRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyTenteraRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMyTenteraRecognizerResult Result => result;

        
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

    public sealed class MyTenteraRecognizerResult : RecognizerResult, IMyTenteraRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyTenteraRecognizer.Result nativeResult;

        internal MyTenteraRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyTenteraRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string ArmyNumber => nativeResult.ArmyNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string NricNumber => nativeResult.NricNumber;
        public string OwnerAddress => nativeResult.OwnerAddress;
        public string OwnerAddressCity => nativeResult.OwnerAddressCity;
        public string OwnerAddressState => nativeResult.OwnerAddressState;
        public string OwnerAddressStreet => nativeResult.OwnerAddressStreet;
        public string OwnerAddressZipCode => nativeResult.OwnerAddressZipCode;
        public IDate OwnerBirthDate => nativeResult.OwnerBirthDate != null ? new Date(nativeResult.OwnerBirthDate) : null;
        public string OwnerFullName => nativeResult.OwnerFullName;
        public string OwnerReligion => nativeResult.OwnerReligion;
        public string OwnerSex => nativeResult.OwnerSex;
    }
}