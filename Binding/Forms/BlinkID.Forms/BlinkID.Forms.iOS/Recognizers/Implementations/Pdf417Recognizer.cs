using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(Pdf417Recognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class Pdf417Recognizer : Recognizer, IPdf417Recognizer
    {
        MBPdf417Recognizer nativeRecognizer;

        Pdf417RecognizerResult result;

        public Pdf417Recognizer() : base(new MBPdf417Recognizer())
        {
            nativeRecognizer = NativeRecognizer as MBPdf417Recognizer;
            result = new Pdf417RecognizerResult(nativeRecognizer.Result);
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
        MBPdf417RecognizerResult nativeResult;

        internal Pdf417RecognizerResult(MBPdf417RecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public BarcodeType BarcodeType => (BarcodeType)nativeResult.BarcodeType;
        public byte[] RawData => nativeResult.RawData != null ? nativeResult.RawData.ToArray() : null;
        public string StringData => nativeResult.StringData;
        public bool Uncertain => nativeResult.Uncertain;
    }
}