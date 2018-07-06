using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SerbiaIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SerbiaIdFrontRecognizer : Recognizer, ISerbiaIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdFrontRecognizer nativeRecognizer;

        SerbiaIdFrontRecognizerResult result;

        public SerbiaIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdFrontRecognizer;
            result = new SerbiaIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISerbiaIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractIssuingDate 
        { 
            get => nativeRecognizer.ShouldExtractIssuingDate(); 
            set => nativeRecognizer.SetExtractIssuingDate(value);
        }
        
        public bool ExtractValidUntil 
        { 
            get => nativeRecognizer.ShouldExtractValidUntil(); 
            set => nativeRecognizer.SetExtractValidUntil(value);
        }
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ShouldReturnFaceImage(); 
            set => nativeRecognizer.SetReturnFaceImage(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ShouldReturnSignatureImage(); 
            set => nativeRecognizer.SetReturnSignatureImage(value);
        }
        
    }

    public sealed class SerbiaIdFrontRecognizerResult : RecognizerResult, ISerbiaIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdFrontRecognizer.Result nativeResult;

        internal SerbiaIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public IDate IssuingDate => nativeResult.IssuingDate != null ? new Date(nativeResult.IssuingDate) : null;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
        public IDate ValidUntil => nativeResult.ValidUntil != null ? new Date(nativeResult.ValidUntil) : null;
    }
}