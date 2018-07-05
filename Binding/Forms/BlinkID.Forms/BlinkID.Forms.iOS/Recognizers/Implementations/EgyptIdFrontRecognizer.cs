using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(EgyptIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class EgyptIdFrontRecognizer : Recognizer, IEgyptIdFrontRecognizer
    {
        MBEgyptIdFrontRecognizer nativeRecognizer;

        EgyptIdFrontRecognizerResult result;

        public EgyptIdFrontRecognizer() : base(new MBEgyptIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBEgyptIdFrontRecognizer;
            result = new EgyptIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IEgyptIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractNationalNumber 
        { 
            get => nativeRecognizer.ExtractNationalNumber; 
            set => nativeRecognizer.ExtractNationalNumber = value;
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
        
    }

    public sealed class EgyptIdFrontRecognizerResult : RecognizerResult, IEgyptIdFrontRecognizerResult
    {
        MBEgyptIdFrontRecognizerResult nativeResult;

        internal EgyptIdFrontRecognizerResult(MBEgyptIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string NationalNumber => nativeResult.NationalNumber;
    }
}