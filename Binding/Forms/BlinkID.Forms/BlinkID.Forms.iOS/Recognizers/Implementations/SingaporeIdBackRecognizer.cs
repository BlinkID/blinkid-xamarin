using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SingaporeIdBackRecognizer : Recognizer, ISingaporeIdBackRecognizer
    {
        MBSingaporeIdBackRecognizer nativeRecognizer;

        SingaporeIdBackRecognizerResult result;

        public SingaporeIdBackRecognizer() : base(new MBSingaporeIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSingaporeIdBackRecognizer;
            result = new SingaporeIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractAddressChangeDate 
        { 
            get => nativeRecognizer.ExtractAddressChangeDate; 
            set => nativeRecognizer.ExtractAddressChangeDate = value;
        }
        
        public bool ExtractBloodType 
        { 
            get => nativeRecognizer.ExtractBloodType; 
            set => nativeRecognizer.ExtractBloodType = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class SingaporeIdBackRecognizerResult : RecognizerResult, ISingaporeIdBackRecognizerResult
    {
        MBSingaporeIdBackRecognizerResult nativeResult;

        internal SingaporeIdBackRecognizerResult(MBSingaporeIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate AddressChangeDate => nativeResult.AddressChangeDate != null ? new Date(nativeResult.AddressChangeDate) : null;
        public string BloodType => nativeResult.BloodType;
        public string CardNumber => nativeResult.CardNumber;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
    }
}