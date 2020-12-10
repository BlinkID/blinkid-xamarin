using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(ImageExtensionFactorsFactory))]
[assembly: Xamarin.Forms.Dependency(typeof(RecognitionModeFilterFactory))]
namespace Microblink.Forms.iOS.Recognizers
{
	public sealed class MrzResult : IMrzResult
    {
        MBMrzResult nativeMrzResult;

        public MrzResult(MBMrzResult nativeMrzResult)
        {
            this.nativeMrzResult = nativeMrzResult;
        }

        public MrtdDocumentType DocumentType => (MrtdDocumentType)nativeMrzResult.DocumentType;

        public string PrimaryId => nativeMrzResult.PrimaryID;

        public string SecondaryId => nativeMrzResult.SecondaryID;

        public string Issuer => nativeMrzResult.Issuer;

        public IDate DateOfBirth => nativeMrzResult.DateOfBirth.Date != null ? new Date(nativeMrzResult.DateOfBirth) : null;

        public string DocumentNumber => nativeMrzResult.DocumentNumber;

        public string Nationality => nativeMrzResult.Nationality;

        public string Gender => nativeMrzResult.Gender;

        public string DocumentCode => nativeMrzResult.DocumentCode;

        public IDate DateOfExpiry => nativeMrzResult.DateOfExpiry.Date != null ? new Date(nativeMrzResult.DateOfExpiry) : null;

        public string Opt1 => nativeMrzResult.Opt1;

        public string Opt2 => nativeMrzResult.Opt2;

        public string AlienNumber => nativeMrzResult.AlienNumber;

        public string ApplicationReceiptNumber => nativeMrzResult.ApplicationReceiptNumber;

        public string ImmigrantCaseNumber => nativeMrzResult.ImmigrantCaseNumber;

        public string MrzText => nativeMrzResult.MrzText;

        public bool Parsed => nativeMrzResult.IsParsed;

        public bool Verified => nativeMrzResult.IsVerified;

        public string SanitizedOpt1 => nativeMrzResult.SanitizedOpt1;

        public string SanitizedOpt2 => nativeMrzResult.SanitizedOpt2;

        public string SanitizedNationality => nativeMrzResult.SanitizedNationality;

        public string SanitizedIssuer => nativeMrzResult.SanitizedIssuer;

        public string SanitizedDocumentCode => nativeMrzResult.SanitizedDocumentCode;

        public string SanitizedDocumentNumber => nativeMrzResult.SanitizedDocumentNumber;

        public int Age => nativeMrzResult.Age;
    }

    public sealed class ImageExtensionFactors : IImageExtensionFactors
    {
        public MBImageExtensionFactors NativeFactors { get; }

        public ImageExtensionFactors(MBImageExtensionFactors nativeFactors)
        {
            NativeFactors = nativeFactors;
        }

        public float UpFactor => (float)NativeFactors.top;
        public float RightFactor => (float)NativeFactors.right;
        public float DownFactor => (float)NativeFactors.bottom;
        public float LeftFactor => (float)NativeFactors.left;
    }

    public sealed class ImageExtensionFactorsFactory : IImageExtensionFactorsFactory
    {
        public IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0, float downFactor = 0, float leftFactor = 0, float rightFactor = 0)
        {
            return new ImageExtensionFactors(new MBImageExtensionFactors { top = upFactor, bottom = downFactor, left = leftFactor, right = rightFactor });
        }
    }

    public sealed class DriverLicenseDetailedInfo : IDriverLicenseDetailedInfo
    {
        MBDriverLicenseDetailedInfo nativeDlDetailedInfo;

        public DriverLicenseDetailedInfo(MBDriverLicenseDetailedInfo nativeDlDetailedInfo)
        {
            this.nativeDlDetailedInfo = nativeDlDetailedInfo;
        }

        public string Restrictions => nativeDlDetailedInfo.Restrictions;

        public string Endorsements => nativeDlDetailedInfo.Endorsements;

        public string VehicleClass => nativeDlDetailedInfo.VehicleClass;

        public string Conditions => nativeDlDetailedInfo.Conditions;
    }

    public sealed class ClassInfo : IClassInfo
    {
        MBClassInfo nativeClassInfo;

        public ClassInfo(MBClassInfo nativeClassInfo)
        {
            this.nativeClassInfo = nativeClassInfo;
        }

        public Country Country => (Country)nativeClassInfo.Country;

        public Region Region => (Region)nativeClassInfo.Region;

        public Type Type => (Type)nativeClassInfo.Type;

    }

    public sealed class ImageAnalysisResult : IImageAnalysisResult
    {
        MBImageAnalysisResult nativeImageAnalysisResult;

        public ImageAnalysisResult(MBImageAnalysisResult nativeImageAnalysisResult)
        {
            this.nativeImageAnalysisResult = nativeImageAnalysisResult;
        }

        public bool Blurred => nativeImageAnalysisResult.Blurred;

        public DocumentImageColorStatus DocumentImageColorStatus => (DocumentImageColorStatus)nativeImageAnalysisResult.DocumentImageColorStatus;

        public ImageAnalysisDetectionStatus DocumentImageMoireStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.DocumentImageMoireStatus;

        public ImageAnalysisDetectionStatus FaceDetectionStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.FaceDetectionStatus;

        public ImageAnalysisDetectionStatus MrzDetectionStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.MrzDetectionStatus;

        public ImageAnalysisDetectionStatus BarcodeDetectionStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.BarcodeDetectionStatus;

    }

    public sealed class BarcodeResult : IBarcodeResult
    {
        MBBarcodeResult nativeBarcodeResult;

        public BarcodeResult(MBBarcodeResult nativeBarcodeResult)
        {
            this.nativeBarcodeResult = nativeBarcodeResult;
        }

        public BarcodeType BarcodeType => (BarcodeType)nativeBarcodeResult.BarcodeType;

        public byte[] RawData => nativeBarcodeResult.RawData != null ? nativeBarcodeResult.RawData.ToArray() : null;

        public string StringData => nativeBarcodeResult.StringData;

        public bool Uncertain => nativeBarcodeResult.Uncertain;

        public string FirstName => nativeBarcodeResult.FirstName;

        public string MiddleName => nativeBarcodeResult.MiddleName;

        public string LastName => nativeBarcodeResult.LastName;

        public string FullName => nativeBarcodeResult.FullName;

        public string AdditionalNameInformation => nativeBarcodeResult.AdditionalNameInformation;

        public string Address => nativeBarcodeResult.Address;

        public string PlaceOfBirth => nativeBarcodeResult.PlaceOfBirth;

        public string Nationality => nativeBarcodeResult.Nationality;

        public string Race => nativeBarcodeResult.Race;

        public string Religion => nativeBarcodeResult.Religion;

        public string Profession => nativeBarcodeResult.Profession;

        public string MaritalStatus => nativeBarcodeResult.MaritalStatus;

        public string ResidentialStatus => nativeBarcodeResult.ResidentialStatus;

        public string Employer => nativeBarcodeResult.Employer;

        public string Sex => nativeBarcodeResult.Sex;

        public IDate DateOfBirth => nativeBarcodeResult.DateOfBirth.Date != null ? new Date(nativeBarcodeResult.DateOfBirth) : null;

        public IDate DateOfIssue => nativeBarcodeResult.DateOfIssue.Date != null ? new Date(nativeBarcodeResult.DateOfIssue) : null;

        public IDate DateOfExpiry => nativeBarcodeResult.DateOfExpiry.Date != null ? new Date(nativeBarcodeResult.DateOfExpiry) : null;

        public string DocumentNumber => nativeBarcodeResult.DocumentNumber;

        public string PersonalIdNumber => nativeBarcodeResult.PersonalIdNumber;

        public string DocumentAdditionalNumber => nativeBarcodeResult.DocumentAdditionalNumber;

        public string IssuingAuthority => nativeBarcodeResult.IssuingAuthority;

        public string Street => nativeBarcodeResult.Street;

        public string PostalCode => nativeBarcodeResult.PostalCode;

        public string City => nativeBarcodeResult.City;

        public string Jurisdiction => nativeBarcodeResult.Jurisdiction;

        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => nativeBarcodeResult.DriverLicenseDetailedInfo != null ? new DriverLicenseDetailedInfo(nativeBarcodeResult.DriverLicenseDetailedInfo) : null;

        public bool Empty => nativeBarcodeResult.Empty;
    }

    public sealed class VizResult : IVizResult
    {
        MBVizResult nativeVizResult;

        public VizResult(MBVizResult nativeVizResult)
        {
            this.nativeVizResult = nativeVizResult;
        }

        public string FirstName => nativeVizResult.FirstName;

        public string LastName => nativeVizResult.LastName;

        public string FullName => nativeVizResult.FullName;

        public string AdditionalNameInformation => nativeVizResult.AdditionalNameInformation;

        public string LocalizedName => nativeVizResult.LocalizedName;

        public string Address => nativeVizResult.Address;

        public string AdditionalAddressInformation => nativeVizResult.AdditionalAddressInformation;

        public string PlaceOfBirth => nativeVizResult.PlaceOfBirth;

        public string Nationality => nativeVizResult.Nationality;

        public string Race => nativeVizResult.Race;

        public string Religion => nativeVizResult.Religion;

        public string Profession => nativeVizResult.Profession;

        public string MaritalStatus => nativeVizResult.MaritalStatus;

        public string ResidentialStatus => nativeVizResult.ResidentialStatus;

        public string Employer => nativeVizResult.Employer;

        public string Sex => nativeVizResult.Sex;

        public IDate DateOfBirth => nativeVizResult.DateOfBirth.Date != null ? new Date(nativeVizResult.DateOfBirth) : null;

        public IDate DateOfIssue => nativeVizResult.DateOfIssue.Date != null ? new Date(nativeVizResult.DateOfIssue) : null;

        public IDate DateOfExpiry => nativeVizResult.DateOfExpiry.Date != null ? new Date(nativeVizResult.DateOfExpiry) : null;

        public string DocumentNumber => nativeVizResult.DocumentNumber;

        public string PersonalIdNumber => nativeVizResult.PersonalIdNumber;

        public string DocumentAdditionalNumber => nativeVizResult.DocumentAdditionalNumber;

        public string AdditionalPersonalIdNumber => nativeVizResult.AdditionalPersonalIdNumber;

        public string IssuingAuthority => nativeVizResult.IssuingAuthority;

        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => nativeVizResult.DriverLicenseDetailedInfo != null ? new DriverLicenseDetailedInfo(nativeVizResult.DriverLicenseDetailedInfo) : null;

        public bool Empty => nativeVizResult.Empty;

        public string DocumentOptionalAdditionalNumber => nativeVizResult.DocumentOptionalAdditionalNumber;
    }

    public sealed class RecognitionModeFilter : IRecognitionModeFilter
    {
        public MBRecognitionModeFilter NativeFilter { get; }

        public RecognitionModeFilter(MBRecognitionModeFilter nativeFilter)
        {
            NativeFilter = nativeFilter;
        }

        public bool EnableMrzId => NativeFilter.EnableMrzId;
        public bool EnableMrzVisa => NativeFilter.EnableMrzVisa;
        public bool EnableMrzPassport => NativeFilter.EnableMrzPassport;
        public bool EnablePhotoId => NativeFilter.EnablePhotoId;
        public bool EnableFullDocumentRecognition => NativeFilter.EnableFullDocumentRecognition;
    }

    public sealed class RecognitionModeFilterFactory : IRecognitionModeFilterFactory
    {
        public IRecognitionModeFilter CreateRecognitionModeFilter(bool enableMrzId = true, bool enableMrzVisa = true, bool enableMrzPassport = true, bool enablePhotoId = true, bool enableFullDocumentRecognition = true)
        {
            MBRecognitionModeFilter recognitionModeFilter = new MBRecognitionModeFilter();
            recognitionModeFilter.EnableMrzId = enableMrzId;
            recognitionModeFilter.EnableMrzVisa = enableMrzVisa;
            recognitionModeFilter.EnableMrzPassport = enableMrzPassport;
            recognitionModeFilter.EnablePhotoId = enablePhotoId;
            recognitionModeFilter.EnableFullDocumentRecognition = enableFullDocumentRecognition;

            return new RecognitionModeFilter(recognitionModeFilter);
        }
    }
}
