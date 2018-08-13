using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BarcodeRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BarcodeRecognizer : Recognizer, IBarcodeRecognizer
    {
        MBBarcodeRecognizer nativeRecognizer;

        BarcodeRecognizerResult result;

        public BarcodeRecognizer() : base(new MBBarcodeRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBarcodeRecognizer;
            result = new BarcodeRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBarcodeRecognizerResult Result => result;

        
        public bool AutoScaleDetection 
        { 
            get => nativeRecognizer.AutoScaleDetection; 
            set => nativeRecognizer.AutoScaleDetection = value;
        }
        
        public bool NullQuietZoneAllowed 
        { 
            get => nativeRecognizer.NullQuietZoneAllowed; 
            set => nativeRecognizer.NullQuietZoneAllowed = value;
        }
        
        public bool ReadCode39AsExtendedData 
        { 
            get => nativeRecognizer.ReadCode39AsExtendedData; 
            set => nativeRecognizer.ReadCode39AsExtendedData = value;
        }
        
        public bool ScanAztecCode 
        { 
            get => nativeRecognizer.ScanAztecCode; 
            set => nativeRecognizer.ScanAztecCode = value;
        }
        
        public bool ScanCode128 
        { 
            get => nativeRecognizer.ScanCode128; 
            set => nativeRecognizer.ScanCode128 = value;
        }
        
        public bool ScanCode39 
        { 
            get => nativeRecognizer.ScanCode39; 
            set => nativeRecognizer.ScanCode39 = value;
        }
        
        public bool ScanDataMatrix 
        { 
            get => nativeRecognizer.ScanDataMatrix; 
            set => nativeRecognizer.ScanDataMatrix = value;
        }
        
        public bool ScanEan13 
        { 
            get => nativeRecognizer.ScanEan13; 
            set => nativeRecognizer.ScanEan13 = value;
        }
        
        public bool ScanEan8 
        { 
            get => nativeRecognizer.ScanEan8; 
            set => nativeRecognizer.ScanEan8 = value;
        }
        
        public bool ScanInverse 
        { 
            get => nativeRecognizer.ScanInverse; 
            set => nativeRecognizer.ScanInverse = value;
        }
        
        public bool ScanItf 
        { 
            get => nativeRecognizer.ScanItf; 
            set => nativeRecognizer.ScanItf = value;
        }
        
        public bool ScanPdf417 
        { 
            get => nativeRecognizer.ScanPdf417; 
            set => nativeRecognizer.ScanPdf417 = value;
        }
        
        public bool ScanQrCode 
        { 
            get => nativeRecognizer.ScanQrCode; 
            set => nativeRecognizer.ScanQrCode = value;
        }
        
        public bool ScanUncertain 
        { 
            get => nativeRecognizer.ScanUncertain; 
            set => nativeRecognizer.ScanUncertain = value;
        }
        
        public bool ScanUpca 
        { 
            get => nativeRecognizer.ScanUpca; 
            set => nativeRecognizer.ScanUpca = value;
        }
        
        public bool ScanUpce 
        { 
            get => nativeRecognizer.ScanUpce; 
            set => nativeRecognizer.ScanUpce = value;
        }
        
        public bool SlowerThoroughScan 
        { 
            get => nativeRecognizer.SlowerThoroughScan; 
            set => nativeRecognizer.SlowerThoroughScan = value;
        }
        
    }

    public sealed class BarcodeRecognizerResult : RecognizerResult, IBarcodeRecognizerResult
    {
        MBBarcodeRecognizerResult nativeResult;

        internal BarcodeRecognizerResult(MBBarcodeRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public BarcodeType BarcodeType => (BarcodeType)nativeResult.BarcodeType;
        public byte[] RawData => nativeResult.RawData != null ? nativeResult.RawData.ToArray() : null;
        public string StringData => nativeResult.StringData;
        public bool Uncertain => nativeResult.Uncertain;
    }
}