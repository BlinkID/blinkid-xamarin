using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Droid.Recognizers;
using Xamarin.Forms;

[assembly: Dependency(typeof(UsdlCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class UsdlCombinedRecognizer : Recognizer, IUsdlCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer nativeRecognizer;
        UsdlCombinedRecognizerResult result;

        public UsdlCombinedRecognizer()
            : base(new Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer;
            result = new UsdlCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IUsdlCombinedRecognizerResult Result => result;

        public uint FaceImageDpi { get => (uint)nativeRecognizer.FaceImageDpi; set => nativeRecognizer.FaceImageDpi = (int)value; }
        public bool ReturnFaceImage { get => nativeRecognizer.ShouldReturnFaceImage(); set => nativeRecognizer.SetReturnFaceImage(value); }
        public uint FullDocumentImageDpi { get => (uint)nativeRecognizer.FullDocumentImageDpi; set => nativeRecognizer.FullDocumentImageDpi = (int)value; }
        public bool ReturnFullDocumentImage { get => nativeRecognizer.ShouldReturnFullDocumentImage(); set => nativeRecognizer.SetReturnFullDocumentImage(value); }
        public uint NumStableDetectionsThreshold 
        { 
            get => (uint)nativeRecognizer.NumStableDetectionsThreshold; 
            set => nativeRecognizer.NumStableDetectionsThreshold = (int)value;
        }
        public bool SignResult { get => nativeRecognizer.ShouldSignResult(); set => nativeRecognizer.SetSignResult(value); }
    }

    public sealed class UsdlCombinedRecognizerResult : RecognizerResult, IUsdlCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer.Result nativeResult;

        internal UsdlCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Usdl.UsdlCombinedRecognizer.Result nativeResult)
            : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public bool Uncertain => nativeResult.IsUncertain;

        public string RawStringData => nativeResult.RawStringData;

        public byte[] RawData => nativeResult.GetRawData();

        public string[] OptionalElements => nativeResult.GetOptionalElements();

        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();

        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;

        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;

        public ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());

        public ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());

        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;

        public string GetField(UsdlKeys key)
        {
            return nativeResult.GetField(Com.Microblink.Entities.Recognizers.Blinkbarcode.Usdl.UsdlKeys.Values()[(int)key]);
        }
    }
}
