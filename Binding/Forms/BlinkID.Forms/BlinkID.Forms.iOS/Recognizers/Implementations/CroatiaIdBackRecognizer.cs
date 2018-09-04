using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CroatiaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class CroatiaIdBackRecognizer : Recognizer, ICroatiaIdBackRecognizer
    {
        MBCroatiaIdBackRecognizer nativeRecognizer;

        CroatiaIdBackRecognizerResult result;

        public CroatiaIdBackRecognizer() : base(new MBCroatiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCroatiaIdBackRecognizer;
            result = new CroatiaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICroatiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
        }
        
        public bool ExtractIssuedBy 
        { 
            get => nativeRecognizer.ExtractIssuedBy; 
            set => nativeRecognizer.ExtractIssuedBy = value;
        }
        
        public bool ExtractResidence 
        { 
            get => nativeRecognizer.ExtractResidence; 
            set => nativeRecognizer.ExtractResidence = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class CroatiaIdBackRecognizerResult : RecognizerResult, ICroatiaIdBackRecognizerResult
    {
        MBCroatiaIdBackRecognizerResult nativeResult;

        internal CroatiaIdBackRecognizerResult(MBCroatiaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public bool DateOfExpiryPermanent => nativeResult.DateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public bool DocumentForNonResident => nativeResult.DocumentForNonResident;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IssuedBy => nativeResult.IssuedBy;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Residence => nativeResult.Residence;
    }
}