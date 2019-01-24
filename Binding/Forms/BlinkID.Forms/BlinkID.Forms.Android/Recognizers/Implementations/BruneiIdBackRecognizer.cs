using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BruneiIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BruneiIdBackRecognizer : Recognizer, IBruneiIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiIdBackRecognizer nativeRecognizer;

        BruneiIdBackRecognizerResult result;

        public BruneiIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiIdBackRecognizer;
            result = new BruneiIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBruneiIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractRace 
        { 
            get => nativeRecognizer.ShouldExtractRace(); 
            set => nativeRecognizer.SetExtractRace(value);
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

    public sealed class BruneiIdBackRecognizerResult : RecognizerResult, IBruneiIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiIdBackRecognizer.Result nativeResult;

        internal BruneiIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Race => nativeResult.Race;
    }
}