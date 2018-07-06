using System;
namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// A collection of recognizer objects.
    /// </summary>
    public interface IRecognizerCollection
    {
        /// <summary>
        /// Whether or not it is allowed for multiple recognizers to process the same image.
        /// If not, then first recognizer that will be successful in processing the image will
        /// end the processing chain and other recognizers will not get the chance to process 
        /// that image.
        /// </summary>
        /// <value><c>true</c> if allow multiple results; otherwise, <c>false</c>.</value>
        bool AllowMultipleResults { get; set; }

        /// <summary>
        /// Gets or sets the number of miliseconds before timeout. The timeout timer starts at
        /// the moment when some recognizer's result becomes non-empty.
        /// </summary>
        /// <value>The miliseconds before timeout.</value>
        uint MilisecondsBeforeTimeout { get; set; }

        /// <summary>
        /// Gets the array of recognizer objects that will be used for recognition.
        /// </summary>
        /// <value>The recognizers.</value>
        IRecognizer[] Recognizers { get; }
    }

    /// <summary>
    /// Recognizer collection factory. Use this to create an instance of IRecognizerCollection.
    /// </summary>
    public interface IRecognizerCollectionFactory
    {
        /// <summary>
        /// Creates the recognizer collection from array of recognizer objects.
        /// </summary>
        /// <returns>The recognizer collection.</returns>
        /// <param name="recognizers">Recognizers that should be used in scanning.</param>
        IRecognizerCollection CreateRecognizerCollection(params IRecognizer[] recognizers);
    }
}
