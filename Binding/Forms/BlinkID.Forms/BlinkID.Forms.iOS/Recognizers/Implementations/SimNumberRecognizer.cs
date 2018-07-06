using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SimNumberRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SimNumberRecognizer : Recognizer, ISimNumberRecognizer
    {
        MBSimNumberRecognizer nativeRecognizer;

        SimNumberRecognizerResult result;

        public SimNumberRecognizer() : base(new MBSimNumberRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSimNumberRecognizer;
            result = new SimNumberRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISimNumberRecognizerResult Result => result;

        
    }

    public sealed class SimNumberRecognizerResult : RecognizerResult, ISimNumberRecognizerResult
    {
        MBSimNumberRecognizerResult nativeResult;

        internal SimNumberRecognizerResult(MBSimNumberRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string SimNumber => nativeResult.SimNumber;
    }
}