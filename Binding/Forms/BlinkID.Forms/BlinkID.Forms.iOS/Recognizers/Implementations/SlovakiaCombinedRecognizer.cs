using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SlovakiaCombinedRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SlovakiaCombinedRecognizer : Recognizer, ISlovakiaCombinedRecognizer
    {
        MBSlovakiaCombinedRecognizer nativeRecognizer;

        SlovakiaCombinedRecognizerResult result;

        public SlovakiaCombinedRecognizer() : base(new MBSlovakiaCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSlovakiaCombinedRecognizer;
            result = new SlovakiaCombinedRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISlovakiaCombinedRecognizerResult Result => result;

        
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
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
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
        
        public bool ExtractDocumentNumber 
        { 
            get => nativeRecognizer.ExtractDocumentNumber; 
            set => nativeRecognizer.ExtractDocumentNumber = value;
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
        
        public bool ExtractNationality 
        { 
            get => nativeRecognizer.ExtractNationality; 
            set => nativeRecognizer.ExtractNationality = value;
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
        
        public bool ExtractSpecialRemarks 
        { 
            get => nativeRecognizer.ExtractSpecialRemarks; 
            set => nativeRecognizer.ExtractSpecialRemarks = value;
        }
        
        public bool ExtractSurnameAtBirth 
        { 
            get => nativeRecognizer.ExtractSurnameAtBirth; 
            set => nativeRecognizer.ExtractSurnameAtBirth = value;
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
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ReturnSignatureImage; 
            set => nativeRecognizer.ReturnSignatureImage = value;
        }
        
        public bool SignResult 
        { 
            get => nativeRecognizer.SignResult; 
            set => nativeRecognizer.SignResult = value;
        }
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = value;
        }
        
    }

    public sealed class SlovakiaCombinedRecognizerResult : RecognizerResult, ISlovakiaCombinedRecognizerResult
    {
        MBSlovakiaCombinedRecognizerResult nativeResult;

        internal SlovakiaCombinedRecognizerResult(MBSlovakiaCombinedRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.DigitalSignature != null ? nativeResult.DigitalSignature.ToArray() : null;
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public DataMatchResult DocumentDataMatch => (DataMatchResult)nativeResult.DocumentDataMatch;
        public string DocumentNumber => nativeResult.DocumentNumber;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentBackImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentFrontImage.Image) : null;
        public string IssuedBy => nativeResult.IssuedBy;
        public string LastName => nativeResult.LastName;
        public bool MrzVerified => nativeResult.MrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string PersonalNumber => nativeResult.PersonalNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public bool ScanningFirstSideDone => nativeResult.ScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public string SpecialRemarks => nativeResult.SpecialRemarks;
        public string SurnameAtBirth => nativeResult.SurnameAtBirth;
    }
}