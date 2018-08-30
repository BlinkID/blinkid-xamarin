namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer that can scan VIN (Vehicle Identification Number) barcode.
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
        /// scanned VIN (Vehicle Identification Number). 
        /// </summary>
        string Vin { get; }
        
    }
}