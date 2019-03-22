using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SloveniaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SloveniaIdBackRecognizer : Recognizer, ISloveniaIdBackRecognizer
    {
        MBSloveniaIdBackRecognizer nativeRecognizer;

        SloveniaIdBackRecognizerResult result;

        public SloveniaIdBackRecognizer() : base(new MBSloveniaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSloveniaIdBackRecognizer;
            result = new SloveniaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISloveniaIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractAdministrativeUnit 
        { 
            get => nativeRecognizer.ExtractAdministrativeUnit; 
            set => nativeRecognizer.ExtractAdministrativeUnit = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
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

    public sealed class SloveniaIdBackRecognizerResult : RecognizerResult, ISloveniaIdBackRecognizerResult
    {
        MBSloveniaIdBackRecognizerResult nativeResult;

        internal SloveniaIdBackRecognizerResult(MBSloveniaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string AdministrativeUnit => nativeResult.AdministrativeUnit;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}