using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CzechiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CzechiaIdBackRecognizer : Recognizer, ICzechiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer nativeRecognizer;

        CzechiaIdBackRecognizerResult result;

        public CzechiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer;
            result = new CzechiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICzechiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ShouldExtractAuthority(); 
            set => nativeRecognizer.SetExtractAuthority(value);
        }
        
        public bool ExtractPermanentStay 
        { 
            get => nativeRecognizer.ShouldExtractPermanentStay(); 
            set => nativeRecognizer.SetExtractPermanentStay(value);
        }
        
        public bool ExtractPersonalNumber 
        { 
            get => nativeRecognizer.ShouldExtractPersonalNumber(); 
            set => nativeRecognizer.SetExtractPersonalNumber(value);
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

    public sealed class CzechiaIdBackRecognizerResult : RecognizerResult, ICzechiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer.Result nativeResult;

        internal CzechiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PermanentStay => nativeResult.PermanentStay;
        public string PersonalNumber => nativeResult.PersonalNumber;
    }
}