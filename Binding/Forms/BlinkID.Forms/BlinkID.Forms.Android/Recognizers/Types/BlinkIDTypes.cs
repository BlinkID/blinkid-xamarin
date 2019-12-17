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
}
