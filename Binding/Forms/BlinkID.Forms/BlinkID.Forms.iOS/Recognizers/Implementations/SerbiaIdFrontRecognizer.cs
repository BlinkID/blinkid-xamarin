using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SerbiaIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SerbiaIdFrontRecognizer : Recognizer, ISerbiaIdFrontRecognizer
    {
        MBSerbiaIdFrontRecognizer nativeRecognizer;

        SerbiaIdFrontRecognizerResult result;

        public SerbiaIdFrontRecognizer() : base(new MBSerbiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSerbiaIdFrontRecognizer;
            result = new SerbiaIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISerbiaIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractIssuingDate 
        { 
            get => nativeRecognizer.ExtractIssuingDate; 
            set => nativeRecognizer.ExtractIssuingDate = value;
        }
        
        public bool ExtractValidUntil 
        { 
            get => nativeRecognizer.ExtractValidUntil; 
            set => nativeRecognizer.ExtractValidUntil = value;
        }
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ReturnFaceImage; 
            set => nativeRecognizer.ReturnFaceImage = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ReturnSignatureImage; 
            set => nativeRecognizer.ReturnSignatureImage = value;
        }
        
    }

    public sealed class SerbiaIdFrontRecognizerResult : RecognizerResult, ISerbiaIdFrontRecognizerResult
    {
        MBSerbiaIdFrontRecognizerResult nativeResult;

        internal SerbiaIdFrontRecognizerResult(MBSerbiaIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IDate IssuingDate => nativeResult.IssuingDate != null ? new Date(nativeResult.IssuingDate) : null;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public IDate ValidUntil => nativeResult.ValidUntil != null ? new Date(nativeResult.ValidUntil) : null;
    }
}