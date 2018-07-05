namespace Microblink.Forms.Core.Recognizers
{
    public interface IVinRecognizer : IRecognizer
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IVinRecognizerResult Result { get; }
    }

    public interface IVinRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Returns the recognized VIN or empty string if recognition failed. 
        /// </summary>
        string Vin { get; }
        
    }
}