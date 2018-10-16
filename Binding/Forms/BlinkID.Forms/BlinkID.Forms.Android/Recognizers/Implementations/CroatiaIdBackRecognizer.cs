using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CroatiaIdBackRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CroatiaIdBackRecognizer : Recognizer, ICroatiaIdBackRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer nativeRecognizer;

        CroatiaIdBackRecognizerResult result;

        public CroatiaIdBackRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer;
            result = new CroatiaIdBackRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICroatiaIdBackRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractIssuedBy 
        { 
            get => nativeRecognizer.ShouldExtractIssuedBy(); 
            set => nativeRecognizer.SetExtractIssuedBy(value);
        }
        
        public bool ExtractResidence 
        { 
            get => nativeRecognizer.ShouldExtractResidence(); 
            set => nativeRecognizer.SetExtractResidence(value);
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

    public sealed class CroatiaIdBackRecognizerResult : RecognizerResult, ICroatiaIdBackRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer.Result nativeResult;

        internal CroatiaIdBackRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdBackRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public bool DateOfExpiryPermanent => nativeResult.IsDateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public bool DocumentForNonResident => nativeResult.IsDocumentForNonResident;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IssuedBy => nativeResult.IssuedBy;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Residence => nativeResult.Residence;
    }
}