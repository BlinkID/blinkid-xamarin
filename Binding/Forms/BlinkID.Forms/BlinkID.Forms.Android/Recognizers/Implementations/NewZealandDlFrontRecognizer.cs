using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(NewZealandDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class NewZealandDlFrontRecognizer : Recognizer, INewZealandDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Newzealand.NewZealandDlFrontRecognizer nativeRecognizer;

        NewZealandDlFrontRecognizerResult result;

        public NewZealandDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Newzealand.NewZealandDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Newzealand.NewZealandDlFrontRecognizer;
            result = new NewZealandDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Newzealand.NewZealandDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public INewZealandDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractDonorIndicator 
        { 
            get => nativeRecognizer.ShouldExtractDonorIndicator(); 
            set => nativeRecognizer.SetExtractDonorIndicator(value);
        }
        
        public bool ExtractExpiryDate 
        { 
            get => nativeRecognizer.ShouldExtractExpiryDate(); 
            set => nativeRecognizer.SetExtractExpiryDate(value);
        }
        
        public bool ExtractFirstNames 
        { 
            get => nativeRecognizer.ShouldExtractFirstNames(); 
            set => nativeRecognizer.SetExtractFirstNames(value);
        }
        
        public bool ExtractIssueDate 
        { 
            get => nativeRecognizer.ShouldExtractIssueDate(); 
            set => nativeRecognizer.SetExtractIssueDate(value);
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

    public sealed class NewZealandDlFrontRecognizerResult : RecognizerResult, INewZealandDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Newzealand.NewZealandDlFrontRecognizer.Result nativeResult;

        internal NewZealandDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Newzealand.NewZealandDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string CardVersion => nativeResult.CardVersion;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public bool DonorIndicator => nativeResult.DonorIndicator;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public string FirstNames => nativeResult.FirstNames;
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public IDate IssueDate => nativeResult.IssueDate != null ? new Date(nativeResult.IssueDate) : null;
        public string LicenseNumber => nativeResult.LicenseNumber;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
        public string Surname => nativeResult.Surname;
    }
}