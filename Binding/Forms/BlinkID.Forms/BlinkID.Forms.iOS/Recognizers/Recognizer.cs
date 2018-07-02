using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(Recognizer))]
[assembly: Xamarin.Forms.Dependency(typeof(RecognizerResult))]
namespace Microblink.Forms.iOS.Recognizers
{
    public abstract class Recognizer : IRecognizer
    {
        public MBRecognizer NativeRecognizer { get; }
        public abstract IRecognizerResult BaseResult { get; }

        protected Recognizer(MBRecognizer nativeRecognizer)
        {
            NativeRecognizer = nativeRecognizer;
        }
    }

    public abstract class RecognizerResult : IRecognizerResult
    {
        public MBRecognizerResult NativeResult { get; }

        protected RecognizerResult(MBRecognizerResult nativeResult)
        {
            NativeResult = nativeResult;
        }

        public RecognizerResultState ResultState => (RecognizerResultState)NativeResult.ResultState;
    }
}
