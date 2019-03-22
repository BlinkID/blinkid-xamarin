using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SloveniaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SloveniaIdBackRecognizer : Recognizer, ISloveniaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer nativeRecognizer;

        SloveniaIdBackRecognizerResult result;

        public SloveniaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer;
            result = new SloveniaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISloveniaIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractAdministrativeUnit 
        { 
            get => nativeRecognizer.ShouldExtractAdministrativeUnit(); 
            set => nativeRecognizer.SetExtractAdministrativeUnit(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
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

    public sealed class SloveniaIdBackRecognizerResult : RecognizerResult, ISloveniaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer.Result nativeResult;

        internal SloveniaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Slovenia.SloveniaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string AdministrativeUnit => nativeResult.AdministrativeUnit;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}