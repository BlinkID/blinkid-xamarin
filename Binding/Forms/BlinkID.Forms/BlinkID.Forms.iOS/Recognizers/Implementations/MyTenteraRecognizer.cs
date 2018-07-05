using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MyTenteraRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MyTenteraRecognizer : Recognizer, IMyTenteraRecognizer
    {
        MBMyTenteraRecognizer nativeRecognizer;

        MyTenteraRecognizerResult result;

        public MyTenteraRecognizer() : base(new MBMyTenteraRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMyTenteraRecognizer;
            result = new MyTenteraRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMyTenteraRecognizerResult Result => result;

        
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

    public sealed class MyTenteraRecognizerResult : RecognizerResult, IMyTenteraRecognizerResult
    {
        MBMyTenteraRecognizerResult nativeResult;

        internal MyTenteraRecognizerResult(MBMyTenteraRecognizerResult nativeResult) : base(nativeResult)
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