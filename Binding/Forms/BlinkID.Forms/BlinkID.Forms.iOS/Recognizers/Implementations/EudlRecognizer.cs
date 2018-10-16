using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(EudlRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class EudlRecognizer : Recognizer, IEudlRecognizer
    {
        MBEudlRecognizer nativeRecognizer;

        EudlRecognizerResult result;

        public EudlRecognizer() : base(new MBEudlRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBEudlRecognizer;
            result = new EudlRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IEudlRecognizerResult Result => result;

        
        public EudlCountry Country 
        { 
            get => (EudlCountry)nativeRecognizer.Country; 
            set => nativeRecognizer.Country = (MBEudlCountry)value;
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
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ExtractIssuingAuthority; 
            set => nativeRecognizer.ExtractIssuingAuthority = value;
        }
        
        public bool ExtractPersonalNumber 
        { 
            get => nativeRecognizer.ExtractPersonalNumber; 
            set => nativeRecognizer.ExtractPersonalNumber = value;
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

    public sealed class EudlRecognizerResult : RecognizerResult, IEudlRecognizerResult
    {
        MBEudlRecognizerResult nativeResult;

        internal EudlRecognizerResult(MBEudlRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string BirthData => nativeResult.BirthData;
        public EudlCountry Country => (EudlCountry)nativeResult.Country;
        public string DriverNumber => nativeResult.DriverNumber;
        public IDate ExpiryDate => nativeResult.ExpiryDate != null ? new Date(nativeResult.ExpiryDate) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertUIImage(nativeResult.FaceImage.Image) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
        public IDate IssueDate => nativeResult.IssueDate != null ? new Date(nativeResult.IssueDate) : null;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string PersonalNumber => nativeResult.PersonalNumber;
    }
}