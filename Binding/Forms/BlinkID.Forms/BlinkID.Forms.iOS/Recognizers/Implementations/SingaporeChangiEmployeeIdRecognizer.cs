using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeChangiEmployeeIdRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SingaporeChangiEmployeeIdRecognizer : Recognizer, ISingaporeChangiEmployeeIdRecognizer
    {
        MBSingaporeChangiEmployeeIdRecognizer nativeRecognizer;

        SingaporeChangiEmployeeIdRecognizerResult result;

        public SingaporeChangiEmployeeIdRecognizer() : base(new MBSingaporeChangiEmployeeIdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSingaporeChangiEmployeeIdRecognizer;
            result = new SingaporeChangiEmployeeIdRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeChangiEmployeeIdRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractCompanyName 
        { 
            get => nativeRecognizer.ExtractCompanyName; 
            set => nativeRecognizer.ExtractCompanyName = value;
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
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

    public sealed class SingaporeChangiEmployeeIdRecognizerResult : RecognizerResult, ISingaporeChangiEmployeeIdRecognizerResult
    {
        MBSingaporeChangiEmployeeIdRecognizerResult nativeResult;

        internal SingaporeChangiEmployeeIdRecognizerResult(MBSingaporeChangiEmployeeIdRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CompanyName => nativeResult.CompanyName;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Name => nativeResult.Name;
    }
}