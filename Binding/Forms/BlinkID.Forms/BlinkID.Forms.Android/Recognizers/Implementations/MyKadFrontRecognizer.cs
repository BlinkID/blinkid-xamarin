using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MyKadFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MyKadFrontRecognizer : Recognizer, IMyKadFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyKadFrontRecognizer nativeRecognizer;

        MyKadFrontRecognizerResult result;

        public MyKadFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyKadFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyKadFrontRecognizer;
            result = new MyKadFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyKadFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMyKadFrontRecognizerResult Result => result;

        
        public bool ExtractArmyNumber 
        { 
            get => nativeRecognizer.ShouldExtractArmyNumber(); 
            set => nativeRecognizer.SetExtractArmyNumber(value);
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

    public sealed class MyKadFrontRecognizerResult : RecognizerResult, IMyKadFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyKadFrontRecognizer.Result nativeResult;

        internal MyKadFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MyKadFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string ArmyNumber => nativeResult.ArmyNumber;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
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