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
        MBMrtdRecognizer nativeRecognizer;

        MrtdRecognizerResult result;

        public MrtdRecognizer() : base(new MBMrtdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMrtdRecognizer;
            result = new MrtdRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        IMrtdRecognizerResult IMrtdRecognizer.Result => result;

        bool IMrtdRecognizer.AllowUnparsedResults { get => nativeRecognizer.AllowUnparsedResults; set => nativeRecognizer.AllowUnparsedResults = value; }
        bool IMrtdRecognizer.AllowUnverifiedResults { get => nativeRecognizer.AllowUnverifiedResults; set => nativeRecognizer.AllowUnverifiedResults = value; }
        bool IMrtdRecognizer.DetectGlare { get => nativeRecognizer.DetectGlare; set => nativeRecognizer.DetectGlare = value; }
        bool IMrtdRecognizer.ReturnFullDocumentImage { get => nativeRecognizer.ReturnFullDocumentImage; set => nativeRecognizer.ReturnFullDocumentImage = value; }
        bool IMrtdRecognizer.ReturnMrzImage { get => nativeRecognizer.ReturnMrzImage; set => nativeRecognizer.ReturnMrzImage = value; }
        int IMrtdRecognizer.SaveImageDPI { get => (int) nativeRecognizer.SaveImageDPI; set => nativeRecognizer.SaveImageDPI = (nuint) value; }
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
