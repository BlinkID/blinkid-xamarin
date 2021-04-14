using System;
using BlinkID.Forms.Droid.Recognizers;
using BlinkID.Forms.Core.Recognizers;

namespace BlinkID.Forms.Droid.Recognizers
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

        public RecognizerResultState ResultState => (RecognizerResultState)NativeResult.ResultState.Ordinal();
    }
}