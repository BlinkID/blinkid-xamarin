using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwitzerlandIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SwitzerlandIdFrontRecognizer : Recognizer, ISwitzerlandIdFrontRecognizer
    {
        MBSwitzerlandIdFrontRecognizer nativeRecognizer;

        SwitzerlandIdFrontRecognizerResult result;

        public SwitzerlandIdFrontRecognizer() : base(new MBSwitzerlandIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSwitzerlandIdFrontRecognizer;
            result = new SwitzerlandIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwitzerlandIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractGivenName 
        { 
            get => nativeRecognizer.ExtractGivenName; 
            set => nativeRecognizer.ExtractGivenName = value;
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ExtractSurname; 
            set => nativeRecognizer.ExtractSurname = value;
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

    public sealed class SwitzerlandIdFrontRecognizerResult : RecognizerResult, ISwitzerlandIdFrontRecognizerResult
    {
        MBSwitzerlandIdFrontRecognizerResult nativeResult;

        internal SwitzerlandIdFrontRecognizerResult(MBSwitzerlandIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string GivenName => nativeResult.GivenName;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public string Surname => nativeResult.Surname;
    }
}