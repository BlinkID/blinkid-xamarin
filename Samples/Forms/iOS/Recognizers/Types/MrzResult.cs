using BlinkIDFormsSample.iOS.Recognizers;
using BlinkIDFormsSample.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(MrzResult))]
namespace BlinkIDFormsSample.iOS.Recognizers
{
	public class MrzResult : IMrzResult
    {
        MBMrzResult nativeMrzResult;

        public MrzResult(MBMrzResult nativeMrzResult)
        {
            this.nativeMrzResult = nativeMrzResult;
        }

        public MrtdDocumentType DocumentType
        {
            get
            {
                switch(nativeMrzResult.DocumentType)
                {
                    case MBMrtdDocumentType.GreenCard:
                        return MrtdDocumentType.GreenCard;
                    case MBMrtdDocumentType.IdentityCard:
                        return MrtdDocumentType.IdentityCard;
                    case MBMrtdDocumentType.Passport:
                        return MrtdDocumentType.Passport;
                    case MBMrtdDocumentType.Visa:
                        return MrtdDocumentType.Visa;
                }
                return MrtdDocumentType.Unknown;

            }
        }

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
}
