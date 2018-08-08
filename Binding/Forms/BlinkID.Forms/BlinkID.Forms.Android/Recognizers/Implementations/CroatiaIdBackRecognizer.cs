using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CroatiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CroatiaIdBackRecognizer : Recognizer, ICroatiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer nativeRecognizer;

        CroatiaIdBackRecognizerResult result;

        public CroatiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer;
            result = new CroatiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICroatiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ShouldExtractIssuingAuthority(); 
            set => nativeRecognizer.SetExtractIssuingAuthority(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class CroatiaIdBackRecognizerResult : RecognizerResult, ICroatiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer.Result nativeResult;

        internal CroatiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public bool DateOfExpiryPermanent => nativeResult.DateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DocumentCode => nativeResult.DocumentCode;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Issuer => nativeResult.Issuer;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
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