using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BruneiTemporaryResidencePermitBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BruneiTemporaryResidencePermitBackRecognizer : Recognizer, IBruneiTemporaryResidencePermitBackRecognizer
    {
        MBBruneiTemporaryResidencePermitBackRecognizer nativeRecognizer;

        BruneiTemporaryResidencePermitBackRecognizerResult result;

        public BruneiTemporaryResidencePermitBackRecognizer() : base(new MBBruneiTemporaryResidencePermitBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBruneiTemporaryResidencePermitBackRecognizer;
            result = new BruneiTemporaryResidencePermitBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBruneiTemporaryResidencePermitBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ExtractAddress; 
            set => nativeRecognizer.ExtractAddress = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
        }
        
        public bool ExtractPassportNumber 
        { 
            get => nativeRecognizer.ExtractPassportNumber; 
            set => nativeRecognizer.ExtractPassportNumber = value;
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

    public sealed class BruneiTemporaryResidencePermitBackRecognizerResult : RecognizerResult, IBruneiTemporaryResidencePermitBackRecognizerResult
    {
        MBBruneiTemporaryResidencePermitBackRecognizerResult nativeResult;

        internal BruneiTemporaryResidencePermitBackRecognizerResult(MBBruneiTemporaryResidencePermitBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PassportNumber => nativeResult.PassportNumber;
    }
}