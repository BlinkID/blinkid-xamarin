using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SlovakiaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SlovakiaIdBackRecognizer : Recognizer, ISlovakiaIdBackRecognizer
    {
        MBSlovakiaIdBackRecognizer nativeRecognizer;

        SlovakiaIdBackRecognizerResult result;

        public SlovakiaIdBackRecognizer() : base(new MBSlovakiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSlovakiaIdBackRecognizer;
            result = new SlovakiaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISlovakiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ExtractAddress; 
            set => nativeRecognizer.ExtractAddress = value;
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ExtractPlaceOfBirth; 
            set => nativeRecognizer.ExtractPlaceOfBirth = value;
        }
        
        public bool ExtractSpecialRemarks 
        { 
            get => nativeRecognizer.ExtractSpecialRemarks; 
            set => nativeRecognizer.ExtractSpecialRemarks = value;
        }
        
        public bool ExtractSurnameAtBirth 
        { 
            get => nativeRecognizer.ExtractSurnameAtBirth; 
            set => nativeRecognizer.ExtractSurnameAtBirth = value;
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

    public sealed class SlovakiaIdBackRecognizerResult : RecognizerResult, ISlovakiaIdBackRecognizerResult
    {
        MBSlovakiaIdBackRecognizerResult nativeResult;

        internal SlovakiaIdBackRecognizerResult(MBSlovakiaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string SpecialRemarks => nativeResult.SpecialRemarks;
        public string SurnameAtBirth => nativeResult.SurnameAtBirth;
    }
}