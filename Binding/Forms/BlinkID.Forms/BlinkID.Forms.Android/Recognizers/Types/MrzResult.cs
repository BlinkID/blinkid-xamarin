using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Shared.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(MrzResult))]
namespace Microblink.Forms.Droid.Recognizers
{
	public class MrzResult : IMrzResult
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

        public bool Parsed => nativeMrzResult.IsMrzParsed;

        public bool Verified => nativeMrzResult.IsMrzVerified;
    }
}
