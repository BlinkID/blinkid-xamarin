namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer that can perform recognition of VINs (Vehicle Identification Number).
    /// </summary>
    public interface IVinRecognizer : IRecognizer
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IVinRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IVinRecognizer.
    /// </summary>
    public interface IVinRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Returns the recognized VIN or empty string if recognition failed. 
        /// </summary>
        string Vin { get; }
        
    }
}