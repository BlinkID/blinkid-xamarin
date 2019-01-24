using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(GermanyIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class GermanyIdBackRecognizer : Recognizer, IGermanyIdBackRecognizer
    {
        MBGermanyIdBackRecognizer nativeRecognizer;

        GermanyIdBackRecognizerResult result;

        public GermanyIdBackRecognizer() : base(new MBGermanyIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBGermanyIdBackRecognizer;
            result = new GermanyIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IGermanyIdBackRecognizerResult Result => result;

        
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
        
        public bool ExtractAuthority 
        { 
            get => nativeRecognizer.ExtractAuthority; 
            set => nativeRecognizer.ExtractAuthority = value;
        }
        
        public bool ExtractColourOfEyes 
        { 
            get => nativeRecognizer.ExtractColourOfEyes; 
            set => nativeRecognizer.ExtractColourOfEyes = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
        }
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ExtractHeight; 
            set => nativeRecognizer.ExtractHeight = value;
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

    public sealed class GermanyIdBackRecognizerResult : RecognizerResult, IGermanyIdBackRecognizerResult
    {
        MBGermanyIdBackRecognizerResult nativeResult;

        internal GermanyIdBackRecognizerResult(MBGermanyIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AddressCity => nativeResult.AddressCity;
        public string AddressHouseNumber => nativeResult.AddressHouseNumber;
        public string AddressStreet => nativeResult.AddressStreet;
        public string AddressZipCode => nativeResult.AddressZipCode;
        public string Authority => nativeResult.Authority;
        public string ColourOfEyes => nativeResult.ColourOfEyes;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string FullAddress => nativeResult.FullAddress;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Height => nativeResult.Height;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
    }
}