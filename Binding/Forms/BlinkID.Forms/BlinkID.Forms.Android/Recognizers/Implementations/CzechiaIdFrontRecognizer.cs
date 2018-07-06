using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CzechiaIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CzechiaIdFrontRecognizer : Recognizer, ICzechiaIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdFrontRecognizer nativeRecognizer;

        CzechiaIdFrontRecognizerResult result;

        public CzechiaIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdFrontRecognizer;
            result = new CzechiaIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICzechiaIdFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractGivenNames 
        { 
            get => nativeRecognizer.ShouldExtractGivenNames(); 
            set => nativeRecognizer.SetExtractGivenNames(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
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

    public sealed class CzechiaIdFrontRecognizerResult : RecognizerResult, ICzechiaIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdFrontRecognizer.Result nativeResult;

        internal CzechiaIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string IdentityCardNumber => nativeResult.IdentityCardNumber;
        public string LastName => nativeResult.LastName;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
    }
}