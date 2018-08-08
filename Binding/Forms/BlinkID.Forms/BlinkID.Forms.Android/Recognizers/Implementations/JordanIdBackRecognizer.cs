using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(JordanIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class JordanIdBackRecognizer : Recognizer, IJordanIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer nativeRecognizer;

        JordanIdBackRecognizerResult result;

        public JordanIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer;
            result = new JordanIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IJordanIdBackRecognizerResult Result => result;

        
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

    public sealed class JordanIdBackRecognizerResult : RecognizerResult, IJordanIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer.Result nativeResult;

        internal JordanIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer.Result nativeResult) : base(nativeResult)
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