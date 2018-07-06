using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwitzerlandIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SwitzerlandIdFrontRecognizer : Recognizer, ISwitzerlandIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdFrontRecognizer nativeRecognizer;

        SwitzerlandIdFrontRecognizerResult result;

        public SwitzerlandIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdFrontRecognizer;
            result = new SwitzerlandIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwitzerlandIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractGivenName 
        { 
            get => nativeRecognizer.ShouldExtractGivenName(); 
            set => nativeRecognizer.SetExtractGivenName(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
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

    public sealed class SwitzerlandIdFrontRecognizerResult : RecognizerResult, ISwitzerlandIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdFrontRecognizer.Result nativeResult;

        internal SwitzerlandIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string GivenName => nativeResult.GivenName;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
        public string Surname => nativeResult.Surname;
    }
}