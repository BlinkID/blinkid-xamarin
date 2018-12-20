using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MrtdRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MrtdRecognizer : Recognizer, IMrtdRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer nativeRecognizer;

        MrtdRecognizerResult result;

        public MrtdRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer;
            result = new MrtdRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result);
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
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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
        
        public uint MrzImageDpi 
        { 
            get => (uint)nativeRecognizer.MrzImageDpi; 
            set => nativeRecognizer.MrzImageDpi = (int)value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
        public bool ReturnMrzImage 
        { 
            get => nativeRecognizer.ShouldReturnMrzImage(); 
            set => nativeRecognizer.SetReturnMrzImage(value);
        }
        
    }

    public sealed class MrtdRecognizerResult : RecognizerResult, IMrtdRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result nativeResult;

        internal MrtdRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource MrzImage => nativeResult.MrzImage != null ? Utils.ConvertAndroidBitmap(nativeResult.MrzImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}