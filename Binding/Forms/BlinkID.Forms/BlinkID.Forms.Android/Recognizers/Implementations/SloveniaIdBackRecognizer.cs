using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SloveniaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SloveniaIdBackRecognizer : Recognizer, ISloveniaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer nativeRecognizer;

        SloveniaIdBackRecognizerResult result;

        public SloveniaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer;
            result = new SloveniaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISloveniaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ShouldExtractAuthority(); 
            set => nativeRecognizer.SetExtractAuthority(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class SloveniaIdBackRecognizerResult : RecognizerResult, ISloveniaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer.Result nativeResult;

        internal SloveniaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer.Result nativeResult) : base(nativeResult)
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
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Issuer => nativeResult.Issuer;
        public bool MrzParsed => nativeResult.IsMrzParsed;
        public string MrzText => nativeResult.MrzText;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string Opt1 => nativeResult.Opt1;
        public string Opt2 => nativeResult.Opt2;
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}