using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(GermanyIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class GermanyIdBackRecognizer : Recognizer, IGermanyIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdBackRecognizer nativeRecognizer;

        GermanyIdBackRecognizerResult result;

        public GermanyIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdBackRecognizer;
            result = new GermanyIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IGermanyIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ShouldExtractAuthority(); 
            set => nativeRecognizer.SetExtractAuthority(value);
        }
        
        public bool ExtractColourOfEyes 
        { 
            get => nativeRecognizer.ShouldExtractColourOfEyes(); 
            set => nativeRecognizer.SetExtractColourOfEyes(value);
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

    public sealed class GermanyIdBackRecognizerResult : RecognizerResult, IGermanyIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdBackRecognizer.Result nativeResult;

        internal GermanyIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AddressCity => nativeResult.AddressCity;
        public string AddressHouseNumber => nativeResult.AddressHouseNumber;
        public string AddressStreet => nativeResult.AddressStreet;
        public string AddressZipCode => nativeResult.AddressZipCode;
        public string Authority => nativeResult.Authority;
        public string ColourOfEyes => nativeResult.ColourOfEyes;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public string FullAddress => nativeResult.FullAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Height => nativeResult.Height;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}