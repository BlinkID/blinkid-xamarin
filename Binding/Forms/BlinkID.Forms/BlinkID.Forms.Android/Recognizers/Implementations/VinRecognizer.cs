using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(VinRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class VinRecognizer : Recognizer, IVinRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Vin.VinRecognizer nativeRecognizer;

        VinRecognizerResult result;

        public VinRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkbarcode.Vin.VinRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkbarcode.Vin.VinRecognizer;
            result = new VinRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkbarcode.Vin.VinRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IVinRecognizerResult Result => result;

        
    }

    public sealed class VinRecognizerResult : RecognizerResult, IVinRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Vin.VinRecognizer.Result nativeResult;

        internal VinRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkbarcode.Vin.VinRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Vin => nativeResult.Vin;
    }
}