using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(AustriaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class AustriaIdBackRecognizer : Recognizer, IAustriaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Austria.AustriaIdBackRecognizer nativeRecognizer;

        AustriaIdBackRecognizerResult result;

        public AustriaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Austria.AustriaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Austria.AustriaIdBackRecognizer;
            result = new AustriaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Austria.AustriaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IAustriaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractDateOfIssuance 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssuance(); 
            set => nativeRecognizer.SetExtractDateOfIssuance(value);
        }
        
        public bool ExtractHeight 
        { 
            get => nativeRecognizer.ShouldExtractHeight(); 
            set => nativeRecognizer.SetExtractHeight(value);
        }
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ShouldExtractIssuingAuthority(); 
            set => nativeRecognizer.SetExtractIssuingAuthority(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractPrincipalResidence 
        { 
            get => nativeRecognizer.ShouldExtractPrincipalResidence(); 
            set => nativeRecognizer.SetExtractPrincipalResidence(value);
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

    public sealed class AustriaIdBackRecognizerResult : RecognizerResult, IAustriaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Austria.AustriaIdBackRecognizer.Result nativeResult;

        internal AustriaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Austria.AustriaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfIssuance => nativeResult.DateOfIssuance.Date != null ? new Date(nativeResult.DateOfIssuance.Date) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public string EyeColour => nativeResult.EyeColour;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string Height => nativeResult.Height;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string PrincipalResidence => nativeResult.PrincipalResidence;
    }
}