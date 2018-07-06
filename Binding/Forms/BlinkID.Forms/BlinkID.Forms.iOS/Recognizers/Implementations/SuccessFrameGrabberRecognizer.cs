using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.iOS.Recognizers;
using Xamarin.Forms;

[assembly: Dependency(typeof(SuccessFrameGrabberRecognizerFactory))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SuccessFrameGrabberRecognizer : Recognizer, ISuccessFrameGrabberRecognizer
    {
        MBSuccessFrameGrabberRecognizer nativeRecognizer;
        Recognizer slaveRecognizer;
        readonly SuccessFrameGrabberRecognizerResult result;

        public SuccessFrameGrabberRecognizer(Recognizer slaveRecognizer)
            : base(new MBSuccessFrameGrabberRecognizer(slaveRecognizer.NativeRecognizer))
        {
            nativeRecognizer = NativeRecognizer as MBSuccessFrameGrabberRecognizer;
            this.slaveRecognizer = slaveRecognizer;
            result = new SuccessFrameGrabberRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IRecognizer SlaveRecognizer => slaveRecognizer;

        public ISuccessFrameGrabberRecognizerResult Result => result;
    }

    public sealed class SuccessFrameGrabberRecognizerResult : RecognizerResult, ISuccessFrameGrabberRecognizerResult
    {
        readonly MBSuccessFrameGrabberRecognizerResult nativeResult;

        internal SuccessFrameGrabberRecognizerResult(MBSuccessFrameGrabberRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public ImageSource SuccessFrame => Utils.ConvertUIImage(nativeResult.SuccessFrame.Image);
    }

    public sealed class SuccessFrameGrabberRecognizerFactory : ISuccessFrameGrabberRecognizerFactory
    {
        public ISuccessFrameGrabberRecognizer CreateSuccessFrameGrabberRecognizer(IRecognizer slaveRecognizer)
        {
            return new SuccessFrameGrabberRecognizer(slaveRecognizer as Recognizer);
        }
    }
}