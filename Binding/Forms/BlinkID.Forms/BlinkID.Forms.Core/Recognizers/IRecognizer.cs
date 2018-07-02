using System;
namespace Microblink.Forms.Core.Recognizers
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
