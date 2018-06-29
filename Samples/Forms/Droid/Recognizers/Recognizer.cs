using System;
using BlinkIDFormsSample.Droid.Recognizers;
using BlinkIDFormsSample.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(Recognizer))]
[assembly: Xamarin.Forms.Dependency(typeof(RecognizerResult))]
namespace BlinkIDFormsSample.Droid.Recognizers
{
    public abstract class Recognizer : IRecognizer
    {
        public Com.Microblink.Entities.Recognizers.Recognizer NativeRecognizer { get; }
        public abstract IRecognizerResult BaseResult { get; }

        protected Recognizer(Com.Microblink.Entities.Recognizers.Recognizer nativeRecognizer)
        {
            NativeRecognizer = nativeRecognizer;
        }
    }

    public abstract class RecognizerResult : IRecognizerResult
    {
        public Com.Microblink.Entities.Recognizers.Recognizer.Result NativeResult { get; }

        protected RecognizerResult(Com.Microblink.Entities.Recognizers.Recognizer.Result nativeResult)
        {
            NativeResult = nativeResult;
        }

        public RecognizerResultState ResultState
        {
            get
            {
                if (NativeResult.ResultState == Com.Microblink.Entities.Recognizers.Recognizer.Result.State.Valid)
                {
                    return RecognizerResultState.Valid;
                }
                if (NativeResult.ResultState == Com.Microblink.Entities.Recognizers.Recognizer.Result.State.Uncertain)
                {
                    return RecognizerResultState.Uncertain;
                }
                if (NativeResult.ResultState ==  Com.Microblink.Entities.Recognizers.Recognizer.Result.State.Empty)
                {
                    return RecognizerResultState.Empty;
                }
                return RecognizerResultState.Empty;
            }
        }
    }
}
