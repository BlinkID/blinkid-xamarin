using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UsdlRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class UsdlRecognizer : Recognizer, IUsdlRecognizer
    {
        MBUsdlRecognizer nativeRecognizer;
        readonly UsdlRecognizerResult result;

        public UsdlRecognizer()
            : base(new MBUsdlRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBUsdlRecognizer;
            result = new UsdlRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public bool UncertainDecoding { get => nativeRecognizer.ScanUncertain; set => nativeRecognizer.ScanUncertain = value; }
        public bool NullQuietZoneAllowed { get => nativeRecognizer.AllowNullQuietZone; set => nativeRecognizer.AllowNullQuietZone = value; }
        public bool EnableCompactParser { get => nativeRecognizer.EnableCompactParser; set => nativeRecognizer.EnableCompactParser = value; }

        public IUsdlRecognizerResult Result => result;
    }

    public sealed class UsdlRecognizerResult : RecognizerResult, IUsdlRecognizerResult
    {
        MBUsdlRecognizerResult nativeResult;

        internal UsdlRecognizerResult(MBUsdlRecognizerResult nativeResult)
            : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public string FirstName => nativeResult.FirstName;

        public string LastName => nativeResult.LastName;

        public string FullName => nativeResult.FullName;

        public string Address => nativeResult.Address;

        public string DocumentNumber => nativeResult.DocumentNumber;

        public string Sex => nativeResult.Sex;

        public string Restrictions => nativeResult.Restrictions;

        public string Endorsements => nativeResult.Endorsements;

        public string VehicleClass => nativeResult.VehicleClass;

        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;

        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;

        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;

        public bool Uncertain => nativeResult.IsUncertain;

        public string RawStringData => nativeResult.Data.ToString(Foundation.NSStringEncoding.UTF8);

        public byte[] RawData => nativeResult.Data.ToArray();

        public string[] OptionalElements => nativeResult.OptionalElements;

        public string GetField(UsdlKeys key)
        {
            return nativeResult.GetField((MBUsdlKeys)key);
        }

        public int Age => nativeResult.Age;

        public string Street => nativeResult.Street;

        public string PostalCode => nativeResult.PostalCode;

        public string City => nativeResult.City;

        public string Jurisdiction => nativeResult.Jurisdiction;
    }
}
