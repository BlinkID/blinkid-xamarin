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
        
        public bool AnonymizeImage 
        { 
            get => nativeRecognizer.AnonymizeImage; 
            set => nativeRecognizer.AnonymizeImage = value;
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
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
        public IClassInfo ClassInfo => new ClassInfo(nativeResult.ClassInfo);
        public string Conditions => nativeResult.Conditions;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public bool DateOfExpiryPermanent => nativeResult.DateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public string DocumentAdditionalNumber => nativeResult.DocumentAdditionalNumber;
        public DocumentImageColorStatus DocumentImageColorStatus => (DocumentImageColorStatus)nativeResult.DocumentImageColorStatus;
        public DocumentImageMoireStatus DocumentImageMoireStatus => (DocumentImageMoireStatus)nativeResult.DocumentImageMoireStatus;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => new DriverLicenseDetailedInfo(nativeResult.DriverLicenseDetailedInfo);
        public string Employer => nativeResult.Employer;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
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