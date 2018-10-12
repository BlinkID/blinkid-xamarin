using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ColombiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class ColombiaIdBackRecognizer : Recognizer, IColombiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer nativeRecognizer;

        ColombiaIdBackRecognizerResult result;

        public ColombiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer;
            result = new ColombiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IColombiaIdBackRecognizerResult Result => result;

        
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
        
        public bool NullQuietZoneAllowed 
        { 
            get => nativeRecognizer.NullQuietZoneAllowed; 
            set => nativeRecognizer.NullQuietZoneAllowed = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
        public bool ScanUncertain 
        { 
            get => nativeRecognizer.ScanUncertain; 
            set => nativeRecognizer.ScanUncertain = value;
        }
        
    }

    public sealed class ColombiaIdBackRecognizerResult : RecognizerResult, IColombiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer.Result nativeResult;

        internal ColombiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Colombia.ColombiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate BirthDate => nativeResult.BirthDate.Date != null ? new Date(nativeResult.BirthDate.Date) : null;
        public string BloodGroup => nativeResult.BloodGroup;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public byte[] Fingerprint => nativeResult.GetFingerprint();
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string LastName => nativeResult.LastName;
        public string Sex => nativeResult.Sex;
    }
}