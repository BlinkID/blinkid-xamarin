using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwitzerlandIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SwitzerlandIdBackRecognizer : Recognizer, ISwitzerlandIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdBackRecognizer nativeRecognizer;

        SwitzerlandIdBackRecognizerResult result;

        public SwitzerlandIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdBackRecognizer;
            result = new SwitzerlandIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwitzerlandIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ShouldExtractAuthority(); 
            set => nativeRecognizer.SetExtractAuthority(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ShouldExtractHeight(); 
            set => nativeRecognizer.SetExtractHeight(value);
        }
        
        public bool ExtractPlaceOfOrigin 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfOrigin(); 
            set => nativeRecognizer.SetExtractPlaceOfOrigin(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
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
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class SwitzerlandIdBackRecognizerResult : RecognizerResult, ISwitzerlandIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdBackRecognizer.Result nativeResult;

        internal SwitzerlandIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Switzerland.SwitzerlandIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Height => nativeResult.Height;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PlaceOfOrigin => nativeResult.PlaceOfOrigin;
        public string Sex => nativeResult.Sex;
    }
}