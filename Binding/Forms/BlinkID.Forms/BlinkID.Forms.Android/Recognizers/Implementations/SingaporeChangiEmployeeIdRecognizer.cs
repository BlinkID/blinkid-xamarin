using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeChangiEmployeeIdRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SingaporeChangiEmployeeIdRecognizer : Recognizer, ISingaporeChangiEmployeeIdRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeChangiEmployeeIdRecognizer nativeRecognizer;

        SingaporeChangiEmployeeIdRecognizerResult result;

        public SingaporeChangiEmployeeIdRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeChangiEmployeeIdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeChangiEmployeeIdRecognizer;
            result = new SingaporeChangiEmployeeIdRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeChangiEmployeeIdRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeChangiEmployeeIdRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractCompanyName 
        { 
            get => nativeRecognizer.ShouldExtractCompanyName(); 
            set => nativeRecognizer.SetExtractCompanyName(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ShouldExtractName(); 
            set => nativeRecognizer.SetExtractName(value);
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
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

    public sealed class SingaporeChangiEmployeeIdRecognizerResult : RecognizerResult, ISingaporeChangiEmployeeIdRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeChangiEmployeeIdRecognizer.Result nativeResult;

        internal SingaporeChangiEmployeeIdRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeChangiEmployeeIdRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CompanyName => nativeResult.CompanyName;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Name => nativeResult.Name;
    }
}