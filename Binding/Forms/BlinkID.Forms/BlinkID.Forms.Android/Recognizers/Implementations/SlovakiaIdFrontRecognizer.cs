using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SlovakiaIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SlovakiaIdFrontRecognizer : Recognizer, ISlovakiaIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdFrontRecognizer nativeRecognizer;

        SlovakiaIdFrontRecognizerResult result;

        public SlovakiaIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdFrontRecognizer;
            result = new SlovakiaIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISlovakiaIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractDocumentNumber 
        { 
            get => nativeRecognizer.ShouldExtractDocumentNumber(); 
            set => nativeRecognizer.SetExtractDocumentNumber(value);
        }
        
        public bool ExtractIssuedBy 
        { 
            get => nativeRecognizer.ShouldExtractIssuedBy(); 
            set => nativeRecognizer.SetExtractIssuedBy(value);
        }
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ShouldExtractNationality(); 
            set => nativeRecognizer.SetExtractNationality(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
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
        
    }

    public sealed class SlovakiaIdFrontRecognizerResult : RecognizerResult, ISlovakiaIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdFrontRecognizer.Result nativeResult;

        internal SlovakiaIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IssuedBy => nativeResult.IssuedBy;
        public string LastName => nativeResult.LastName;
        public string Nationality => nativeResult.Nationality;
        public string PersonalNumber => nativeResult.PersonalNumber;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
    }
}