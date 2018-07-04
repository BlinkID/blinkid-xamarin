using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MrtdRecognizer : Recognizer, IMrtdRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer nativeRecognizer;

        MrtdRecognizerResult result;

        public MrtdRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer;
            result = new MrtdRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        IMrtdRecognizerResult IMrtdRecognizer.Result => result;

        bool IMrtdRecognizer.AllowUnparsedResults { get => nativeRecognizer.AllowUnparsedResults; set => nativeRecognizer.AllowUnparsedResults = value; }
        bool IMrtdRecognizer.AllowUnverifiedResults { get => nativeRecognizer.AllowUnverifiedResults; set => nativeRecognizer.AllowUnverifiedResults = value; }
        bool IMrtdRecognizer.DetectGlare { get => nativeRecognizer.ShouldDetectGlare(); set => nativeRecognizer.SetDetectGlare(value); }
        bool IMrtdRecognizer.ReturnFullDocumentImage { get => nativeRecognizer.ShouldReturnFullDocumentImage(); set => nativeRecognizer.SetReturnFullDocumentImage(value); }
        bool IMrtdRecognizer.ReturnMrzImage { get => nativeRecognizer.ShouldReturnMrzImage(); set => nativeRecognizer.SetReturnMrzImage(value); }
        int IMrtdRecognizer.SaveImageDPI { get => nativeRecognizer.SaveImageDPI; set => nativeRecognizer.SaveImageDPI = value; }
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
