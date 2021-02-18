using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(BlinkIdRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class BlinkIdRecognizer : Recognizer, IBlinkIdRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdRecognizer nativeRecognizer;

        BlinkIdRecognizerResult result;

        public BlinkIdRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdRecognizer;
            result = new BlinkIdRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IBlinkIdRecognizerResult Result => result;

        
        public bool AllowBlurFilter 
        { 
            get => nativeRecognizer.ShouldAllowBlurFilter(); 
            set => nativeRecognizer.SetAllowBlurFilter(value);
        }
        
        public bool AllowUnparsedMrzResults 
        { 
            get => nativeRecognizer.ShouldAllowUnparsedMrzResults(); 
            set => nativeRecognizer.SetAllowUnparsedMrzResults(value);
        }
        
        public bool AllowUnverifiedMrzResults 
        { 
            get => nativeRecognizer.ShouldAllowUnverifiedMrzResults(); 
            set => nativeRecognizer.SetAllowUnverifiedMrzResults(value);
        }
        
        public AnonymizationMode AnonymizationMode 
        { 
            get => (AnonymizationMode)nativeRecognizer.AnonymizationMode.Ordinal(); 
            set => nativeRecognizer.AnonymizationMode = Com.Microblink.Entities.Recognizers.Blinkid.Generic.AnonymizationMode.Values()[(int)value];
        }
        
        public int FaceImageDpi 
        { 
            get => nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
        }
        
        public int FullDocumentImageDpi 
        { 
            get => nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        
        public float PaddingEdge 
        { 
            get => nativeRecognizer.PaddingEdge; 
            set => nativeRecognizer.PaddingEdge = value;
        }
        
        public IRecognitionModeFilter RecognitionModeFilter 
        { 
            get => new RecognitionModeFilter(nativeRecognizer.RecognitionModeFilter); 
            set => nativeRecognizer.RecognitionModeFilter = (value as RecognitionModeFilter).NativeFilter;
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
        
        public bool ScanCroppedDocumentImage 
        { 
            get => nativeRecognizer.ShouldScanCroppedDocumentImage(); 
            set => nativeRecognizer.SetScanCroppedDocumentImage(value);
        }
        
        public int SignatureImageDpi 
        { 
            get => nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = (int)value;
        }
        
        public bool ValidateResultCharacters 
        { 
            get => nativeRecognizer.ShouldValidateResultCharacters(); 
            set => nativeRecognizer.SetValidateResultCharacters(value);
        }
        
    }

    public sealed class BlinkIdRecognizerResult : RecognizerResult, IBlinkIdRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdRecognizer.Result nativeResult;

        internal BlinkIdRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Generic.BlinkIdRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string AdditionalAddressInformation => nativeResult.AdditionalAddressInformation;
        public string AdditionalNameInformation => nativeResult.AdditionalNameInformation;
        public string Address => nativeResult.Address;
        public int Age => (int)nativeResult.Age;
        public IBarcodeResult BarcodeResult => new BarcodeResult(nativeResult.BarcodeResult);
        public IClassInfo ClassInfo => nativeResult.ClassInfo != null ? new ClassInfo(nativeResult.ClassInfo) : null;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public bool DateOfExpiryPermanent => nativeResult.IsDateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public string DocumentOptionalAdditionalNumber => nativeResult.DocumentOptionalAdditionalNumber;
        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => new DriverLicenseDetailedInfo(nativeResult.DriverLicenseDetailedInfo);
        public string Employer => nativeResult.Employer;
        public bool Expired => nativeResult.IsExpired;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
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
        public ProcessingStatus ProcessingStatus => (ProcessingStatus)nativeResult.ProcessingStatus.Ordinal();
        public string Profession => nativeResult.Profession;
        public string Race => nativeResult.Race;
        public RecognitionMode RecognitionMode => (RecognitionMode)nativeResult.RecognitionMode.Ordinal();
        public string Religion => nativeResult.Religion;
        public string ResidentialStatus => nativeResult.ResidentialStatus;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
        public IVizResult VizResult => new VizResult(nativeResult.VizResult);
    }
}