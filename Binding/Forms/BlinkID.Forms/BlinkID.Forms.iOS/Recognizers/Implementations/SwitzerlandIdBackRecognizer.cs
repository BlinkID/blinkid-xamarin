using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwitzerlandIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SwitzerlandIdBackRecognizer : Recognizer, ISwitzerlandIdBackRecognizer
    {
        MBSwitzerlandIdBackRecognizer nativeRecognizer;

        SwitzerlandIdBackRecognizerResult result;

        public SwitzerlandIdBackRecognizer() : base(new MBSwitzerlandIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSwitzerlandIdBackRecognizer;
            result = new SwitzerlandIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwitzerlandIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ExtractHeight; 
            set => nativeRecognizer.ExtractHeight = value;
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
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class SwitzerlandIdBackRecognizerResult : RecognizerResult, ISwitzerlandIdBackRecognizerResult
    {
        MBSwitzerlandIdBackRecognizerResult nativeResult;

        internal SwitzerlandIdBackRecognizerResult(MBSwitzerlandIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Height => nativeResult.Height;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PlaceOfOrigin => nativeResult.PlaceOfOrigin;
        public string Sex => nativeResult.Sex;
    }
}