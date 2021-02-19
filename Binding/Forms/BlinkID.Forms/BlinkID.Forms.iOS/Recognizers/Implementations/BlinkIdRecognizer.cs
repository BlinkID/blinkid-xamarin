using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class BlinkIdRecognizer : Recognizer, IBlinkIdRecognizer
    {
        MBBlinkIdRecognizer nativeRecognizer;

        BlinkIdRecognizerResult result;

        public BlinkIdRecognizer() : base(new MBBlinkIdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBBlinkIdRecognizer;
            result = new BlinkIdRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkIdRecognizerResult Result => result;

        
        public bool AllowBlurFilter 
        { 
            get => nativeRecognizer.AllowBlurFilter; 
            set => nativeRecognizer.AllowBlurFilter = value;
        }
        
        public bool AllowUnparsedMrzResults 
        { 
            get => nativeRecognizer.AllowUnparsedMrzResults; 
            set => nativeRecognizer.AllowUnparsedMrzResults = value;
        }
        
        public bool AllowUnverifiedMrzResults 
        { 
            get => nativeRecognizer.AllowUnverifiedMrzResults; 
            set => nativeRecognizer.AllowUnverifiedMrzResults = value;
        }
        
        public AnonymizationMode AnonymizationMode 
        { 
            get => (AnonymizationMode)nativeRecognizer.AnonymizationMode; 
            set => nativeRecognizer.AnonymizationMode = (MBAnonymizationMode)value;
        }
        
        public int FaceImageDpi 
        { 
            get => (int)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
        }
        
        public int FullDocumentImageDpi 
        { 
            get => (int)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
        
        public float PaddingEdge 
        { 
            get => (float)nativeRecognizer.PaddingEdge; 
            set => nativeRecognizer.PaddingEdge = value;
        }
        
        public IRecognitionModeFilter RecognitionModeFilter 
        { 
            get => new RecognitionModeFilter(nativeRecognizer.RecognitionModeFilter); 
            set => nativeRecognizer.RecognitionModeFilter = (value as RecognitionModeFilter).NativeFilter;
        }
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ReturnFaceImage; 
            set => nativeRecognizer.ReturnFaceImage = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ReturnSignatureImage; 
            set => nativeRecognizer.ReturnSignatureImage = value;
        }
        
        public bool ScanCroppedDocumentImage 
        { 
            get => nativeRecognizer.ScanCroppedDocumentImage; 
            set => nativeRecognizer.ScanCroppedDocumentImage = value;
        }
        
        public int SignatureImageDpi 
        { 
            get => (int)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = value;
        }
        
        public bool ValidateResultCharacters 
        { 
            get => nativeRecognizer.ValidateResultCharacters; 
            set => nativeRecognizer.ValidateResultCharacters = value;
        }
        
    }

    public sealed class BlinkIdRecognizerResult : RecognizerResult, IBlinkIdRecognizerResult
    {
        MBBlinkIdRecognizerResult nativeResult;

        internal BlinkIdRecognizerResult(MBBlinkIdRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AdditionalAddressInformation => nativeResult.AdditionalAddressInformation;
        public string AdditionalNameInformation => nativeResult.AdditionalNameInformation;
        public string Address => nativeResult.Address;
        public int Age => (int)nativeResult.Age;
        public IBarcodeResult BarcodeResult => new BarcodeResult(nativeResult.BarcodeResult);
        public IClassInfo ClassInfo => new ClassInfo(nativeResult.ClassInfo);
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public bool DateOfExpiryPermanent => nativeResult.DateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public string DocumentOptionalAdditionalNumber => nativeResult.DocumentOptionalAdditionalNumber;
        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => new DriverLicenseDetailedInfo(nativeResult.DriverLicenseDetailedInfo);
        public string Employer => nativeResult.Employer;
        public bool Expired => nativeResult.Expired;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string FullName => nativeResult.FullName;
        public IImageAnalysisResult ImageAnalysisResult => new ImageAnalysisResult(nativeResult.ImageAnalysisResult);
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string LocalizedName => nativeResult.LocalizedName;
        public string MaritalStatus => nativeResult.MaritalStatus;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdNumber => nativeResult.PersonalIdNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public ProcessingStatus ProcessingStatus => (ProcessingStatus)nativeResult.ProcessingStatus;
        public string Profession => nativeResult.Profession;
        public string Race => nativeResult.Race;
        public RecognitionMode RecognitionMode => (RecognitionMode)nativeResult.RecognitionMode;
        public string Religion => nativeResult.Religion;
        public string ResidentialStatus => nativeResult.ResidentialStatus;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public IVizResult VizResult => new VizResult(nativeResult.VizResult);
    }
}