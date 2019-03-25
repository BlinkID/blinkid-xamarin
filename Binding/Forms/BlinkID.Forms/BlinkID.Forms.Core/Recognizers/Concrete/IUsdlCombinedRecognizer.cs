namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// USDL Combined Recognizer.
    ///
    /// USDL Combined recognizer is used for scanning both front and back side of US Driver's License.
    /// </summary>
    public interface IUsdlCombinedRecognizer : IRecognizer
    {
        /// <summary>
        /// Gets or sets the face image DPI. Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception.
        /// Default value is <c>250</c>
        /// </summary>
        /// <value>The face image dpi.</value>
        uint FaceImageDpi { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether face image from ID card should be extracted
        /// Default value is <c>false</c>
        /// </summary>
        /// <value><c>true</c> if return face image; otherwise, <c>false</c>.</value>
        bool ReturnFaceImage { get; set; }

        /// <summary>
        /// Gets or sets the full document image DPI. Valid ranges are [100,400]. Setting DPI out of valid ranges throws an exception.
        /// Default value is <c>250</c>
        /// </summary>
        /// <value>The full document image dpi.</value>
        uint FullDocumentImageDpi { get; set; }

        /// <summary>
        /// Gets or sets the extension factors for full document image.
        /// Default value is <c>[0.0, 0.0, 0.0, 0.0]</c>
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Gets or sets the minimum number of stable detections required for detection to be successful.
        /// Default value is <c>6</c>
        /// </summary>
        uint NumStableDetectionsThreshold { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether full document image of ID card should be extracted
        /// Default value is <c>false</c>
        /// </summary>
        /// <value><c>true</c> if return face image; otherwise, <c>false</c>.</value>
        bool ReturnFullDocumentImage { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether recognition result should be signed.
        /// </summary>
        /// <value><c>true</c> if sign result; otherwise, <c>false</c>.</value>
        bool SignResult { get; set; }

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>The result.</value>
        IUsdlCombinedRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IUsdlCombinedRecognizer.
    /// </summary>
    public interface IUsdlCombinedRecognizerResult : IRecognizerResult
    {
        /// <summary>
        /// Gets the digital signature of the recognition result. Available only if enabled with SignResult property. 
        /// </summary>
        /// <value>The digital signature.</value>
        byte[] DigitalSignature { get; }

        /// <summary>
        /// Gets the version of the digital signature. Available only if enabled with signResult property. 
        /// </summary>
        /// <value>The digital signature version.</value>
        uint DigitalSignatureVersion { get; }

        /// <summary>
        /// Returns true if data from scanned parts/sides of the document match,
        /// false otherwise. For example if date of expiry is scanned from the front and back side
        /// of the document and values do not match, this method will return false. Result will
        /// be true only if scanned values for all fields that are compared are the same. 
        /// </summary>
        /// <value><c>true</c> if document data match; otherwise, <c>false</c>.</value>
        bool DocumentDataMatch { get; }

        /// <summary>
        /// Gets the face image from the document if enabled with ReturnFaceImage property. 
        /// </summary>
        /// <value>The face image.</value>
        Xamarin.Forms.ImageSource FaceImage { get; }

        /// <summary>
        /// Gets the full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        /// <value>The full document image.</value>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }

        /// <summary>
        /// Returns true if recognizer has finished scanning first side and is now scanning back side,
        /// false if it's still scanning first side. 
        /// </summary>
        /// <value><c>true</c> if scanning first side done; otherwise, <c>false</c>.</value>
        bool ScanningFirstSideDone { get; }

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
