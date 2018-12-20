using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwitzerlandPassportRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SwitzerlandPassportRecognizer : Recognizer, ISwitzerlandPassportRecognizer
    {
        MBSwitzerlandPassportRecognizer nativeRecognizer;

        SwitzerlandPassportRecognizerResult result;

        public SwitzerlandPassportRecognizer() : base(new MBSwitzerlandPassportRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSwitzerlandPassportRecognizer;
            result = new SwitzerlandPassportRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwitzerlandPassportRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ExtractAuthority; 
            set => nativeRecognizer.ExtractAuthority = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
        }
        
        public bool ExtractGivenName 
        { 
            get => nativeRecognizer.ExtractGivenName; 
            set => nativeRecognizer.ExtractGivenName = value;
        }
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ExtractHeight; 
            set => nativeRecognizer.ExtractHeight = value;
        }
        
        public bool ExtractPassportNumber 
        { 
            get => nativeRecognizer.ExtractPassportNumber; 
            set => nativeRecognizer.ExtractPassportNumber = value;
        }
        
        public bool ExtractPlaceOfOrigin 
        { 
            get => nativeRecognizer.ExtractPlaceOfOrigin; 
            set => nativeRecognizer.ExtractPlaceOfOrigin = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ExtractSurname; 
            set => nativeRecognizer.ExtractSurname = value;
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

    public sealed class SwitzerlandPassportRecognizerResult : RecognizerResult, ISwitzerlandPassportRecognizerResult
    {
        MBSwitzerlandPassportRecognizerResult nativeResult;

        internal SwitzerlandPassportRecognizerResult(MBSwitzerlandPassportRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string GivenName => nativeResult.GivenName;
        public string Height => nativeResult.Height;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PassportNumber => nativeResult.PassportNumber;
        public string PlaceOfOrigin => nativeResult.PlaceOfOrigin;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}