using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SloveniaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SloveniaIdBackRecognizer : Recognizer, ISloveniaIdBackRecognizer
    {
        MBSloveniaIdBackRecognizer nativeRecognizer;

        SloveniaIdBackRecognizerResult result;

        public SloveniaIdBackRecognizer() : base(new MBSloveniaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSloveniaIdBackRecognizer;
            result = new SloveniaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISloveniaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ExtractAuthority; 
            set => nativeRecognizer.ExtractAuthority = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class SloveniaIdBackRecognizerResult : RecognizerResult, ISloveniaIdBackRecognizerResult
    {
        MBSloveniaIdBackRecognizerResult nativeResult;

        internal SloveniaIdBackRecognizerResult(MBSloveniaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string Authority => nativeResult.Authority;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DocumentCode => nativeResult.DocumentCode;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Issuer => nativeResult.Issuer;
        public bool MrzParsed => nativeResult.MrzParsed;
        public string MrzText => nativeResult.MrzText;
        public bool MrzVerified => nativeResult.MrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string Opt1 => nativeResult.Opt1;
        public string Opt2 => nativeResult.Opt2;
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}