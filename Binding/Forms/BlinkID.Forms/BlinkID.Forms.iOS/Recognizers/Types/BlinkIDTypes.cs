using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(ImageExtensionFactorsFactory))]
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

    }
}
