using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(RomaniaIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class RomaniaIdFrontRecognizer : Recognizer, IRomaniaIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Romania.RomaniaIdFrontRecognizer nativeRecognizer;

        RomaniaIdFrontRecognizerResult result;

        public RomaniaIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Romania.RomaniaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Romania.RomaniaIdFrontRecognizer;
            result = new RomaniaIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Romania.RomaniaIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IRomaniaIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractFirstName 
        { 
            get => nativeRecognizer.ShouldExtractFirstName(); 
            set => nativeRecognizer.SetExtractFirstName(value);
        }
        
        public bool ExtractIssuedBy 
        { 
            get => nativeRecognizer.ShouldExtractIssuedBy(); 
            set => nativeRecognizer.SetExtractIssuedBy(value);
        }
        
        public bool ExtractLastName 
        { 
            get => nativeRecognizer.ShouldExtractLastName(); 
            set => nativeRecognizer.SetExtractLastName(value);
        }
        
        public bool ExtractNonMRZSex 
        { 
            get => nativeRecognizer.ShouldExtractNonMRZSex(); 
            set => nativeRecognizer.SetExtractNonMRZSex(value);
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractPlaceOfBirth(); 
            set => nativeRecognizer.SetExtractPlaceOfBirth(value);
        }
        
        public bool ExtractValidFrom 
        { 
            get => nativeRecognizer.ShouldExtractValidFrom(); 
            set => nativeRecognizer.SetExtractValidFrom(value);
        }
        
        public bool ExtractValidUntil 
        { 
            get => nativeRecognizer.ShouldExtractValidUntil(); 
            set => nativeRecognizer.SetExtractValidUntil(value);
        }
        
        public bool ReturnFaceImage 
        { 
            get => nativeRecognizer.ShouldReturnFaceImage(); 
            set => nativeRecognizer.SetReturnFaceImage(value);
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class RomaniaIdFrontRecognizerResult : RecognizerResult, IRomaniaIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Romania.RomaniaIdFrontRecognizer.Result nativeResult;

        internal RomaniaIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Romania.RomaniaIdFrontRecognizer.Result nativeResult) : base(nativeResult)
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
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public string IdSeries => nativeResult.IdSeries;
        public string IssuedBy => nativeResult.IssuedBy;
        public string Issuer => nativeResult.Issuer;
        public string LastName => nativeResult.LastName;
        public bool MrzParsed => nativeResult.IsMrzParsed;
        public string MrzText => nativeResult.MrzText;
        public bool MrzVerified => nativeResult.IsMrzVerified;
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