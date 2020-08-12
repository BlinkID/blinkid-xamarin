namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// The ID Barcode Recognizer is used for scanning ID Barcode.
    /// </summary>
    public interface IIdBarcodeRecognizer : IRecognizer
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IIdBarcodeRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IIdBarcodeRecognizer.
    /// </summary>
    public interface IIdBarcodeRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The additional name information of the document owner. 
        /// </summary>
        string AdditionalNameInformation { get; }
        
        /// <summary>
        /// The address of the document owner. 
        /// </summary>
        string Address { get; }
        
        /// <summary>
        /// The current age of the document owner in years. It is calculated difference 
        /// </summary>
        int Age { get; }
        
        /// <summary>
        /// The format of the scanned barcode. 
        /// </summary>
        BarcodeType BarcodeType { get; }
        
        /// <summary>
        /// The city address portion of the document owner. 
        /// </summary>
        string City { get; }
        
        /// <summary>
        /// The date of birth of the document owner. 
        /// </summary>
        IDate DateOfBirth { get; }
        
        /// <summary>
        /// The date of expiry of the document. 
        /// </summary>
        IDate DateOfExpiry { get; }
        
        /// <summary>
        /// The date of issue of the document. 
        /// </summary>
        IDate DateOfIssue { get; }
        
        /// <summary>
        /// The additional number of the document. 
        /// </summary>
        string DocumentAdditionalNumber { get; }
        
        /// <summary>
        /// The document number. 
        /// </summary>
        string DocumentNumber { get; }
        
        /// <summary>
        /// The document type deduced from the recognized barcode 
        /// </summary>
        IdBarcodeDocumentType DocumentType { get; }
        
        /// <summary>
        /// The employer of the document owner. 
        /// </summary>
        string Employer { get; }
        
        /// <summary>
        /// The additional privileges granted to the driver license owner. 
        /// </summary>
        string Endorsements { get; }
        
        /// <summary>
        /// Checks whether the document has expired or not by comparing the current 
        /// </summary>
        bool Expired { get; }
        
        /// <summary>
        /// The first name of the document owner. 
        /// </summary>
        string FirstName { get; }
        
        /// <summary>
        /// The full name of the document owner. 
        /// </summary>
        string FullName { get; }
        
        /// <summary>
        /// The issuing authority of the document. 
        /// </summary>
        string IssuingAuthority { get; }
        
        /// <summary>
        /// The jurisdiction code address portion of the document owner. 
        /// </summary>
        string Jurisdiction { get; }
        
        /// <summary>
        /// The last name of the document owner. 
        /// </summary>
        string LastName { get; }
        
        /// <summary>
        /// The marital status of the document owner. 
        /// </summary>
        string MaritalStatus { get; }
        
        /// <summary>
        /// The nationality of the documet owner. 
        /// </summary>
        string Nationality { get; }
        
        /// <summary>
        /// The personal identification number. 
        /// </summary>
        string PersonalIdNumber { get; }
        
        /// <summary>
        /// The place of birth of the document owner. 
        /// </summary>
        string PlaceOfBirth { get; }
        
        /// <summary>
        /// The postal code address portion of the document owner. 
        /// </summary>
        string PostalCode { get; }
        
        /// <summary>
        /// The profession of the document owner. 
        /// </summary>
        string Profession { get; }
        
        /// <summary>
        /// The race of the document owner. 
        /// </summary>
        string Race { get; }
        
        /// <summary>
        /// The raw bytes contained inside barcode. 
        /// </summary>
        byte[] RawData { get; }
        
        /// <summary>
        /// The religion of the document owner. 
        /// </summary>
        string Religion { get; }
        
        /// <summary>
        /// The residential status of the document owner. 
        /// </summary>
        string ResidentialStatus { get; }
        
        /// <summary>
        /// The restrictions to driving privileges for the driver license owner. 
        /// </summary>
        string Restrictions { get; }
        
        /// <summary>
        /// The sex of the document owner. 
        /// </summary>
        string Sex { get; }
        
        /// <summary>
        /// The street address portion of the document owner. 
        /// </summary>
        string Street { get; }
        
        /// <summary>
        /// String representation of data inside barcode. 
        /// </summary>
        string StringData { get; }
        
        /// <summary>
        /// True if returned result is uncertain, i.e. if scanned barcode was incomplete (i.e. 
        /// </summary>
        bool Uncertain { get; }
        
        /// <summary>
        /// The type of vehicle the driver license owner has privilege to drive. 
        /// </summary>
        string VehicleClass { get; }
        
    }
}