using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CzechiaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class CzechiaIdBackRecognizer : Recognizer, ICzechiaIdBackRecognizer
    {
        MBCzechiaIdBackRecognizer nativeRecognizer;

        CzechiaIdBackRecognizerResult result;

        public CzechiaIdBackRecognizer() : base(new MBCzechiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBCzechiaIdBackRecognizer;
            result = new CzechiaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICzechiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ExtractAuthority; 
            set => nativeRecognizer.ExtractAuthority = value;
        }
        
        public bool ExtractPermanentStay 
        { 
            get => nativeRecognizer.ExtractPermanentStay; 
            set => nativeRecognizer.ExtractPermanentStay = value;
        }
        
        public bool ExtractPersonalNumber 
        { 
            get => nativeRecognizer.ExtractPersonalNumber; 
            set => nativeRecognizer.ExtractPersonalNumber = value;
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

    public sealed class CzechiaIdBackRecognizerResult : RecognizerResult, ICzechiaIdBackRecognizerResult
    {
        MBCzechiaIdBackRecognizerResult nativeResult;

        internal CzechiaIdBackRecognizerResult(MBCzechiaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Authority => nativeResult.Authority;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PermanentStay => nativeResult.PermanentStay;
        public string PersonalNumber => nativeResult.PersonalNumber;
    }
}