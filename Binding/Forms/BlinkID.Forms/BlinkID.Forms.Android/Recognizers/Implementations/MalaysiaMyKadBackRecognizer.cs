using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MalaysiaMyKadBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MalaysiaMyKadBackRecognizer : Recognizer, IMalaysiaMyKadBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadBackRecognizer nativeRecognizer;

        MalaysiaMyKadBackRecognizerResult result;

        public MalaysiaMyKadBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadBackRecognizer;
            result = new MalaysiaMyKadBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IMalaysiaMyKadBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractOldNric 
        { 
            get => nativeRecognizer.ShouldExtractOldNric(); 
            set => nativeRecognizer.SetExtractOldNric(value);
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

    public sealed class MalaysiaMyKadBackRecognizerResult : RecognizerResult, IMalaysiaMyKadBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadBackRecognizer.Result nativeResult;

        internal MalaysiaMyKadBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Malaysia.MalaysiaMyKadBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public string ExtendedNric => nativeResult.ExtendedNric;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Nric => nativeResult.Nric;
        public string OldNric => nativeResult.OldNric;
    }
}