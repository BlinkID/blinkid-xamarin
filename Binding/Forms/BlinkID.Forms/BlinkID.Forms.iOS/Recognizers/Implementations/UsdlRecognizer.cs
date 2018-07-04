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

        public bool Uncertain => nativeResult.IsUncertain;

        public string RawStringData => nativeResult.Data.ToString(Foundation.NSStringEncoding.UTF8);

        public byte[] RawData => nativeResult.Data.ToArray();

        public string[] OptionalElements => nativeResult.OptionalElements;

        public string GetField(UsdlKeys key)
        {
            return nativeResult.GetField((MBUsdlKeys)key);
        }
    }
}
