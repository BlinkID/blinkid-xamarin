using System;
namespace Microblink.Forms.Shared.Recognizers
{
    public enum MrtdDocumentType
    {
        /** Unknown document type */
        Unknown,
        /** Identity card */
        IdentityCard,
        /** Passport */
        Passport,
        /** Visa */
        Visa,
        /** US Green Card */
        GreenCard,
        /** Malaysian PASS type IMM13P */
        MalaysianPassIMM13P
    }

    public interface IMrzResult
    {
        MrtdDocumentType DocumentType { get; }
        string PrimaryId { get; }
        string SecondaryId { get; }
        string Issuer { get; }
        IDate DateOfBirth { get; }
        string DocumentNumber { get; }
        string Nationality { get; }
        string Gender { get; }
        string DocumentCode { get; }
        IDate DateOfExpiry { get; }
        string Opt1 { get; }
        string Opt2 { get; }
        string AlienNumber { get; }
        string ApplicationReceiptNumber { get; }
        string ImmigrantCaseNumber { get; }
        string MrzText { get; }
        bool Parsed { get; }
        bool Verified { get; }
    }
}
