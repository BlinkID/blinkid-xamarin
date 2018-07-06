using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;
using Microblink;

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
