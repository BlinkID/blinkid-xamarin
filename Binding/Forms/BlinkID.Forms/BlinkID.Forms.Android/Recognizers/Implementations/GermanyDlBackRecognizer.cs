using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(GermanyDlBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class GermanyDlBackRecognizer : Recognizer, IGermanyDlBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyDlBackRecognizer nativeRecognizer;

        GermanyDlBackRecognizerResult result;

        public GermanyDlBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyDlBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyDlBackRecognizer;
            result = new GermanyDlBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyDlBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IGermanyDlBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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

    public sealed class GermanyDlBackRecognizerResult : RecognizerResult, IGermanyDlBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyDlBackRecognizer.Result nativeResult;

        internal GermanyDlBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyDlBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfIssueB10 => nativeResult.DateOfIssueB10.Date != null ? new Date(nativeResult.DateOfIssueB10.Date) : null;
        public bool DateOfIssueB10NotSpecified => nativeResult.IsDateOfIssueB10NotSpecified;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
    }
}