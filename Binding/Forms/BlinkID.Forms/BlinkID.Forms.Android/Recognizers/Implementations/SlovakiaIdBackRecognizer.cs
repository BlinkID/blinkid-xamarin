using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SlovakiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SlovakiaIdBackRecognizer : Recognizer, ISlovakiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer nativeRecognizer;

        SlovakiaIdBackRecognizerResult result;

        public SlovakiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer;
            result = new SlovakiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISlovakiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractSpecialRemarks 
        { 
            get => nativeRecognizer.ShouldExtractSpecialRemarks(); 
            set => nativeRecognizer.SetExtractSpecialRemarks(value);
        }
        
        public bool ExtractSurnameAtBirth 
        { 
            get => nativeRecognizer.ShouldExtractSurnameAtBirth(); 
            set => nativeRecognizer.SetExtractSurnameAtBirth(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class SlovakiaIdBackRecognizerResult : RecognizerResult, ISlovakiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer.Result nativeResult;

        internal SlovakiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
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
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
        public string SpecialRemarks => nativeResult.SpecialRemarks;
        public string SurnameAtBirth => nativeResult.SurnameAtBirth;
    }
}