namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// Recognizer that scan 2D barcodes from United States Driver License.
    /// </summary>
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

    /// <summary>
    /// Result object for IUsdlRecognizer.
    /// </summary>
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

        /// <summary>
        /// The first name of the United States driver license owner.
        /// </summary>
        string FirstName { get; }

        /// <summary>
        /// The last name of the United States driver license owner.
        /// </summary>
        string LastName { get; }

        /// <summary>
        /// The full name of the United States driver license owner.
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// The full address of the United States driver license owner.
        /// </summary>
        string Address { get; }

        /// <summary>
        /// The document number of the United States driver license.
        /// </summary>
        string DocumentNumber { get; }

        /// <summary>
        /// The sex of the United States driver license owner.
        /// </summary>
        string Sex { get; }

        /// <summary>
        /// The restrictions to driving privileges for the United States driver license owner.
        /// </summary>
        string Restrictions { get; }

        /// <summary>
        /// The additional privileges granted to the United States driver license owner.
        /// </summary>
        string Endorsements { get; }

        /// <summary>
        /// The type of vehicle the driver license owner has privilege to drive.
        /// </summary>
        string VehicleClass { get; }

         /// <summary>
        /// The date of birth of United States driver license owner.
        /// </summary>
        IDate DateOfBirth { get; }

        /// <summary>
        /// The document date of issue of the United States driver license.
        /// </summary>
        IDate DateOfIssue { get; }

        /// <summary>
        /// The document date of expiry of the United States driver license.
        /// </summary>
        IDate DateOfExpiry { get; }
    }
}
