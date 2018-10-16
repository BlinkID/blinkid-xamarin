using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(KuwaitIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class KuwaitIdBackRecognizer : Recognizer, IKuwaitIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdBackRecognizer nativeRecognizer;

        KuwaitIdBackRecognizerResult result;

        public KuwaitIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdBackRecognizer;
            result = new KuwaitIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IKuwaitIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractSerialNo 
        { 
            get => nativeRecognizer.ShouldExtractSerialNo(); 
            set => nativeRecognizer.SetExtractSerialNo(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class KuwaitIdBackRecognizerResult : RecognizerResult, IKuwaitIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdBackRecognizer.Result nativeResult;

        internal KuwaitIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Kuwait.KuwaitIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string SerialNo => nativeResult.SerialNo;
    }
}