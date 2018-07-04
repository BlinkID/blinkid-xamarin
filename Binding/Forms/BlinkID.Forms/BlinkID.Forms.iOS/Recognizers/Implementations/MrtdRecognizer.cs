using System;
using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;
using Microblink;
using Xamarin.Forms;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public class MrtdRecognizer : Recognizer, IMrtdRecognizer
    {
        MBMrtdRecognizer nativeMrtdRecognizer;

        MrtdRecognizerResult mrtdRecognizerResult;

        public MrtdRecognizer() : base(new MBMrtdRecognizer())
        {
            nativeMrtdRecognizer = (MBMrtdRecognizer)NativeRecognizer;
            mrtdRecognizerResult = new MrtdRecognizerResult(nativeMrtdRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => mrtdRecognizerResult;

        IMrtdRecognizerResult IMrtdRecognizer.Result => mrtdRecognizerResult;

        bool IMrtdRecognizer.AllowUnparsedResults { get => nativeMrtdRecognizer.AllowUnparsedResults; set => nativeMrtdRecognizer.AllowUnparsedResults = value; }
        bool IMrtdRecognizer.AllowUnverifiedResults { get => nativeMrtdRecognizer.AllowUnverifiedResults; set => nativeMrtdRecognizer.AllowUnverifiedResults = value; }
        bool IMrtdRecognizer.DetectGlare { get => nativeMrtdRecognizer.DetectGlare; set => nativeMrtdRecognizer.DetectGlare = value; }
        bool IMrtdRecognizer.ReturnFullDocumentImage { get => nativeMrtdRecognizer.ReturnFullDocumentImage; set => nativeMrtdRecognizer.ReturnFullDocumentImage = value; }
        bool IMrtdRecognizer.ReturnMrzImage { get => nativeMrtdRecognizer.ReturnMrzImage; set => nativeMrtdRecognizer.ReturnMrzImage = value; }
        int IMrtdRecognizer.SaveImageDPI { get => (int) nativeMrtdRecognizer.SaveImageDPI; set => nativeMrtdRecognizer.SaveImageDPI = (nuint) value; }
    }

    public class MrtdRecognizerResult : RecognizerResult, IMrtdRecognizerResult
    {
        MBMrtdRecognizerResult nativeResult;

        internal MrtdRecognizerResult(MBMrtdRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;

        public ImageSource MrzImage => nativeResult.MrzImage != null ? Utils.ConvertUIImage(nativeResult.MrzImage.Image) : null;

        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}
