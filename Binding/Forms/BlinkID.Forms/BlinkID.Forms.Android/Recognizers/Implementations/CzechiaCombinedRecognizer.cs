using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(CzechiaCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class CzechiaCombinedRecognizer : Recognizer, ICzechiaCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaCombinedRecognizer nativeRecognizer;

        CzechiaCombinedRecognizerResult result;

        public CzechiaCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaCombinedRecognizer;
            result = new CzechiaCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ICzechiaCombinedRecognizerResult Result => result;

        
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

    public sealed class CzechiaCombinedRecognizerResult : RecognizerResult, ICzechiaCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaCombinedRecognizer.Result nativeResult;

        internal CzechiaCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Czechia.CzechiaCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Address => nativeResult.Address;
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public Xamarin.Forms.ImageSource FaceImage => nativeResult.FaceImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap()) : null;
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => nativeResult.FullDocumentBackImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap()) : null;
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => nativeResult.FullDocumentFrontImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap()) : null;
        public string IdentityCardNumber => nativeResult.IdentityCardNumber;
        public string IssuingAuthority => nativeResult.IssuingAuthority;
        public string LastName => nativeResult.LastName;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public string PersonalIdentificationNumber => nativeResult.PersonalIdentificationNumber;
        public string PlaceOfBirth => nativeResult.PlaceOfBirth;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => nativeResult.SignatureImage != null ? Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap()) : null;
    }
}