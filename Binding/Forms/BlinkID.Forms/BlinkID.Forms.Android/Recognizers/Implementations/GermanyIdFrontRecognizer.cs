using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(GermanyIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class GermanyIdFrontRecognizer : Recognizer, IGermanyIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdFrontRecognizer nativeRecognizer;

        GermanyIdFrontRecognizerResult result;

        public GermanyIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdFrontRecognizer;
            result = new GermanyIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IGermanyIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractCanNumber 
        { 
            get => nativeRecognizer.ShouldExtractCanNumber(); 
            set => nativeRecognizer.SetExtractCanNumber(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractDocumentNumber 
        { 
            get => nativeRecognizer.ShouldExtractDocumentNumber(); 
            set => nativeRecognizer.SetExtractDocumentNumber(value);
        }
        
        public bool ExtractGivenNames 
        { 
            get => nativeRecognizer.ShouldExtractGivenNames(); 
            set => nativeRecognizer.SetExtractGivenNames(value);
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ShouldExtractNationality(); 
            set => nativeRecognizer.SetExtractNationality(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
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
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ShouldReturnFaceImage(); 
            set => nativeRecognizer.SetReturnFaceImage(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ShouldReturnSignatureImage(); 
            set => nativeRecognizer.SetReturnSignatureImage(value);
        }
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = (int)value;
        }
        
    }

    public sealed class GermanyIdFrontRecognizerResult : RecognizerResult, IGermanyIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdFrontRecognizer.Result nativeResult;

        internal GermanyIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Germany.GermanyIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string CanNumber => nativeResult.CanNumber;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string GivenNames => nativeResult.GivenNames;
        public string Nationality => nativeResult.Nationality;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
        public string Surname => nativeResult.Surname;
    }
}