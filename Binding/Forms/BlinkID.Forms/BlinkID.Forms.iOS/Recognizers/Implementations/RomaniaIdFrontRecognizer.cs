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
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ExtractDateOfExpiry; 
            set => nativeRecognizer.ExtractDateOfExpiry = value;
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ExtractDateOfIssue; 
            set => nativeRecognizer.ExtractDateOfIssue = value;
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
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ExtractPlaceOfBirth; 
            set => nativeRecognizer.ExtractPlaceOfBirth = value;
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ExtractSex; 
            set => nativeRecognizer.ExtractSex = value;
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ExtractSurname; 
            set => nativeRecognizer.ExtractSurname = value;
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
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
        public string CnpNumber => nativeResult.CnpNumber;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IssuedBy => nativeResult.IssuedBy;
        public IMrzResult MrzResult => new MrzResult(nativeResult.MrzResult);
        public string Nationality => nativeResult.Nationality;
        public string ParentName => nativeResult.ParentName;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public string Sex => nativeResult.Sex;
        public string Surname => nativeResult.Surname;
    }
}