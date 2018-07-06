using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(PolandIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class PolandIdBackRecognizer : Recognizer, IPolandIdBackRecognizer
    {
        MBPolandIdBackRecognizer nativeRecognizer;

        PolandIdBackRecognizerResult result;

        public PolandIdBackRecognizer() : base(new MBPolandIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBPolandIdBackRecognizer;
            result = new PolandIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPolandIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class PolandIdBackRecognizerResult : RecognizerResult, IPolandIdBackRecognizerResult
    {
        MBPolandIdBackRecognizerResult nativeResult;

        internal PolandIdBackRecognizerResult(MBPolandIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
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
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
    }
}