using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(Pdf417Recognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class Pdf417Recognizer : Recognizer, IPdf417Recognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Pdf417.Pdf417Recognizer nativeRecognizer;

        Pdf417RecognizerResult result;

        public Pdf417Recognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkbarcode.Pdf417.Pdf417Recognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkbarcode.Pdf417.Pdf417Recognizer;
            result = new Pdf417RecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkbarcode.Pdf417.Pdf417Recognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IPdf417RecognizerResult Result => result;

        
        public bool NullQuietZoneAllowed 
        { 
            get => nativeRecognizer.NullQuietZoneAllowed; 
            set => nativeRecognizer.NullQuietZoneAllowed = value;
        }
        
        public bool ScanInverse 
        { 
            get => nativeRecognizer.ScanInverse; 
            set => nativeRecognizer.ScanInverse = value;
        }
        
        public bool ScanUncertain 
        { 
            get => nativeRecognizer.ScanUncertain; 
            set => nativeRecognizer.ScanUncertain = value;
        }
        
    }

    public sealed class Pdf417RecognizerResult : RecognizerResult, IPdf417RecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Pdf417.Pdf417Recognizer.Result nativeResult;

        internal Pdf417RecognizerResult(Com.Microblink.Entities.Recognizers.Blinkbarcode.Pdf417.Pdf417Recognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public BarcodeType BarcodeType => (BarcodeType)nativeResult.BarcodeType.Ordinal();
        public byte[] RawData => nativeResult.GetRawData();
        public string StringData => nativeResult.StringData;
        public bool Uncertain => nativeResult.IsUncertain;
    }
}