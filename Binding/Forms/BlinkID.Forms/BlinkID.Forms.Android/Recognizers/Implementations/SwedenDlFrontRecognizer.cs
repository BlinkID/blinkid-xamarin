using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwedenDlFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SwedenDlFrontRecognizer : Recognizer, ISwedenDlFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Sweden.DL.SwedenDlFrontRecognizer nativeRecognizer;

        SwedenDlFrontRecognizerResult result;

        public SwedenDlFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Sweden.DL.SwedenDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Sweden.DL.SwedenDlFrontRecognizer;
            result = new SwedenDlFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Sweden.DL.SwedenDlFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwedenDlFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractIssuingAgency 
        { 
            get => nativeRecognizer.ShouldExtractIssuingAgency(); 
            set => nativeRecognizer.SetExtractIssuingAgency(value);
        }
        
        public bool ExtractLicenceCategories 
        { 
            get => nativeRecognizer.ShouldExtractLicenceCategories(); 
            set => nativeRecognizer.SetExtractLicenceCategories(value);
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ShouldExtractName(); 
            set => nativeRecognizer.SetExtractName(value);
        }
        
        public bool ExtractReferenceNumber 
        { 
            get => nativeRecognizer.ShouldExtractReferenceNumber(); 
            set => nativeRecognizer.SetExtractReferenceNumber(value);
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ShouldExtractSurname(); 
            set => nativeRecognizer.SetExtractSurname(value);
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
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

    public sealed class SwedenDlFrontRecognizerResult : RecognizerResult, ISwedenDlFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Sweden.DL.SwedenDlFrontRecognizer.Result nativeResult;

        internal SwedenDlFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Sweden.DL.SwedenDlFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string IssuingAgency => nativeResult.IssuingAgency;
        public string LicenceCategories => nativeResult.LicenceCategories;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string Name => nativeResult.Name;
        public string ReferenceNumber => nativeResult.ReferenceNumber;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
        public string Surname => nativeResult.Surname;
    }
}