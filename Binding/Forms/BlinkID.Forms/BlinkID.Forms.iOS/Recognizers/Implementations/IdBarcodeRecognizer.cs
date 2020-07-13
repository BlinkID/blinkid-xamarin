using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(IdBarcodeRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class IdBarcodeRecognizer : Recognizer, IIdBarcodeRecognizer
    {
        MBIdBarcodeRecognizer nativeRecognizer;

        IdBarcodeRecognizerResult result;

        public IdBarcodeRecognizer() : base(new MBIdBarcodeRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBIdBarcodeRecognizer;
            result = new IdBarcodeRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IIdBarcodeRecognizerResult Result => result;

        
    }

    public sealed class IdBarcodeRecognizerResult : RecognizerResult, IIdBarcodeRecognizerResult
    {
        MBIdBarcodeRecognizerResult nativeResult;

        internal IdBarcodeRecognizerResult(MBIdBarcodeRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AdditionalNameInformation => nativeResult.AdditionalNameInformation;
        public string Address => nativeResult.Address;
        public int Age => (int)nativeResult.Age;
        public BarcodeType BarcodeType => (BarcodeType)nativeResult.BarcodeType;
        public string City => nativeResult.City;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public IdBarcodeDocumentType DocumentType => (IdBarcodeDocumentType)nativeResult.DocumentType;
        public string Employer => nativeResult.Employer;
        public string Endorsements => nativeResult.Endorsements;
        public bool Expired => nativeResult.Expired;
        public string FirstName => nativeResult.FirstName;
        public string FullName => nativeResult.FullName;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string Jurisdiction => nativeResult.Jurisdiction;
        public string LastName => nativeResult.LastName;
        public string MaritalStatus => nativeResult.MaritalStatus;
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdNumber => nativeResult.PersonalIdNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string PostalCode => nativeResult.PostalCode;
        public string Profession => nativeResult.Profession;
        public string Race => nativeResult.Race;
        public byte[] RawData => nativeResult.RawData != null ? nativeResult.RawData.ToArray() : null;
        public string Religion => nativeResult.Religion;
        public string ResidentialStatus => nativeResult.ResidentialStatus;
        public string Restrictions => nativeResult.Restrictions;
        public string Sex => nativeResult.Sex;
        public string Street => nativeResult.Street;
        public string StringData => nativeResult.StringData;
        public bool Uncertain => nativeResult.Uncertain;
        public string VehicleClass => nativeResult.VehicleClass;
    }
}