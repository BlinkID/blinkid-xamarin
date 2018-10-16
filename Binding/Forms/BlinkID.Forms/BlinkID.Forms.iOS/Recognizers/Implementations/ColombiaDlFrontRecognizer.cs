using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ColombiaDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class ColombiaDlFrontRecognizer : Recognizer, IColombiaDlFrontRecognizer
    {
        MBColombiaDlFrontRecognizer nativeRecognizer;

        ColombiaDlFrontRecognizerResult result;

        public ColombiaDlFrontRecognizer() : base(new MBColombiaDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBColombiaDlFrontRecognizer;
            result = new ColombiaDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IColombiaDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractDriverRestrictions 
        { 
            get => nativeRecognizer.ExtractDriverRestrictions; 
            set => nativeRecognizer.ExtractDriverRestrictions = value;
        }
        
        public bool ExtractIssuingAgency 
        { 
            get => nativeRecognizer.ExtractIssuingAgency; 
            set => nativeRecognizer.ExtractIssuingAgency = value;
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
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
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

    public sealed class ColombiaDlFrontRecognizerResult : RecognizerResult, IColombiaDlFrontRecognizerResult
    {
        MBColombiaDlFrontRecognizerResult nativeResult;

        internal ColombiaDlFrontRecognizerResult(MBColombiaDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DriverRestrictions => nativeResult.DriverRestrictions;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IssuingAgency => nativeResult.IssuingAgency;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string Name => nativeResult.Name;
    }
}