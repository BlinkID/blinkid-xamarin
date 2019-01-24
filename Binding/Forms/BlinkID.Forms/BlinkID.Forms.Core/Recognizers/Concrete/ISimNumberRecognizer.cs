namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer that can perform recognition of barcodes on SIM packaging.
    /// </summary>
    public interface ISimNumberRecognizer : IRecognizer
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ISimNumberRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for ISimNumberRecognizer.
    /// </summary>
    public interface ISimNumberRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// Returns the recognized SIM number from barcode or empty string if recognition failed. 
        /// </summary>
        string SimNumber { get; }
        
    }
}