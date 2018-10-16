using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(ItalyDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class ItalyDlFrontRecognizer : Recognizer, IItalyDlFrontRecognizer
    {
        MBItalyDlFrontRecognizer nativeRecognizer;

        ItalyDlFrontRecognizerResult result;

        public ItalyDlFrontRecognizer() : base(new MBItalyDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBItalyDlFrontRecognizer;
            result = new ItalyDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IItalyDlFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractGivenName 
        { 
            get => nativeRecognizer.ExtractGivenName; 
            set => nativeRecognizer.ExtractGivenName = value;
        }
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ExtractIssuingAuthority; 
            set => nativeRecognizer.ExtractIssuingAuthority = value;
        }
        
        public bool ExtractLicenceCategories 
        { 
            get => nativeRecognizer.ExtractLicenceCategories; 
            set => nativeRecognizer.ExtractLicenceCategories = value;
        }
        
        public bool ExtractPlaceOfBirth 
        { 
            get => nativeRecognizer.ExtractPlaceOfBirth; 
            set => nativeRecognizer.ExtractPlaceOfBirth = value;
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
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ReturnSignatureImage; 
            set => nativeRecognizer.ReturnSignatureImage = value;
        }
        
        public uint SignatureImageDpi 
        { 
            get => (uint)nativeRecognizer.SignatureImageDpi; 
            set => nativeRecognizer.SignatureImageDpi = value;
        }
        
    }

    public sealed class ItalyDlFrontRecognizerResult : RecognizerResult, IItalyDlFrontRecognizerResult
    {
        MBItalyDlFrontRecognizerResult nativeResult;

        internal ItalyDlFrontRecognizerResult(MBItalyDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string GivenName => nativeResult.GivenName;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LicenceCategories => nativeResult.LicenceCategories;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public string Surname => nativeResult.Surname;
    }
}