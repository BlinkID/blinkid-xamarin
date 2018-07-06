using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SimNumberRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SimNumberRecognizer : Recognizer, ISimNumberRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Simnumber.SimNumberRecognizer nativeRecognizer;

        SimNumberRecognizerResult result;

        public SimNumberRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkbarcode.Simnumber.SimNumberRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkbarcode.Simnumber.SimNumberRecognizer;
            result = new SimNumberRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkbarcode.Simnumber.SimNumberRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISimNumberRecognizerResult Result => result;

        
    }

    public sealed class SimNumberRecognizerResult : RecognizerResult, ISimNumberRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Simnumber.SimNumberRecognizer.Result nativeResult;

        internal SimNumberRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkbarcode.Simnumber.SimNumberRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string SimNumber => nativeResult.SimNumber;
    }
}