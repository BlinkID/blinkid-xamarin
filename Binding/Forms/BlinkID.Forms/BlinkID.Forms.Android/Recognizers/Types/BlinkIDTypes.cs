using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ImageExtensionFactorsFactory))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class MrzResult : IMrzResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrzResult nativeMrzResult;

        public MrzResult(Com.Microblink.Entities.Recognizers.Blinkid.Mrtd.MrzResult nativeMrzResult)
        {
            this.nativeMrzResult = nativeMrzResult;
        }

        public MrtdDocumentType DocumentType => (MrtdDocumentType)nativeMrzResult.DocumentType.Ordinal();

        public string PrimaryId => nativeMrzResult.PrimaryId;

        public string SecondaryId => nativeMrzResult.SecondaryId;

        public string Issuer => nativeMrzResult.Issuer;

        public IDate DateOfBirth => nativeMrzResult.DateOfBirth.Date != null ? new Date(nativeMrzResult.DateOfBirth.Date) : null;

        public int Age =>  nativeMrzResult.Age;

        public string DocumentNumber => nativeMrzResult.DocumentNumber;

        public string Nationality => nativeMrzResult.Nationality;

        public string Gender => nativeMrzResult.Gender;

        public string DocumentCode => nativeMrzResult.DocumentCode;

        public IDate DateOfExpiry => nativeMrzResult.DateOfExpiry.Date != null ? new Date(nativeMrzResult.DateOfExpiry.Date) : null;

        public string Opt1 => nativeMrzResult.Opt1;

        public string Opt2 => nativeMrzResult.Opt2;

        public string AlienNumber => nativeMrzResult.AlienNumber;

        public string ApplicationReceiptNumber => nativeMrzResult.ApplicationReceiptNumber;

        public string ImmigrantCaseNumber => nativeMrzResult.ImmigrantCaseNumber;

        public string MrzText => nativeMrzResult.MrzText;

        public string SanitizedOpt1 => nativeMrzResult.SanitizedOpt1;

        public string SanitizedOpt2 => nativeMrzResult.SanitizedOpt2;

        public string SanitizedNationality => nativeMrzResult.SanitizedNationality;

        public string SanitizedIssuer => nativeMrzResult.SanitizedIssuer;

        public string SanitizedDocumentCode => nativeMrzResult.SanitizedDocumentCode;

        public string SanitizedDocumentNumber => nativeMrzResult.SanitizedDocumentNumber;

        public bool Parsed => nativeMrzResult.IsMrzParsed;

        public bool Verified => nativeMrzResult.IsMrzVerified;
    }

    public sealed class DriverLicenseDetailedInfo : IDriverLicenseDetailedInfo
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.DriverLicenseDetailedInfo nativeDlDetailedInfo;

        public DriverLicenseDetailedInfo(Com.Microblink.Entities.Recognizers.Blinkid.Generic.DriverLicenseDetailedInfo nativeDlDetailedInfo)
        {
            this.nativeDlDetailedInfo = nativeDlDetailedInfo;
        }

        public string Restrictions => nativeDlDetailedInfo.Restrictions;

        public string Endorsements => nativeDlDetailedInfo.Endorsements;

        public string VehicleClass => nativeDlDetailedInfo.VehicleClass;

        public string Conditions => nativeDlDetailedInfo.Conditions;

    }

    public sealed class ImageExtensionFactors : IImageExtensionFactors
    {
        public Com.Microblink.Entities.Recognizers.Blinkid.Imageoptions.Extension.ImageExtensionFactors NativeImageExtensionFactors { get; }

        public ImageExtensionFactors(Com.Microblink.Entities.Recognizers.Blinkid.Imageoptions.Extension.ImageExtensionFactors nativeExtentionFactors)
        {
            NativeImageExtensionFactors = nativeExtentionFactors;
        }

        public float UpFactor => NativeImageExtensionFactors.UpFactor;
        public float RightFactor => NativeImageExtensionFactors.RightFactor;
        public float DownFactor => NativeImageExtensionFactors.DownFactor;
        public float LeftFactor => NativeImageExtensionFactors.LeftFactor;
    }

    public sealed class ImageExtensionFactorsFactory : IImageExtensionFactorsFactory
    {
        public IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0, float downFactor = 0, float leftFactor = 0, float rightFactor = 0)
        {
            return new ImageExtensionFactors(new Com.Microblink.Entities.Recognizers.Blinkid.Imageoptions.Extension.ImageExtensionFactors(upFactor, downFactor, leftFactor, rightFactor));
        }
    }

    public sealed class ClassInfo : IClassInfo
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.Classinfo.ClassInfo nativeClassInfo;

        public ClassInfo(Com.Microblink.Entities.Recognizers.Blinkid.Generic.Classinfo.ClassInfo nativeClassInfo)
        {
            this.nativeClassInfo = nativeClassInfo;
        }


        public Country Country => (Country)nativeClassInfo.Country.Ordinal();

        public Region Region => (Region)nativeClassInfo.Region.Ordinal();

        public Type Type => (Type)nativeClassInfo.Type.Ordinal();

    }

    public sealed class ImageAnalysisResult : IImageAnalysisResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.Imageanalysis.ImageAnalysisResult nativeImageAnalysisResult;

        public ImageAnalysisResult(Com.Microblink.Entities.Recognizers.Blinkid.Generic.Imageanalysis.ImageAnalysisResult nativeImageAnalysisResult)
        {
            this.nativeImageAnalysisResult = nativeImageAnalysisResult;
        }

        public bool Blurred => nativeImageAnalysisResult.IsBlurred;

        public DocumentImageColorStatus DocumentImageColorStatus => (DocumentImageColorStatus)nativeImageAnalysisResult.DocumentImageColorStatus.Ordinal();

        public ImageAnalysisDetectionStatus DocumentImageMoireStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.DocumentImageMoireStatus.Ordinal();

        public ImageAnalysisDetectionStatus FaceDetectionStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.FaceDetectionStatus.Ordinal();

        public ImageAnalysisDetectionStatus MrzDetectionStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.MrzDetectionStatus.Ordinal();

        public ImageAnalysisDetectionStatus BarcodeDetectionStatus => (ImageAnalysisDetectionStatus)nativeImageAnalysisResult.BarcodeDetectionStatus.Ordinal();
    }

    public sealed class BarcodeResult : IBarcodeResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.Barcode.BarcodeResult nativeBarcodeResult;

        public BarcodeResult(Com.Microblink.Entities.Recognizers.Blinkid.Generic.Barcode.BarcodeResult nativeBarcodeResult)
        {
            this.nativeBarcodeResult = nativeBarcodeResult;
        }

        public BarcodeType BarcodeType => (BarcodeType)nativeBarcodeResult.BarcodeType.Ordinal();

        public byte[] RawData => nativeBarcodeResult.GetRawData() ;

        public string StringData => nativeBarcodeResult.StringData;

        public bool Uncertain => nativeBarcodeResult.IsUncertain;

        public string FirstName => nativeBarcodeResult.FirstName;

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

        public IDate DateOfBirth => nativeBarcodeResult.DateOfBirth.Date != null ? new Date(nativeBarcodeResult.DateOfBirth.Date) : null;

        public IDate DateOfIssue => nativeBarcodeResult.DateOfIssue.Date != null ? new Date(nativeBarcodeResult.DateOfIssue.Date) : null;

        public IDate DateOfExpiry => nativeBarcodeResult.DateOfExpiry.Date != null ? new Date(nativeBarcodeResult.DateOfExpiry.Date) : null;

        public string DocumentNumber => nativeBarcodeResult.DocumentNumber;

        public string PersonalIdNumber => nativeBarcodeResult.PersonalIdNumber;

        public string DocumentAdditionalNumber => nativeBarcodeResult.DocumentAdditionalNumber;

        public string IssuingAuthority => nativeBarcodeResult.IssuingAuthority;

        public string Street => nativeBarcodeResult.Street;

        public string PostalCode => nativeBarcodeResult.PostalCode;

        public string City => nativeBarcodeResult.City;

        public string Jurisdiction => nativeBarcodeResult.Jurisdiction;

        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => nativeBarcodeResult.DriverLicenseDetailedInfo != null ? new DriverLicenseDetailedInfo(nativeBarcodeResult.DriverLicenseDetailedInfo) : null;

        public bool Empty => nativeBarcodeResult.IsEmpty;
    }

    public sealed class VizResult : IVizResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Generic.Viz.VizResult nativeVizResult;

        public VizResult(Com.Microblink.Entities.Recognizers.Blinkid.Generic.Viz.VizResult nativeVizResult)
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

        public IDate DateOfBirth => nativeVizResult.DateOfBirth.Date != null ? new Date(nativeVizResult.DateOfBirth.Date) : null;

        public IDate DateOfIssue => nativeVizResult.DateOfIssue.Date != null ? new Date(nativeVizResult.DateOfIssue.Date) : null;

        public IDate DateOfExpiry => nativeVizResult.DateOfExpiry.Date != null ? new Date(nativeVizResult.DateOfExpiry.Date) : null;

        public string DocumentNumber => nativeVizResult.DocumentNumber;

        public string PersonalIdNumber => nativeVizResult.PersonalIdNumber;

        public string DocumentAdditionalNumber => nativeVizResult.DocumentAdditionalNumber;

        public string AdditionalPersonalIdNumber => nativeVizResult.AdditionalPersonalIdNumber;

        public string IssuingAuthority => nativeVizResult.IssuingAuthority;

        public IDriverLicenseDetailedInfo DriverLicenseDetailedInfo => nativeVizResult.DriverLicenseDetailedInfo != null ? new DriverLicenseDetailedInfo(nativeVizResult.DriverLicenseDetailedInfo) : null;

        public string Conditions => nativeVizResult.Conditions;

        public bool Empty => nativeVizResult.IsEmpty;
    }

    public sealed class RecognitionModeFilter : IRecognitionModeFilter
    {
        public Com.Microblink.Entities.Recognizers.Blinkid.Generic.RecognitionModeFilter NativeFilter { get; }

        public RecognitionModeFilter(Com.Microblink.Entities.Recognizers.Blinkid.Generic.RecognitionModeFilter nativeFilter)
        {
            NativeFilter = nativeFilter;
        }

        public bool EnableMrzId => NativeFilter.enableMrzId;
        public bool EnableMrzVisa => NativeFilter.enableMrzVisa;
        public bool EnableMrzPassport => NativeFilter.enableMrzPassport;
        public bool EnablePhotoId => NativeFilter.enablePhotoId;
        public bool EnableFullDocumentRecognition => NativeFilter.enableFullDocumentRecognition;
    }

    public sealed class RecognitionModeFilterFactory : IRecognitionModeFilterFactory
    {
        public IRecognitionModeFilter CreateRecognitionModeFilter(bool enableMrzId = true, bool enableMrzVisa = true, bool enableMrzPassport = true, bool enablePhotoId = true, bool enableFullDocumentRecognition = true)
        {
            return new RecognitionModeFilter(new RecognitionModeFilter(Com.Microblink.Entities.Recognizers.Blinkid.Generic.RecognitionModeFilter(
                        enableMrzId, enableMrzVisa, enableMrzPassport, enablePhotoId, enableFullDocumentRecognition
            )));
        }
    }

}
