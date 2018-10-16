using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SingaporeDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SingaporeDlFrontRecognizer : Recognizer, ISingaporeDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeDlFrontRecognizer nativeRecognizer;

        SingaporeDlFrontRecognizerResult result;

        public SingaporeDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeDlFrontRecognizer;
            result = new SingaporeDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISingaporeDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractBirthDate 
        { 
            get => nativeRecognizer.ShouldExtractBirthDate(); 
            set => nativeRecognizer.SetExtractBirthDate(value);
        }
        
        public bool ExtractIssueDate 
        { 
            get => nativeRecognizer.ShouldExtractIssueDate(); 
            set => nativeRecognizer.SetExtractIssueDate(value);
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ShouldExtractName(); 
            set => nativeRecognizer.SetExtractName(value);
        }
        
        public bool ExtractValidTill 
        { 
            get => nativeRecognizer.ShouldExtractValidTill(); 
            set => nativeRecognizer.SetExtractValidTill(value);
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

    public sealed class SingaporeDlFrontRecognizerResult : RecognizerResult, ISingaporeDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeDlFrontRecognizer.Result nativeResult;

        internal SingaporeDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Singapore.SingaporeDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate.Date != null ? new Date(nativeResult.BirthDate.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IDate IssueDate => nativeResult.IssueDate.Date != null ? new Date(nativeResult.IssueDate.Date) : null;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string Name => nativeResult.Name;
        public IDate ValidTill => nativeResult.ValidTill.Date != null ? new Date(nativeResult.ValidTill.Date) : null;
    }
}