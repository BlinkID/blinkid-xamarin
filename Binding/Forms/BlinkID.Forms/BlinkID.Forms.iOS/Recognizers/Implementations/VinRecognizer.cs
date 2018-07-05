using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(VinRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class VinRecognizer : Recognizer, IVinRecognizer
    {
        MBVinRecognizer nativeRecognizer;

        VinRecognizerResult result;

        public VinRecognizer() : base(new MBVinRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBVinRecognizer;
            result = new VinRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IVinRecognizerResult Result => result;

        
    }

    public sealed class VinRecognizerResult : RecognizerResult, IVinRecognizerResult
    {
        MBVinRecognizerResult nativeResult;

        internal VinRecognizerResult(MBVinRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Vin => nativeResult.Vin;
    }
}