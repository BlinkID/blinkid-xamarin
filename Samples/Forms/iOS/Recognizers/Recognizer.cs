using BlinkIDFormsSample.iOS.Recognizers;
using BlinkIDFormsSample.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(Recognizer))]
[assembly: Xamarin.Forms.Dependency(typeof(RecognizerResult))]
namespace BlinkIDFormsSample.iOS.Recognizers
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

        public RecognizerResultState ResultState
        {
            get
            {
                switch(NativeResult.ResultState)
                {
                    case MBRecognizerResultState.Empty:
                        return RecognizerResultState.Empty;
                    case MBRecognizerResultState.Uncertain:
                        return RecognizerResultState.Uncertain;
                    case MBRecognizerResultState.Valid:
                        return RecognizerResultState.Valid;
                }
                return RecognizerResultState.Empty;
            }
        }
    }
}
