using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(AustriaIdBackRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class AustriaIdBackRecognizer : Recognizer, IAustriaIdBackRecognizer
    {
        MBAustriaIdBackRecognizer nativeRecognizer;

        AustriaIdBackRecognizerResult result;

        public AustriaIdBackRecognizer() : base(new MBAustriaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBAustriaIdBackRecognizer;
            result = new AustriaIdBackRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IAustriaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDateOfIssuance 
        { 
            get => nativeRecognizer.ExtractDateOfIssuance; 
            set => nativeRecognizer.ExtractDateOfIssuance = value;
        }
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ExtractHeight; 
            set => nativeRecognizer.ExtractHeight = value;
        }
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ExtractIssuingAuthority; 
            set => nativeRecognizer.ExtractIssuingAuthority = value;
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ExtractPlaceOfBirth; 
            set => nativeRecognizer.ExtractPlaceOfBirth = value;
        }
        
        public bool ExtractPrincipalResidence 
        { 
            get => nativeRecognizer.ExtractPrincipalResidence; 
            set => nativeRecognizer.ExtractPrincipalResidence = value;
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

    public sealed class AustriaIdBackRecognizerResult : RecognizerResult, IAustriaIdBackRecognizerResult
    {
        MBAustriaIdBackRecognizerResult nativeResult;

        internal AustriaIdBackRecognizerResult(MBAustriaIdBackRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfIssuance => nativeResult.DateOfIssuance != null ? new Date(nativeResult.DateOfIssuance) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public string EyeColour => nativeResult.EyeColour;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string Height => nativeResult.Height;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string PrincipalResidence => nativeResult.PrincipalResidence;
    }
}