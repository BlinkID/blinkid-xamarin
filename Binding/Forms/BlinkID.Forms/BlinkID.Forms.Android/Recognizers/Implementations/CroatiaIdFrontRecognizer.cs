using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CroatiaIdFrontRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CroatiaIdFrontRecognizer : Recognizer, ICroatiaIdFrontRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdFrontRecognizer nativeRecognizer;

        CroatiaIdFrontRecognizerResult result;

        public CroatiaIdFrontRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdFrontRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdFrontRecognizer;
            result = new CroatiaIdFrontRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdFrontRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICroatiaIdFrontRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
        }
        
        public bool ExtractCitizenship 
        { 
            get => nativeRecognizer.ShouldExtractCitizenship(); 
            set => nativeRecognizer.SetExtractCitizenship(value);
        }
        
        public bool ExtractDateOfBirth 
        { 
            get => nativeRecognizer.ShouldExtractDateOfBirth(); 
            set => nativeRecognizer.SetExtractDateOfBirth(value);
        }
        
        public bool ExtractDateOfExpiry 
        { 
            get => nativeRecognizer.ShouldExtractDateOfExpiry(); 
            set => nativeRecognizer.SetExtractDateOfExpiry(value);
        }
        
        public bool ExtractSex 
        { 
            get => nativeRecognizer.ShouldExtractSex(); 
            set => nativeRecognizer.SetExtractSex(value);
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
        
        public bool ReturnSignatureImage 
        { 
            get => nativeRecognizer.ShouldReturnSignatureImage(); 
            set => nativeRecognizer.SetReturnSignatureImage(value);
        }
        
    }

    public sealed class CroatiaIdFrontRecognizerResult : RecognizerResult, ICroatiaIdFrontRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdFrontRecognizer.Result nativeResult;

        internal CroatiaIdFrontRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaIdFrontRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Citizenship => nativeResult.Citizenship;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public bool DateOfExpiryPermanent => nativeResult.IsDateOfExpiryPermanent;
        public bool DocumentBilingual => nativeResult.IsDocumentBilingual;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap());
        public string IdentityCardNumber => nativeResult.IdentityCardNumber;
        public string LastName => nativeResult.LastName;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
    }
}