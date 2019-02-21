using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BruneiTemporaryResidencePermitBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BruneiTemporaryResidencePermitBackRecognizer : Recognizer, IBruneiTemporaryResidencePermitBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitBackRecognizer nativeRecognizer;

        BruneiTemporaryResidencePermitBackRecognizerResult result;

        public BruneiTemporaryResidencePermitBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitBackRecognizer;
            result = new BruneiTemporaryResidencePermitBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBruneiTemporaryResidencePermitBackRecognizerResult Result => result;

        
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
        
        public bool ExtractPassportNumber 
        { 
            get => nativeRecognizer.ShouldExtractPassportNumber(); 
            set => nativeRecognizer.SetExtractPassportNumber(value);
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

    public sealed class BruneiTemporaryResidencePermitBackRecognizerResult : RecognizerResult, IBruneiTemporaryResidencePermitBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitBackRecognizer.Result nativeResult;

        internal BruneiTemporaryResidencePermitBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Brunei.BruneiTemporaryResidencePermitBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PassportNumber => nativeResult.PassportNumber;
    }
}