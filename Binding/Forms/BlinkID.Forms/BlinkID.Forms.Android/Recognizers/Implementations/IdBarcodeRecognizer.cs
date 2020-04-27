using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(IdBarcodeRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class IdBarcodeRecognizer : Recognizer, IIdBarcodeRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Idbarcode.IdBarcodeRecognizer nativeRecognizer;

        IdBarcodeRecognizerResult result;

        public IdBarcodeRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Idbarcode.IdBarcodeRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Idbarcode.IdBarcodeRecognizer;
            result = new IdBarcodeRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Idbarcode.IdBarcodeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IIdBarcodeRecognizerResult Result => result;

        
    }

    public sealed class IdBarcodeRecognizerResult : RecognizerResult, IIdBarcodeRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Idbarcode.IdBarcodeRecognizer.Result nativeResult;

        internal IdBarcodeRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Idbarcode.IdBarcodeRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AdditionalAddressInformation => nativeResult.AdditionalAddressInformation;
        public string AdditionalNameInformation => nativeResult.AdditionalNameInformation;
        public string Address => nativeResult.Address;
        public int Age => (int)nativeResult.Age;
        public BarcodeType BarcodeType => (BarcodeType)nativeResult.BarcodeType.Ordinal();
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public IdBarcodeDocumentType DocumentType => (IdBarcodeDocumentType)nativeResult.DocumentType.Ordinal();
        public string Employer => nativeResult.Employer;
        public string FirstName => nativeResult.FirstName;
        public string FullName => nativeResult.FullName;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string MaritalStatus => nativeResult.MaritalStatus;
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdNumber => nativeResult.PersonalIdNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string Profession => nativeResult.Profession;
        public string Race => nativeResult.Race;
        public byte[] RawData => nativeResult.GetRawData();
        public string Religion => nativeResult.Religion;
        public string ResidentialStatus => nativeResult.ResidentialStatus;
        public string Sex => nativeResult.Sex;
        public string StringData => nativeResult.StringData;
        public bool Uncertain => nativeResult.IsUncertain;
    }
}