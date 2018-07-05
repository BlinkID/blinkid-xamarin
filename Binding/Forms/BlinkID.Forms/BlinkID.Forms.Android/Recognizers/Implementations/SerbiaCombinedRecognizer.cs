using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(SerbiaCombinedRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class SerbiaCombinedRecognizer : Recognizer, ISerbiaCombinedRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaCombinedRecognizer nativeRecognizer;

        SerbiaCombinedRecognizerResult result;

        public SerbiaCombinedRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaCombinedRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaCombinedRecognizer;
            result = new SerbiaCombinedRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaCombinedRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public ISerbiaCombinedRecognizerResult Result => result;

        
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

    public sealed class SerbiaCombinedRecognizerResult : RecognizerResult, ISerbiaCombinedRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaCombinedRecognizer.Result nativeResult;

        internal SerbiaCombinedRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkid.Serbia.SerbiaCombinedRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate DateOfBirth => nativeResult.DateOfBirth != null ? new Date(nativeResult.DateOfBirth) : null;
        public IDate DateOfExpiry => nativeResult.DateOfExpiry != null ? new Date(nativeResult.DateOfExpiry) : null;
        public IDate DateOfIssue => nativeResult.DateOfIssue != null ? new Date(nativeResult.DateOfIssue) : null;
        public byte[] DigitalSignature => nativeResult.GetDigitalSignature();
        public uint DigitalSignatureVersion => (uint)nativeResult.DigitalSignatureVersion;
        public bool DocumentDataMatch => nativeResult.IsDocumentDataMatch;
        public Xamarin.Forms.ImageSource FaceImage => Utils.ConvertAndroidBitmap(nativeResult.FaceImage.ConvertToBitmap());
        public string FirstName => nativeResult.FirstName;
        public Xamarin.Forms.ImageSource FullDocumentBackImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentBackImage.ConvertToBitmap());
        public Xamarin.Forms.ImageSource FullDocumentFrontImage => Utils.ConvertAndroidBitmap(nativeResult.FullDocumentFrontImage.ConvertToBitmap());
        public string IdentityCardNumber => nativeResult.IdentityCardNumber;
        public string Issuer => nativeResult.Issuer;
        public string Jmbg => nativeResult.Jmbg;
        public string LastName => nativeResult.LastName;
        public bool MrzVerified => nativeResult.IsMrzVerified;
        public string Nationality => nativeResult.Nationality;
        public bool ScanningFirstSideDone => nativeResult.IsScanningFirstSideDone;
        public string Sex => nativeResult.Sex;
        public Xamarin.Forms.ImageSource SignatureImage => Utils.ConvertAndroidBitmap(nativeResult.SignatureImage.ConvertToBitmap());
    }
}