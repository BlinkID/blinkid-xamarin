using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(AustraliaDlBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class AustraliaDlBackRecognizer : Recognizer, IAustraliaDlBackRecognizer
    {
        MBAustraliaDlBackRecognizer nativeRecognizer;

        AustraliaDlBackRecognizerResult result;

        public AustraliaDlBackRecognizer() : base(new MBAustraliaDlBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBAustraliaDlBackRecognizer;
            result = new AustraliaDlBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IAustraliaDlBackRecognizerResult Result => result;

        
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
        
        public bool ExtractLastName 
        { 
            get => nativeRecognizer.ExtractLastName; 
            set => nativeRecognizer.ExtractLastName = value;
        }
        
        public bool ExtractLicenceNumber 
        { 
            get => nativeRecognizer.ExtractLicenceNumber; 
            set => nativeRecognizer.ExtractLicenceNumber = value;
        }
        
        public bool ExtractLicenseExpiry 
        { 
            get => nativeRecognizer.ExtractLicenseExpiry; 
            set => nativeRecognizer.ExtractLicenseExpiry = value;
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

    public sealed class AustraliaDlBackRecognizerResult : RecognizerResult, IAustraliaDlBackRecognizerResult
    {
        MBAustraliaDlBackRecognizerResult nativeResult;

        internal AustraliaDlBackRecognizerResult(MBAustraliaDlBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string LastName => nativeResult.LastName;
        public IDate LicenceExpiry => nativeResult.LicenceExpiry != null ? new Date(nativeResult.LicenceExpiry) : null;
        public string LicenceNumber => nativeResult.LicenceNumber;
    }
}