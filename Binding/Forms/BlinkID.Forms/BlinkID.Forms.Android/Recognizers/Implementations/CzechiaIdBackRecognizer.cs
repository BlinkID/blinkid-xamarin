using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CzechiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CzechiaIdBackRecognizer : Recognizer, ICzechiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer nativeRecognizer;

        CzechiaIdBackRecognizerResult result;

        public CzechiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer;
            result = new CzechiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICzechiaIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractPermanentStay 
        { 
            get => nativeRecognizer.ShouldExtractPermanentStay(); 
            set => nativeRecognizer.SetExtractPermanentStay(value);
        }
        
        public bool ExtractPersonalNumber 
        { 
            get => nativeRecognizer.ShouldExtractPersonalNumber(); 
            set => nativeRecognizer.SetExtractPersonalNumber(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class CzechiaIdBackRecognizerResult : RecognizerResult, ICzechiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer.Result nativeResult;

        internal CzechiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public string DocumentCode => nativeResult.DocumentCode;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string Issuer => nativeResult.Issuer;
        public bool MrzParsed => nativeResult.IsMrzParsed;
        public string MrzText => nativeResult.MrzText;
        public bool MrzVerified => nativeResult.IsMrzVerified;
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