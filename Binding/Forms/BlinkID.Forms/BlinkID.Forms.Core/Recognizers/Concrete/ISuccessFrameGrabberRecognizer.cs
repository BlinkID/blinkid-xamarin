namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// ISuccessFrameGrabberRecognizer can wrap any other recognizer and obtain camera
    /// frame on which the other recognizer finished recognition.
    /// </summary>
    public interface ISuccessFrameGrabberRecognizer : IRecognizer
    {
        /// <summary>
        /// Gets the slave recognizer that success frame grabber recognizer will watch.
        /// </summary>
        /// <value>The slave recognizer.</value>
        IRecognizer SlaveRecognizer { get; }

        /// <summary>
        /// Gets the recognizer's result.
        /// </summary>
        /// <value>The result.</value>
        ISuccessFrameGrabberRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISuccessFrameGrabberRecognizer.
    /// </summary>
    public interface ISuccessFrameGrabberRecognizerResult : IRecognizerResult
    { 
        /// <summary>
        /// Gets the camera frame at the time slave recognizer finished recognition.
        /// </summary>
        /// <value>The success frame.</value>
        Xamarin.Forms.ImageSource SuccessFrame { get; }
    }

    /// <summary>
    /// Success frame grabber recognizer factory. Use this to create instance of ISuccessFrameGrabberRecognizer.
    /// </summary>
    public interface ISuccessFrameGrabberRecognizerFactory
    {
        /// <summary>
        /// Creates the success frame grabber recognizer that will watch the given slave recognizer.
        /// </summary>
        /// <returns>The success frame grabber recognizer.</returns>
        /// <param name="slaveRecognizer">Slave recognizer.</param>
        ISuccessFrameGrabberRecognizer CreateSuccessFrameGrabberRecognizer(IRecognizer slaveRecognizer);
    }
}
