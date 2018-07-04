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
    }

    public sealed class ImageExtensionFactors : IImageExtensionFactors
    {
        MBImageExtensionFactors nativeFactors;

        public ImageExtensionFactors(MBImageExtensionFactors nativeFactors)
        {
            this.nativeFactors = nativeFactors;
        }

        public float UpFactor => (float)nativeFactors.top;

        public float RightFactor => (float)nativeFactors.right;

        public float DownFactor => (float)nativeFactors.bottom;

        public float LeftFactor => (float)nativeFactors.left;
    }

    public sealed class ImageExtensionFactorsFactory : IImageExtensionFactorsFactory
    {
        public IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0, float downFactor = 0, float leftFactor = 0, float rightFactor = 0)
        {
            return new ImageExtensionFactors(new MBImageExtensionFactors { top = upFactor, bottom = downFactor, left = leftFactor, right = rightFactor });
        }
    }
}
