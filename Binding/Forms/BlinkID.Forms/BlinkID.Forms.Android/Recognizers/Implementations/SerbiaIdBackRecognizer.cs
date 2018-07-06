using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SerbiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SerbiaIdBackRecognizer : Recognizer, ISerbiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdBackRecognizer nativeRecognizer;

        SerbiaIdBackRecognizerResult result;

        public SerbiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdBackRecognizer;
            result = new SerbiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISerbiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class SerbiaIdBackRecognizerResult : RecognizerResult, ISerbiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdBackRecognizer.Result nativeResult;

        internal SerbiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
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
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}