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
        /// scanned VIN (Vehicle Identification Number). 
        /// </summary>
        string Vin { get; }
        
    }
}