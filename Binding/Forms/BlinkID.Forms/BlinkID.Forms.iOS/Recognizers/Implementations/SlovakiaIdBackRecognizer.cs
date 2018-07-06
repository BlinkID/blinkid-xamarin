using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SlovakiaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SlovakiaIdBackRecognizer : Recognizer, ISlovakiaIdBackRecognizer
    {
        MBSlovakiaIdBackRecognizer nativeRecognizer;

        SlovakiaIdBackRecognizerResult result;

        public SlovakiaIdBackRecognizer() : base(new MBSlovakiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSlovakiaIdBackRecognizer;
            result = new SlovakiaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISlovakiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ExtractPlaceOfBirth; 
            set => nativeRecognizer.ExtractPlaceOfBirth = value;
        }
        
        public bool ExtractSpecialRemarks 
        { 
            get => nativeRecognizer.ExtractSpecialRemarks; 
            set => nativeRecognizer.ExtractSpecialRemarks = value;
        }
        
        public bool ExtractSurnameAtBirth 
        { 
            get => nativeRecognizer.ExtractSurnameAtBirth; 
            set => nativeRecognizer.ExtractSurnameAtBirth = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class SlovakiaIdBackRecognizerResult : RecognizerResult, ISlovakiaIdBackRecognizerResult
    {
        MBSlovakiaIdBackRecognizerResult nativeResult;

        internal SlovakiaIdBackRecognizerResult(MBSlovakiaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
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
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
        public string SpecialRemarks => nativeResult.SpecialRemarks;
        public string SurnameAtBirth => nativeResult.SurnameAtBirth;
    }
}