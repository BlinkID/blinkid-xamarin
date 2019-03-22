using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(JordanIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class JordanIdBackRecognizer : Recognizer, IJordanIdBackRecognizer
    {
        MBJordanIdBackRecognizer nativeRecognizer;

        JordanIdBackRecognizerResult result;

        public JordanIdBackRecognizer() : base(new MBJordanIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBJordanIdBackRecognizer;
            result = new JordanIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IJordanIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractFullName 
        { 
            get => nativeRecognizer.ExtractFullName; 
            set => nativeRecognizer.ExtractFullName = value;
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

    public sealed class JordanIdBackRecognizerResult : RecognizerResult, IJordanIdBackRecognizerResult
    {
        MBJordanIdBackRecognizerResult nativeResult;

        internal JordanIdBackRecognizerResult(MBJordanIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string FullName => nativeResult.FullName;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}