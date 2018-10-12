using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(EudlRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class EudlRecognizer : Recognizer, IEudlRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Eudl.EudlRecognizer nativeRecognizer;

        EudlRecognizerResult result;

        public EudlRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Eudl.EudlRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Eudl.EudlRecognizer;
            result = new EudlRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Eudl.EudlRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IEudlRecognizerResult Result => result;

        
        public EudlCountry Country 
        { 
            get => (EudlCountry)nativeRecognizer.Country.Ordinal(); 
            set => nativeRecognizer.Country = Com.Microblink.Entities.Recognizers.Blinkid.Eudl.EudlCountry.Values()[(int)value];
        }
        
        public bool ExtractAddress 
        { 
            get => nativeRecognizer.ShouldExtractAddress(); 
            set => nativeRecognizer.SetExtractAddress(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractDateOfIssue 
        { 
            get => nativeRecognizer.ShouldExtractDateOfIssue(); 
            set => nativeRecognizer.SetExtractDateOfIssue(value);
        }
        
        public bool ExtractIssuingAuthority 
        { 
            get => nativeRecognizer.ShouldExtractIssuingAuthority(); 
            set => nativeRecognizer.SetExtractIssuingAuthority(value);
        }
        
        public bool ExtractPersonalNumber 
        { 
            get => nativeRecognizer.ShouldExtractPersonalNumber(); 
            set => nativeRecognizer.SetExtractPersonalNumber(value);
        }
        
        public uint FaceImageDpi 
        { 
            get => (uint)nativeRecognizer.FaceImageDpi; 
            set => nativeRecognizer.FaceImageDpi = (int)value;
        }
        
        public uint FullDocumentImageDpi 
        { 
            get => (uint)nativeRecognizer.FullDocumentImageDpi; 
            set => nativeRecognizer.FullDocumentImageDpi = (int)value;
        }
        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
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

    public sealed class EudlRecognizerResult : RecognizerResult, IEudlRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Eudl.EudlRecognizer.Result nativeResult;

        internal EudlRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Eudl.EudlRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string BirthData => nativeResult.BirthData;
        public EudlCountry Country => (EudlCountry)nativeResult.Country.Ordinal();
        public string DriverNumber => nativeResult.DriverNumber;
        public IDate ExpiryDate => nativeResult.ExpiryDate.Date != null ? new Date(nativeResult.ExpiryDate.Date) : null;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
        public IDate IssueDate => nativeResult.IssueDate.Date != null ? new Date(nativeResult.IssueDate.Date) : null;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public string PersonalNumber => nativeResult.PersonalNumber;
    }
}