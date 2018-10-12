using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ColombiaDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class ColombiaDlFrontRecognizer : Recognizer, IColombiaDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaDlFrontRecognizer nativeRecognizer;

        ColombiaDlFrontRecognizerResult result;

        public ColombiaDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaDlFrontRecognizer;
            result = new ColombiaDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IColombiaDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractDriverRestrictions 
        { 
            get => nativeRecognizer.ShouldExtractDriverRestrictions(); 
            set => nativeRecognizer.SetExtractDriverRestrictions(value);
        }
        
        public bool ExtractIssuingAgency 
        { 
            get => nativeRecognizer.ShouldExtractIssuingAgency(); 
            set => nativeRecognizer.SetExtractIssuingAgency(value);
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

    public sealed class ColombiaDlFrontRecognizerResult : RecognizerResult, IColombiaDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaDlFrontRecognizer.Result nativeResult;

        internal ColombiaDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public string DriverRestrictions => nativeResult.DriverRestrictions;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IssuingAgency => nativeResult.IssuingAgency;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string Name => nativeResult.Name;
    }
}