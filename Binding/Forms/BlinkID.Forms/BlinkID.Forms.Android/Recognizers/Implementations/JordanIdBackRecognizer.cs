using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(JordanIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class JordanIdBackRecognizer : Recognizer, IJordanIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer nativeRecognizer;

        JordanIdBackRecognizerResult result;

        public JordanIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer;
            result = new JordanIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IJordanIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractFullName 
        { 
            get => nativeRecognizer.ShouldExtractFullName(); 
            set => nativeRecognizer.SetExtractFullName(value);
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

    public sealed class JordanIdBackRecognizerResult : RecognizerResult, IJordanIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer.Result nativeResult;

        internal JordanIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Jordan.JordanIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}