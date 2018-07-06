using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SwedenDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class SwedenDlFrontRecognizer : Recognizer, ISwedenDlFrontRecognizer
    {
        MBSwedenDlFrontRecognizer nativeRecognizer;

        SwedenDlFrontRecognizerResult result;

        public SwedenDlFrontRecognizer() : base(new MBSwedenDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBSwedenDlFrontRecognizer;
            result = new SwedenDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISwedenDlFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractIssuingAgency 
        { 
            get => nativeRecognizer.ExtractIssuingAgency; 
            set => nativeRecognizer.ExtractIssuingAgency = value;
        }
        
        public bool ExtractLicenceCategories 
        { 
            get => nativeRecognizer.ExtractLicenceCategories; 
            set => nativeRecognizer.ExtractLicenceCategories = value;
        }
        
        public bool ExtractName 
        { 
            get => nativeRecognizer.ExtractName; 
            set => nativeRecognizer.ExtractName = value;
        }
        
        public bool ExtractReferenceNumber 
        { 
            get => nativeRecognizer.ExtractReferenceNumber; 
            set => nativeRecognizer.ExtractReferenceNumber = value;
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ExtractSurname; 
            set => nativeRecognizer.ExtractSurname = value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = value;
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
        
    }

    public sealed class SwedenDlFrontRecognizerResult : RecognizerResult, ISwedenDlFrontRecognizerResult
    {
        MBSwedenDlFrontRecognizerResult nativeResult;

        internal SwedenDlFrontRecognizerResult(MBSwedenDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public string IssuingAgency => nativeResult.IssuingAgency;
        public string LicenceCategories => nativeResult.LicenceCategories;
        public string LicenceNumber => nativeResult.LicenceNumber;
        public string Name => nativeResult.Name;
        public string ReferenceNumber => nativeResult.ReferenceNumber;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public string Surname => nativeResult.Surname;
    }
}