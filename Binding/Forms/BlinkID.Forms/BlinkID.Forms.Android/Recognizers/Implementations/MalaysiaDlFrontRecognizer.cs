using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MalaysiaDlFrontRecognizer : Recognizer, IMalaysiaDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaDlFrontRecognizer nativeRecognizer;

        MalaysiaDlFrontRecognizerResult result;

        public MalaysiaDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaDlFrontRecognizer;
            result = new MalaysiaDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractDlClass 
        { 
            get => nativeRecognizer.ShouldExtractDlClass(); 
            set => nativeRecognizer.SetExtractDlClass(value);
        }
        
        public bool ExtractFullAddress 
        { 
            get => nativeRecognizer.ShouldExtractFullAddress(); 
            set => nativeRecognizer.SetExtractFullAddress(value);
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ShouldExtractName(); 
            set => nativeRecognizer.SetExtractName(value);
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ShouldExtractNationality(); 
            set => nativeRecognizer.SetExtractNationality(value);
        }
        
        public bool ExtractValidFrom 
        { 
            get => nativeRecognizer.ShouldExtractValidFrom(); 
            set => nativeRecognizer.SetExtractValidFrom(value);
        }
        
        public bool ExtractValidUntil 
        { 
            get => nativeRecognizer.ShouldExtractValidUntil(); 
            set => nativeRecognizer.SetExtractValidUntil(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
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

    public sealed class MalaysiaDlFrontRecognizerResult : RecognizerResult, IMalaysiaDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaDlFrontRecognizer.Result nativeResult;

        internal MalaysiaDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string City => nativeResult.City;
        public string DlClass => nativeResult.DlClass;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FullAddress => nativeResult.FullAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IdentityNumber => nativeResult.IdentityNumber;
        public string Name => nativeResult.Name;
        public string Nationality => nativeResult.Nationality;
        public string State => nativeResult.State;
        public string Street => nativeResult.Street;
        public IDate ValidFrom => nativeResult.ValidFrom != null ? new Date(nativeResult.ValidFrom) : null;
        public IDate ValidUntil => nativeResult.ValidUntil != null ? new Date(nativeResult.ValidUntil) : null;
        public string ZipCode => nativeResult.ZipCode;
    }
}