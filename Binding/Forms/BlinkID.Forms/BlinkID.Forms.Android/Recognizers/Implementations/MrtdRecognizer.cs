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
        
        public uint SaveImageDPI 
        { 
            get => (uint)nativeRecognizer.SaveImageDPI; 
            set => nativeRecognizer.SaveImageDPI = (int)value;
        }
        
    }

    public sealed class MrtdRecognizerResult : RecognizerResult, IMrtdRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result nativeResult;

        internal MrtdRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrtdRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource MrzImage => Utils.ConvertAndroidBitmap(nativeResult.MrzImage.ConvertToBitmap());
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}