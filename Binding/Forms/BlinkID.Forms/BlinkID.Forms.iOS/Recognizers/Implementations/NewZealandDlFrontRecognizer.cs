using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(NewZealandDlFrontRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class NewZealandDlFrontRecognizer : Recognizer, INewZealandDlFrontRecognizer
    {
        MBNewZealandDlFrontRecognizer nativeRecognizer;

        NewZealandDlFrontRecognizerResult result;

        public NewZealandDlFrontRecognizer() : base(new MBNewZealandDlFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBNewZealandDlFrontRecognizer;
            result = new NewZealandDlFrontRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public INewZealandDlFrontRecognizerResult Result => result;

        
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
        
        public bool ExtractDonorIndicator 
        { 
            get => nativeRecognizer.ExtractDonorIndicator; 
            set => nativeRecognizer.ExtractDonorIndicator = value;
        }
        
        public bool ExtractExpiryDate 
        { 
            get => nativeRecognizer.ExtractExpiryDate; 
            set => nativeRecognizer.ExtractExpiryDate = value;
        }
        
        public bool ExtractFirstNames 
        { 
            get => nativeRecognizer.ExtractFirstNames; 
            set => nativeRecognizer.ExtractFirstNames = value;
        }
        
        public bool ExtractIssueDate 
        { 
            get => nativeRecognizer.ExtractIssueDate; 
            set => nativeRecognizer.ExtractIssueDate = value;
        }
        
        public bool ExtractSurname 
        { 
            get => nativeRecognizer.ExtractSurname; 
            set => nativeRecognizer.ExtractSurname = value;
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

    public sealed class NewZealandDlFrontRecognizerResult : RecognizerResult, INewZealandDlFrontRecognizerResult
    {
        MBNewZealandDlFrontRecognizerResult nativeResult;

        internal NewZealandDlFrontRecognizerResult(MBNewZealandDlFrontRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string CardVersion => nativeResult.CardVersion;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public bool DonorIndicator => nativeResult.DonorIndicator;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstNames => nativeResult.FirstNames;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IDate IssueDate => nativeResult.IssueDate != null ? new Date(nativeResult.IssueDate) : null;
        public string LicenseNumber => nativeResult.LicenseNumber;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertUIImage(nativeResult.SignatureImage.Image) : null;
        public string Surname => nativeResult.Surname;
    }
}