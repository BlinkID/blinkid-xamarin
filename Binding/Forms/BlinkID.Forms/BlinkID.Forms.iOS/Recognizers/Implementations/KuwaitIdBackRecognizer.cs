using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(KuwaitIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class KuwaitIdBackRecognizer : Recognizer, IKuwaitIdBackRecognizer
    {
        MBKuwaitIdBackRecognizer nativeRecognizer;

        KuwaitIdBackRecognizerResult result;

        public KuwaitIdBackRecognizer() : base(new MBKuwaitIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBKuwaitIdBackRecognizer;
            result = new KuwaitIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IKuwaitIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractSerialNo 
        { 
            get => nativeRecognizer.ExtractSerialNo; 
            set => nativeRecognizer.ExtractSerialNo = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class KuwaitIdBackRecognizerResult : RecognizerResult, IKuwaitIdBackRecognizerResult
    {
        MBKuwaitIdBackRecognizerResult nativeResult;

        internal KuwaitIdBackRecognizerResult(MBKuwaitIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string SerialNo => nativeResult.SerialNo;
    }
}