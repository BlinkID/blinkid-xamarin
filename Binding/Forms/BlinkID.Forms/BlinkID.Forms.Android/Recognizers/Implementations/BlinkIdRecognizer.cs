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
        
        public bool AnonymizeImage 
        { 
            get => nativeRecognizer.ShouldAnonymizeImage(); 
            set => nativeRecognizer.SetAnonymizeImage(value);
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
        
        public float PaddingEdge 
        { 
            get => nativeRecognizer.PaddingEdge; 
            set => nativeRecognizer.PaddingEdge = value;
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
        public IClassInfo ClassInfo => nativeResult.ClassInfo != null ? new ClassInfo(nativeResult.ClassInfo) : null;
        public string Conditions => nativeResult.Conditions;
        public IDate DateOfBirth => nativeResult.DateOfBirth.Date != null ? new Date(nativeResult.DateOfBirth.Date) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry.Date != null ? new Date(nativeResult.DateOfExpiry.Date) : null;
        public bool DateOfExpiryPermanent => nativeResult.IsDateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue.Date != null ? new Date(nativeResult.DateOfIssue.Date) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public DocumentImageColorStatus DocumentImageColorStatus => (DocumentImageColorStatus)nativeResult.DocumentImageColorStatus.Ordinal();
        public DocumentImageMoireStatus DocumentImageMoireStatus => (DocumentImageMoireStatus)nativeResult.DocumentImageMoireStatus.Ordinal();
        public string DocumentNumber => nativeResult.DocumentNumber;
        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => new DriverLicenseDetailedInfo(nativeResult.DriverLicenseDetailedInfo);
        public string Employer => nativeResult.Employer;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string FullName => nativeResult.FullName;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string LocalizedName => nativeResult.LocalizedName;
        public string MaritalStatus => nativeResult.MaritalStatus;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdNumber => nativeResult.PersonalIdNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string Profession => nativeResult.Profession;
        public string Race => nativeResult.Race;
        public string Religion => nativeResult.Religion;
        public string ResidentialStatus => nativeResult.ResidentialStatus;
        public string Sex => nativeResult.Sex;
    }
}