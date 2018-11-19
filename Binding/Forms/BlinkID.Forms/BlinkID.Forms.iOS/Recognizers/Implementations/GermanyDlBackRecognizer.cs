using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(GermanyDlBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class GermanyDlBackRecognizer : Recognizer, IGermanyDlBackRecognizer
    {
        MBGermanyDlBackRecognizer nativeRecognizer;

        GermanyDlBackRecognizerResult result;

        public GermanyDlBackRecognizer() : base(new MBGermanyDlBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBGermanyDlBackRecognizer;
            result = new GermanyDlBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IGermanyDlBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
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

    public sealed class GermanyDlBackRecognizerResult : RecognizerResult, IGermanyDlBackRecognizerResult
    {
        MBGermanyDlBackRecognizerResult nativeResult;

        internal GermanyDlBackRecognizerResult(MBGermanyDlBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfIssueB10 => nativeResult.DateOfIssueB10 != null ? new Date(nativeResult.DateOfIssueB10) : null;
        public bool DateOfIssueB10NotSpecified => nativeResult.DateOfIssueB10NotSpecified;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
    }
}