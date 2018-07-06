using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CzechiaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class CzechiaIdBackRecognizer : Recognizer, ICzechiaIdBackRecognizer
    {
        MBCzechiaIdBackRecognizer nativeRecognizer;

        CzechiaIdBackRecognizerResult result;

        public CzechiaIdBackRecognizer() : base(new MBCzechiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCzechiaIdBackRecognizer;
            result = new CzechiaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICzechiaIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractPermanentStay 
        { 
            get => nativeRecognizer.ExtractPermanentStay; 
            set => nativeRecognizer.ExtractPermanentStay = value;
        }
        
        public bool ExtractPersonalNumber 
        { 
            get => nativeRecognizer.ExtractPersonalNumber; 
            set => nativeRecognizer.ExtractPersonalNumber = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class CzechiaIdBackRecognizerResult : RecognizerResult, ICzechiaIdBackRecognizerResult
    {
        MBCzechiaIdBackRecognizerResult nativeResult;

        internal CzechiaIdBackRecognizerResult(MBCzechiaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
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
        public string PermanentStay => nativeResult.PermanentStay;
        public string PersonalNumber => nativeResult.PersonalNumber;
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}