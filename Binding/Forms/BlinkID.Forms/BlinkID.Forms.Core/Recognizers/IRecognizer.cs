using System;
namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Base class for all recognizers.
    /// Recognizer is an object that performs recognition of image
    /// and updates its result with data extracted from the image.
    /// </summary>
    public interface IRecognizer
    {
        /// <summary>
        /// Gets the base result of the recognizer.
        /// </summary>
        /// <value>The base result.</value>
        IRecognizerResult BaseResult { get; }
    }

    /// <summary>
    /// Recognizer result state. This enum contains possible states in which
    /// Recognizer's result can be.
    /// </summary>
    public enum RecognizerResultState
    {
        /// <summary>
        /// Recognizer result is empty.
        /// </summary>
        Empty,
        /// <summary>
        /// Recognizer result contains some values, but is incomplete or it
        /// contains all values, but some are uncertain
        /// </summary>
        Uncertain,
        /// <summary>
        /// Recognizer result contains all required values.
        /// </summary>
        Valid,
        /// <summary>
        /// Recognizer result contains all required fields first side.
        /// </summary>
        StageValid
    }

    /// <summary>
    /// Base class for all recognizer's result objects.
    /// Recognizer result contains data extracted from the image.
    /// </summary>
    public interface IRecognizerResult
    {
        /// <summary>
        /// Gets the state of the result.
        /// </summary>
        /// <value>The state of the result.</value>
        RecognizerResultState ResultState { get; }
    }
}
