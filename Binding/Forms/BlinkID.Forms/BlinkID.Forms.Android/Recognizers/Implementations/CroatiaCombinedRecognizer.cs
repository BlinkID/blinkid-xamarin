using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CroatiaCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CroatiaCombinedRecognizer : Recognizer, ICroatiaCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaCombinedRecognizer nativeRecognizer;

        CroatiaCombinedRecognizerResult result;

        public CroatiaCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaCombinedRecognizer;
            result = new CroatiaCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICroatiaCombinedRecognizerResult Result => result;

        
        public bool DetectGlare 
        { 
            get => nativeRecognizer.ShouldDetectGlare(); 
            set => nativeRecognizer.SetDetectGlare(value);
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
        
        public bool SignResult 
        { 
            get => nativeRecognizer.ShouldSignResult(); 
            set => nativeRecognizer.SetSignResult(value);
        }
        
    }

    public sealed class CroatiaCombinedRecognizerResult : RecognizerResult, ICroatiaCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaCombinedRecognizer.Result nativeResult;

        internal CroatiaCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Croatia.CroatiaCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public string Citizenship => nativeResult.Citizenship;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public bool DateOfExpiryPermanent => nativeResult.IsDateOfExpiryPermanent;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentBilingual => nativeResult.IsDocumentBilingual;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap());
        public string IdentityCardNumber => nativeResult.IdentityCardNumber;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public bool NonResident => nativeResult.IsNonResident;
        public string PersonalIdentificationNumber => nativeResult.PersonalIdentificationNumber;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
    }
}