using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BruneiResidencePermitBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BruneiResidencePermitBackRecognizer : Recognizer, IBruneiResidencePermitBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiResidencePermitBackRecognizer nativeRecognizer;

        BruneiResidencePermitBackRecognizerResult result;

        public BruneiResidencePermitBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiResidencePermitBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiResidencePermitBackRecognizer;
            result = new BruneiResidencePermitBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiResidencePermitBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBruneiResidencePermitBackRecognizerResult Result => result;

        
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

    public sealed class BruneiResidencePermitBackRecognizerResult : RecognizerResult, IBruneiResidencePermitBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiResidencePermitBackRecognizer.Result nativeResult;

        internal BruneiResidencePermitBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiResidencePermitBackRecognizer.Result nativeResult) : base(nativeResult)
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