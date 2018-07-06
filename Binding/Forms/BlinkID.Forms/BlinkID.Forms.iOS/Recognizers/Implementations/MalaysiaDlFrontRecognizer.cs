using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MalaysiaDlFrontRecognizer : Recognizer, IMalaysiaDlFrontRecognizer
    {
        MBMalaysiaDlFrontRecognizer nativeRecognizer;

        MalaysiaDlFrontRecognizerResult result;

        public MalaysiaDlFrontRecognizer() : base(new MBMalaysiaDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMalaysiaDlFrontRecognizer;
            result = new MalaysiaDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDlClass 
        { 
            get => nativeRecognizer.ExtractDlClass; 
            set => nativeRecognizer.ExtractDlClass = value;
        }
        
        public bool ExtractFullAddress 
        { 
            get => nativeRecognizer.ExtractFullAddress; 
            set => nativeRecognizer.ExtractFullAddress = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ExtractNationality; 
            set => nativeRecognizer.ExtractNationality = value;
        }
        
        public bool ExtractValidFrom 
        { 
            get => nativeRecognizer.ExtractValidFrom; 
            set => nativeRecognizer.ExtractValidFrom = value;
        }
        
        public bool ExtractValidUntil 
        { 
            get => nativeRecognizer.ExtractValidUntil; 
            set => nativeRecognizer.ExtractValidUntil = value;
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

    public sealed class MalaysiaDlFrontRecognizerResult : RecognizerResult, IMalaysiaDlFrontRecognizerResult
    {
        MBMalaysiaDlFrontRecognizerResult nativeResult;

        internal MalaysiaDlFrontRecognizerResult(MBMalaysiaDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string City => nativeResult.City;
        public string DlClass => nativeResult.DlClass;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FullAddress => nativeResult.FullAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
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