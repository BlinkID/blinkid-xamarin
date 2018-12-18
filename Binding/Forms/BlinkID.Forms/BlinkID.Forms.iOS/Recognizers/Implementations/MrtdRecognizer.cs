using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class MrtdRecognizer : Recognizer, IMrtdRecognizer
    {
        MBMrtdRecognizer nativeRecognizer;

        MrtdRecognizerResult result;

        public MrtdRecognizer() : base(new MBMrtdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBMrtdRecognizer;
            result = new MrtdRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMrtdRecognizerResult Result => result;

        
        public bool AllowUnparsedResults 
        { 
            get => nativeRecognizer.AllowUnparsedResults; 
            set => nativeRecognizer.AllowUnparsedResults = value;
        }
        
        public bool AllowUnverifiedResults 
        { 
            get => nativeRecognizer.AllowUnverifiedResults; 
            set => nativeRecognizer.AllowUnverifiedResults = value;
        }
        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
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
        
        public uint MrzImageDpi 
        { 
            get => (uint)nativeRecognizer.MrzImageDpi; 
            set => nativeRecognizer.MrzImageDpi = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        public bool ReturnMrzImage 
        { 
            get => nativeRecognizer.ReturnMrzImage; 
            set => nativeRecognizer.ReturnMrzImage = value;
        }
        
    }

    public sealed class MrtdRecognizerResult : RecognizerResult, IMrtdRecognizerResult
    {
        MBMrtdRecognizerResult nativeResult;

        internal MrtdRecognizerResult(MBMrtdRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public Xamarin.Forms.ImageSource MrzImage => nativeResult.MrzImage != null ? Utils.ConvertUIImage(nativeResult.MrzImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}