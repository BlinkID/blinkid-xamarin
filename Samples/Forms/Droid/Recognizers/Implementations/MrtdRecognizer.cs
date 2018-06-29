using BlinkIDFormsSample.Droid.Recognizers;
using BlinkIDFormsSample.Recognizers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdRecognizer))]
[assembly: Xamarin.Forms.Dependency(typeof(MrtdRecognizerResult))]
namespace BlinkIDFormsSample.Droid.Recognizers
{
    public class MrtdRecognizer : Recognizer, IMrtdRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer nativeMrtdRecognizer;

        MrtdRecognizerResult mrtdRecognizerResult;

        public MrtdRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer())
        {
            nativeMrtdRecognizer = (Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer)NativeRecognizer;
            mrtdRecognizerResult = new MrtdRecognizerResult((Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result)nativeMrtdRecognizer.GetResult());
        }

        public override IRecognizerResult BaseResult => mrtdRecognizerResult;

        IMrtdRecognizerResult IMrtdRecognizer.Result => mrtdRecognizerResult;

        bool IMrtdRecognizer.AllowUnparsedResults { get => nativeMrtdRecognizer.AllowUnparsedResults; set => nativeMrtdRecognizer.AllowUnparsedResults = value; }
        bool IMrtdRecognizer.AllowUnverifiedResults { get => nativeMrtdRecognizer.AllowUnverifiedResults; set => nativeMrtdRecognizer.AllowUnverifiedResults = value; }
        bool IMrtdRecognizer.DetectGlare { get => nativeMrtdRecognizer.ShouldDetectGlare(); set => nativeMrtdRecognizer.SetDetectGlare(true); }
        bool IMrtdRecognizer.ReturnFullDocumentImage { get => nativeMrtdRecognizer.ShouldReturnFullDocumentImage(); set => nativeMrtdRecognizer.SetReturnFullDocumentImage(value); }
        bool IMrtdRecognizer.ReturnMrzImage { get => nativeMrtdRecognizer.ShouldReturnMrzImage(); set => nativeMrtdRecognizer.SetReturnMrzImage(value); }
        int IMrtdRecognizer.SaveImageDPI { get => nativeMrtdRecognizer.SaveImageDPI; set => nativeMrtdRecognizer.SaveImageDPI = value; }
    }

    public class MrtdRecognizerResult : RecognizerResult, IMrtdRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result nativeResult;

        internal MrtdRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;

        public ImageSource MrzImage => nativeResult.MrzImage != null ? Utils.ConvertAndroidBitmap(nativeResult.MrzImage.ConvertToBitmap()) : null;

        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}
