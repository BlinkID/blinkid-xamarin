using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SpainDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SpainDlFrontRecognizer : Recognizer, ISpainDlFrontRecognizer
    {
        MBSpainDlFrontRecognizer nativeRecognizer;

        SpainDlFrontRecognizerResult result;

        public SpainDlFrontRecognizer() : base(new MBSpainDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSpainDlFrontRecognizer;
            result = new SpainDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISpainDlFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.DetectGlare; 
            set => nativeRecognizer.DetectGlare = value;
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ExtractDateOfBirth; 
            set => nativeRecognizer.ExtractDateOfBirth = value;
        }
        
        public bool ExtractFirstName 
        { 
            get => nativeRecognizer.ExtractFirstName; 
            set => nativeRecognizer.ExtractFirstName = value;
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

    public sealed class SpainDlFrontRecognizerResult : RecognizerResult, ISpainDlFrontRecognizerResult
    {
        MBSpainDlFrontRecognizerResult nativeResult;

        internal SpainDlFrontRecognizerResult(MBSpainDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LicenceCategories => nativeResult.LicenceCategories;
        public string Number => nativeResult.Number;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public string Surname => nativeResult.Surname;
        public IDate ValidFrom => nativeResult.ValidFrom != null ? new Date(nativeResult.ValidFrom) : null;
        public IDate ValidUntil => nativeResult.ValidUntil != null ? new Date(nativeResult.ValidUntil) : null;
    }
}