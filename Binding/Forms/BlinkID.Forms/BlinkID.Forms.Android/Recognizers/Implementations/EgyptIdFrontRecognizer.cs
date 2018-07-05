using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(EgyptIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class EgyptIdFrontRecognizer : Recognizer, IEgyptIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Egypt.EgyptIdFrontRecognizer nativeRecognizer;

        EgyptIdFrontRecognizerResult result;

        public EgyptIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Egypt.EgyptIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Egypt.EgyptIdFrontRecognizer;
            result = new EgyptIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Egypt.EgyptIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IEgyptIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractNationalNumber 
        { 
            get => nativeRecognizer.ShouldExtractNationalNumber(); 
            set => nativeRecognizer.SetExtractNationalNumber(value);
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
        
    }

    public sealed class EgyptIdFrontRecognizerResult : RecognizerResult, IEgyptIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Egypt.EgyptIdFrontRecognizer.Result nativeResult;

        internal EgyptIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Egypt.EgyptIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string NationalNumber => nativeResult.NationalNumber;
    }
}