using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PolandIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class PolandIdBackRecognizer : Recognizer, IPolandIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer nativeRecognizer;

        PolandIdBackRecognizerResult result;

        public PolandIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer;
            result = new PolandIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPolandIdBackRecognizerResult Result => result;

        
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

    public sealed class PolandIdBackRecognizerResult : RecognizerResult, IPolandIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer.Result nativeResult;

        internal PolandIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Poland.PolandIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
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
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}