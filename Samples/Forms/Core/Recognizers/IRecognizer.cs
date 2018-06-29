using System;
namespace BlinkIDFormsSample.Recognizers
{
    public interface IRecognizer
    {
        IRecognizerResult BaseResult { get; }
    }

    public enum RecognizerResultState 
    {
        Empty,
        Uncertain,
        Valid
    }

    public interface IRecognizerResult
    {
        RecognizerResultState ResultState { get; }
    }
}
