using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SlovakiaCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SlovakiaCombinedRecognizer : Recognizer, ISlovakiaCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaCombinedRecognizer nativeRecognizer;

        SlovakiaCombinedRecognizerResult result;

        public SlovakiaCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaCombinedRecognizer;
            result = new SlovakiaCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISlovakiaCombinedRecognizerResult Result => result;

        
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
        
        public bool ExtractSpecialRemarks 
        { 
            get => nativeRecognizer.ShouldExtractSpecialRemarks(); 
            set => nativeRecognizer.SetExtractSpecialRemarks(value);
        }
        
        public bool ExtractSurnameAtBirth 
        { 
            get => nativeRecognizer.ShouldExtractSurnameAtBirth(); 
            set => nativeRecognizer.SetExtractSurnameAtBirth(value);
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class SlovakiaCombinedRecognizerResult : RecognizerResult, ISlovakiaCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaCombinedRecognizer.Result nativeResult;

        internal SlovakiaCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Slovakia.SlovakiaCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdentificationNumber => nativeResult.PersonalIdentificationNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
        public string SpecialRemarks => nativeResult.SpecialRemarks;
        public string SurnameAtBirth => nativeResult.SurnameAtBirth;
    }
}