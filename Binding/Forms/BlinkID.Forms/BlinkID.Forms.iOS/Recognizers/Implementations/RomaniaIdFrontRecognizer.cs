using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(RomaniaIdFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class RomaniaIdFrontRecognizer : Recognizer, IRomaniaIdFrontRecognizer
    {
        MBRomaniaIdFrontRecognizer nativeRecognizer;

        RomaniaIdFrontRecognizerResult result;

        public RomaniaIdFrontRecognizer() : base(new MBRomaniaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBRomaniaIdFrontRecognizer;
            result = new RomaniaIdFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IRomaniaIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ExtractAddress; 
            set => nativeRecognizer.ExtractAddress = value;
        }
        
        public bool ExtractFirstName 
        { 
            get => nativeRecognizer.ExtractFirstName; 
            set => nativeRecognizer.ExtractFirstName = value;
        }
        
        public bool ExtractIssuedBy 
        { 
            get => nativeRecognizer.ExtractIssuedBy; 
            set => nativeRecognizer.ExtractIssuedBy = value;
        }
        
        public bool ExtractLastName 
        { 
            get => nativeRecognizer.ExtractLastName; 
            set => nativeRecognizer.ExtractLastName = value;
        }
        
        public bool ExtractNonMRZSex 
        { 
            get => nativeRecognizer.ExtractNonMRZSex; 
            set => nativeRecognizer.ExtractNonMRZSex = value;
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ExtractPlaceOfBirth; 
            set => nativeRecognizer.ExtractPlaceOfBirth = value;
        }
        
        public bool ExtractValidFrom 
        { 
            get => nativeRecognizer.ExtractValidFrom; 
            set => nativeRecognizer.ExtractValidFrom = value;
        }
        
        public bool ExtractValidUntil 
        { 
            get => nativeRecognizer.ExtractValidUntil; 
            set => nativeRecognizer.ExtractValidUntil = value;
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
        
    }

    public sealed class RomaniaIdFrontRecognizerResult : RecognizerResult, IRomaniaIdFrontRecognizerResult
    {
        MBRomaniaIdFrontRecognizerResult nativeResult;

        internal RomaniaIdFrontRecognizerResult(MBRomaniaIdFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string CardNumber => nativeResult.CardNumber;
        public string Cnp => nativeResult.Cnp;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public string DocumentCode => nativeResult.DocumentCode;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IdSeries => nativeResult.IdSeries;
        public string IssuedBy => nativeResult.IssuedBy;
        public string Issuer => nativeResult.Issuer;
        public string LastName => nativeResult.LastName;
        public bool MrzParsed => nativeResult.MrzParsed;
        public string MrzText => nativeResult.MrzText;
        public bool MrzVerified => nativeResult.MrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string NonMRZNationality => nativeResult.NonMRZNationality;
        public string NonMRZSex => nativeResult.NonMRZSex;
        public string Opt1 => nativeResult.Opt1;
        public string Opt2 => nativeResult.Opt2;
        public string ParentNames => nativeResult.ParentNames;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string PrimaryId => nativeResult.PrimaryId;
        public string SecondaryId => nativeResult.SecondaryId;
        public string Sex => nativeResult.Sex;
        public IDate ValidFrom => nativeResult.ValidFrom != null ? new Date(nativeResult.ValidFrom) : null;
        public IDate ValidUntil => nativeResult.ValidUntil != null ? new Date(nativeResult.ValidUntil) : null;
    }
}