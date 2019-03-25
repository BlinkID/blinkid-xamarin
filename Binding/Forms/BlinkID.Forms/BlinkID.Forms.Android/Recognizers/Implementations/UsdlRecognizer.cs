using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Droid.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(UsdlRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class UsdlRecognizer : Recognizer, IUsdlRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlRecognizer nativeRecognizer;
        readonly UsdlRecognizerResult result;

        public UsdlRecognizer()
            : base(new Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlRecognizer;
            result = new UsdlRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public bool UncertainDecoding { get => nativeRecognizer.UncertainDecoding; set => nativeRecognizer.UncertainDecoding = value; }
        public bool NullQuietZoneAllowed { get => nativeRecognizer.NullQuietZoneAllowed; set => nativeRecognizer.NullQuietZoneAllowed = value; }

        public IUsdlRecognizerResult Result => result;
    }

    public sealed class UsdlRecognizerResult : RecognizerResult, IUsdlRecognizerResult
    {
        readonly Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlRecognizer.Result nativeResult;

        internal UsdlRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlRecognizer.Result nativeResult)
            : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public bool Uncertain => nativeResult.IsUncertain;

        public string RawStringData => nativeResult.RawStringData;

        public byte[] RawData => nativeResult.GetRawData();

        public string[] OptionalElements => nativeResult.GetOptionalElements();

        public string GetField(UsdlKeys key)
        {
            return nativeResult.GetField(Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlKeys.Values()[(int)key]);
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
    }
}
