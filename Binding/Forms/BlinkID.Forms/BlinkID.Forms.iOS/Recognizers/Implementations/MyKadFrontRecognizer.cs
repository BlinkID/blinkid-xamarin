using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MyKadFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MyKadFrontRecognizer : Recognizer, IMyKadFrontRecognizer
    {
        MBMyKadFrontRecognizer nativeRecognizer;

        MyKadFrontRecognizerResult result;

        public MyKadFrontRecognizer() : base(new MBMyKadFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMyKadFrontRecognizer;
            result = new MyKadFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMyKadFrontRecognizerResult Result => result;

        
        public bool ExtractArmyNumber 
        { 
            get => nativeRecognizer.ExtractArmyNumber; 
            set => nativeRecognizer.ExtractArmyNumber = value;
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

    public sealed class MyKadFrontRecognizerResult : RecognizerResult, IMyKadFrontRecognizerResult
    {
        MBMyKadFrontRecognizerResult nativeResult;

        internal MyKadFrontRecognizerResult(MBMyKadFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string ArmyNumber => nativeResult.ArmyNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
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