namespace Microblink.Forms.Core.Recognizers
{
    public interface IUsdlRecognizer : IRecognizer
    {

        /// <summary>
        /// Enable decoding of non-standard PDF417 barcodes, but without
        /// guarantee that all data will be read.This option should be enabled
        /// for PDF417 barcode that has missing rows(i.e.not whole barcode is
        /// printed)
        /// By default, this is set to <c>true</c>
        /// </summary>
        /// <value><c>true</c> if uncertain decoding; otherwise, <c>false</c>.</value>
        bool UncertainDecoding { get; set; }

        /// <summary>
        /// Allow scanning PDF417 barcodes which don't have quiet zone
        /// surrounding it(e.g.text concatenated with barcode). This
        /// option can significantly increase recognition time.
        /// By default, this is set to <c>true</c>
        /// </summary>
        /// <value><c>true</c> if null quiet zone allowed; otherwise, <c>false</c>.</value>
        bool NullQuietZoneAllowed { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        IUsdlRecognizerResult Result { get; }
    }

    public interface IUsdlRecognizerResult : IRecognizerResult
    {

        /// <summary>
        /// Gets a value indicating whether this result is uncertain, i.e. if scanned barcode 
        /// was incomplete (i.e. (has parts of it missing).
        /// </summary>
        /// <value><c>true</c> if uncertain; otherwise, <c>false</c>.</value>
        bool Uncertain { get; }

        /// <summary>
        /// Gets the raw string data inside 2D barcode.
        /// </summary>
        /// <value>The raw string data.</value>
        string RawStringData { get; }

        /// <summary>
        /// Gets the raw data bytes contained inside 2D barcode.
        /// </summary>
        /// <value>The raw data.</value>
        byte[] RawData { get; }

        /// <summary>
        /// Gets the array of elements that are not part of AAMVA standard and are specific to each US state.
        /// If no specific elements existed inside 2D barcode, this is an empty array.Otherwise,
        /// this array contains list of state-specific elements in the same order as given inside
        /// barcode.
        /// NOTE: Size of this array is both state-specific and barcode-specific.Each US state has
        /// ability to arbitrarily define size and contents of these elements.You can obtain the
        /// US state with getField(UsdlKeys) and using UsdlKeys.IssuingJurisdictionName
        /// as a parameter.
        /// </summary>
        /// <value>The optional elements.</value>
        string[] OptionalElements { get; }

        /// <summary>
        /// Gets the field inside US Driver's licence. Available Keys are listed in UsdlKeys enum.
        /// </summary>
        /// <returns>The field.</returns>
        /// <param name="key">Key.</param>
        string GetField(UsdlKeys key);
    }
}
