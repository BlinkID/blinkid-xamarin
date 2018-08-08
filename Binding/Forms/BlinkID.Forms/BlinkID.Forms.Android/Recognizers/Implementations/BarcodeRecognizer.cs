using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BarcodeRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BarcodeRecognizer : Recognizer, IBarcodeRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Barcode.BarcodeRecognizer nativeRecognizer;

        BarcodeRecognizerResult result;

        public BarcodeRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkbarcode.Barcode.BarcodeRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkbarcode.Barcode.BarcodeRecognizer;
            result = new BarcodeRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkbarcode.Barcode.BarcodeRecognizer.Result);
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
            get => nativeRecognizer.ShouldReadCode39AsExtendedData(); 
            set => nativeRecognizer.SetReadCode39AsExtendedData(value);
        }
        
        public bool ScanAztecCode 
        { 
            get => nativeRecognizer.ShouldScanAztecCode(); 
            set => nativeRecognizer.SetScanAztecCode(value);
        }
        
        public bool ScanCode128 
        { 
            get => nativeRecognizer.ShouldScanCode128(); 
            set => nativeRecognizer.SetScanCode128(value);
        }
        
        public bool ScanCode39 
        { 
            get => nativeRecognizer.ShouldScanCode39(); 
            set => nativeRecognizer.SetScanCode39(value);
        }
        
        public bool ScanDataMatrix 
        { 
            get => nativeRecognizer.ShouldScanDataMatrix(); 
            set => nativeRecognizer.SetScanDataMatrix(value);
        }
        
        public bool ScanEan13 
        { 
            get => nativeRecognizer.ShouldScanEan13(); 
            set => nativeRecognizer.SetScanEan13(value);
        }
        
        public bool ScanEan8 
        { 
            get => nativeRecognizer.ShouldScanEan8(); 
            set => nativeRecognizer.SetScanEan8(value);
        }
        
        public bool ScanInverse 
        { 
            get => nativeRecognizer.ScanInverse; 
            set => nativeRecognizer.ScanInverse = value;
        }
        
        public bool ScanItf 
        { 
            get => nativeRecognizer.ShouldScanItf(); 
            set => nativeRecognizer.SetScanItf(value);
        }
        
        public bool ScanPdf417 
        { 
            get => nativeRecognizer.ShouldScanPdf417(); 
            set => nativeRecognizer.SetScanPdf417(value);
        }
        
        public bool ScanQrCode 
        { 
            get => nativeRecognizer.ShouldScanQrCode(); 
            set => nativeRecognizer.SetScanQrCode(value);
        }
        
        public bool ScanUncertain 
        { 
            get => nativeRecognizer.ScanUncertain; 
            set => nativeRecognizer.ScanUncertain = value;
        }
        
        public bool ScanUpca 
        { 
            get => nativeRecognizer.ShouldScanUpca(); 
            set => nativeRecognizer.SetScanUpca(value);
        }
        
        public bool ScanUpce 
        { 
            get => nativeRecognizer.ShouldScanUpce(); 
            set => nativeRecognizer.SetScanUpce(value);
        }
        
        public bool SlowerThoroughScan 
        { 
            get => nativeRecognizer.SlowerThoroughScan; 
            set => nativeRecognizer.SlowerThoroughScan = value;
        }
        
    }

    public sealed class BarcodeRecognizerResult : RecognizerResult, IBarcodeRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkbarcode.Barcode.BarcodeRecognizer.Result nativeResult;

        internal BarcodeRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkbarcode.Barcode.BarcodeRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public BarcodeType BarcodeType => (BarcodeType)nativeResult.BarcodeType.Ordinal();
        public byte[] RawData => nativeResult.GetRawData();
        public string StringData => nativeResult.StringData;
        public bool Uncertain => nativeResult.IsUncertain;
    }
}